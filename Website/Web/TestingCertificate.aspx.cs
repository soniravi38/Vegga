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
            if (Request.QueryString["CertificateNo"] != null || Request.QueryString["Weight"] != null)
            {
                FillReportData(Request.QueryString["CertificateNo"].ToString(), Request.QueryString["Weight"].ToString());
            }
            else
            {
                Response.Redirect("Reports.aspx");
            }
        }
    }
    #endregion

    #region[AllFunctions]
    private void FillReportData(string CertificateNo, string weight)
    {
        Guid ID = new Guid();
        //dt = cls.select_data_dt("Exec Proc_CertificateMaster 'GetbyId','"+ Id + "','','','','','','','','',''");
        dt = cls.select_data_dt("Proc_CertificateMaster 'GetbyCerti','" + ID + "','" + CertificateNo + "','" + weight + "','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            lblCertificateNo1.Text = dt.Rows[0]["CertificateNo"].ToString();
            lblWeight1.Text = dt.Rows[0]["Weight"].ToString();
            lblCertificateNo2.Text = dt.Rows[0]["CertificateNo"].ToString();
            lblWeight2.Text = dt.Rows[0]["Weight"].ToString();
            lblUnit.Text = dt.Rows[0]["Unit"].ToString();
            lblShapeNCut.Text = dt.Rows[0]["ShapeNCut"].ToString();
            lblDimension.Text = dt.Rows[0]["Dimension"].ToString();
            lblColor.Text = dt.Rows[0]["Color"].ToString();
            lblRI.Text = dt.Rows[0]["RI"].ToString();
            lblStoneName.Text = dt.Rows[0]["StoneName"].ToString();
            lblComments.Text = dt.Rows[0]["Comments"].ToString();
            imgCertificatePhoto.ImageUrl = "../App_Content/Picture/Certificate/actual/" + Convert.ToString(dt.Rows[0]["Image"]);
            lblVariety.Text = dt.Rows[0]["Variety"].ToString();
            lblOrigin.Text = dt.Rows[0]["Origin"].ToString();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Certificate No. or Weight Invalid');window.location='Reports.aspx';", true);
        }
    }
    #endregion

    #region[AllEvents]
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("Reports.aspx");
    }
    #endregion
}