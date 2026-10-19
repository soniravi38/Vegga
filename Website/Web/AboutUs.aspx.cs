using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Collections.Specialized;

public partial class Web_AboutUs : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    SendSMS SendMessage = new SendSMS();
    #endregion

    #region [PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            GetAboutText();
            GetHeaderImage();
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetAboutText()
    {
        dt = cls.select_data_dt("Exec Proc_AboutUs 'GetAll','',''");
        if (dt.Rows.Count > 0)
        {
            lblAboutUsText.Text = dt.Rows[0]["AboutUsText"].ToString();
            lblWhyUsText.Text = dt.Rows[0]["WhyUsText"].ToString();
        }
    }
    private void GetHeaderImage()
    {
        dt = cls.select_data_dt("Exec Proc_AllImages 'GetAll','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgHeader.ImageUrl = "../App_Content/Picture/AllImages/actual/" + Convert.ToString(dt.Rows[0]["AboutUs"]);
        }
    }
    #endregion
}