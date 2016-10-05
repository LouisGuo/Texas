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
    /// Administrator 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Administrator : System.Web.Services.WebService
    {
        private DB db = new DB();

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public bool CheckAdministrator(string name, string password)
        {
            DataTable table = db.GetDataTable("select * from Administrators where UserName='" + name + "'");
            if (table.Rows.Count != 0 && table != null)
            {
                if (table.Rows[0]["Password"].ToString().Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        [WebMethod]
        public bool ResetPassword(string name, string newPassword)
        {
            if (db.ExecuteNonQury("update Administrators set Password='" + newPassword + "' where UserName='" + name + "'"))
            {
                return true;
            }
            return false;
        }

        [WebMethod]
        public int GetPlayerIDForPlayerLogin(string ipAdress)
        {
            DataTable ipTable = db.GetDataTable("select * from PlayerIPs where IPAdress='" + ipAdress + "'");
            if (ipTable.Rows.Count != 0)
            {
                return int.Parse(ipTable.Rows[0]["PlayerID"].ToString());
            }
            return 0;
        }

        [WebMethod]
        public bool SetPlayerIP(int playerID, string ipAdress)
        {
            bool result = false;
            DataTable oldIPTable = db.GetDataTable("select * from PlayerIPs where IPAdress='" + ipAdress + "'");
            if (oldIPTable.Rows.Count == 0)
            {
                result = db.ExecuteNonQury(string.Format("insert into PlayerIPs(IPAdress, PlayerID) values('{0}','{1}')", ipAdress, playerID));
            }
            else
            {
                result = db.ExecuteNonQury("update PlayerIPs set PlayerID=" + playerID + " where IPAdress ='" + ipAdress + "'");
            }

            return true;
        }
    }
}
