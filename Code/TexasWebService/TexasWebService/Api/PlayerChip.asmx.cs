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
    /// PlayerChip 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class PlayerChip : System.Web.Services.WebService
    {
        private DB db = new DB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool NewLoan(int loanchips1, int loanchips2, int loanchips3, int loanchips4, int loanchips5, int loanchips6, int loanchips7, int loanchips8)
        {
            var gameUnfinished = db.GetDataTable("select * from Games where State=0");
            var gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
            var tableplayerchips = db.GetDataTable("select * from PlayerChips where GameID =" + gameID);
            var playerNumber = tableplayerchips.Rows.Count;
            int[] loanchips = new int[] { loanchips1, loanchips2, loanchips3, loanchips4, loanchips5, loanchips6, loanchips7, loanchips8 };
            for (int i = 1; i <= playerNumber; i++)
            {
                db.ExecuteNonQury("update PlayerChips set LoanChips= LoanChips + " + loanchips[i - 1] + "where PlayerID=" + i + " and GameID=" + gameID);

                DataTable start1 = db.GetDataTable("select * from PlayerChips where GameID=" + gameID + " and PlayerID=" + i);
                int startChips1 = int.Parse(start1.Rows[0]["StartChips"].ToString());
                int newstartChips1 = startChips1 + loanchips[i - 1];
                db.ExecuteNonQury("update PlayerChips set StartChips=" + newstartChips1 + "where PlayerID=" + i + "and GameID=" + gameID);
            }

            return true;
        }

        [WebMethod]
        //gainChips修改为玩家的名次
        public bool JudgeWinner(int gainchips1, int gainchips2, int gainchips3, int gainchips4, int gainchips5, int gainchips6, int gainchips7, int gainchips8)
        {
            var gameUnfinished = db.GetDataTable("select * from Games where State=0");
            int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
            var tableplayerchips = db.GetDataTable("select * from PlayerChips where GameID =" + gameID);
            int playerNumber = tableplayerchips.Rows.Count;
            int[] gainChips = new int[] { gainchips1, gainchips2, gainchips3, gainchips4, gainchips5, gainchips6, gainchips7, gainchips8 };
            //int bet11 = int.Parse(PreplayerChips1.Rows[0]["BetChips1"].ToString());
            //int bet12 = int.Parse(PreplayerChips1.Rows[0]["BetChips2"].ToString());
            //int bet13 = int.Parse(PreplayerChips1.Rows[0]["BetChips3"].ToString());
            //int bet14 = int.Parse(PreplayerChips1.Rows[0]["BetChips4"].ToString());

            List<string> playerOrderList = new List<string>();
            for (int i = 1; i <= playerNumber; i++)
            {
                for (int j = 0; j < playerNumber; j++)
                {
                    if (gainChips[j] == i)
                    {
                        if (playerOrderList.Count < i)
                        {
                            playerOrderList.Add("" + (j + 1));
                        }
                        else
                        {
                            playerOrderList[i - 1] = playerOrderList[i - 1] + (j + 1);
                        }
                    }
                }
            }

            DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID);
            int[] playerAllBetChips = new int[8];
            for (int i = 0; i < playerChipsTable.Rows.Count; i++)
            {
                int betChips1 = int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString());
                int betChips2 = int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString());
                int betChips3 = int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString());
                int betChips4 = int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString());

                playerAllBetChips[i] = betChips1 + betChips2 + betChips3 + betChips4;
            }
            int[] chipsHopesToWin = new int[8];
            for (int i = 0; i < playerChipsTable.Rows.Count; i++)
            {
                for (int j = 0; j < playerChipsTable.Rows.Count; j++)
                {
                    if (playerAllBetChips[i] <= playerAllBetChips[j])
                    {
                        chipsHopesToWin[i] += playerAllBetChips[i];
                    }

                    else
                    {
                        chipsHopesToWin[i] += playerAllBetChips[j];
                    }

                }
            }

            int chipsAlreadyTaken = 0;
            int[] reallyGainChips = new int[8];

            for (int i = 0; i < playerOrderList.Count; i++)
            {
                if (playerOrderList[i].Length == 1)
                {
                    int winnerPlayerID = int.Parse(playerOrderList[i].ToString());
                    reallyGainChips[winnerPlayerID - 1] = chipsHopesToWin[winnerPlayerID - 1] - chipsAlreadyTaken;
                    chipsAlreadyTaken = chipsHopesToWin[winnerPlayerID - 1];
                }
                else
                {
                    int levelPlayerNumber = playerOrderList[i].Length;
                    List<int> levelChipsHopeToWinArise = new List<int>();
                    List<int> levelPlayerID = new List<int>();

                    for (int s1 = 0; s1 < levelPlayerNumber; s1++)
                    {
                        int min = 100000000;
                        int index = 0;
                        for (int s2 = 0; s2 < levelPlayerNumber; s2++)
                        {
                            int tempPlayerID = int.Parse(playerOrderList[i].Substring(s2, 1));

                            if (chipsHopesToWin[tempPlayerID - 1] <= min)
                            {
                                min = chipsHopesToWin[tempPlayerID - 1];
                                index = tempPlayerID - 1;
                            }

                        }

                        levelChipsHopeToWinArise.Add(min);
                        levelPlayerID.Add(index + 1);
                        chipsHopesToWin[index] = 100000000;
                    }

                    List<int> eachLevelGain = new List<int>();
                    eachLevelGain.Add((levelChipsHopeToWinArise[0] - chipsAlreadyTaken) / levelPlayerNumber);
                    for (int s = 1; s < levelPlayerNumber; s++)
                    {
                        eachLevelGain.Add(levelChipsHopeToWinArise[s] - levelChipsHopeToWinArise[s - 1]);
                    }

                    for (int s = 0; s < levelPlayerNumber; s++)
                    {
                        for (int s1 = 0; s1 < levelPlayerNumber; s1++)
                        {
                            if (s1 <= s)
                            {
                                reallyGainChips[levelPlayerID[s] - 1] += eachLevelGain[s1];
                            }
                        }
                    }
                    chipsAlreadyTaken = levelChipsHopeToWinArise[levelChipsHopeToWinArise.Count - 1];
                }
            }
            //result = db.ExecuteNonQury("delete from PlayerChips where RecordID=" + recordID);
            //result = db.ExecuteNonQury("delete from Operations where GameID in (select ID from Games where RecordID=" + recordID + ")");
            //result = db.ExecuteNonQury("delete from PrivateCards where GameID in (select ID from Games where RecordID=" + recordID + ")");
            //result = db.ExecuteNonQury("delete from Games where RecordID =" + recordID);

            for (int i = 1; i <= playerNumber; i++)
            {
                db.ExecuteNonQury("update PlayerChips set GainChips=" + reallyGainChips[i - 1] + "where PlayerID=" + i + " and GameID=" + gameID);
            }
            db.ExecuteNonQury(string.Format("insert into Operations(GameID,PlayerID,Operation) values('{0}','{1}','{2}')", gameID, 0, "判定"));
            //db.ExecuteNonQury("update Games set State=1 where State=0");
            //db.ExecuteNonQury(string.Format("insert into Games(RecordID,State) values('{0}','{1}')",int.Parse(gameUnfinished.Rows[0]["RecordID"].ToString()),0));

            new Game().NewGame();


            return true;
        }

        [WebMethod]
        public DataSet GetStartChipsForJudgeShow()
        {
            DataSet resultSet = new DataSet();
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                resultSet = db.GetDataSet("select * from PlayerChips where GameID=" + gameID);
            }

            return resultSet;
        }

        [WebMethod]
        public DataSet GetStartChipsByGameID(int gameID)
        {
            DataSet resultSet = new DataSet();
            resultSet = db.GetDataSet("select * from PlayerChips where GameID=" + gameID);

            return resultSet;
        }

        [WebMethod]
        public DataSet GetLastGameResultForLive()
        {
            DataTable gameFinished = db.GetDataTable("select top 1 * from Games where State=1 order by ID DESC");
            int gameID = int.Parse(gameFinished.Rows[0]["ID"].ToString());
            DataSet resultSet = db.GetDataSet("select * from PlayerChips where GameID=" + gameID);

            return resultSet;
        }

        [WebMethod]
        public DataSet GetGameResultByGameID(int gameID)
        {
            DataSet resultSet = db.GetDataSet("select * from PlayerChips where GameID=" + gameID);

            return resultSet;
        }

        [WebMethod]
        public DataSet GetPlayerChipsByRecordID(int recordID)
        {
            DataSet resultSet = db.GetDataSet("select * from PlayerChips where RecordID=" + recordID + " order by ID");

            return resultSet;
        }

        [WebMethod]
        public bool SetHeadPicture(int playerID, string headPicture)
        {
            DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");

            if (recordUnfinished.Rows.Count != 0)
            {
                if (playerID > int.Parse(recordUnfinished.Rows[0]["PlayerNumber"].ToString()))
                    return false;
                int recordID = int.Parse(recordUnfinished.Rows[0]["ID"].ToString());
                switch (playerID)
                {
                    case 1:
                        db.ExecuteNonQury("update Records set HeadPicture1='" + headPicture + "' where ID=" + recordID);
                        break;
                    case 2:
                        db.ExecuteNonQury("update Records set HeadPicture2='" + headPicture + "' where ID=" + recordID);
                        break;
                    case 3:
                        db.ExecuteNonQury("update Records set HeadPicture3='" + headPicture + "' where ID=" + recordID);
                        break;
                    case 4:
                        db.ExecuteNonQury("update Records set HeadPicture4='" + headPicture + "' where ID=" + recordID);
                        break;
                    case 5:
                        db.ExecuteNonQury("update Records set HeadPicture5='" + headPicture + "' where ID=" + recordID);
                        break;
                    case 6:
                        db.ExecuteNonQury("update Records set HeadPicture6='" + headPicture + "' where ID=" + recordID);
                        break;
                    case 7:
                        db.ExecuteNonQury("update Records set HeadPicture7='" + headPicture + "' where ID=" + recordID);
                        break;
                    case 8:
                        db.ExecuteNonQury("update Records set HeadPicture8='" + headPicture + "' where ID=" + recordID);
                        break;
                }
                return true;
            }
            return false;
        }

        [WebMethod]
        public string GetPlayerChipsInPoolForLive(string chipsBet)
        {
            string playerChipsInPool = "";

            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID);
                int[] playerAllBetChips = new int[8];
                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                {
                    int betChips1 = int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString());
                    int betChips2 = int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString());
                    int betChips3 = int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString());
                    int betChips4 = int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString());

                    if (chipsBet.Equals("1"))
                        playerAllBetChips[i] = betChips1;
                    else if (chipsBet.Equals("2"))
                        playerAllBetChips[i] = betChips1 + betChips2;
                    else if (chipsBet.Equals("3"))
                        playerAllBetChips[i] = betChips1 + betChips2 + betChips3;
                    else
                        playerAllBetChips[i] = betChips1 + betChips2 + betChips3 + betChips4;
                }
                DataTable allInOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='全下'");

                DataTable foldOperationTable = new DataTable();
                DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='发牌' and ChipsBet='" + chipsBet + "'");
                if (fapaiOperationTable.Rows.Count == 0)
                {
                    foldOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='弃牌'");
                }
                else
                {
                    int fapaiID = int.Parse(fapaiOperationTable.Rows[0]["ID"].ToString());
                    foldOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='弃牌' and ID<" + fapaiID);
                }


                int[] chipsHopesToWin = new int[8];
                int[] chipsHopesToWin1 = new int[8];
                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                {
                    for (int j = 0; j < playerChipsTable.Rows.Count; j++)
                    {
                        if (playerAllBetChips[i] <= playerAllBetChips[j])
                        {
                            chipsHopesToWin[i] += playerAllBetChips[i];
                            chipsHopesToWin1[i] += playerAllBetChips[i];
                        }

                        else
                        {
                            chipsHopesToWin[i] += playerAllBetChips[j];
                            chipsHopesToWin1[i] += playerAllBetChips[j];
                        }

                    }
                }

                for (int i = 0; i < foldOperationTable.Rows.Count; i++)
                {
                    chipsHopesToWin[int.Parse(foldOperationTable.Rows[i]["PlayerID"].ToString()) - 1] = 0;
                    chipsHopesToWin1[int.Parse(foldOperationTable.Rows[i]["PlayerID"].ToString()) - 1] = 0;
                }

                int[] ChipsHopesToWinDESC = new int[8];
                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                {
                    int max = 0;
                    int index = 0;
                    for (int j = 0; j < playerChipsTable.Rows.Count; j++)
                    {
                        if (chipsHopesToWin[j] >= max)
                        {
                            max = chipsHopesToWin[j];
                            index = j;
                        }
                    }
                    ChipsHopesToWinDESC[i] = max;
                    max = 0;
                    chipsHopesToWin[index] = 0;
                }

                for (int i = ChipsHopesToWinDESC.Length; i > 1; i--)
                {
                    string thisCipsPlayer = "";
                    int newChipsinpool = ChipsHopesToWinDESC[i - 1] - ChipsHopesToWinDESC[i - 2];
                    if (newChipsinpool < 0)
                    {
                        for (int j = 0; j < chipsHopesToWin1.Length; j++)
                        {
                            if (chipsHopesToWin1[j] > 0)
                            {
                                if (chipsHopesToWin1[j] >= ChipsHopesToWinDESC[i - 2])
                                {
                                    thisCipsPlayer = thisCipsPlayer + (j + 1) + ",";
                                }
                            }
                        }
                        playerChipsInPool = playerChipsInPool + "&" + thisCipsPlayer;
                    }
                }

                string thisCipsPlayer0 = "";
                for (int j = 0; j < chipsHopesToWin1.Length; j++)
                {

                    if (chipsHopesToWin1[j] >= ChipsHopesToWinDESC[0])
                        thisCipsPlayer0 = thisCipsPlayer0 + (j + 1) + ",";
                }
                playerChipsInPool = playerChipsInPool + "&" + thisCipsPlayer0;

                //if (ChipsHopesToWinDESC[playerChipsTable.Rows.Count - 1] != 0)
                //    playerChipsInPool = playerChipsInPool + "&" + ChipsHopesToWinDESC[playerChipsTable.Rows.Count - 1];
                //for (int i = playerChipsTable.Rows.Count; i > 1; i--)
                //{
                //    int newChipsinpool = ChipsHopesToWinDESC[i - 2] - ChipsHopesToWinDESC[i - 1];
                //    if (newChipsinpool > 0)
                //        playerChipsInPool = playerChipsInPool + "&" + newChipsinpool;
                //}

            }

            return playerChipsInPool;
        }

        [WebMethod]
        public string GetChipsInPoolForLive(string chipsBet)
        {
            string chipsInPool = "";

            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID);
                int[] playerAllBetChips = new int[8];
                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                {
                    int betChips1 = int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString());
                    int betChips2 = int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString());
                    int betChips3 = int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString());
                    int betChips4 = int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString());

                    if (chipsBet.Equals("1"))
                        playerAllBetChips[i] = betChips1;
                    else if (chipsBet.Equals("2"))
                        playerAllBetChips[i] = betChips1 + betChips2;
                    else if (chipsBet.Equals("3"))
                        playerAllBetChips[i] = betChips1 + betChips2 + betChips3;
                    else
                        playerAllBetChips[i] = betChips1 + betChips2 + betChips3 + betChips4;
                }
                DataTable allInOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='全下'");

                DataTable foldOperationTable = new DataTable();
                DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='发牌' and ChipsBet='" + chipsBet + "'");
                if (fapaiOperationTable.Rows.Count == 0)
                {
                    foldOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='弃牌'");
                }
                else
                {
                    int fapaiID = int.Parse(fapaiOperationTable.Rows[0]["ID"].ToString());
                    foldOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='弃牌' and ID<" + fapaiID);
                }


                int[] chipsHopesToWin = new int[8];
                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                {
                    for (int j = 0; j < playerChipsTable.Rows.Count; j++)
                    {
                        if (playerAllBetChips[i] <= playerAllBetChips[j])
                            chipsHopesToWin[i] += playerAllBetChips[i];
                        else
                            chipsHopesToWin[i] += playerAllBetChips[j];
                    }
                }

                for (int i = 0; i < foldOperationTable.Rows.Count; i++)
                {
                    chipsHopesToWin[int.Parse(foldOperationTable.Rows[i]["PlayerID"].ToString()) - 1] = 0;
                }

                int[] ChipsHopesToWinDESC = new int[8];
                for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                {
                    int max = 0;
                    int index = 0;
                    for (int j = 0; j < playerChipsTable.Rows.Count; j++)
                    {
                        if (chipsHopesToWin[j] >= max)
                        {
                            max = chipsHopesToWin[j];
                            index = j;
                        }
                    }
                    ChipsHopesToWinDESC[i] = max;
                    max = 0;
                    chipsHopesToWin[index] = 0;
                }
                if (ChipsHopesToWinDESC[playerChipsTable.Rows.Count - 1] != 0)
                    chipsInPool = chipsInPool + "&" + ChipsHopesToWinDESC[playerChipsTable.Rows.Count - 1];
                for (int i = playerChipsTable.Rows.Count; i > 1; i--)
                {
                    int newChipsinpool = ChipsHopesToWinDESC[i - 2] - ChipsHopesToWinDESC[i - 1];
                    if (newChipsinpool > 0)
                        chipsInPool = chipsInPool + "&" + newChipsinpool;
                }

            }

            return chipsInPool;
        }

        [WebMethod]
        public string GetChipsInPoolByGameID(int gameID, string chipsBet)
        {
            string chipsInPool = "";
            DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID);
            int[] playerAllBetChips = new int[8];
            for (int i = 0; i < playerChipsTable.Rows.Count; i++)
            {
                int betChips1 = int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString());
                int betChips2 = int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString());
                int betChips3 = int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString());
                int betChips4 = int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString());

                if (chipsBet.Equals("1"))
                    playerAllBetChips[i] = betChips1;
                else if (chipsBet.Equals("2"))
                    playerAllBetChips[i] = betChips1 + betChips2;
                else if (chipsBet.Equals("3"))
                    playerAllBetChips[i] = betChips1 + betChips2 + betChips3;
                else
                    playerAllBetChips[i] = betChips1 + betChips2 + betChips3 + betChips4;
            }
            DataTable allInOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='全下'");
            DataTable foldOperationTable = new DataTable();
            DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='发牌' and ChipsBet='" + chipsBet + "'");
            if (fapaiOperationTable.Rows.Count == 0)
            {
                foldOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='弃牌'");
            }
            else
            {
                int fapaiID = int.Parse(fapaiOperationTable.Rows[0]["ID"].ToString());
                foldOperationTable = db.GetDataTable("select * from Operations where GameID=" + gameID + " and Operation='弃牌' and ID<" + fapaiID);
            }
            int[] chipsHopesToWin = new int[8];
            for (int i = 0; i < playerChipsTable.Rows.Count; i++)
            {
                for (int j = 0; j < playerChipsTable.Rows.Count; j++)
                {
                    if (playerAllBetChips[i] <= playerAllBetChips[j])
                        chipsHopesToWin[i] += playerAllBetChips[i];
                    else
                        chipsHopesToWin[i] += playerAllBetChips[j];
                }
            }

            for (int i = 0; i < foldOperationTable.Rows.Count; i++)
            {
                chipsHopesToWin[int.Parse(foldOperationTable.Rows[i]["PlayerID"].ToString()) - 1] = 0;
            }

            int[] ChipsHopesToWinDESC = new int[8];
            for (int i = 0; i < playerChipsTable.Rows.Count; i++)
            {
                int max = 0;
                int index = 0;
                for (int j = 0; j < playerChipsTable.Rows.Count; j++)
                {
                    if (chipsHopesToWin[j] >= max)
                    {
                        max = chipsHopesToWin[j];
                        index = j;
                    }
                }
                ChipsHopesToWinDESC[i] = max;
                max = 0;
                chipsHopesToWin[index] = 0;
            }
            if (ChipsHopesToWinDESC[playerChipsTable.Rows.Count - 1] != 0)
                chipsInPool = chipsInPool + "&" + ChipsHopesToWinDESC[playerChipsTable.Rows.Count - 1];
            for (int i = playerChipsTable.Rows.Count; i > 1; i--)
            {
                int newChipsinpool = ChipsHopesToWinDESC[i - 2] - ChipsHopesToWinDESC[i - 1];
                if (newChipsinpool > 0)
                    chipsInPool = chipsInPool + "&" + newChipsinpool;
            }
            return chipsInPool;
        }

        [WebMethod]
        public int GetMaxBetChipsForLive()
        {
            int maxBetChips = 0;
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where Operation='发牌' and  GameID=" + gameID);
                int turns = fapaiOperationTable.Rows.Count;
                DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID);
                if (turns == 0)
                {
                    for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                    {
                        if (int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString()) > maxBetChips)
                            maxBetChips = int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString());
                    }
                }
                else if (turns == 1)
                {
                    for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                    {
                        if (int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString()) > maxBetChips)
                            maxBetChips = int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString());
                    }
                }
                else if (turns == 2)
                {
                    for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                    {
                        if (int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString()) > maxBetChips)
                            maxBetChips = int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString());
                    }
                }
                else if (turns == 3)
                {
                    for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                    {
                        if (int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString()) > maxBetChips)
                            maxBetChips = int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString());
                    }
                }
            }
            return maxBetChips;
        }

        [WebMethod]
        public int GetTurnsBetChipsForNextPlayer(int playerID)
        {
            int turnsBetChips = 0;
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where Operation='发牌' and  GameID=" + gameID);
                int turns = fapaiOperationTable.Rows.Count;
                DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID + " and PlayerID=" + playerID);
                int betChips1 = int.Parse(playerChipsTable.Rows[0]["BetChips1"].ToString());
                int betChips2 = int.Parse(playerChipsTable.Rows[0]["BetChips2"].ToString());
                int betChips3 = int.Parse(playerChipsTable.Rows[0]["BetChips3"].ToString());
                int betChips4 = int.Parse(playerChipsTable.Rows[0]["BetChips4"].ToString());

                if (turns == 0)
                {
                    turnsBetChips = betChips1;
                }
                else if (turns == 1)
                {
                    turnsBetChips = betChips2;
                }
                else if (turns == 2)
                {
                    turnsBetChips = betChips3;
                }
                else if (turns == 3)
                {
                    turnsBetChips = betChips4;
                }

            }
            return turnsBetChips;
        }

        [WebMethod]
        public int GetTurnsLeftBetChipsForNextPlayer(int playerID)
        {
            int turnsLeftBetChips = 0;
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable fapaiOperationTable = db.GetDataTable("select * from Operations where Operation='发牌' and  GameID=" + gameID);
                int turns = fapaiOperationTable.Rows.Count;
                DataTable playerChipsTable = db.GetDataTable("select * from PlayerChips where GameID=" + gameID + " and PlayerID=" + playerID);
                int startChips = int.Parse(playerChipsTable.Rows[0]["StartChips"].ToString());
                int betChips1 = int.Parse(playerChipsTable.Rows[0]["BetChips1"].ToString());
                int betChips2 = int.Parse(playerChipsTable.Rows[0]["BetChips2"].ToString());
                int betChips3 = int.Parse(playerChipsTable.Rows[0]["BetChips3"].ToString());
                int betChips4 = int.Parse(playerChipsTable.Rows[0]["BetChips4"].ToString());

                if (turns == 0)
                {
                    turnsLeftBetChips = startChips;
                }
                else if (turns == 1)
                {
                    turnsLeftBetChips = startChips - betChips1;
                }
                else if (turns == 2)
                {
                    turnsLeftBetChips = startChips - betChips1 - betChips2;
                }
                else if (turns == 3)
                {
                    turnsLeftBetChips = startChips - betChips1 - betChips2 - betChips3;
                }

            }
            return turnsLeftBetChips;
        }

    }
}
