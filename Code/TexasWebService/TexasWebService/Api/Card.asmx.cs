using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using TexasWebService.Common;

namespace TexasWebService.Api
{
    /// <summary>
    /// Card 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    [System.Web.Script.Services.ScriptService]
    public class Card : System.Web.Services.WebService
    {
        private DB db = new DB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool DealFirstTwoPublicCard(string firstCard, string secondCard)
        {
            DataTable table = db.GetDataTable("select * from Games where State= 0");
            if (table.Rows.Count == 0)
                return false;
            else
            {
                db.ExecuteNonQury("update Games set FirstCard = '" + firstCard + "', SecondCard='"+secondCard+"'  where ID=" + int.Parse(table.Rows[0]["ID"].ToString()));
                return true;
            }
        }

        [WebMethod]
        public bool DealFirstThreePublicCard(string firstCard,string secondCard, string thirdCard)
        {
            DataTable table = db.GetDataTable("select * from Games where State= 0");
            if (table.Rows.Count == 0)
                return false;
            else
            {
                db.ExecuteNonQury("update Games set FirstCard = '"+firstCard+"', SecondCard='"+secondCard+"', ThirdCard='"+thirdCard+"' where ID=" +int.Parse(table.Rows[0]["ID"].ToString()));
                return true;
            }
        }

        [WebMethod]
        public bool DealFourthPublicCard(string fourthCard)
        {
            DataTable table = db.GetDataTable("select * from Games where State= 0");
            if (table.Rows.Count == 0 )
                return false;
            else
            {
                db.ExecuteNonQury("update Games set FourthCard = '" + fourthCard + "' where ID=" +int.Parse(table.Rows[0]["ID"].ToString()));
                return true;
            }
        }

        [WebMethod]
        public bool DealFifthPublicCard(string fifthCard)
        {
            DataTable table = db.GetDataTable("select * from Games where State= 0");
            if (table.Rows.Count == 0 )
                return false;
            else
            {
                db.ExecuteNonQury("update Games set FifthCard = '" + fifthCard + "' where ID=" + int.Parse(table.Rows[0]["ID"].ToString()));
                return true;
            }
        }

        [WebMethod]
        public bool DealPrivateCard(int playerID, string firstCard, string secondCard)
        {
            DataTable table = db.GetDataTable("select * from Games where State= 0");
            if (table.Rows.Count == 0 )
                return false;
            else
            {
                DataTable privacardtable = db.GetDataTable("select * from PrivateCards where GameID=" + int.Parse(table.Rows[0]["ID"].ToString()) +"and PlayerID="+playerID);
                if (privacardtable.Rows.Count == 0)
                    db.ExecuteNonQury("insert into PrivateCards(GameID, PlayerID, FirstCard, SecondCard) values(" + int.Parse(table.Rows[0]["ID"].ToString()) + ",'" + playerID + "','" + firstCard + "','" + secondCard + "')");
                else if (privacardtable.Rows.Count == 1)
                    db.ExecuteNonQury("update PrivateCards set FirstCard='" + firstCard + "' ,SecondCard= '" + secondCard + "' where  GameID=" + int.Parse(table.Rows[0]["ID"].ToString()) + "and PlayerID=" + playerID);
                return true;
            }
        }

        [WebMethod]
        public DataSet GetPublicCardForLive()
        {
            
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            DataSet table = new DataSet();
            if(gameUnfinished.Rows.Count!=0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());

                table = db.GetDataSet("select * from Games where ID=" + gameID);
                string card1 = table.Tables[0].Rows[0]["FirstCard"].ToString();
            }
            
            return table;
        }

        [WebMethod]
        public DataSet GetPrivateCardForLive()
        {
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            DataSet table = new DataSet();
            if(gameUnfinished.Rows.Count!=0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());

                table = db.GetDataSet("select * from PrivateCards where GameID =" + gameID);
            }

