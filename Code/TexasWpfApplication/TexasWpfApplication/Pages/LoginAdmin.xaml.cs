using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TexasWpfApplication.Common;

namespace TexasWpfApplication.Pages
{
    /// <summary>
    /// AdminMenu.xaml 的交互逻辑
    /// </summary>
    public partial class LoginAdmin : Window
    {
        private Display display = new Display();
        private MyService myService = new MyService();

        public LoginAdmin()
        {
            InitializeComponent();
        }


        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string testWebService = new MyService().GetAdministrator().HelloWorld();
            }
            catch
            {
                MessageBox.Show("无法连接到服务器，请确保网络连接和ip(你输入的ip地址： " + App.ip + ")地址正确(正确ip地址示例：121.197.3.168:8080)");
                return;
            }
            
            ServiceAdministrator.AdministratorSoapClient serviceAdministrator = myService.GetAdministrator();
            string username = this.Textboxname.Text.ToString();
            string pwd = this.Passwordboxpwd.Password.ToString();
            if(serviceAdministrator.CheckAdministrator(username,pwd))
            {
                //new AdminMenu().Show();
                AdminMenu am = new AdminMenu();
                am.AdminName=username;
                am.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("用户名不存在或密码错误");
            }
            
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Login_hover.png", UriKind.Relative));
            imageLogin.Source = imagetemp;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
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
    }
}
