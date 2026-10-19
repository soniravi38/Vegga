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

public partial class Web_Reports : System.Web.UI.Page
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
            GetHeaderImage();
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetHeaderImage()
    {
        dt = cls.select_data_dt("Exec Proc_AllImages 'GetAll','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgHeader.ImageUrl = "../App_Content/Picture/AllImages/actual/" + Convert.ToString(dt.Rows[0]["Certificates"]);
        }
    }
    #endregion

    #region[AllEvents]
    protected void btnQuerySubmit_Click(object sender, EventArgs e)
    {
        cls_connection cls = new cls_connection();
        Guid ID = new Guid();
        dt = cls.select_data_dt("Proc_CertificateMaster 'GetbyCerti','" + ID + "','" + txtCertificateNo.Text + "','" + txtWeight.Text + "','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            //Response.Redirect("TestingCertificate.aspx?id=" + dt.Rows[0]["id"].ToString());
            Response.Redirect("TestingCertificate.aspx?CertificateNo=" + txtCertificateNo.Text + "&Weight=" + txtWeight.Text);
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Certificate No. or Weight Invalid');window.location='Reports.aspx';", true);
        }
    }
    #endregion
}