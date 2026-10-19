using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AddMainImages : System.Web.UI.Page
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
                lblHeading.Text = "Update Main Images";
                btnSubmit.Text = "Update";
                btnDelete.Visible = true;
                FillData();
            }
            else
            {
                lblHeading.Text = "Add Main Images";
                btnSubmit.Text = "Add";
                btnDelete.Visible = false;
            }

        }
    }
    #endregion

    #region [all-fuctions]
    private string UploadMainSlider()
    {
        if (fuPicture.HasFile == true)
        {
            if (fuPicture.PostedFile.FileName != "")
            {
                string mpath = Server.MapPath("../App_Content/Picture/MainImages/medium/");
                string spath = Server.MapPath("../App_Content/Picture/MainImages/small/");
                string opath = Server.MapPath("../App_Content/Picture/MainImages/actual/");
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
        dt = cls.select_data_dt("Exec Proc_MainImages 'Get','" + Request.QueryString["id"] + "','','',''");
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
            string MainSlider = UploadMainSlider();
            intresult = cls.insert_data("Exec Proc_MainImages 'Insert','" + ID + "','" + MainSlider + "','"+txtTitle.Text+"','"+txtLink.Text+"'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Inserted successfully.');window.location='ListMainImages.aspx';", true);
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
            string MainSlider = UploadMainSlider();
            intresult = cls.insert_data("Exec Proc_MainImages 'Update','" + Request.QueryString["id"] + "','" + MainSlider + "','"+txtTitle.Text+"','"+txtLink.Text+"'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='ListMainImages.aspx';", true);
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
            dt = cls.select_data_dt("Proc_MainImages 'IsDelete','" + Request.QueryString["id"] + "','','',''");
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Deleted successfully.');window.location='ListMainImages.aspx';", true);
        }
        catch
        {
            Function.MessageBox("Sorry. Something Went Wrong !");
        }
    }
    #endregion
}