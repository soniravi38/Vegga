using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AddMenuMaster : System.Web.UI.Page
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
            if (Request.QueryString["id"] != null)
            {
                lblHeading.Text = "Update Menu";
                btnSubmit.Text = "Update";
                btnDelete.Visible = true;
                FillData();
            }
            else
            {
                lblHeading.Text = "Add Menu";
                btnSubmit.Text = "Add";
                btnDelete.Visible = false;
            }

        }
    }
    #endregion

    #region [all-fuctions]
    
    private void FillData()
    {
        dt = cls.select_data_dt("Exec Proc_MenuMaster 'Get','" + Request.QueryString["id"] + "','','',''");
        if (dt.Rows.Count > 0)
        {
            txtMenuName.Text = dt.Rows[0]["Menu"].ToString();
            txtMenuLink.Text = dt.Rows[0]["href"].ToString();
            txtPosition.Text= dt.Rows[0]["position"].ToString();
        }
    }
    private void clear()
    {
        txtMenuName.Text = "";
        txtMenuLink.Text = "";
        txtPosition.Text = "";
    }
    #endregion

    #region [All-Events]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            #region [insert]
            Int32 intresult = 0;
            Guid ID = new Guid();
            intresult = cls.insert_data("Exec Proc_MenuMaster 'Insert','" + ID + "','" + txtMenuName.Text + "','"+ txtMenuLink.Text + "','"+Convert.ToInt32(txtPosition.Text)+"'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Inserted successfully.');window.location='ListMenuMaster.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('Oops! something went wrong')</script>");
                clear();
            }
            #endregion
        }
        else
        {
            #region [update]
            Int32 intresult = 0;
            intresult = cls.insert_data("Exec Proc_MenuMaster 'Update','" + Request.QueryString["id"] + "','" + txtMenuName.Text + "','" + txtMenuLink.Text + "','" + Convert.ToInt32(txtPosition.Text) + "'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='ListMenuMaster.aspx';", true);
            }
            else
            {
                Response.Write("<script>alert('Oops! something went wrong')</script>");
                clear();
            }
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
            dt = cls.select_data_dt("Proc_MenuMaster 'IsDelete','" + Request.QueryString["id"] + "','','',''");
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Deleted successfully.');window.location='ListMenuMaster.aspx';", true);
        }
        catch
        {
            Function.MessageBox("Sorry. Something Went Wrong !");
        }
    }
    #endregion
}