using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace METools
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            MesInterface mes = new MesInterface();
            InitializeComponent();
            this.Title = Assembly.GetExecutingAssembly().GetName().Name.ToString()+" "+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (!mes.InitMes(@"C:\FinTest\MESConfig.ini", "OMS"))
            {
                MessageBox.Show("初始化失败,MESConfig文件丢失", "Error");
                //Environment.Exit(0);
            }
            mainFrame.Navigate(new Uri("/Pages/LoginPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
