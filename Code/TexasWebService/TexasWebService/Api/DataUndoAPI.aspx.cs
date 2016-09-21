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
    public partial class DataUndoAPI : System.Web.UI.Page
    {
        private DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["type"] != null)
                {
                    string type = Request.QueryString["type"].ToString();

                    string result = DataUndoAPIMethod(type);

                    Response.Clear();
                    Response.Write(result);
                    Response.Flush();
                    Response.End();
                }

            }
        }

        public string DataUndoAPIMethod(string type)
        {
            DataTable gameUnfinished = db.GetDataTable("select * from Games where State=0");
            if (gameUnfinished.Rows.Count != 0)
            {
                int gameID = int.Parse(gameUnfinished.Rows[0]["ID"].ToString());
                DataTable recordUnfinished = db.GetDataTable("select * from Records where State=0");
                int playerNumber = int.Parse(recordUnfinished.Rows[0]["PlayerNumber"].ToString());

                DataTable privateCardsTable = db.GetDataTable("select * from PrivateCards where GameID=" + gameID);
                int playerCount = privateCardsTable.Rows.Count;
                if (playerCount == 0)
                    return "00";

                //玩家顺序
                if (type.Equals("0"))
                {
                    if (privateCardsTable.Rows[playerCount - 1]["SecondCard"].ToString().Equals(""))
                    {
                        db.ExecuteNonQury("delete from PrivateCards where ID=" + int.Parse(privateCardsTable.Rows[playerCount - 1]["ID"].ToString()));
                        return playerCount + "1";
                    }
                    else
                    {
                        db.ExecuteNonQury("update PrivateCards set SecondCard='' where ID=" + int.Parse(privateCardsTable.Rows[playerCount - 1]["ID"].ToString()));
                        return playerCount + "2";
                    }
                }
                //发牌顺序
                else
                {
                    if (playerCount < playerNumber)
                    {
                        db.ExecuteNonQury("delete from PrivateCards where ID=" + privateCardsTable.Rows[playerCount - 1]["ID"].ToString());
                        return playerCount + "1";
                    }
                    else
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
                        if (thisPlayer == 1)
                        {
                            db.ExecuteNonQury("delete from PrivateCards where ID=" + int.Parse(privateCardsTable.Rows[playerCount - 1]["ID"].ToString()));
                            return playerCount + "1";
                        }
                        else if ((thisPlayer > 1 && thisPlayer <= playerNumber))
                        {
                            db.ExecuteNonQury("update PrivateCards set SecondCard='' where ID=" + int.Parse(privateCardsTable.Rows[thisPlayer - 2]["ID"].ToString()));
                            return (thisPlayer - 1) + "2";
                        }
                        else if(thisPlayer==0)
                        {
                            db.ExecuteNonQury("update PrivateCards set SecondCard='' where ID=" + int.Parse(privateCardsTable.Rows[playerCount-1]["ID"].ToString()));
                            return playerCount + "2";
                        }

                    }
                }
            }
            return "00";
        }
    }
}