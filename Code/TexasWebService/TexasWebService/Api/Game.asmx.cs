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
    /// Game 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Game : System.Web.Services.WebService
    {
        private DB db = new DB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool NewGame()
        {
            var table = db.GetDataTable("select * from Records where State = 0");
            if (table.Rows.Count == 0)
                return false;
            else
            {
                db.ExecuteNonQury("update Games set State=1 where State=0");
                db.ExecuteNonQury("insert into Games(RecordID, State) values(" + int.Parse(table.Rows[0]["ID"].ToString()) + ",0) ");
                var gameUnfinished = db.GetDataTable("select * from Games where State=0");
                int playerNumber = int.Parse(table.Rows[0]["PlayerNumber"].ToString());
                int recordID = int.Parse(table.Rows[0]["ID"].ToString());
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());


                for (int i = 1; i <= playerNumber; i++)
                {
                    var PreplayerChips1 = db.GetDataTable("select top 1 * from PlayerChips where RecordID=" + int.Parse(table.Rows[0]["ID"].ToString()) + "and PlayerID=" + i + " order by ID DESC");
                    int preStartChips1 = int.Parse(PreplayerChips1.Rows[0]["StartChips"].ToString());
                    int gainChips = int.Parse(PreplayerChips1.Rows[0]["GainChips"].ToString());
                    int bet11 = int.Parse(PreplayerChips1.Rows[0]["BetChips1"].ToString());
                    int bet12 = int.Parse(PreplayerChips1.Rows[0]["BetChips2"].ToString());
                    int bet13 = int.Parse(PreplayerChips1.Rows[0]["BetChips3"].ToString());
                    int bet14 = int.Parse(PreplayerChips1.Rows[0]["BetChips4"].ToString());
                    int startChips1 = preStartChips1 + gainChips - bet11 - bet12 - bet13 - bet14;
                    db.ExecuteNonQury(string.Format("insert into PlayerChips(RecordID, GameID, PlayerID, StartChips) values('{0}','{1}','{2}','{3}')", recordID, gameID, i, startChips1));
                }
            }
            return true;
        }

        [WebMethod]
        public bool FinishGame()
        {
            var table = db.GetDataTable("select * from Games where State = 0 order by ID ");
            if (table.Rows.Count != 0 && table != null)
            {
                db.ExecuteNonQury("update Games set State=1 where ID = " + int.Parse(table.Rows[0]["ID"].ToString()));
            }
            return true;
        }

        [WebMethod]
        public DataTable GetGames(int recordID)
        {
            var table = db.GetDataTable("select * from Games where RecordID = " + recordID);
            return table;
        }

        [WebMethod]
        public DataSet GetGameByGameID(int gameID)
        {
            var table = db.GetDataSet("select * from Games where ID = " + gameID);
            return table;
        }
    }
}
