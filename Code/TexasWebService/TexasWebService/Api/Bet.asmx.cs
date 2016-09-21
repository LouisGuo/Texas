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
    /// Bet 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Bet : System.Web.Services.WebService
    {
        private DB db = new DB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int GetDaMangChips()
        {
            DataTable operationTable = db.GetDataTable("select * from Operations where GameID=(select ID from Games where State=0) and PlayerID <>0");
            DataTable playernum = db.GetDataTable("select * from Records where State=0");
            if (playernum.Rows.Count != 0)
            {
                int playerNumber = int.Parse(playernum.Rows[0]["PlayerNumber"].ToString());
                if (operationTable.Rows.Count == 1)
                {
                    int xiaomangChips = int.Parse(operationTable.Rows[0]["ChipsBet"].ToString());
                    return 2 * xiaomangChips;
                    
                }
            }

            return 0;
        }


        [WebMethod]
        public int GetDaMangPlayerID()
        {
            DataTable operationTable = db.GetDataTable("select * from Operations where GameID=(select ID from Games where State=0) and PlayerID <>0");
            DataTable playernum = db.GetDataTable("select * from Records where State=0");
            if(playernum.Rows.Count!=0)
            {
                int playerNumber = int.Parse(playernum.Rows[0]["PlayerNumber"].ToString());
                if (operationTable.Rows.Count == 1)
                {
                    int xiaomangID = int.Parse(operationTable.Rows[0]["PlayerID"].ToString());
                    if (xiaomangID == playerNumber)
                        return 1;
                    else
                        return xiaomangID + 1;
                }
            }
            
            return 0;
        }

        [WebMethod]
        public int GetXiaoMangPlayerID()
        {
            DataTable operationTable = db.GetDataTable("select * from Operations where  GameID=(select ID from Games where State=0) and PlayerID<>0");
            
            if (operationTable.Rows.Count == 0)
            {
                DataTable gamesFinished = db.GetDataTable("select * from Games where RecordID=(select ID from Records where State=0) and State<>0");
                if (gamesFinished.Rows.Count == 0)
                    return 1;
                else if(gamesFinished.Rows.Count>0)
                {
                    DataTable playernum = db.GetDataTable("select * from Records where State=0");
                    int playerNumber=int.Parse(playernum.Rows[0]["PlayerNumber"].ToString());
                    return gamesFinished.Rows.Count % playerNumber + 1;
                }
            }
            return 0;
        }

        //在Operation表里插入一条记录，同时更新playerchips里的bet1234
        [WebMethod]
        public bool NewBet(int playerID, string operation, string chipsBet)
        {
            DataTable gameUnfinished=db.GetDataTable("select * from Games where State=0");
            int gameID=int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
            int chipsInHand=0;
            if(playerID==0)
                db.ExecuteNonQury(string.Format("insert into Operations(GameID,PlayerID,Operation,ChipsBet,ChipsInHand) values('{0}','{1}','{2}','{3}','{4}')", int.Parse(gameUnfinished.Rows[0]["ID"].ToString()), playerID, operation, chipsBet, chipsInHand));
            else if(playerID>0&&playerID<9)
            {
                string card1 = gameUnfinished.Rows[0]["FirstCard"].ToString();
                string card2 = gameUnfinished.Rows[0]["SecondCard"].ToString();
                string card3 = gameUnfinished.Rows[0]["ThirdCard"].ToString();
                string card4 = gameUnfinished.Rows[0]["FourthCard"].ToString();
                string card5 = gameUnfinished.Rows[0]["FifthCard"].ToString();
                string turns = "";
                if (card1.Equals(""))
                    turns = "BetChips1";
                if (!card1.Equals("") && card4.Equals(""))
                    turns = "BetChips2";
                if (!card4.Equals("") && card5.Equals(""))
                    turns = "BetChips3";
                if (!card5.Equals(""))
                    turns = "BetChips4";
                if (operation.Equals("跟注"))
                {
                    DataTable callchips = db.GetDataTable("select * from PlayerChips where GameID="+gameID+"order by "+turns+" DESC");
                    chipsBet = callchips.Rows[0][turns].ToString();
                }
                if (operation.Equals("全下"))
                {
                    DataTable Allinchips = db.GetDataTable("select * from PlayerChips where GameID=" + gameID + " and PlayerID="+playerID);
                    int startChips = int.Parse(Allinchips.Rows[0]["StartChips"].ToString());
                    int bet1 = int.Parse(Allinchips.Rows[0]["BetChips1"].ToString());
                    int bet2 = int.Parse(Allinchips.Rows[0]["BetChips2"].ToString());
                    int bet3 = int.Parse(Allinchips.Rows[0]["BetChips3"].ToString());
                    int bet4 = int.Parse(Allinchips.Rows[0]["BetChips4"].ToString());
                    if (turns.Equals("BetChips1"))
                        chipsBet = startChips + "";
                    else if (turns.Equals("BetChips2"))
                        chipsBet = startChips - bet1 + "";
                    else if (turns.Equals("BetChips3"))
                        chipsBet = startChips - bet1 - bet2 + "";
                    else if (turns.Equals("BetChips4"))
                        chipsBet = startChips - bet1 - bet2 - bet3 + "";
                }
                if(operation.Equals("跟注")||operation.Equals("加注")||operation.Equals("全下")||operation.Equals("小盲")||operation.Equals("大盲"))
                {
                    
                    if(card1.Equals(""))
                        db.ExecuteNonQury("update PlayerChips set BetChips1=" + int.Parse(chipsBet) + "where GameID=" + gameID + "and PlayerID=" + playerID);
                    if(!card1.Equals("")&&card4.Equals(""))
                        db.ExecuteNonQury("update PlayerChips set BetChips2=" + int.Parse(chipsBet) + "where GameID=" + gameID + "and PlayerID=" + playerID);
                    if(!card4.Equals("")&&card5.Equals(""))
                        db.ExecuteNonQury("update PlayerChips set BetChips3=" + int.Parse(chipsBet) + "where GameID=" + gameID + "and PlayerID=" + playerID);
                    if(!card5.Equals(""))
                        db.ExecuteNonQury("update PlayerChips set BetChips4=" + int.Parse(chipsBet) + "where GameID=" + gameID + "and PlayerID=" + playerID);
                    //if (gameUnfinished.Rows[0]["FirstCard"].ToString().Equals("") || gameUnfinished.Rows[0]["FirstCard"] == null)
                    //    db.ExecuteNonQury("update PlayerChips set BetChips1=" + int.Parse(chipsBet)+"where GameID="+gameID +"and PlayerID="+playerID);
                    //if ((gameUnfinished.Rows[0]["FourthCard"].ToString().Equals("") || gameUnfinished.Rows[0]["FourthCard"] == null)&&((!gameUnfinished.Rows[0]["FirstCard"].ToString().Equals(""))||gameUnfinished.Rows[0]["FirstCard"]!=null))
                    //    db.ExecuteNonQury("update PlayerChips set BetChips2=" + int.Parse(chipsBet) + "where GameID=" + gameID + "and PlayerID=" + playerID);
                    //if ((gameUnfinished.Rows[0]["FifthCard"].ToString().Equals("") || gameUnfinished.Rows[0]["FifthCard"] == null) && ((!gameUnfinished.Rows[0]["FourthCard"].ToString().Equals("")) || gameUnfinished.Rows[0]["FourthCard"] != null))
                    //    db.ExecuteNonQury("update PlayerChips set BetChips3=" + int.Parse(chipsBet) + "where GameID=" + gameID + "and PlayerID=" + playerID);
                    //if (((!gameUnfinished.Rows[0]["FifthCard"].ToString().Equals("")) || gameUnfinished.Rows[0]["FifthCard"] != null))
                    //    db.ExecuteNonQury("update PlayerChips set BetChips4=" + int.Parse(chipsBet) + "where GameID=" + gameID + "and PlayerID=" + playerID);

                    DataTable playerChipsUnfinished = db.GetDataTable("select * from PlayerChips where PlayerID=" + playerID + "and GameID=" + int.Parse(gameUnfinished.Rows[0]["ID"].ToString()));
                    int startChips = int.Parse(playerChipsUnfinished.Rows[0]["StartChips"].ToString());
                    int bet1 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips1"].ToString());
                    int bet2 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips2"].ToString());
                    int bet3 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips3"].ToString());
                    int bet4 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips4"].ToString());

                    chipsInHand = startChips - bet1 - bet2 - bet3 - bet4;
                    db.ExecuteNonQury(string.Format("insert into Operations(GameID,PlayerID,Operation,ChipsBet,ChipsInHand) values('{0}','{1}','{2}','{3}','{4}')", int.Parse(gameUnfinished.Rows[0]["ID"].ToString()), playerID, operation, chipsBet, chipsInHand));
                }
                else if (operation.Equals("弃牌") || operation.Equals("看牌"))
                {
                    DataTable playerChipsUnfinished = db.GetDataTable("select * from PlayerChips where PlayerID=" + playerID + "and GameID=" + int.Parse(gameUnfinished.Rows[0]["ID"].ToString()));
                    int startChips = int.Parse(playerChipsUnfinished.Rows[0]["StartChips"].ToString());
                    int bet1 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips1"].ToString());
                    int bet2 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips2"].ToString());
                    int bet3 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips3"].ToString());
                    int bet4 = int.Parse(playerChipsUnfinished.Rows[0]["BetChips4"].ToString());

                    chipsInHand = startChips - bet1 - bet2 - bet3 - bet4;
                    db.ExecuteNonQury(string.Format("insert into Operations(GameID,PlayerID,Operation,ChipsBet,ChipsInHand) values('{0}','{1}','{2}','{3}','{4}')", int.Parse(gameUnfinished.Rows[0]["ID"].ToString()), playerID, operation, chipsBet, chipsInHand));
                }
                
            }
            
            return true;
            
        }

        [WebMethod]
        public bool UndoPreOperation()
        {
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
            DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
            int playerNumber = int.Parse(recordUnfinished.Rows[0]["PlayerNumber"].ToString());

            DataTable preOperation = db.GetDataTable("select top 1 * from Operations where GameID="+gameID+" order by ID DESC");
            //撤销判定
            if(preOperation.Rows.Count==0)
            {
                DataTable preGame = db.GetDataTable("select top 1 * from Games where State=1 and RecordID= "+int.Parse(recordUnfinished.Rows[0]["ID"].ToString())+"  order by ID DESC");
                if(preGame.Rows.Count==0)
                {
                    return false;
                }
                //db.ExecuteNonQury("delete from Games where State=0");
                //db.ExecuteNonQury("delete from PlayerChips where GameID="+gameID);
                DataTable preGameOperation = db.GetDataTable("select top 1 * from Operations where GameID="+int.Parse(preGame.Rows[0]["ID"].ToString())+" order by ID DESC");
                if(int.Parse(preGameOperation.Rows[0]["PlayerID"].ToString())==0&&preGameOperation.Rows[0]["Operation"].ToString().Equals("判定"))
                {
                    db.ExecuteNonQury("delete from Operations where ID="+ int.Parse(preGameOperation.Rows[0]["ID"].ToString()));
                    db.ExecuteNonQury("update Games set State=0 where ID="+int.Parse(preGame.Rows[0]["ID"].ToString()));

                    db.ExecuteNonQury("update PlayerChips set GainChips=0 where GameID="+int.Parse(preGame.Rows[0]["ID"].ToString()));

                    db.ExecuteNonQury("delete from Games where ID=" + gameID);
                    db.ExecuteNonQury("delete from PlayerChips where GameID=" + gameID);
                }
                
            }
            //撤销判定以外的其他操作
            else
            {
                int preOperationID=int.Parse(preOperation.Rows[0]["ID"].ToString());
                int prePlayerID = int.Parse(preOperation.Rows[0]["PlayerID"].ToString());
                string prePlayerOperation=preOperation.Rows[0]["Operation"].ToString();
                //荷官操作（发牌，贷款）
                if(prePlayerID==0)
                {
                    if(prePlayerOperation.Equals("贷款"))
                    {
                        db.ExecuteNonQury("delete from Operations where ID=" + preOperationID);
                        DataTable loanChips = db.GetDataTable("select * from PlayerChips where GameID="+gameID);
                        int playerNum = loanChips.Rows.Count;
                        int[] loan=new int[8];
                        int[] start=new int[8];
                        int[] newStart=new int[8];
                        for (int j = 1; j <= playerNum;j++ )
                        {
                            for (int s = 1; s <= playerNum;s++ )
                            {
                                if (int.Parse(loanChips.Rows[s - 1]["PlayerID"].ToString()) == j)
                                {
                                    loan[j - 1] = int.Parse(loanChips.Rows[s - 1]["LoanChips"].ToString());
                                    start[j - 1] = int.Parse(loanChips.Rows[s - 1]["StartChips"].ToString());
                                    newStart[j - 1] = start[j - 1] - loan[j - 1];
                                }
                            }
                                
                        }

                        for (int i = 1; i <= playerNum; i++)
                        {
                            db.ExecuteNonQury("update PlayerChips set LoanChips = 0 , StartChips = "+newStart[i-1] +" where PlayerID="+i +" and GameID="+gameID);
                        }
                    }
                    else if(prePlayerOperation.Equals("发牌"))
                    {
                        db.ExecuteNonQury("delete from Operations where ID=" + preOperationID);
                        string betchips=preOperation.Rows[0]["ChipsBet"].ToString();
                        if (betchips.Equals("1"))
                            db.ExecuteNonQury("update Games set FirstCard= '', SecondCard='' , ThirdCard='' where ID="+gameID);
                        else if (betchips.Equals("2"))
                            db.ExecuteNonQury("update Games set FourthCard='' where ID = "+ gameID);
                        else if (betchips.Equals("3"))
                            db.ExecuteNonQury("update Games set FifthCard='' where ID = "+gameID);
                    }
                }
                //玩家操作
                else
                {
                    if(prePlayerOperation.Equals("看牌")||prePlayerOperation.Equals("弃牌"))
                    {
                        db.ExecuteNonQury("delete from Operations where ID="+preOperationID);
                    }
                    else if(prePlayerOperation.Equals("小盲")||prePlayerOperation.Equals("大盲"))
                    {
                        db.ExecuteNonQury("delete from Operations where ID=" + preOperationID);
                        db.ExecuteNonQury("update PlayerChips set BetChips1= 0 where GameID="+gameID+" and PlayerID="+prePlayerID);
                    }
                    else if(prePlayerOperation.Equals("跟注")||prePlayerOperation.Equals("加注")||prePlayerOperation.Equals("全下"))
                    {
                        db.ExecuteNonQury("delete from Operations where ID=" + preOperationID);
                        DataTable fapaiOperation = db.GetDataTable("select * from Operations where PlayerID=0 and Operation='发牌' and GameID="+gameID);
                        //第一轮
                        if(fapaiOperation.Rows.Count==0)
                        {
                            DataTable turnsOperation = db.GetDataTable("select * from Operations where GameID="+gameID+" and PlayerID="+prePlayerID);
                            if(turnsOperation.Rows.Count==1)
                            {
                                db.ExecuteNonQury("delete from Operations where ID="+preOperationID);
                                db.ExecuteNonQury("update PlayerChips set BetChips1=0 where GameID="+gameID+" and PlayerID="+prePlayerID);

                            }
                            else
                            {
                                db.ExecuteNonQury("delete from Operations where ID=" + preOperationID);
                                DataTable allOperation = db.GetDataTable("select * from Operations where GameID="+gameID);
                                db.ExecuteNonQury("delete from Operations where GameID=" + gameID);
                                db.ExecuteNonQury("update PlayerChips set BetChips1=0 where GameID=" + gameID);
                                for(int i=0;i<allOperation.Rows.Count;i++)
                                {
                                    new Bet().NewBet(int.Parse(allOperation.Rows[i]["PlayerID"].ToString()),allOperation.Rows[i]["Operation"].ToString(),allOperation.Rows[i]["ChipsBet"].ToString());
                                }
                            }
                        }
                        //第二，三，四轮
                        else
                        {
                            DataTable preFaPai = db.GetDataTable("select top 1 * from Operations where PlayerID=0 and Operation='发牌' order by ID DESC");
                            int preFaPaiOperationID=int.Parse(preFaPai.Rows[0]["ID"].ToString());
                            int turns = int.Parse(preFaPai.Rows[0]["ChipsBet"].ToString());
                            DataTable allOperation = db.GetDataTable("select * from Operations where ID>"+preFaPaiOperationID);
                            db.ExecuteNonQury("delete from Operations where ID>"+preFaPaiOperationID);

                            if(turns==1)
                                db.ExecuteNonQury("update PlayerChips set BetChips2=0 where GameID="+gameID);
                            else if(turns ==2)
                                db.ExecuteNonQury("update PlayerChips set BetChips3=0 where GameID=" + gameID);
                            else if (turns == 3)
                                db.ExecuteNonQury("update PlayerChips set BetChips4=0 where GameID=" + gameID);

                            for(int i=0;i<allOperation.Rows.Count;i++)
                            {
                                new Bet().NewBet(int.Parse(allOperation.Rows[i]["PlayerID"].ToString()), allOperation.Rows[i]["Operation"].ToString(), allOperation.Rows[i]["ChipsBet"].ToString());
                            }
                        }
                    }
                }
            }

            return true;
        }

        [WebMethod]
        public DataSet GetBetForLive()
        {
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            int gameID=int.Parse(gameUnfinished.Rows[0]["ID"].ToString());

            

            DataSet table = db.GetDataSet("select * from Operations where GameID=" + gameID);

            return table;
        }

        [WebMethod]
        public DataSet GetBetForLive1()
        {
            DataSet table = new DataSet();
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if(gameUnfinished.Rows.Count!=0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                table = db.GetDataSet("select * from Operations where GameID=" + gameID);
            }
            DataTable preGameFinished = db.GetDataTable("select top 1 * from Games where State = 1 order by ID DESC");
            if (table.Tables[0].Rows.Count == 0)
                table = db.GetDataSet("select * from Operations where GameID=" + int.Parse(preGameFinished.Rows[0]["ID"].ToString()));
            return table;
        }

        [WebMethod]
        public DataSet GetBetByRecordID(int recordID)
        {
            DataSet set = db.GetDataSet("select * from Operations where GameID in (select ID from Games where RecordID="+recordID+")");
            return set;
        }

        [WebMethod]
        public DataSet GetAllBetInUnfinishedRecord()
        {
            DataSet set = new DataSet();
            DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
            if(recordUnfinished.Rows.Count!=0)
            {
                int recordID = int.Parse(recordUnfinished.Rows[0]["ID"].ToString());
                set = db.GetDataSet("select * from Operations where GameID in (select ID from Games where RecordID=" + recordID + ")");
            }
            
            return set;
        }

        [WebMethod]
        public int GetNextPlayerIDForLive1()
        {
            

            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
            if (recordUnfinished.Rows.Count != 0)
            {
                int playerNumber = int.Parse(recordUnfinished.Rows[0]["PlayerNumber"].ToString());
                if (gameUnfinished.Rows.Count != 0)
                {
                    int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                    DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where Operation='发牌' and GameID=" + gameID);

                    //全弃牌的
                    DataTable allFoldPlayerTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID + " and PlayerID not in (select PlayerID from Operations where Operation='弃牌' and GameID=" + gameID + ")");
                    if (allFoldPlayerTable.Rows.Count == 1)
                        return -1;

                    //第一轮
                    if (fapaiOperationTable.Rows.Count == 0)
                    {
                        
                        DataTable operationTable = db.GetDataTable("select * from Operations where PlayerID<>0 and GameID="+gameID);
                        int operationCount = operationTable.Rows.Count;
                        //除去大小盲
                        if (operationCount > 1)
                        {
                            int lastPlayerID = int.Parse(operationTable.Rows[operationCount - 1]["PlayerID"].ToString());
                            //第一圈
                            if(operationCount<playerNumber)
                            {
                                if (lastPlayerID + 1 <= playerNumber)
                                    return lastPlayerID + 1;
                                else
                                    return 1;
                            }
                            //第一圈之后
                            else
                            {
                                //int lastPlayerID=int.Parse(operationTable.Rows[operationCount-1]["PlayerID"].ToString());
                                int nextPlayerID=0;
                                
                                DataTable playerChipsAvailableTable = db.GetDataTable("select * from PlayerChips where GameID="+gameID+" and PlayerID not in (select PlayerID from Operations where (Operation='弃牌' or Operation='全下') and GameID="+gameID+")");
                                List<int> playerList = new List<int>();
                                List<int> betList = new List<int>();
                                for(int i=0;i<playerChipsAvailableTable.Rows.Count;i++)
                                {
                                    playerList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["PlayerID"].ToString()));
                                    betList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["BetChips1"].ToString()));
                                }
                                
                                if(playerList.Count==0)
                                {
                                    return 0;
                                }
                                else
                                {
                                    for(int i=0;i<playerList.Count;i++)
                                    {
                                        if(playerList[i]>lastPlayerID)
                                        {
                                            nextPlayerID = playerList[i];
                                            break;
                                        }
                                            
                                    }
                                    if(nextPlayerID==0)
                                        nextPlayerID=playerList[0];
                                    int nextPlayerBet=0;
                                    DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID="+gameID);
                                    for(int i=0;i<playerChipsTable.Rows.Count;i++)
                                    {
                                        if (int.Parse(playerChipsTable.Rows[i]["PlayerID"].ToString()) == nextPlayerID)
                                            nextPlayerBet = int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString());
                                    }
                                    bool ISMAX = true;
                                    for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                                    {
                                        if (int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString()) > nextPlayerBet)
                                            ISMAX = false;
                                    }
                                    if (ISMAX)
                                        return 0;
                                    else
                                        return nextPlayerID;
                                }
                            }
                        }
                    }
                    //第二三四轮
                    else
                    {
                        int turns = 1;
                        if (fapaiOperationTable.Rows.Count == 1)
                            turns = 2;
                        else if (fapaiOperationTable.Rows.Count == 2)
                            turns = 3;
                        else if (fapaiOperationTable.Rows.Count == 3)
                            turns = 4;

                        DataTable operationTable = db.GetDataTable("select * from Operations where GameID="+gameID+" and ID>"+int.Parse(fapaiOperationTable.Rows[turns-2]["ID"].ToString()));
                        
                        DataTable turnsPlayerChipsAvailableTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID + " and PlayerID not in( select PlayerID from Operations where (Operation='全下' or Operation='弃牌') and GameID=" + gameID + " and ID<" + int.Parse(fapaiOperationTable.Rows[turns - 2]["ID"].ToString()) + ")");
                        int turnsPlayerNumber = turnsPlayerChipsAvailableTable.Rows.Count;
                        //无合法玩家
                        if(turnsPlayerNumber==0)
                        {
                            return 0;
                        }
                        //第一圈
                        if(operationTable.Rows.Count<turnsPlayerNumber)
                        {
                            int xiaomangPlayerID=0;
                            //新的一轮开始
                            if(operationTable.Rows.Count<1)
                            {
                                DataTable gamesFinished = db.GetDataTable("select * from Games where RecordID=(select ID from Records where State=0) and State<>0");
                                xiaomangPlayerID = 1;
                                if (gamesFinished.Rows.Count == 0)
                                    xiaomangPlayerID = 1;
                                else if (gamesFinished.Rows.Count > 0)
                                {
                                    xiaomangPlayerID = gamesFinished.Rows.Count % playerNumber + 1;
                                }
                                DataTable onlyOneLeggalPlayerTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID + " and PlayerID not in (select PlayerID from Operations where (Operation='全下' or Operation='弃牌') and GameID=" + gameID + ")");
                                //DataTable onlyOneLeggalPlayerTable = db.GetDataTable("select distinct PlayerID from Operations where Operation <>'全下' and Operation<>'弃牌' and GameID="+gameID);
                                if (onlyOneLeggalPlayerTable.Rows.Count == 1)
                                    return 0;
                            }
                            int lastPlayerID;
                            if(operationTable.Rows.Count==0)
                            {
                                if (xiaomangPlayerID != 1)
                                    lastPlayerID = xiaomangPlayerID - 1;
                                else
                                    lastPlayerID = playerNumber;
                            }
                            else
                                lastPlayerID = int.Parse(operationTable.Rows[operationTable.Rows.Count-1]["PlayerID"].ToString());
                            
                            List<int> turnsPlayerList = new List<int>();
                            List<int> turnsBetList = new List<int>();
                            if(turns==2)
                            {
                                for (int i = 0; i < turnsPlayerNumber; i++)
                                {
                                    turnsPlayerList.Add(int.Parse(turnsPlayerChipsAvailableTable.Rows[i]["PlayerID"].ToString()));
                                    turnsBetList.Add(int.Parse(turnsPlayerChipsAvailableTable.Rows[i]["BetChips2"].ToString()));
                                }
                            }
                            else if(turns==3)
                            {
                                for (int i = 0; i < turnsPlayerNumber; i++)
                                {
                                    turnsPlayerList.Add(int.Parse(turnsPlayerChipsAvailableTable.Rows[i]["PlayerID"].ToString()));
                                    turnsBetList.Add(int.Parse(turnsPlayerChipsAvailableTable.Rows[i]["BetChips3"].ToString()));
                                }
                            }
                            else if(turns==4)
                            {
                                for (int i = 0; i < turnsPlayerNumber; i++)
                                {
                                    turnsPlayerList.Add(int.Parse(turnsPlayerChipsAvailableTable.Rows[i]["PlayerID"].ToString()));
                                    turnsBetList.Add(int.Parse(turnsPlayerChipsAvailableTable.Rows[i]["BetChips4"].ToString()));
                                }
                            }
                            for(int i=0;i<turnsPlayerList.Count;i++)
                            {
                                if(turnsPlayerList[i]>lastPlayerID)
                                    return turnsPlayerList[i];
                            }

                            return turnsPlayerList[0];
                            
                            
                        }
                        //第一圈之后
                        else
                        {
                            int lastPlayerID = int.Parse(operationTable.Rows[operationTable.Rows.Count-1]["PlayerID"].ToString());
                            DataTable playerChipsAvailableTable = db.GetDataTable("select * from PlayerChips where GameID="+gameID+" and PlayerID not in (select PlayerID from Operations where (Operation='全下' or Operation='弃牌') and GameID="+gameID+")");
                            if (playerChipsAvailableTable.Rows.Count == 0)
                                return 0;
                            List<int> playerList = new List<int>();
                            List<int> betList = new List<int>();
                            if (turns == 2)
                            {
                                for (int i = 0; i < playerChipsAvailableTable.Rows.Count; i++)
                                {
                                    playerList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["PlayerID"].ToString()));
                                    betList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["BetChips2"].ToString()));
                                }
                            }
                            else if (turns == 3)
                            {
                                for (int i = 0; i < playerChipsAvailableTable.Rows.Count; i++)
                                {
                                    playerList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["PlayerID"].ToString()));
                                    betList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["BetChips3"].ToString()));
                                }
                            }
                            else if (turns == 4)
                            {
                                for (int i = 0; i < playerChipsAvailableTable.Rows.Count; i++)
                                {
                                    playerList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["PlayerID"].ToString()));
                                    betList.Add(int.Parse(playerChipsAvailableTable.Rows[i]["BetChips4"].ToString()));
                                }
                            }

                            int nextPlayerID = 0;
                            for(int i=0;i<playerList.Count;i++)
                            {
                                if(playerList[i]>lastPlayerID)
                                {
                                    nextPlayerID = playerList[i];
                                    break;
                                }
                                    
                            }
                            if(nextPlayerID==0)
                                nextPlayerID=playerList[0];

                            int nextPlayerBet = 0;
                            DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID);
                            
                            if(turns==2)
                            {
                                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                                {
                                    if (int.Parse(playerChipsTable.Rows[i]["PlayerID"].ToString()) == nextPlayerID)
                                        nextPlayerBet = int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString());
                                }
                            }
                            if (turns == 3)
                            {
                                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                                {
                                    if (int.Parse(playerChipsTable.Rows[i]["PlayerID"].ToString()) == nextPlayerID)
                                        nextPlayerBet = int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString());
                                }
                            }
                            if (turns == 4)
                            {
                                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                                {
                                    if (int.Parse(playerChipsTable.Rows[i]["PlayerID"].ToString()) == nextPlayerID)
                                        nextPlayerBet = int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString());
                                }
                            }
                            
                            bool ISMAX = true;
                            if(turns==2)
                            {
                                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                                {
                                    if (int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString()) > nextPlayerBet)
                                        ISMAX = false;
                                }
                            }
                            else if (turns == 3)
                            {
                                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                                {
                                    if (int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString()) > nextPlayerBet)
                                        ISMAX = false;
                                }
                            }
                            else if (turns == 4)
                            {
                                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                                {
                                    if (int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString()) > nextPlayerBet)
                                        ISMAX = false;
                                }
                            }
                            
                            if (ISMAX)
                                return 0;
                            else
                                return nextPlayerID;


                        }

                    }
                }
            }
            return -7;
        }

        [WebMethod]
        public int GetNextPlayerIDForLive()
        {
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
            if(recordUnfinished.Rows.Count!=0)
            {
                int playerNumber = int.Parse(recordUnfinished.Rows[0]["PlayerNumber"].ToString());
                if (gameUnfinished.Rows.Count != 0)
                {
                    int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                    DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where Operation='发牌' and GameID=" + gameID);

                    DataTable foldTable = db.GetDataTable("select * from Operations where Operation='弃牌' and GameID=" + gameID);
                    int foldNumber = foldTable.Rows.Count;
                    if (foldNumber == playerNumber - 1)
                        return -1;
                    DataTable allinTable = db.GetDataTable("select * from Operations where Operation='全下' and GameID="+gameID);
                    int allinNumber = allinTable.Rows.Count;

                    //if (allinNumber + foldNumber >= playerNumber - 1)
                    //{
                    //    if (allinNumber > 0)
                    //        return -100;
                    //}

                    if (fapaiOperationTable.Rows.Count == 0)
                    {

                        DataTable operationTable = db.GetDataTable("select * from Operations where GameID=" + gameID);
                        DataTable AllPlayerOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and PlayerID<>0");

                        if (AllPlayerOperationTable.Rows.Count != 0)
                        {
                            int allOperations = AllPlayerOperationTable.Rows.Count;
                            int lastPlayerID = int.Parse(operationTable.Rows[allOperations - 1]["PlayerID"].ToString());
                            if (allOperations < 2)
                            {
                                return -2;
                            }
                            else if (allOperations >= 2 && allOperations < playerNumber)
                            {
                               
                                if (lastPlayerID + 1 > playerNumber)
                                    return 1;

                                return lastPlayerID + 1;
                            }
                            else
                            {
                                DataTable playerAvailableTable = db.GetDataTable(@"select * from PlayerChips where PlayerID not in (select PlayerID from Operations where (Operation='全下' or Operation='弃牌') and GameID=" + gameID + ") and GameID=" + gameID);
                                
                                
                                if (playerAvailableTable.Rows.Count == 1)
                                {
                                    int thisPlayerID=int.Parse(playerAvailableTable.Rows[0]["PlayerID"].ToString());
                                    int turnsBetChips = new PlayerChip().GetTurnsBetChipsForNextPlayer(thisPlayerID);
                                    int maxTrunsBetChips = new PlayerChip().GetMaxBetChipsForLive();

                                    if(turnsBetChips==maxTrunsBetChips)
                                    {
                                        if(allinNumber!=0)
                                        {
                                            return -100;
                                        }
                                    }
                                    return -1;
                                }
                                else
                                {
                                    List<int> playerList = new List<int>();
                                    List<int> betList = new List<int>();
                                    for (int i = 0; i < playerAvailableTable.Rows.Count; i++)
                                    {
                                        playerList.Add(int.Parse(playerAvailableTable.Rows[i]["PlayerID"].ToString()));
                                        betList.Add(int.Parse(playerAvailableTable.Rows[i]["BetChips1"].ToString()));
                                    }
                                    bool isEqual = true;
                                    for (int i = 1; i < betList.Count; i++)
                                    {
                                        if (betList[i - 1] != betList[i])
                                            isEqual = false;
                                    }
                                    if (isEqual)
                                    {
                                        return 0;
                                    }
                                    else
                                    {
                                        for (int i = 0; i < playerList.Count; i++)
                                        {
                                            if (playerList[i] > lastPlayerID)
                                                return playerList[i];
                                        }
                                        return playerList[0];
                                    }
                                }
                            }
                        }

                    }
                    else
                    {
                        int turns = fapaiOperationTable.Rows.Count;
                        DataTable playerAvailableTable = db.GetDataTable(@"select * from PlayerChips where PlayerID not in (select PlayerID from Operations where (Operation='全下' or Operation='弃牌') and GameID=" + gameID + ") and GameID=" + gameID);
                        DataTable operationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and ID>" + int.Parse(fapaiOperationTable.Rows[turns - 1]["ID"].ToString()));
                        int allOperations = operationTable.Rows.Count;

                        List<int> playerList = new List<int>();
                        List<int> betList = new List<int>();

                        int maxBet = 0;
                        if (turns == 1)
                        {
                            for (int i = 0; i < playerAvailableTable.Rows.Count; i++)
                            {
                                playerList.Add(int.Parse(playerAvailableTable.Rows[i]["PlayerID"].ToString()));
                                betList.Add(int.Parse(playerAvailableTable.Rows[i]["BetChips2"].ToString()));
                            }
                            DataTable maxBetTable = db.GetDataTable("Select * from PlayerChips where GameID=" + gameID + " order by BetChips2 DESC");
                            maxBet = int.Parse(maxBetTable.Rows[0]["BetChips2"].ToString());
                        }
                        else if (turns == 2)
                        {
                            for (int i = 0; i < playerAvailableTable.Rows.Count; i++)
                            {
                                playerList.Add(int.Parse(playerAvailableTable.Rows[i]["PlayerID"].ToString()));
                                betList.Add(int.Parse(playerAvailableTable.Rows[i]["BetChips3"].ToString()));
                            }
                            DataTable maxBetTable = db.GetDataTable("Select * from PlayerChips where GameID=" + gameID + " order by BetChips3 DESC");
                            maxBet = int.Parse(maxBetTable.Rows[0]["BetChips3"].ToString());
                        }
                        else if (turns == 3)
                        {
                            for (int i = 0; i < playerAvailableTable.Rows.Count; i++)
                            {
                                playerList.Add(int.Parse(playerAvailableTable.Rows[i]["PlayerID"].ToString()));
                                betList.Add(int.Parse(playerAvailableTable.Rows[i]["BetChips4"].ToString()));
                            }
                            DataTable maxBetTable = db.GetDataTable("Select * from PlayerChips where GameID=" + gameID + " order by BetChips4 DESC");
                            maxBet = int.Parse(maxBetTable.Rows[0]["BetChips4"].ToString());
                        }




                        if (operationTable.Rows.Count == 0&&playerAvailableTable.Rows.Count>1)
                        {
                            DataTable gamesFinished = db.GetDataTable("select * from Games where RecordID=(select ID from Records where State=0) and State<>0");
                            int xiaomangPlayerID = 1;
                            if (gamesFinished.Rows.Count == 0)
                                xiaomangPlayerID = 1;
                            else if (gamesFinished.Rows.Count > 0)
                            {
                                xiaomangPlayerID = gamesFinished.Rows.Count % playerNumber + 1;
                            }
                            for (int i = 0; i < playerList.Count; i++)
                            {
                                if (playerList[i] >= xiaomangPlayerID)
                                    return playerList[i];
                            }
                            return playerList[0];

                        }
                        else if (operationTable.Rows.Count != 0)
                        {
                            int lastPlayerID = int.Parse(operationTable.Rows[allOperations - 1]["PlayerID"].ToString());
                            DataTable thisTurnTaoTaiPlayerTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and (Operation ='全下' or Operation='弃牌') and ID>" + int.Parse(fapaiOperationTable.Rows[turns - 1]["ID"].ToString()));
                            if (operationTable.Rows.Count < playerList.Count + thisTurnTaoTaiPlayerTable.Rows.Count)
                            {
                                //if (playerList.Count == 1)
                                //    return -1;
                                for (int i = 0; i < playerList.Count; i++)
                                {
                                    if (playerList[i] > lastPlayerID)
                                        return playerList[i];
                                }
                                return playerList[0];
                            }
                            else
                            {
                                bool isMax = true;
                                for (int i = 0; i < betList.Count; i++)
                                {
                                    if (betList[i] < maxBet)
                                        isMax = false;
                                }

                                if(playerAvailableTable.Rows.Count==1)
                                {
                                    int thisPlayerID = int.Parse(playerAvailableTable.Rows[0]["PlayerID"].ToString());
                                    int turnsBetChips = new PlayerChip().GetTurnsBetChipsForNextPlayer(thisPlayerID);
                                    int maxTrunsBetChips = new PlayerChip().GetMaxBetChipsForLive();

                                    if (turnsBetChips == maxTrunsBetChips)
                                    {
                                        if (allinNumber != 0)
                                        {
                                            return -100;
                                        }
                                    }
                                    else
                                        return thisPlayerID;

                                }

                                if (playerAvailableTable.Rows.Count <= 1 && isMax && allinNumber == 0)
                                    return -1;
                                else if (playerAvailableTable.Rows.Count <= 1 && isMax && allinNumber != 0)
                                    return -100;
                                bool isEqual = true;
                                for (int i = 1; i < betList.Count; i++)
                                {
                                    if (betList[i - 1] != betList[i])
                                        isEqual = false;
                                }
                                if (betList[0] < maxBet)
                                    isEqual = false;
                                if (isEqual)
                                {
                                    return 0;
                                }
                                else
                                {
                                    for (int i = 0; i < playerList.Count; i++)
                                    {
                                        if (playerList[i] > lastPlayerID)
                                            return playerList[i];
                                    }
                                    return playerList[0];
                                }
                            }
                        }

                    }

                }
            }
            
            return -3;
        }
    }
}
