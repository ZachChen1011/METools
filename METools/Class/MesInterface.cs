using MESdll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace METools
{
    class MesInterface
    {
        public static string errMsgs = "";
        public static MESdll.MESMain mes = new MESMain();
        string errMsg;
        public bool InitMes(string path, string resource)
        {
            if (File.Exists(path))
            {
                bool result = mes.Init(path, resource);
                return result;
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("config文件不存在，请检查！");
                return false;
            }
        }
        public bool VerifyEmployeeID(string user, string psd)
        {
            return mes.VerifyEmployeeName(user, psd, ref errMsg);
        }
    }
}
