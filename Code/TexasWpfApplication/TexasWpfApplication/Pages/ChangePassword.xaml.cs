using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    /// ChangePassword.xaml 的交互逻辑
    /// </summary>
    public partial class ChangePassword : Window
    {
        private MyService myService = new MyService();
        public string AdminName;
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void imagePre_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Pre_Step_hover.png", UriKind.Relative));
            imagePre.Source = imagetemp;
        }

        private void imagePre_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Pre_Step.png", UriKind.Relative));
            imagePre.Source = imagetemp;
        }

        private void imagePre_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AdminMenu am = new AdminMenu();
            am.AdminName = AdminName;
            am.Show();
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

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string oldpwd = this.OldPassword.Password.ToString();
            string newPwd = this.NewPassword.Password.ToString();
            string newPwdAgain = this.NewPasswordAgain.Password.ToString();
            if (!newPwd.Equals(NewPasswordAgain))
                MessageBox.Show("两次密码输入不同");
            else
            {
                if (NewPasswordAgain.Equals(""))
                    MessageBox.Show("新密码不能为空");
                else
                {
                    bool result = myService.GetAdministrator().CheckAdministrator(AdminName,oldpwd);
                    if(result)
                    {
                        result = myService.GetAdministrator().ResetPassword(AdminName,newPwd);
                        if(result)
                        {
                            MessageBox.Show("密码修改成功");
                            AdminMenu am = new AdminMenu();
                            am.AdminName = AdminName;
                            am.Show();
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("密码输入错误");
                }
            }
        }

        private void Label_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Login_hover.png", UriKind.Relative));
            imageLogin.Source = imagetemp;
        }

        private void Label_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Button_Login.png", UriKind.Relative));
            imageLogin.Source = imagetemp;
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string oldpwd = this.OldPassword.Password.ToString();
            string newPwd = this.NewPassword.Password.ToString();
            string newPwdAgain = this.NewPasswordAgain.Password.ToString();
            if (!newPwd.Equals(newPwdAgain))
                MessageBox.Show("两次密码输入不同");
            else
            {
                if (NewPasswordAgain.Equals(""))
                    MessageBox.Show("新密码不能为空");
                else
                {
                    bool result = myService.GetAdministrator().CheckAdministrator(AdminName, oldpwd);
                    if (result)
                    {
                        result = myService.GetAdministrator().ResetPassword(AdminName, newPwd);
                        if (result)
                        {
                            MessageBox.Show("密码修改成功");
                            AdminMenu am = new AdminMenu();
                            am.AdminName = AdminName;
                            am.Show();
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("密码输入错误");
                }
            }
        }
    }
}
