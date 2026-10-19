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

public partial class Web_GetInformations : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    SendSMS SendMessage = new SendSMS();
    #endregion

    #region [PagePreInit]
    protected void Page_PreInit(object sender, EventArgs e)
    {
       if(Session["ClientVerify"] != null)
        {
            Response.Redirect("ProductDescription.aspx?ProductID=" + Request.QueryString["ProductID"].ToString());
        }
    }
    #endregion

    
    #region [PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            GetHeaderImage();
            GetProductInfo(Guid.Parse(Request.QueryString["ProductID"].ToString()));
        }
    }
    #endregion

    #region[AllFunctions]
    private void GetHeaderImage()
    {
        dt = cls.select_data_dt("Exec Proc_AllImages 'GetAll','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgHeader.ImageUrl = "../App_Content/Picture/AllImages/actual/" + Convert.ToString(dt.Rows[0]["ClientInfo"]);
            imgCallUs.ImageUrl = "../App_Content/Picture/AllImages/actual/" + Convert.ToString(dt.Rows[0]["CallUs"]);
        }
    }
    private void GetProductInfo(Guid ProductID)
    {
        dt = cls.select_data_dt("Exec Proc_ProductMaster 'Get','" + ProductID + "','','',''");
        if (dt.Rows.Count > 0)
        {
            Session["ProductName"] = dt.Rows[0]["Name"].ToString();
        }
    }
    #endregion

    #region [AllEvents]
    protected void btnInfoSubmit_Click(object sender, EventArgs e)
    {
        Int32 intresult = 0;
        Guid ID = new Guid();
        intresult = cls.insert_data("Exec Proc_ListCustomers 'Insert','" + ID + "','" + txtClientName.Text + "','" + txtClientNumber.Text + "','" + txtClientEmail.Text + "','"+ Session["ProductName"] + "','" + Convert.ToString(Request.UserHostAddress) + "',''");
        if (intresult > 0)
        {
            string message = "Someone Check '" + Session["ProductName"] + "'!"+ Environment.NewLine + "Name :" + txtClientName.Text + Environment.NewLine + "Mobile : " + txtClientNumber.Text + Environment.NewLine + "Email : " + txtClientEmail.Text ;
            SendMessage.sms(message);
            Session["ClientVerify"] = "True";
            Response.Redirect("ProductDescription.aspx?ProductID=" + Request.QueryString["ProductID"].ToString());
        }
        else
        {
            Response.Write("<script>alert('Oops! something went wrong')</script>");
        }
    }
    #endregion
}