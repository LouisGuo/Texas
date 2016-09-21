using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
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
using System.Windows.Threading;
using TexasWpfApplication.Common;

namespace TexasWpfApplication.Pages
{
    /// <summary>
    /// LoginPlayer.xaml 的交互逻辑
    /// </summary>
    public partial class LoginPlayer : Window
    {
        private MyService myService = new MyService();

        public LoginPlayer()
        {
            InitializeComponent();
            try
            {
                string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();

                int playerID = myService.GetAdministrator().GetPlayerIDForPlayerLogin(ip);


                if (playerID > 0 && playerID < 9)
                {
                    this.ComboBoxPlayerID.SelectedIndex = playerID - 1;
                }
                else
                {
                    MessageBox.Show("计算机尚未注册，请联系管理员");
                }
            }
            catch
            {
                MessageBox.Show("请连接网络");
            }

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int playerID = this.ComboBoxPlayerID.SelectedIndex + 1;
            timer.Stop();
            new GameLive(playerID).Show();
            this.Close();
        }

        private void imageLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Login_hover.png", UriKind.Relative));
            imageLogin.Source = imagetemp;
        }

        private void imageLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Login.png", UriKind.Relative));
            imageLogin.Source = imagetemp;
        }

        private void imageClose_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Quit_hover.png", UriKind.Relative));
            imageClose.Source = imagetemp;
        }

        private void imageClose_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Quit.png", UriKind.Relative));
            imageClose.Source = imagetemp;
        }

        private void imageClose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void imageConcel_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Cance_hover.png", UriKind.Relative));
            this.imageConcel.Source = imagetemp;
        }

        private void imageConcel_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Cancel.png", UriKind.Relative));
            this.imageConcel.Source = imagetemp;
        }

        private void imageConfirm_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Login_hover.png", UriKind.Relative));
            imageConfirm.Source = imagetemp;
        }

        private void imageConfirm_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Login.png", UriKind.Relative));
            imageConfirm.Source = imagetemp;
        }

        private void imageConfirm_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ServiceAdministrator.AdministratorSoapClient serviceAdministrator = myService.GetAdministrator();
            string username = this.UserName.Text.ToString();
            string pwd = this.Password.Password.ToString();
            if (serviceAdministrator.CheckAdministrator(username, pwd))
            {
                this.grid1.Visibility = Visibility.Hidden;
                this.ComboBoxPlayerID.IsDropDownOpen = true;
                
            }
            else
            {
                MessageBox.Show("用户名不存在或密码错误");
            }
        }


        private void imageConcel_Copy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.grid1.Visibility == Visibility.Hidden)
                this.grid1.Visibility = Visibility.Visible;
            else if (this.grid1.Visibility == Visibility.Visible)
                this.grid1.Visibility = Visibility.Hidden;
            this.Password.Password = "";

        }


        private void ComboBoxPlayerID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
            int playerID = this.ComboBoxPlayerID.SelectedIndex + 1;
            bool result = myService.GetAdministrator().SetPlayerIP(playerID,ip);
            if (result)
            {
                
            }
            else
                MessageBox.Show("设置失败");
        }


        private DispatcherTimer timer = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += ChangeHeadPic;
            timer.Start();
        }

        public void ChangeHeadPic(object source, EventArgs e)
        {
            try
            {
                string pyerID = myService.GetAdministrator().HelloWorld();

            }
            catch
            {
                return;
            }

            int playerID = this.ComboBoxPlayerID.SelectedIndex + 1;
            DataSet headPicSet = myService.GetRecord().GetRecordForLive();
            if (headPicSet.Tables.Count != 0)
            {
                DataTable headPictureTable = headPicSet.Tables[0];
                string headPic = "";
                if (headPictureTable.Rows.Count != 0)
                {
                    string headPic1 = headPictureTable.Rows[0]["HeadPicture1"].ToString();
                    string headPic2 = headPictureTable.Rows[0]["HeadPicture2"].ToString();
                    string headPic3 = headPictureTable.Rows[0]["HeadPicture3"].ToString();
                    string headPic4 = headPictureTable.Rows[0]["HeadPicture4"].ToString();
                    string headPic5 = headPictureTable.Rows[0]["HeadPicture5"].ToString();
                    string headPic6 = headPictureTable.Rows[0]["HeadPicture6"].ToString();
                    string headPic7 = headPictureTable.Rows[0]["HeadPicture7"].ToString();
                    string headPic8 = headPictureTable.Rows[0]["HeadPicture8"].ToString();

                    if (playerID == 1)
                        headPic = headPic1;
                    if (playerID == 2)
                        headPic = headPic2;
                    if (playerID == 3)
                        headPic = headPic3;
                    if (playerID == 4)
                        headPic = headPic4;
                    if (playerID == 5)
                        headPic = headPic5;
                    if (playerID == 6)
                        headPic = headPic6;
                    if (playerID == 7)
                        headPic = headPic7;
                    if (playerID == 8)
                        headPic = headPic8;

                    BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/"+headPic+".png", UriKind.Relative));
                    BitmapImage headSource1 = new BitmapImage(new Uri("/Resources/Head/default.png", UriKind.Relative));

                    if(!headPic.Equals(""))
                        this.imageHead.Source = headSource;
                    else
                        this.imageHead.Source = headSource1;
                }


            }
        }

       
    }
}
