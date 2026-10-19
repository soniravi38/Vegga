using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

public partial class Software_MasterPage : System.Web.UI.MasterPage
{
    #region [properties]
    DataTable dt = new DataTable();
    DataTable dtUp = new DataTable();
    cls_connection cls = new cls_connection();
    #endregion

    #region [PageLoad]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["AdminUserID"] != null && Session["AdminID"] != null && Session["AdminPicture"] != null && Session["AdminName"] != null && Session["AdminDesignation"] != null)
            {
                GetCompanyInfo();
                GetUserSessions();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
    #endregion
    #region [AllFunctions]
    private void GetCompanyInfo()
    {
        dt = cls.select_data_dt("Exec Proc_CompanyMaster 'GetAll','','','','','','','','','','','','','','','','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            imgCompanyLogo.ImageUrl = "../App_Content/Picture/CompanyLogo/actual/" + Convert.ToString(dt.Rows[0]["CompanyLogo"]);
            imgCompanyShortLogo.ImageUrl = "../App_Content/Picture/CompanyShortLogo/actual/" + Convert.ToString(dt.Rows[0]["CompanyShortLogo"]);
            LogoIcon.Href = "../App_Content/Picture/CompanyShortLogo/actual/" + Convert.ToString(dt.Rows[0]["CompanyShortLogo"]);
            title.Text = "Admin Panel - " + dt.Rows[0]["CompanyName"].ToString();
            lblFooter.Text= dt.Rows[0]["FooterText"].ToString();
        }
    }

    private void GetUserSessions()
    {
        lblAdminName1.Text = Session["AdminName"].ToString();
        lblAdminName2.Text = Session["AdminName"].ToString();
        lblAdminName3.Text = Session["AdminName"].ToString();
        lblAdminDesignation.Text = Session["AdminDesignation"].ToString();
        imgAdminPicture1.ImageUrl = Session["AdminPicture"].ToString();
        imgAdminPicture2.ImageUrl = Session["AdminPicture"].ToString();
        imgAdminPicture3.ImageUrl = Session["AdminPicture"].ToString();
    }
    #endregion
    #region [AllEvents]
    protected void lnkbtnProfile_Click(object sender, EventArgs e)
    {
        Response.Redirect("AddUserMaster.aspx?id="+Session["AdminID"].ToString());
    }

    protected void lnkbtnLogOut_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("Default.aspx");
    }
    #endregion

}
