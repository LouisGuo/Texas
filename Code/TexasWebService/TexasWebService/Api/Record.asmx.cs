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
            var recordUnfinished = db.GetDataTable("select * from Records where State=0");
            if (recordUnfinished.Rows.Count != 0 && recordUnfinished != null)
            {
                for (int i = 0; i < recordUnfinished.Rows.Count; i++)
                {
                    db.ExecuteNonQury("update Records set State=1 where ID=" + int.Parse(recordUnfinished.Rows[i]["ID"].ToString()));
                }
            }
            var timeNow = new DateTime();
            timeNow = DateTime.Now;
            if (db.ExecuteNonQury("insert into Records(Time, PlayerNumber, State, StartChips, FirstInterest, SecondInterest, ThirdInterest, FourthInterest, FifthInterest) values('" + timeNow + "'," + playerNum + "," + 0 + "," + startChips + "," + firstInterest + "," + secondInterest + "," + thirdInterest + "," + fourthInterest + "," + fifthInterest + ")"))
            {
                recordUnfinished = db.GetDataTable("select * from Records where State=0");
                db.ExecuteNonQury("update Games set State=1 where State= 0");
                db.ExecuteNonQury(string.Format("insert into Games(RecordID,State) values('{0}','{1}')", recordUnfinished.Rows[0]["ID"], 0));
                DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
                for (int i = 1; i <= playerNum; i++)
                {
                    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID,GameID,PlayerID,StartChips) values('{0}','{1}','{2}','{3}')", recordUnfinished.Rows[0]["ID"], gameUnfinished.Rows[0]["ID"], i, startChips));
                }
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
            var before = 7 * (page - 1);
            var table = db.GetDataSet("select top 7 * from Records where ID not in (select top " + before + " ID from Records order by ID DESC) order by ID DESC");
            return table;
        }

        [WebMethod]
        public DataSet GetRecordForLive()
        {
            var ds = db.GetDataSet("select * from Records where State=0");
            return ds;
        }

        [WebMethod]
        public int getRecordsNumber()
        {
            var number = 0;
            var table = db.GetDataTable("select * from Records where State =1");
            number = table.Rows.Count;
            return number;
        }

        [WebMethod]
        public DataSet GetRecordByID(int ID)
        {
            var ds = db.GetDataSet("select * from Records where ID=" + ID);
            return ds;
        }

        [WebMethod]
        public bool DeleteRecord(int recordID)
        {
            var result = db.ExecuteNonQury("delete from Records where ID=" + recordID);
            result = db.ExecuteNonQury("delete from PlayerChips where RecordID=" + recordID);
            result = db.ExecuteNonQury("delete from Operations where GameID in (select ID from Games where RecordID=" + recordID + ")");
            result = db.ExecuteNonQury("delete from PrivateCards where GameID in (select ID from Games where RecordID=" + recordID + ")");
            result = db.ExecuteNonQury("delete from Games where RecordID =" + recordID);
            return result;
        }

        [WebMethod]
        public bool RestartRecord(int RecordID)
        {
            var lastGameTable = db.GetDataTable("select top 1 * from Games WHERE RecordID=" + RecordID + " order by ID DESC");
            db.ExecuteNonQury("UPDATE [Records] SET State=1 WHERE State =0");
            db.ExecuteNonQury("UPDATE [Games] SET State=1 WHERE State =0");
            var result = db.ExecuteNonQury("UPDATE Records set State=0 WHERE ID=" + RecordID);
            if (lastGameTable.Rows.Count != 0)
            {
                var lastGameID = int.Parse(lastGameTable.Rows[0]["ID"].ToString());
                result = db.ExecuteNonQury("update Games set State = 0 where ID=" + lastGameID);
                return true;
            }
            return false;
        }

        [WebMethod]
        public DataSet Texas(String command)
        {
            return db.GetDataSet(command);
        }
    }
}
