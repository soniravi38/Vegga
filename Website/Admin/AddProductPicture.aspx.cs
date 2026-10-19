using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AddProductPicture : System.Web.UI.Page
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
                lblHeading.Text = "Update Product Picture";
                btnSubmit.Text = "Update";
                btnDelete.Visible = true;
                FillData();
            }
            else
            {
                lblHeading.Text = "Add Product Picture";
                btnSubmit.Text = "Add";
                btnDelete.Visible = false;
            }

        }
    }
    #endregion

    #region [all-fuctions]
    private string UploadPicture()
    {
        if (fuPicture.HasFile == true)
        {
            if (fuPicture.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/ProductPicture/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/ProductPicture/medium/");
                string spath = Server.MapPath("../App_Content/Picture/ProductPicture/small/");
                string Extension = System.IO.Path.GetExtension(fuPicture.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuPicture.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuPicture.PostedFile.SaveAs(fullpath);
                    objImageResize.FixedSize(FileName, opath + FileName, spath + FileName, 50, 50);
                    return FileName;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Key", "alert('Please select valid image. !');", true);
                }
            }
        }
        return " ";
    }

    private void FillData()
    {
        dt = cls.select_data_dt("Exec Proc_ProductPictureMaster 'Get','" + Request.QueryString["id"] + "','" + Request.QueryString["id"] + "',''");
        if (dt.Rows.Count > 0)
        {
            ddlProduct.SelectedValue= dt.Rows[0]["ProductID"].ToString();
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
            string picture = UploadPicture();
            intresult = cls.insert_data("Exec Proc_ProductPictureMaster 'Insert','" + ID + "','" + Guid.Parse(ddlProduct.SelectedValue) + "','"+ picture + "'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Inserted successfully.');window.location='ListProductPicture.aspx';", true);
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
            string picture = UploadPicture();
            intresult = cls.insert_data("Exec Proc_ProductPictureMaster 'Update','" + Request.QueryString["id"] + "','" + Guid.Parse(ddlProduct.SelectedValue) + "','" + picture + "'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='ListProductPicture.aspx';", true);
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
            dt = cls.select_data_dt("Proc_ProductPictureMaster 'IsDelete','" + Request.QueryString["id"] + "','" + Request.QueryString["id"] + "',''");
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Deleted successfully.');window.location='ListProductPicture.aspx';", true);
        }
        catch
        {
            Function.MessageBox("Sorry. Something Went Wrong !");
        }
    }
    #endregion
}