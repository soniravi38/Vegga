using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AboutUsMaster : System.Web.UI.Page
{
    #region [properties]
    DataTable dt = new DataTable();
    cls_connection cls = new cls_connection();
    clsImageResize objImageResize = new clsImageResize();
    #endregion

    #region [pageload]
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            lblHeading.Text = "Update About Us";
            btnSubmit.Text = "Update";
            btnDelete.Visible = false;
            FillData();
        }
    }
    #endregion

    #region [all-fuctions]
    private void FillData()
    {
        dt = cls.select_data_dt("Exec Proc_AboutUs 'GetAll','',''");
        if (dt.Rows.Count > 0)
        {
            txtAboutUs.Text = dt.Rows[0]["AboutUsText"].ToString();
            txtWhyUs.Text = dt.Rows[0]["WhyUsText"].ToString();
        }
    }
    private void clear()
    {
        txtAboutUs.Text = "";
        txtWhyUs.Text = "";
    }
    #endregion

    #region [All-Events]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region [update]
        Int32 intresult = 0;
        intresult = cls.insert_data("Exec Proc_AboutUs 'Update','" + txtAboutUs.Text + "','"+txtWhyUs.Text+"'");
        if (intresult > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='Dashboard.aspx';", true);
        }
        else
        {
            Response.Write("<script>alert('Oops! something went wrong')</script>");
            clear();
        }
        #endregion
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        clear();
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {

    }
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        try
        {
            dt = cls.select_data_dt("Proc_BlogMaster 'IsDelete','" + Request.QueryString["id"] + "','','',''");
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Deleted successfully.');window.location='ListBlogMaster.aspx';", true);
        }
        catch
        {
            Function.MessageBox("Sorry. Something Went Wrong !");
        }
    }
    #endregion
}