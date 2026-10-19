using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Net;
using System.Collections.Specialized;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

/// <summary>
/// Summary description for SendSMS
/// </summary>
public class SendSMS
{
    public SendSMS()
    {

    }

    public void sms(string message)
    {
        try
        {
            DataTable dt = new DataTable();
            cls_connection cls = new cls_connection();
            dt = cls.select_data_dt("Exec Proc_CompanyMaster 'GetAll','','','','','','','','','','','','','','','','','','','','','',''");
            string api = dt.Rows[0]["SMSApi"].ToString();
            string Mobile = "91" + dt.Rows[0]["SMSMobile"].ToString();
            using (var wb = new WebClient())
            {
                byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                {
                {"apikey" , api},
                {"numbers" , Mobile},
                {"message" , message},
                {"sender" , "TXTLCL"}
                });
                string result = System.Text.Encoding.UTF8.GetString(response);
                var sms = (JObject)JsonConvert.DeserializeObject(result);
                Int32 intresult = 0;
                if (sms["balance"].Value<string>() != null)
                {
                    intresult = cls.insert_data("Exec Proc_sms 'Update','" + sms["balance"].Value<string>() + "'");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}