            return table;
        }

        [WebMethod]
        public DataSet GetPrivateCardByPlayerID(int playerID)
        {
            DataSet table = new DataSet();
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if(gameUnfinished.Rows.Count!=0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());

                table = db.GetDataSet("select * from PrivateCards where GameID =" + gameID + " and PlayerID=" + playerID);
            }
           

            return table;
        }

        [WebMethod]
        public DataSet GetPrivateCardByGameID(int gameID)
        {
            DataSet table = db.GetDataSet("select * from PrivateCards where GameID =" + gameID );

            return table;
        }

        [WebMethod]
        public DataSet GetPublicCardsByGameID(int gameID)
        {
            DataSet set = db.GetDataSet("");
            return set;
        }


        [WebMethod]
        //type||0：玩家顺序；1：发牌顺序
        //返回值：2位字符串，xy，对应界面上的格子，例如52，代表第5组的第2格，错误返回00
        public string DataUploadAPI(string card, string type)
        {
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
                int playerNumber = int.Parse(recordUnfinished.Rows[0]["PlayerNumber"].ToString());

                DataTable privateCardsTable = db.GetDataTable("select * from PrivateCards where GameID="+gameID);
                int playerCount = privateCardsTable.Rows.Count;

                //玩家顺序
                if (type.Equals("0"))
                {
                    if(privateCardsTable.Rows[playerCount-1]["SecondCard"].ToString().Equals(""))
                    {
                        db.ExecuteNonQury("update PrivateCards set SecondCard='"+card+"' where ID="+int.Parse(privateCardsTable.Rows[playerCount-1]["ID"].ToString()));
                        return playerCount + "2";
                    }
                    else
                    {
                        db.ExecuteNonQury(string.Format("insert into PrivateCards(GameID,PlayerID,FirstCard) values({0},{1},'{2}')",gameID,(playerCount+1),card));
                        return (playerCount+1)+"1";
                    }
                }
                //发牌顺序
                else if (type.Equals("1"))
                {
                    if(playerCount<playerNumber)
                    {
                        db.ExecuteNonQury(string.Format("insert into PrivateCards(GameID,PlayerID,FirstCard) values({0},{1},'{2}')", gameID, (playerCount + 1), card));
                        return (playerCount + 1) + "1";
                    }
                    else if(playerNumber==playerCount)
                    {
                        int thisPlayer = 0;
                        for(int i=0;i<playerNumber;i++)
                        {
                            if(privateCardsTable.Rows[i]["SecondCard"].ToString().Equals(""))
                            {
                                thisPlayer = i + 1;
                                break;
                            }
                        }
                        db.ExecuteNonQury("update PrivateCards set SecondCard='" + card + "' where PlayerID=" + thisPlayer);
                        return thisPlayer + "2";

                    }
                }
            }
            

            return "00";
        }

        [WebMethod]
        //type||0：玩家顺序；1：发牌顺序
        //返回值：2位字符串，xy，对应界面上的格子，例如52，代表第5组的第2格，错误返回00
        public string DataUndoAPI(string type)
        {
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
                int playerNumber = int.Parse(recordUnfinished.Rows[0]["PlayerNumber"].ToString());

                DataTable privateCardsTable = db.GetDataTable("select * from PrivateCards where GameID=" + gameID);
                int playerCount = privateCardsTable.Rows.Count;

                //玩家顺序
                if(type.Equals("0"))
                {
                    if(privateCardsTable.Rows[playerCount-1]["SecondCard"].ToString().Equals(""))
                    {
                        db.ExecuteNonQury("delete from PrivateCards where ID="+int.Parse(privateCardsTable.Rows[playerCount-1]["ID"].ToString()));
                        return playerCount + "1";
                    }
                    else
                    {
                        db.ExecuteNonQury("update PrivateCards set SecondCard='' where ID="+int.Parse(privateCardsTable.Rows[playerCount-1]["ID"].ToString()));
                        return playerCount + "2";
                    }
                }
                //发牌顺序
                else
                {
                    if(playerCount<playerNumber)
                    {
                        db.ExecuteNonQury("delete from PrivateCards where ID="+privateCardsTable.Rows[playerCount-1]["ID"].ToString());
                        return playerCount + "1";
                    }
                    else
                    {
                        int thisPlayer = 0;
                        for(int i=0;i<playerNumber;i++)
                        {
                            if(privateCardsTable.Rows[i]["SecondCard"].ToString().Equals(""))
                            {
                                thisPlayer = i + 1;
                                break;
                            }
                        }
                        if(thisPlayer==1)
                        {
                            db.ExecuteNonQury("delete from PrivateCards where ID="+int.Parse(privateCardsTable.Rows[playerCount-1]["ID"].ToString()));
                            return playerCount + "1";
                        }
                        else if(thisPlayer>1&&thisPlayer<=playerNumber)
                        {
                            db.ExecuteNonQury("update PrivateCards set SecondCard='' where ID="+int.Parse(privateCardsTable.Rows[thisPlayer-2]["ID"].ToString()));
                            return (thisPlayer - 2)+"2";
                        }

                    }
                }
            }
            return "00";
        }

    }
}
