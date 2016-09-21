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
    /// Record 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Record : System.Web.Services.WebService
    {
        private DB db = new DB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool NewRecord(int playerNum, int startChips, float firstInterest, float secondInterest, float thirdInterest, float fourthInterest, float fifthInterest)
        {
            DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
            if(recordUnfinished.Rows.Count!=0&&recordUnfinished!=null)
            {
                for (int i = 0; i < recordUnfinished.Rows.Count;i++ )
                {
                    db.ExecuteNonQury("update Records set State=1 where ID="+ int.Parse(recordUnfinished.Rows[i]["ID"].ToString()));
                }
            }
            DateTime timeNow = new DateTime();
            timeNow = DateTime.Now;
            if (db.ExecuteNonQury("insert into Records(Time, PlayerNumber, State, StartChips, FirstInterest, SecondInterest, ThirdInterest, FourthInterest, FifthInterest) values('" + timeNow + "'," + playerNum + "," + 0 + "," + startChips + "," + firstInterest + "," + secondInterest + "," + thirdInterest + "," + fourthInterest + "," + fifthInterest + ")"))
            {
                recordUnfinished = db.GetDataTable("select * from Records where State=0");
                db.ExecuteNonQury("update Games set State=1 where State= 0");
                db.ExecuteNonQury(string.Format("insert into Games(RecordID,State) values('{0}','{1}')", recordUnfinished.Rows[0]["ID"], 0));
                DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
                for (int i = 1; i <= playerNum;i++ )
                {
                    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], i, startChips));
                }
                //if (playerNum >= 2)
                //{
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 1, startChips));
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 2, startChips));
                //}
                //if(playerNum>=3)
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 3, startChips));
                //if (playerNum >= 4)
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 4, startChips));
                //if (playerNum >= 5)
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 5, startChips));
                //if (playerNum >= 6)
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 6, startChips));
                //if (playerNum >= 7)
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 7, startChips));
                //if (playerNum >= 8)
                //    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], 8, startChips));
                
                
                return true;
            }
            else
                return false;
        }

        [WebMethod]
        public bool FinishRecord()
        {
            db.ExecuteNonQury("update Records set State=1 where State=0");
            db.ExecuteNonQury("update Games set State =1 where State=0");
            return true;
        }

        [WebMethod]
        public DataSet GetRecords()
        {
            DataSet table = db.GetDataSet("select * from Records order by ID DESC");
            return table;
        }

        [WebMethod]
        public DataSet GetRecordsByPage(int page)
        {
            int before = 7*(page-1);
            DataSet table = db.GetDataSet("select top 7 * from Records where ID not in (select top " + before + " ID from Records order by ID DESC) order by ID DESC");
            return table;
        }

        [WebMethod]
        public int getRecordsNumber()
        {
            int number = 0;
            DataTable table = db.GetDataTable("select * from Records where State =1");
            number = table.Rows.Count;
            return number;
        }

        [WebMethod]
        public DataSet GetRecordForLive()
        {
            DataSet ds = db.GetDataSet("select * from Records where State=0");
            return ds;
        }

        [WebMethod]
        public DataSet GetRecordByID(int ID)
        {
            DataSet ds = db.GetDataSet("select * from Records where ID="+ID);
            return ds;
        }

        [WebMethod]
        public bool DeleteRecord(int recordID)
        {
            bool result = db.ExecuteNonQury("delete from Records where ID="+recordID);
            result = db.ExecuteNonQury("delete from PlayerChips where RecordID="+recordID);
            result = db.ExecuteNonQury("delete from Operations where GameID in (select ID from Games where RecordID="+recordID+")");
            result = db.ExecuteNonQury("delete from PrivateCards where GameID in (select ID from Games where RecordID=" + recordID + ")");
            result = db.ExecuteNonQury("delete from Games where RecordID =" + recordID);
            return result;
        }

        [WebMethod]
        public bool RestartRecord(int RecordID)
        {
            db.ExecuteNonQury("update Records set State=1 where State =0");
            db.ExecuteNonQury("update Games set State=1 where State =0");
            bool result = db.ExecuteNonQury("update Records set State=0 where ID="+RecordID);
            DataTable lastGameTable = db.GetDataTable("select top 1 * from Games where RecordID="+RecordID+" order by ID DESC");
            if(lastGameTable.Rows.Count!=0)
            {
                int lastGameID = int.Parse(lastGameTable.Rows[0]["ID"].ToString());
                result = db.ExecuteNonQury("update Games set State = 0 where ID="+lastGameID);
                return true;
            }
            
            return false;
        }
        
    }
}
