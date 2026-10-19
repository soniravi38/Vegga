using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AddProductDescription : System.Web.UI.Page
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
            FillProduct();
            if (Request.QueryString["id"] != null)
            {
                lblHeading.Text = "Update Product Description";
                btnSubmit.Text = "Update";
                btnDelete.Visible = true;
                FillData();
            }
            else
            {
                lblHeading.Text = "Add Product Description";
                btnSubmit.Text = "Add";
                btnDelete.Visible = false;
            }

        }
    }
    #endregion

    #region [all-fuctions]
    private void FillData()
    {
        dt = cls.select_data_dt("Exec Proc_ProductDescriptionMaster 'Get','" + Request.QueryString["id"] + "','" + Request.QueryString["id"] + "','',''");
        if (dt.Rows.Count > 0)
        {
            ddlProduct.SelectedValue= dt.Rows[0]["ProductID"].ToString();
            txtShortDescription.Text = dt.Rows[0]["ShortDescription"].ToString();
            txtFullDescription.Text = dt.Rows[0]["FullDescription"].ToString();
        }
    }
    private void FillProduct()
    {
        DataTable dt = new DataTable();
        Guid ID = new Guid();
        dt = cls.select_data_dt("Exec Proc_ProductMaster 'GetAllForDDL','"+ ID + "','" + ID + "','',''");
        ddlProduct.DataSource = dt;
        ddlProduct.DataValueField = "id";
        ddlProduct.DataTextField = "name";
        ddlProduct.DataBind();
        ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));
    }
    private void clear()
    {
        txtFullDescription.Text = "";
        txtShortDescription.Text = "";
        ddlProduct.SelectedIndex = 0;
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
            intresult = cls.insert_data("Exec Proc_ProductDescriptionMaster 'Insert','" + ID + "','" + Guid.Parse(ddlProduct.SelectedValue) + "','"+ txtShortDescription.Text+"','"+txtFullDescription.Text+"'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Inserted successfully.');window.location='ListProductDescription.aspx';", true);
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
            intresult = cls.insert_data("Exec Proc_ProductDescriptionMaster 'Update','" + Request.QueryString["id"] + "','" + Guid.Parse(ddlProduct.SelectedValue) + "','" + txtShortDescription.Text + "','" + txtFullDescription.Text + "'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='ListProductDescription.aspx';", true);
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
            dt = cls.select_data_dt("Proc_ProductDescriptionMaster 'IsDelete','" + Request.QueryString["id"] + "','" + Request.QueryString["id"] + "','',''");
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Deleted successfully.');window.location='ListProductDescription.aspx';", true);
        }
        catch
        {
            Function.MessageBox("Sorry. Something Went Wrong !");
        }
    }
    #endregion
}