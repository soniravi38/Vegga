using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Drawing.Imaging;


public partial class Root_captcha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["Str"] != null)
        {
            Bitmap objBMP = new System.Drawing.Bitmap(70, 25);
            Graphics objGraphics = System.Drawing.Graphics.FromImage(objBMP);
            objGraphics.Clear(Color.White);
            Font objFont = new Font("ArialBlack", 14, FontStyle.Bold);
            objGraphics.DrawString(Request["Str"].ToString(), objFont, Brushes.Maroon, 3, 3);
            Response.ContentType = "image/Jpeg";
            objBMP.Save(Response.OutputStream, ImageFormat.Jpeg);
        }
    }
}