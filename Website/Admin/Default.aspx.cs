using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Root_Admin_Default : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    #endregion

    #region [PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {

        if(!IsPostBack)
        {
            fillCaptcha();
            GetCompanyInfo();
        }
    }
    #endregion

    #region [AllFunctions]
    private void fillCaptcha()
    {
        string randomStr = "";
        Random Rand = new Random();
        for (int x = 0; x < 5; x++)
        {
            randomStr += Convert.ToInt32(Rand.Next(0, 9));
        }
        ViewState["Captcha"] = randomStr;
        Image1Captcha.ImageUrl = "captcha.aspx?Str=" + randomStr;
    }
    private void GetCompanyInfo()
    {
        dt = cls.select_data_dt("Exec Proc_CompanyMaster 'GetAll','','','','','','','','','','','','','','','','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgCompanyLogo.ImageUrl = "../App_Content/Picture/CompanyLogo/actual/" + Convert.ToString(dt.Rows[0]["CompanyLogo"]);
            LogoIcon.Href = "../App_Content/Picture/CompanyShortLogo/actual/" + Convert.ToString(dt.Rows[0]["CompanyShortLogo"]);
            title.Text = "Admin Login - " + dt.Rows[0]["CompanyName"].ToString();
            lblHeading.Text = "Login with Admin - " + dt.Rows[0]["CompanyName"].ToString();
        }
    }
    private void clear()
    {
        txtCaptcha.Text = "";
        txtloginid.Text = "";
        txtPassword.Text = "";
    }
    #endregion

    #region [Submit]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (this.txtCaptcha.Text != ViewState["Captcha"].ToString())
        {
            Response.Write("<script>alert('Security Code InValid. Enter Valid Security Code And Try Again.')</script>");
            return;
        }
        this.txtCaptcha.Text = "";
        if(txtloginid.Text != "" && txtPassword.Text != "")
        {
            Guid ID = new Guid();
            dt = cls.select_data_dt("Exec Proc_UserMaster 'Login','"+ ID + "','','','','" + txtloginid.Text + "','" + txtPassword.Text+"'");
            if(dt.Rows.Count>0)
            {
                Session.Add("Admin", dt);
                Session.Add("AdminUserID", dt.Rows[0]["UserID"].ToString());
                Session.Add("AdminID", (Guid)(dt.Rows[0]["id"]));
                Session.Add("AdminPicture", "../App_Content/Picture/UserMaster/actual/" + dt.Rows[0]["Picture"].ToString());
                Session.Add("AdminName", dt.Rows[0]["Name"].ToString());
                Session.Add("AdminDesignation", dt.Rows[0]["Designation"].ToString());
                Response.Redirect("Dashboard.aspx");
            }
            else
            {
                clear();
                fillCaptcha();
                Response.Write("<script>alert('Invalid Login Details')</script>");
            }
        }
    }
    #endregion

}