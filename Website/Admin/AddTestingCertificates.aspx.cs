using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_AddTestingCertificates : System.Web.UI.Page
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
                lblHeading.Text = "Update Testing Certificates";
                btnSubmit.Text = "Update";
                btnDelete.Visible = true;
                FillData();
            }
            else
            {
                lblHeading.Text = "Add Testing Certificates";
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
                string opath = Server.MapPath("../App_Content/Picture/Certificate/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/Certificate/medium/");
                string spath = Server.MapPath("../App_Content/Picture/Certificate/small/");
                string Extension = System.IO.Path.GetExtension(fuPicture.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = txtCertificateNo.Text.ToString() + Extension.ToString();
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
        dt = cls.select_data_dt("Exec Proc_CertificateMaster 'GetbyId','" + Request.QueryString["id"] + "','','','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            txtCertificateNo.Text = dt.Rows[0]["CertificateNo"].ToString();
            txtWeight.Text = dt.Rows[0]["Weight"].ToString();
            txtUnit.Text = dt.Rows[0]["Unit"].ToString();
            txtShapeNCut.Text = dt.Rows[0]["ShapeNCut"].ToString();
            txtDimension.Text = dt.Rows[0]["Dimension"].ToString();
            txtColor.Text = dt.Rows[0]["Color"].ToString();
            txtRI.Text = dt.Rows[0]["RI"].ToString();
            txtStoneName.Text = dt.Rows[0]["StoneName"].ToString();
            txtComments.Text = dt.Rows[0]["Comments"].ToString();
            txtVariety.Text = dt.Rows[0]["Variety"].ToString();
            txtOrigin.Text = dt.Rows[0]["Origin"].ToString();
        }
    }
    private void clear()
    {
        txtCertificateNo.Text = "";
        txtWeight.Text = "";
        txtUnit.Text = "";
        txtShapeNCut.Text = "";
        txtDimension.Text = "";
        txtColor.Text = "";
        txtRI.Text = "";
        txtStoneName.Text = "";
        txtComments.Text = "";
        txtVariety.Text = "";
        txtOrigin.Text = "";

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
            string CertificatePic = UploadPicture();
            intresult = cls.insert_data("Exec Proc_CertificateMaster 'Insert','" + ID + "','" + txtCertificateNo.Text + "','"+ txtWeight.Text + "','"+ txtUnit.Text+"','"+ txtShapeNCut.Text+ "','"+ txtDimension.Text+ "','"+ txtColor.Text+ "','"+ txtRI.Text+ "','"+ txtStoneName.Text+ "','"+ txtComments.Text+ "','"+ CertificatePic + "','" + txtVariety.Text + "','" + txtOrigin.Text + "'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Inserted successfully.');window.location='ListTestingCertificates.aspx';", true);
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
            string CertificatePic = UploadPicture();
            intresult = cls.insert_data("Exec Proc_CertificateMaster 'Update','" + Request.QueryString["id"] + "','" + txtCertificateNo.Text + "','" + txtWeight.Text + "','" + txtUnit.Text + "','" + txtShapeNCut.Text + "','" + txtDimension.Text + "','" + txtColor.Text + "','" + txtRI.Text + "','" + txtStoneName.Text + "','" + txtComments.Text + "','"+ CertificatePic + "','" + txtVariety.Text + "','" + txtOrigin.Text + "'");
            if (intresult > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Updated successfully.');window.location='ListTestingCertificates.aspx';", true);
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
            dt = cls.select_data_dt("Proc_CertificateMaster 'IsDelete','" + Request.QueryString["id"] + "','','','','','','','','',''");
            Page.ClientScript.RegisterStartupScript(this.GetType(), Guid.NewGuid().ToString(), "alert('Data Deleted successfully.');window.location='ListTestingCertificates.aspx';", true);
        }
        catch
        {
            Function.MessageBox("Sorry. Something Went Wrong !");
        }
    }
    #endregion
}