using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace METools.Pages
{
    /// <summary>
    /// LoginPage.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPage : Page
    {
        MesInterface mesInterface = new MesInterface();
        public LoginPage()
        {
            InitializeComponent();
        }
        LoginWindow loginWindow { get => Application.Current.MainWindow as LoginWindow; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //loginWindow.mainFrame.Navigate(new Uri("/Pages/dashboard.xaml", UriKind.RelativeOrAbsolute));
            //MainWindow mainWindow = new MainWindow();
            //mainWindow.Show();
            //loginWindow.Close();
            GlobalParams.ClearParams();
            if (string.IsNullOrEmpty(employeeBox.email.Text.Trim()) || string.IsNullOrEmpty(passBox.passbox.Password.Trim()))
            {
                MessageBox.Show("Employee ID or Password is Null,Please input the correct value.", "Error"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                GlobalParams.employeeID = employeeBox.email.Text.Trim();
                GlobalParams.password = passBox.passbox.Password.Trim();
                DirectoryInfo folder = new DirectoryInfo(@"C:\Fintest\MEP");
                foreach (FileInfo file in folder.GetFiles("*.JPG"))
                {
                    if (file.Name.Contains(GlobalParams.employeeID))
                    {
                        GlobalParams.employeeName = file.Name.Split(' ')[1].Split('.')[0];
                        GlobalParams.employeePicPath = file.FullName;
                        break;
                    }
                }
                if (string.IsNullOrEmpty(GlobalParams.employeePicPath))
                {
                    DirectoryInfo folderNet = new DirectoryInfo(@"\\wux-hr03\Employee_Picture");
                    foreach (FileInfo netFile in folderNet.GetFiles("*.JPG"))
                    {
                        if (netFile.Name.Contains(GlobalParams.employeeID))
                        {//10000216
                            GlobalParams.CopyFileTo(netFile.FullName, @"C:\Fintest\MEP");
                            GlobalParams.employeeName = netFile.Name.Split(' ')[1].Split('.')[0];
                            GlobalParams.employeePicPath = @"C:\Fintest\MEP" + @"\" + netFile.Name;
                        }
                    }
                }
                if (mesInterface.VerifyEmployeeID(GlobalParams.employeeID, GlobalParams.password))
                {

                    Thread.Sleep(100);
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    loginWindow.Close();
                }
                // mainWindow.mainFrame.Navigate(new Uri("/pages/dashboard.xaml", UriKind.RelativeOrAbsolute));
                else
                    MessageBox.Show("Login Fail .", "Error"
                    , MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("explorer.exe", "http://cn-csapp.chn.ii-vi.net/imes2017/IMESLogin.aspx");
        }
    }
}
