using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
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
    /// HomePage.xaml 的交互逻辑
    /// </summary>
    public partial class HomePage : Page
    {
        private UserDBModel userdb;
        public HomePage()
        {
            InitializeComponent();
            userdb = new UserDBModel();
            //dataGrir1.DataContext = userdb;
            this.DataContext = userdb;
        }


        public class UserModel
        {
            public UInt32 UserID { get; set; }
            public string ProductName { get; set; }//产品名称
            public string ProductLine { get; set; }//产线
            public string Location { get; set; }//位置
            public string Creater { get; set; }//创建者
            public string CreatTime { get; set; }//创建时间
            public string UpdateTime { get; set; }//更新时间
            public string RecordName { get; set; }//备案名称
            public string Alarm_Stock { get; set; }//Alarm&Stock
            public string PicPath { get; set; }//图片
            public string Record { get; set; }//备案
            public string Quotation { get; set; }//报价单
            public string Comment { get; set; }//报价单
            public UserModel() { }
            public UserModel(UInt32 id,
                             string productName,
                             string productLine,
                             string location,
                             string creater,
                             string creatTime,
                             string updateTime,
                             string recordName,
                             string alarm_Stock,
                             string picPath,
                             string record,
                             string quotation,
                             string comment)
            {
                UserID = id;
                ProductName = productName;
                ProductLine = productLine;
                Location = location;
                Creater = creater;
                CreatTime = creatTime;
                UpdateTime = updateTime;
                RecordName = recordName;
                Alarm_Stock = alarm_Stock;
                PicPath = picPath;
                Record = record;
                Quotation = quotation;
                Comment = comment;
            }
        }
        public class UserModel1
        {
            public UInt32 UserID { get; set; }
            public string UserName { get; set; }
            public UInt32 UserAccount { get; set; }
            public string UserPasswd { get; set; }
            public UInt64 UserPhone { get; set; }
            public string UserEmail { get; set; }
            public string UserEmail1 { get; set; }
            public bool UserSex { get; set; }
            public UserModel1() { }
            public UserModel1(UInt32 id,
                             string name,
                             UInt32 account,
                             string passwd,
                             UInt64 phone,
                             string email,
                             string email1,
                             bool sex)
            {
                UserID = id;
                UserName = name;
                UserAccount = account;
                UserPasswd = passwd;
                UserPhone = phone;
                UserEmail = email;
                UserEmail1 = email1;
                UserSex = sex;
            }
        }
        public class UserDBModel : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged(PropertyChangedEventArgs e)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, e);
            }
            private ObservableCollection<UserModel> userdb = new ObservableCollection<UserModel>();
            public ObservableCollection<UserModel> UserDB
            {
                get { return userdb; }
                set
                {
                    userdb = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("UserDB"));
                }
            }
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            //清空数据
            userdb = new UserDBModel();
            //dataGrir1.DataContext = userdb;
            this.DataContext = userdb;
            DataBase iOMEDb = new DataBase();
            DataTable dTable = iOMEDb.GetTable("SELECT [id] as ID ,[Description] as DescriptionInfo ,[PRODUCT_TYPE] as NameInfo  ,[START_TIME] as CreateDate  ,[END_TIME] as UpdateDate ,[Info1] as Production  ,[Info2] as CNO_L_F_S ,[Info3] as CreateUser  ,[Info4] as Detail ,[Info5] as SupplierType ,[Info6] as ADDInfo ,[Info7] as Stock_Alarm ,[Info8] as PicPath  ,[Mark] as Buyer_DeclareInfo ,[COMMENT] as QuotationPath FROM[ILX_Oven].[dbo].[OMEAI_DATASETS] where Description = 'Spare Part'");
            foreach (DataRow row in dTable.Rows)
            {// row[0].ToString();
                UserModel user = new UserModel((UInt32)dTable.Rows.Count,
                                               row[2].ToString(),//产品名称
                                               row[5].ToString(),//产线
                                               row[6].ToString(),//位置
                                               row[7].ToString(),//创建者
                                               row[3].ToString(),//创建时间
                                               row[4].ToString(),//更新时间
                                               row[9].ToString(),//备案名称
                                               row[11].ToString(),//Alarm&Stock
                                               row[12].ToString(),//图片
                                               row[13].ToString(),//备案
                                               row[14].ToString(),//报价单
                                               row[8].ToString() //Comment
                                                                 );
                userdb.UserDB.Add(user);
            }
            #region Orig
            //dataGrir1.Columns.Clear();
            //如果不需要实现刷新，那么直接创建一个List<UserModel>类型的列表，作为datagrid的ItemSource也可。
            //int num = userdb.UserDB.Count + 1;
            //UserModel user = new UserModel((UInt32)num,
            //                               "test" + num.ToString(),
            //                               (UInt32)(1000000000 + num),
            //                               "passwd" + num.ToString(),
            //                               (UInt64)(10000000000 + num),
            //                               "test@" + num.ToString() + ".com",
            //                               "test@" + num.ToString() + ".com",
            //                               num % 2 == 0);
            //userdb.UserDB.Add(user);
            #endregion
        }
        private void AddData1_Click(object sender, RoutedEventArgs e)
        {
            //清空数据
            userdb = new UserDBModel();
            //dataGrir1.DataContext = userdb;
            this.DataContext = userdb;
        }
    }
}
