using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Common;

public partial class Admin_CompanyMaster : System.Web.UI.Page
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
            lblHeading.Text = "Company Master";
            btnSubmit.Text = "Update";
            btnDelete.Visible = false;
            FillData();
        }
    }
    #endregion

    #region [all-fuctions]
    private string uploadCompanyLogo()
    {
        if (fuCompanyLogo.HasFile == true)
        {
            if (fuCompanyLogo.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/CompanyLogo/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/CompanyLogo/medium/");
                string spath = Server.MapPath("../App_Content/Picture/CompanyLogo/small/");
                string Extension = System.IO.Path.GetExtension(fuCompanyLogo.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuCompanyLogo.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuCompanyLogo.PostedFile.SaveAs(fullpath);
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

    private string uploadCompanyShortLogo()
    {
        if (fuCompanyShortLogo.HasFile == true)
        {
            if (fuCompanyShortLogo.PostedFile.FileName != "")
            {
                string opath = Server.MapPath("../App_Content/Picture/CompanyShortLogo/actual/");
                string mpath = Server.MapPath("../App_Content/Picture/CompanyShortLogo/medium/");
                string spath = Server.MapPath("../App_Content/Picture/CompanyShortLogo/small/");
                string Extension = System.IO.Path.GetExtension(fuCompanyShortLogo.FileName).ToLower();
                if (Extension == ".jpg" || Extension == ".jpeg" || Extension == ".png" || Extension == ".gif")
                {
                    string FileName = DateTime.Now.Ticks + fuCompanyShortLogo.FileName.ToString();
                    string fullpath = Convert.ToString(opath + FileName);
                    fuCompanyShortLogo.PostedFile.SaveAs(fullpath);
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
        dt = cls.select_data_dt("Exec Proc_CompanyMaster 'GetAll','','','','','','','','','','','','','','','','','','','','','','','',''");
        if (dt.Rows.Count > 0)
        {
            txtCompanyName.Text = Convert.ToString(dt.Rows[0]["CompanyName"]);
            txtOwnerName.Text = Convert.ToString(dt.Rows[0]["OwnerName"]);
            txtGSTIN.Text = Convert.ToString(dt.Rows[0]["GSTIN"]);
            txtPAN.Text = Convert.ToString(dt.Rows[0]["PAN"]);
            txtMobile1.Text = Convert.ToString(dt.Rows[0]["Mobile1"]);
            txtMobile2.Text = Convert.ToString(dt.Rows[0]["Mobile2"]);
            txtEmail1.Text = Convert.ToString(dt.Rows[0]["Email1"]);
            txtEmail2.Text = Convert.ToString(dt.Rows[0]["Email2"]);
            txtWebsite.Text = Convert.ToString(dt.Rows[0]["Website"]);
            txtAddress.Text = Convert.ToString(dt.Rows[0]["Address"]);
            txtGoogleMapAPI.Text = Convert.ToString(dt.Rows[0]["GoogleMapApi"]);
            txtWhatsappMobile.Text = Convert.ToString(dt.Rows[0]["WhatsappMobile"]);
            txtSMSMobile.Text = Convert.ToString(dt.Rows[0]["SMSMobile"]);
            txtSMSApi.Text = Convert.ToString(dt.Rows[0]["SMSApi"]);
            txtFacebook.Text = Convert.ToString(dt.Rows[0]["Facebook"]);
            txtInstagram.Text = Convert.ToString(dt.Rows[0]["Instagram"]);
            txtTwitter.Text = Convert.ToString(dt.Rows[0]["Twitter"]);
            txtGooglePlus.Text = Convert.ToString(dt.Rows[0]["GooglePlus"]);
            txtLinkdin.Text = Convert.ToString(dt.Rows[0]["Linkdin"]);
            txtFooter.Text = Convert.ToString(dt.Rows[0]["FooterText"]);
            txtPhone1.Text = Convert.ToString(dt.Rows[0]["Phone1"]);
            txtPhone2.Text = Convert.ToString(dt.Rows[0]["Phone2"]);
        }
    }
    private void clear()
    {
        txtAddress.Text = "";
        txtCompanyName.Text = "";
        txtEmail1.Text = "";
        txtEmail2.Text = "";
        txtFacebook.Text = "";
        txtFooter.Text = "";
        txtGoogleMapAPI.Text = "";
        txtGooglePlus.Text = "";
        txtGSTIN.Text = "";
        txtInstagram.Text = "";
        txtLinkdin.Text = "";
        txtMobile1.Text = "";
        txtMobile2.Text = "";
        txtOwnerName.Text = "";
        txtPAN.Text = "";
        txtSMSApi.Text = "";
        txtSMSMobile.Text = "";
        txtTwitter.Text = "";
        txtWebsite.Text = "";
        txtWhatsappMobile.Text = "";
        txtPhone1.Text = "";
        txtPhone2.Text = "";
    }
    #endregion

    #region [All-Events]
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        #region [update]
        Int32 intresult = 0;
        string CompanyLogo = uploadCompanyLogo();
        string CompanyShortLogo = uploadCompanyShortLogo();
        intresult = cls.insert_data("Exec Proc_CompanyMaster 'Update','" + txtCompanyName.Text+"','"+txtOwnerName.Text+"','"+ CompanyLogo + "','"+ CompanyShortLogo + "','"+txtGSTIN.Text+"','"+txtPAN.Text+"','"+txtPhone1.Text+ "','" + txtPhone2.Text + "','" + txtMobile1.Text+"','"+txtMobile2.Text+"','"+txtEmail1.Text+"','"+txtEmail2.Text+"','"+txtWebsite.Text+"','"+txtAddress.Text+"','"+txtGoogleMapAPI.Text+"','"+txtWhatsappMobile.Text+"','"+txtSMSMobile.Text+"','"+txtSMSApi.Text+"','"+txtFacebook.Text+"','"+txtInstagram.Text+"','"+txtTwitter.Text+"','"+txtGooglePlus.Text+"','"+txtLinkdin.Text+"','"+txtFooter.Text+"'");
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
    #endregion
}