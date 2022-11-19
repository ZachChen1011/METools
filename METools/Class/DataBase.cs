using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METools
{
    class DataBase
    {
        //string cs_ILX_oven = "Server=wux-Prod01;Database=ILX_oven;User Id=Oven_data;Password=Oven_data";
        string cs_ILX_oven = ConfigurationManager.AppSettings["ConnectionString_ILX_oven"];
        public DataBase()
        {
            GlobalParams.conString = cs_ILX_oven;
        }
        public DataTable GetTable(string sqlcmd)
        {
            DataTable dt = null;
            //SqlConnection conn = new SqlConnection(cs_ILX_oven);
            using (SqlConnection sqlcon = new SqlConnection(GlobalParams.conString))
            {
                SqlCommand cmd = new SqlCommand(sqlcmd, sqlcon);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);
                //x = dt.Rows[0]["DescriptionInfo"].ToString();
            }
            return dt;
        }
    }
}
