using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TexasWebService
{
    public partial class Save : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string addon = "";
            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpPostedFile file = Request.Files[0];
                    //string filePath = "C:\\Documents and Settings\\Administrator\\桌面\\2\\" + file.FileName;//this.MapPath("UploadDocument")  
                    string filePath = "D:\\GuoLuqiang\\" + file.FileName;

                    addon = addon + filePath;
                    file.SaveAs(filePath);
                    Response.Write(addon);
                }
                catch(Exception ex)
                {
                    addon = addon + ex.Message.ToString();

                    Response.Write(addon);
                }
            }
            else
            {
                Response.Write(addon);
            }  
        }
    }
}