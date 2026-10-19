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

public partial class Web_ContactUs : System.Web.UI.Page
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
            GetCompanyInfo();
            GetHeaderImage();
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetCompanyInfo()
    {
        dt = cls.select_data_dt("Exec Proc_CompanyMaster 'GetAll','','','','','','','','','','','','','','','','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            CompanyMap.Attributes.Add("src", dt.Rows[0]["GoogleMapApi"].ToString());
            imgCompanyLogo.ImageUrl = "../App_Content/Picture/CompanyLogo/actual/" + Convert.ToString(dt.Rows[0]["CompanyLogo"]);
            lblCompanyAddress.Text = dt.Rows[0]["Address"].ToString();
            lblFooterMobile.Text = dt.Rows[0]["Mobile1"].ToString() + ", " + dt.Rows[0]["Mobile2"].ToString();
            lblFooterPhone.Text = dt.Rows[0]["Phone1"].ToString() + ", " + dt.Rows[0]["Phone2"].ToString();
            lblFooterEmail.Text = dt.Rows[0]["email1"].ToString() + ", " + dt.Rows[0]["email2"].ToString();
        }
    }

    private void GetHeaderImage()
    {
        dt = cls.select_data_dt("Exec Proc_AllImages 'GetAll','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgHeader.ImageUrl = "../App_Content/Picture/AllImages/actual/" + Convert.ToString(dt.Rows[0]["ContactUs"]);
        }
    }
    #endregion

    #region[AllEvents]
    protected void btnQuerySubmit_Click(object sender, EventArgs e)
    {
        Int32 intresult = 0;
        Guid ID = new Guid();
        intresult = cls.insert_data("Exec Proc_ListQueries 'Insert','" + ID + "','" + txtQueryName.Text + "','" + txtQueryEmail.Text + "','" + txtQueryNumber.Text + "','" + txtQueryLocation.Text + "','" + txtQueryQuery.Text + "'");
        if (intresult > 0)
        {
            string message = "Someone send a Query!" + Environment.NewLine + "Name :" + txtQueryName.Text + Environment.NewLine + "Email : " + txtQueryEmail.Text + Environment.NewLine + "Mobile : " + txtQueryNumber.Text + Environment.NewLine + "Location : " + txtQueryLocation.Text + Environment.NewLine + "Query : " + txtQueryQuery.Text;
            SendMessage.sms(message);
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Your Query has been sent, we will Contact you shortly!');window.location='Default.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Oops! something went wrong')</script>");
        }
    }
    #endregion
}