using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.IO;
using System.Web;
using System.Data;


public static class SMS
{
  
    static string[] arrTemplate = new string[] 
    {
        "Zero",
        "Your current balance is @v0@. Thanks",//1
        "Your Number @v0@ is successfully recharged with amount @v1@. TxID is @v2@. Thanks",//2
        "Recharge amount @v1@ for number @v0@ is failed. TxID is @v2@. Thanks",//3
        "Recharge amount @v1@ for number @v0@ is pending. TxID is @v2@. Thanks",//4
        "You have successfully transfer amount @v1@ to number @v0@. Thanks",//5
        "Your mobile no successfully changed. New mobile no is @v0@. Thanks",//6
        "Status of TxID @v0@ is @v1@ Thanks.",//7
        "Dear Member, Last recharges are @v0@. Thanks",//8--Done
        "welcome in Yashika Digital, your login id @v0@, password @v1@",//9
        //"Dear @v0@, Welcome to Yashika Digital, You have registered successfully, Now you can login.",//9
        "You have successfully credit Rs. @v0@, Now your total amount is Rs. @v1@. Thanks",//10
        "Dear @v0@, Welcome to Yashika Digital, Your Student Registration successfully done, Login with userid:@v1@ and password:@v2@.",//11    
        "Dear @v0@, Welcome to Yashika Digital, Your password recover successfully, Login with user-id:@v1@ and password @v2@. Thanks",//12
        "You have a new fund request of Rs. @v0@ from @v1@. Thanks",//13
        "Dear @v0@, Welcome to the Our Company, Your Id : @v1@, Password : @v2@. Thanks",//14
        "You have successfully credit Rs. @v1@, Now your total amount is Rs. @v0@. Thanks", //15
        "Dear Customer, Your Number @v0@ is successfully recharged with amount @v1@, TxID is @v2@, Current Bal @v3@. Thanks", //16
        "Invalid Request, Please try again.", //17
        "System Error, Please try again later.", //18
        "Your account has been debited with amount @v1@ by @v0@. Thanks",//19
        "You have successfully Debit with Rs. @v0@, Now your total amount is Rs. @v1@. Thanks",//20
        "Dear @v0@ , Your one time password is : @v1@",//21
        "Hello @v0@, I am using Yashika Digital Join to rechage fast and smoothly. Thanks by @v1@", //22
        "Congratulation! Your friend @v0@ successfully joined us. You are rewarded with @v1@ points.", //23
        "You have successfully credit Rs. @v0@ for redeem  @v1@ Points.", //24
        "Dear @v0@, Recahrge of Rs @v1@ on @v2@ has been refunded. Your current balance is @v3@.", //25
        "Dear @v0@ , Your password is : @v1@",//26
        "You have successfully  added in your wallet.Your Current EWallet Balance  is Rs. @v1@. Thanks", //27
        "You have successfully  successfully deducted Rs. @v0@, Now Your Current EWallet Balance  is Rs. @v1@. Thanks", //28
        "Dear @v0@ , your fund request for amount @v1@ has been approved. Thanks ", //29
        "You have successfully Sending Force Success Request and Your amount is @v0@. Thanks", //30
        "You have successfully Sending Force Failed Request and Your amount is @v0@. Thanks", //31
        "Dear Customer, Rs. @v1@ has been successfully added in your wallet through Payment Gateway.", //32
        "Dear @v0@, Mobile No. @v1@ is recharged with Amount @v2@. TxID is @v3@. Thanks", //33
        "Dear @v0@, Welcome to Yashika Digital Your Id: @v1@, Password : @v2@. www.YashikaDigital.in  Thanks",//34
        
    };


    public static void SendWithVar(string Mobile, int Template, string[] ValueArray, int MsrNo)
    {
        try
        {
            
            //cls_connection cls = new cls_connection();
            //int ApiID = cls.select_data_scalar_int("select SMSAPI from tblMLM_MemberMaster where MsrNo=" + MsrNo);
            //cls.insert_data("exec ProcSMS_updateCount '" + Mobile + "'");
            //HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //WebClient client = new WebClient();
            //string smsMessage = GetString(Template, ValueArray);
            //string baseurl = get_SMSBaseURL(Mobile, smsMessage, ApiID,"T");
            ////string baseurl = "http://sms.click4bulksms.in/sendsms?uname=siwtindia&pwd=siwt@india&senderid=SIWTIN&to=" + Mobile + "&msg=" + smsMessage + "&route=T";
            //Stream data = client.OpenRead(baseurl);
            //StreamReader reader = new StreamReader(data);
            //string s = reader.ReadToEnd();
            //data.Close();
            //reader.Close();
        }
        catch (Exception ex)
        {

        }
    }



