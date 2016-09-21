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
    /// StartNew.xaml 的交互逻辑
    /// </summary>
    public partial class StartNew : Window
    {
        private MyService myService = new MyService();
        public StartNew()
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
            int[] headIndex=new int[8];
            string[] headPicture =new string[8] ;
            headIndex[0] = this.ComboBoxHeadPicture1.SelectedIndex;
            headIndex[1] = this.ComboBoxHeadPicture2.SelectedIndex;
            headIndex[2] = this.ComboBoxHeadPicture3.SelectedIndex;
            headIndex[3] = this.ComboBoxHeadPicture4.SelectedIndex;
            headIndex[4] = this.ComboBoxHeadPicture5.SelectedIndex;
            headIndex[5] = this.ComboBoxHeadPicture6.SelectedIndex;
            headIndex[6] = this.ComboBoxHeadPicture7.SelectedIndex;
            headIndex[7] = this.ComboBoxHeadPicture8.SelectedIndex;
            for(int i=0;i<8;i++)
            {  
                switch (headIndex[i])
                {  
                    case 0:
                        headPicture[i] = "Bear";
                        break;
                    case 1:
                        headPicture[i] = "Beauty";
                        break;
                    case 2:
                        headPicture[i] = "Cat";
                        break;
                    case 3:
                        headPicture[i] = "Dog";
                        break;
                    case 4:
                        headPicture[i] = "Eagle";
                        break;
                    case 5:
                        headPicture[i] = "Fox";
                        break;
                    case 6:
                        headPicture[i] = "Horse";
                        break;
                    case 7:
                        headPicture[i] = "Leopard";
                        break;
                    case 8:
                        headPicture[i] = "Lion";
                        break;
                    case 9:
                        headPicture[i] = "Panda";
                        break;
                    case 10:
                        headPicture[i] = "Tiger";
                        break;
                }
            }

            
            
            ServiceRecord.RecordSoapClient serviceRecord = myService.GetRecord();
            int playerNumber = this.ComboBoxPlayerNum.SelectedIndex + 2;
            int startChips = int.Parse(this.TextBoxStartChips.Text.ToString());
            string firstInterest = this.TextBoxFirstInterest.Text.ToString();
            string secondInterest = this.TextBoxSecondInterest.Text.ToString();
            string thirdInterest = this.TextBoxThirdInterest.Text.ToString();
            string fourthInterest = this.TextBoxFourthInterest.Text.ToString();
            string fifthInterest = this.TextBoxFifthInterest.Text.ToString();
            double first = int.Parse(firstInterest.Substring(0, firstInterest.Length - 1)) * 0.01;
            double second = int.Parse(secondInterest.Substring(0, secondInterest.Length - 1)) * 0.01;
            double third = int.Parse(thirdInterest.Substring(0, thirdInterest.Length - 1)) * 0.01;
            double fourth = int.Parse(fourthInterest.Substring(0, fourthInterest.Length - 1)) * 0.01;
            double fifth = int.Parse(fifthInterest.Substring(0, fifthInterest.Length - 1)) * 0.01;
            if (serviceRecord.NewRecord(playerNumber, startChips, (float)first, (float)second, (float)third, (float)fourth, (float)fifth))
            {

                new GameInput(playerNumber,startChips).Show();

                //在Record开始后设置头像
                bool result = false;
                for (int i = 0; i < ComboBoxPlayerNum.SelectedIndex + 2; i++)
                {
                    result = myService.GetPlayerChip().SetHeadPicture(i + 1, headPicture[i]);
                }
            

                this.Close();
            }
            else
            {
                MessageBox.Show("false");
            }

            
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
            new AdminMenu().Show();
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

        private void ComboBoxPlayerNum_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int playerNumber = this.ComboBoxPlayerNum.SelectedIndex + 2;

            this.ComboBoxHeadPicture1.Visibility = Visibility.Hidden;
            this.ComboBoxHeadPicture2.Visibility = Visibility.Hidden;
            this.ComboBoxHeadPicture3.Visibility = Visibility.Hidden;
            this.ComboBoxHeadPicture4.Visibility = Visibility.Hidden;
            this.ComboBoxHeadPicture5.Visibility = Visibility.Hidden;
            this.ComboBoxHeadPicture6.Visibility = Visibility.Hidden;
            this.ComboBoxHeadPicture7.Visibility = Visibility.Hidden;
            this.ComboBoxHeadPicture8.Visibility = Visibility.Hidden;
            if(playerNumber>1)
            {
                this.ComboBoxHeadPicture1.Visibility = Visibility.Visible;
                this.ComboBoxHeadPicture2.Visibility = Visibility.Visible;
            }
            if(playerNumber>2)
                this.ComboBoxHeadPicture3.Visibility = Visibility.Visible;
            if (playerNumber > 3)
                this.ComboBoxHeadPicture4.Visibility = Visibility.Visible;
            if (playerNumber > 4)
                this.ComboBoxHeadPicture5.Visibility = Visibility.Visible;
            if (playerNumber > 5)
                this.ComboBoxHeadPicture6.Visibility = Visibility.Visible;
            if (playerNumber >6)
                this.ComboBoxHeadPicture7.Visibility = Visibility.Visible;
            if (playerNumber > 7)
                this.ComboBoxHeadPicture8.Visibility = Visibility.Visible;
        }

    }
}
