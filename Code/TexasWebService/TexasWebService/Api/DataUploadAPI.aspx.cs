using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexasWebService.Common;

namespace TexasWebService.Api
{
    public partial class DataUploadAPI : System.Web.UI.Page
    {
        private DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(Request.QueryString["card"]!=null&&Request.QueryString["type"]!=null)
                {
                    string card = Request.QueryString["card"].ToString();
                    string type = Request.QueryString["type"].ToString();

                    
                    if (GetCardName(card).Equals(""))
                    {
                        Response.Clear();
                        Response.Write("00");
                        Response.Flush();
                        Response.End();
                    }
                    else
                    {
                        string result = DataUploadAPIMethod(card, type);
                        Response.Clear();
                        Response.Write(result);
                        Response.Flush();
                        Response.End();
                    }

                    
                }
                
            }
        }


        private string GetCardName(string input)
        {
            if (input.Length != 3)
                return "";
            else
            {
                string head = input.Substring(0, 1);
                string body = input.Substring(1, 2);
                int output = -1;
                if (int.TryParse(body, out output))
                {
                    if (head.ToUpper().Equals("H") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "红桃" + int.Parse(body);
                    }
                    else if (head.ToUpper().Equals("D") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "方块" + int.Parse(body);
                    }
                    else if (head.ToUpper().Equals("S") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "黑桃" + int.Parse(body);
                    }
                    else if (head.ToUpper().Equals("C") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "梅花" + int.Parse(body);
                    }
                    else
                        return "";
                }
                else
                    return "";

            }
        }

        private string DataUploadAPIMethod(string card, string type)
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
                if (type.Equals("0"))
                {
                    if(playerCount==0)
                    {
                        db.ExecuteNonQury(string.Format("insert into PrivateCards(GameID,PlayerID,FirstCard) values({0},{1},'{2}')", gameID, (playerCount + 1), card));
                        return (playerCount + 1) + "1";
                    }
                    if (privateCardsTable.Rows[playerCount - 1]["SecondCard"].ToString().Equals(""))
                    {
                        db.ExecuteNonQury("update PrivateCards set SecondCard='" + card + "' where ID=" + int.Parse(privateCardsTable.Rows[playerCount - 1]["ID"].ToString()));
                        return playerCount + "2";
                    }
                    else
                    {
                        if (playerCount == playerNumber)
                            return "00";
                        db.ExecuteNonQury(string.Format("insert into PrivateCards(GameID,PlayerID,FirstCard) values({0},{1},'{2}')", gameID, (playerCount + 1), card));
                        return (playerCount + 1) + "1";
                    }
                }
                //发牌顺序
                else if (type.Equals("1"))
                {
                    if (playerCount < playerNumber)
                    {
                        db.ExecuteNonQury(string.Format("insert into PrivateCards(GameID,PlayerID,FirstCard) values({0},{1},'{2}')", gameID, (playerCount + 1), card));
                        return (playerCount + 1) + "1";
                    }
                    else if (playerNumber == playerCount)
                    {
                        int thisPlayer = 0;
                        for (int i = 0; i < playerNumber; i++)
                        {
                            if (privateCardsTable.Rows[i]["SecondCard"].ToString().Equals(""))
                            {
                                thisPlayer = i + 1;
                                break;
                            }
                        }
                        if (thisPlayer == 0)
                            return "00";
                        db.ExecuteNonQury("update PrivateCards set SecondCard='" + card + "' where PlayerID=" + thisPlayer);
                        return thisPlayer + "2";

                    }
                }
            }


            return "00";
        }
    }
}