using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AddRatingMaster : System.Web.UI.Page
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
                lblHeading.Text = "Update Rating";
                btnSubmit.Text = "Update";
                btnDelete.Visible = true;
                FillData();
            }
            else
            {
                lblHeading.Text = "Add Rating";
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
                string opath = Server.MapPath("../App_Content/Picture/Rating/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/Rating/medium/");
                string spath = Server.MapPath("../App_Content/Picture/Rating/small/");
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
        dt = cls.select_data_dt("Exec Proc_RatingMaster 'Get','" + Request.QueryString["id"] + "','','',''");
        if (dt.Rows.Count > 0)
        {
            txtTitle.Text = dt.Rows[0]["title"].ToString();
            txtLink.Text = dt.Rows[0]["href"].ToString();
        }
    }
    private void clear()
    {
        txtTitle.Text = "";
        txtLink.Text = "";
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
            string Picture = UploadPicture();
            intresult = cls.insert_data("Exec Proc_RatingMaster 'Insert','" + ID + "','" + Picture + "','"+txtTitle.Text+"','"+txtLink.Text+"'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Inserted successfully.');window.location='ListRatingMaster.aspx';", true);
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
            string Picture = UploadPicture();
            intresult = cls.insert_data("Exec Proc_RatingMaster 'Update','" + Request.QueryString["id"] + "','" + Picture + "','" + txtTitle.Text + "','" + txtLink.Text + "'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='ListRatingMaster.aspx';", true);
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
            dt = cls.select_data_dt("Proc_RatingMaster 'IsDelete','" + Request.QueryString["id"] + "',''");
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Deleted successfully.');window.location='ListRatingMaster.aspx';", true);
        }
        catch
        {
            Function.MessageBox("Sorry. Something Went Wrong !");
        }
    }
    #endregion
}