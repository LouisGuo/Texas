using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// LoginAdmin.xaml 的交互逻辑
    /// </summary>
    public partial class AdminMenu : Window
    {
        public string AdminName;


        private Display dispaly = new Display();

        public AdminMenu()
        {
            InitializeComponent();

           
        }



        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            new StartNew().Show();
            this.Close();
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            foreach (Window w in App.Current.Windows)
            {
                if (w is SelectOld)
                {
                    w.Close();
                }
            }
            new SelectOld().Show();
            this.Close();
        }

        private void image_MouseEnter(object sender, MouseEventArgs e)
        {
            //string realPath = string.Format("/Resources/RecordNew_hover.png");
            //Uri pathUri = new Uri(realPath);
            //System.Windows.Media.Imaging.BitmapImage bi = new System.Windows.Media.Imaging.BitmapImage();
            //bi.BeginInit();
            //bi.UriSource = pathUri;
            //bi.EndInit();
            //this.imageNEW.Source = bi;
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/RecordNew_hover.png", UriKind.Relative));
            imageNEW.Source = imagetemp;
        }

        private void image_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/RecordNew.png", UriKind.Relative));
            imageNEW.Source = imagetemp;
        }

        private void imageOld_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/ReplayHistory_hover.png", UriKind.Relative));
            imageOld.Source = imagetemp;
        }

        private void imageOld_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/ReplayHistory.png", UriKind.Relative));
            imageOld.Source = imagetemp;
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
            new LoginAdmin().Show();
            this.Close();
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

        private void imageClose_Copy_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/ChangePass_hover.png", UriKind.Relative));
            imageChangePassword.Source = imagetemp;
        }

        private void imageClose_Copy_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/ChangePass.png", UriKind.Relative));
            imageChangePassword.Source = imagetemp;
        }

        private void imageClose_Copy_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //new ChangePassword().Show();
            ChangePassword cp = new ChangePassword();
            cp.AdminName = AdminName;
            cp.Show();
            this.Close();
        }

    }
}
