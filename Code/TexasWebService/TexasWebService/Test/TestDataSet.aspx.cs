using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TexasWebService.Common;

namespace TexasWebService.Test
{
    public partial class TestDataSet : System.Web.UI.Page
    {
        private DB db = new DB();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataSet set = db.GetDataSet("select * from Records");
            this.Label1.Text = set.Tables[0].Rows.Count.ToString();
        }
    }
}