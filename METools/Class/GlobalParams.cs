using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METools
{
    class GlobalParams
    {
        private static string EmployeeID = "";

        public static string employeeID
        {
            get { return EmployeeID; }
            set { EmployeeID = value; }
        }
        private static string EmployeeName="";

        public static string employeeName
        {
            get { return EmployeeName; }
            set { EmployeeName = value; }
        }


        private static string Password = "";

        public static string password
        {
            get { return Password; }
            set { Password = value; }
        }


        private static string ErrorMsg = "None";

        public static string errorMsg
        {
            get { return ErrorMsg; }
            set { ErrorMsg = value; }
        }

        private static string SqlCmdString;

        public static string sqlCmdString
        {
            get { return SqlCmdString; }
            set { SqlCmdString = value; }
        }
        private static string ConnectString;

        public static string conString
        {
            get { return ConnectString; }
            set { ConnectString = value; }
        }

        private static string EmployeePicPath;

        public static string employeePicPath
        {
            get { return EmployeePicPath; }
            set { EmployeePicPath = value; }
        }
        public static bool ClearParams()
        {
            try
            {
                GlobalParams.employeeID = "";
                GlobalParams.employeeName = "";
                GlobalParams.employeePicPath = "";
                GlobalParams.password = "";
                GlobalParams.errorMsg = "";
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool CopyFileTo(string filePath,string ToPath)
        {
            try
            {
                FileInfo file = new FileInfo(filePath);
                string newFileName = file.Name;
                file.CopyTo(ToPath + @"\" + newFileName, true);
                return true;
            }
            catch(Exception ex)
            {
                GlobalParams.errorMsg = ex.ToString();
                return false;
            }
        }
    }
}
