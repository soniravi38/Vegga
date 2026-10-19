using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Class1
    {
        public string connstr()
        {
            string str="";
            try
                
            {
                str = DAL.Properties.Settings.Default.ShoppingConnectionString;
            }
            catch (Exception ex)
            {
              str=ex.ToString();     
            }
            
            return str;
            // TODO: Add constructor logic here
            
        }
    }

}