    public static void Send(string Mobile, string smsMessage, int MsrNo)
    {
        try
        {
            cls_connection cls = new cls_connection();
            int ApiID = cls.select_data_scalar_int("select SMSAPI from tblMLM_MemberMaster where MsrNo=" + MsrNo);
            cls.insert_data("exec ProcSMS_updateCount '" + Mobile + "'");
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            WebClient client = new WebClient();
            string baseurl = get_SMSBaseURL(Mobile, smsMessage, ApiID,"T");
            // string baseurl = "http://sms.click4bulksms.in/sendsms?uname=aaracomm&pwd=aarvcom123&senderid=AARAVC&to=" + Mobile + "&msg=" + smsMessage + "&route=T";
            Stream data = client.OpenRead(baseurl);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();
        }
        catch (Exception ex)
        {

        }
    }

    public static string GetString(int Template, string[] ValueArray)
    {
        string fileData = arrTemplate[Template];
        if ((ValueArray == null))
        {
            fileData = HttpUtility.UrlEncode(fileData);
            return fileData;
        }
        else
        {
            for (int i = ValueArray.GetLowerBound(0); i <= ValueArray.GetUpperBound(0); i++)
            {
                fileData = fileData.Replace("@v" + i.ToString() + "@", (string)ValueArray[i]);
            }
            fileData = HttpUtility.UrlEncode(fileData);
            return fileData;
        }
    }


    public static string get_SMSBaseURL(string Mobile, string smsMessage, int ApiID, string Route)
    {
        cls_connection cls = new cls_connection();
        DataTable dtAPI = new DataTable();
        
        dtAPI = cls.select_data_dt("Proc_Recharge_SMSApi 'getDataById',"+ApiID+"");
       string str = "";
       str = dtAPI.Rows[0]["URL"].ToString() + dtAPI.Rows[0]["prm1"].ToString() + "=" + dtAPI.Rows[0]["prm1val"].ToString() + "&";
       if (dtAPI.Rows[0]["prm2"].ToString() != "" && dtAPI.Rows[0]["prm2val"].ToString() != "")
       {
           str = str + dtAPI.Rows[0]["prm2"].ToString() + "=" + dtAPI.Rows[0]["prm2val"].ToString() + "&";
       }
       if (dtAPI.Rows[0]["prm3"].ToString() != "" && dtAPI.Rows[0]["prm3val"].ToString() != "")
       {
           str = str + dtAPI.Rows[0]["prm3"].ToString() + "=" + dtAPI.Rows[0]["prm3val"].ToString() + "&";
       }
       if (dtAPI.Rows[0]["prm4"].ToString() != "" && dtAPI.Rows[0]["prm4val"].ToString() != "")
       {
           str = str + dtAPI.Rows[0]["prm4"].ToString() + "=" + dtAPI.Rows[0]["prm4val"].ToString() + "&";
       }
       if (dtAPI.Rows[0]["prm5"].ToString() != "" && dtAPI.Rows[0]["prm5val"].ToString() != "")
       {
           str = str + dtAPI.Rows[0]["prm5"].ToString() + "=" + dtAPI.Rows[0]["prm5val"].ToString() + "&";
       }
       if (dtAPI.Rows[0]["prm6"].ToString() != "")
       {
           str = str + dtAPI.Rows[0]["prm6"].ToString() + "=" + Mobile + "&";
       }
       if (dtAPI.Rows[0]["prm7"].ToString() != "")
       {
           str = str + dtAPI.Rows[0]["prm7"].ToString() + "=" + smsMessage + "&";
       }
       //if (dtAPI.Rows[0]["prm8"].ToString() != "")
       //{
       //    str = str + dtAPI.Rows[0]["prm8"].ToString();
       //}
       str = str + "route=" + Route;
       //if (dtAPI.Rows[0]["prm9"].ToString() != "" && dtAPI.Rows[0]["prm9val"].ToString() != "")
       //{
       //    str = str + dtAPI.Rows[0]["prm9"].ToString() + "=" + dtAPI.Rows[0]["prm9val"].ToString() + "&";
       //}
       //if (dtAPI.Rows[0]["prm10"].ToString() != "" && dtAPI.Rows[0]["prm10val"].ToString() != "")
       //{
       //    str = str + dtAPI.Rows[0]["prm10"].ToString() + "=" + dtAPI.Rows[0]["prm10val"].ToString() + "&";
       //}
        return str;
    }
}