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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TexasWpfApplication.Common;

namespace TexasWpfApplication.Pages
{
    /// <summary>
    /// UserControlGameInput3.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlGameInput3 : UserControl
    {
        public int playerID;
        private MyService myService = new MyService();
        private string grayColor = "#FF808080";
        public UserControlGameInput3()
        {
            InitializeComponent();
        }


        //private void buttonRaise_Click(object sender, RoutedEventArgs e)
        //{
        //    this.grid2.Visibility = Visibility.Visible;
        //    this.buttonRaise.Background = new ImageBrush
        //    {
        //        ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
        //    };
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    ServiceBet.BetSoapClient serviceBet = myService.GetBet();
        //    serviceBet.NewBet(playerID,"弃牌","");
        //    this.Visibility = Visibility.Hidden;
        //}

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    ServiceBet.BetSoapClient serviceBet = myService.GetBet();
        //    serviceBet.NewBet(playerID, "跟注", "");
        //    this.Visibility = Visibility.Hidden;
        //}

        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    ServiceBet.BetSoapClient serviceBet = myService.GetBet();
        //    serviceBet.NewBet(playerID, "看牌", "");
        //    this.Visibility = Visibility.Hidden;
        //}

        //private void Button_Click_3(object sender, RoutedEventArgs e)
        //{
        //    ServiceBet.BetSoapClient serviceBet = myService.GetBet();
        //    serviceBet.NewBet(playerID, "全下", "");
        //    this.Visibility = Visibility.Hidden;
        //}

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int output;
            if(int.TryParse(this.TextboxChips.Text.ToString(),out output))
            {
                int maxBetChips = myService.GetPlayerChip().GetMaxBetChipsForLive();

                if (int.Parse(this.TextboxChips.Text.ToString()) <= maxBetChips)
                {
                    MessageBox.Show("加注额太少");
                    return;
                }


                ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                serviceBet.NewBet(playerID, "加注", this.TextboxChips.Text.ToString());
                this.grid2.Visibility = Visibility.Hidden;
                this.labelRaise.Background = null;
                this.Visibility = Visibility.Hidden;
            }
            
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK_hover.png", UriKind.Relative));
            imageOK.Source = imagetemp;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK.png", UriKind.Relative));
            imageOK.Source = imagetemp;
        }


        ImageBrush back_hover = new ImageBrush
        {
            ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
        };

        private void labelFold_MouseEnter(object sender, MouseEventArgs e)
        {
            this.labelFold.Background = back_hover;
            this.labelRaise.Background = null;
            this.labelCheck.Background = null;
            this.labelCall.Background = null;
            this.labelAllin.Background = null;

            this.grid2.Visibility = Visibility.Hidden;
        }

        private void labelCall_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this.labelCall.Foreground.ToString().Equals(grayColor))
            {
                this.labelFold.Background = null;
                this.labelRaise.Background = null;
                this.labelCheck.Background = null;
                this.labelCall.Background = back_hover;
                this.labelAllin.Background = null;

                this.grid2.Visibility = Visibility.Hidden;
            }

        }

        private void labelRaise_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this.labelRaise.Foreground.ToString().Equals(grayColor))
            {
                this.TextboxChips.Text = "";

                this.labelFold.Background = null;
                this.labelRaise.Background = back_hover;
                this.labelCheck.Background = null;
                this.labelCall.Background = null;
                this.labelAllin.Background = null;

                this.grid2.Visibility = Visibility.Visible;
                this.TextboxChips.Focus();
            }


        }

        private void labelCheck_MouseEnter(object sender, MouseEventArgs e)
        {
            if (!this.labelCheck.Foreground.ToString().Equals(grayColor))
            {
                this.labelFold.Background = null;
                this.labelRaise.Background = null;
                this.labelCheck.Background = back_hover;
                this.labelCall.Background = null;
                this.labelAllin.Background = null;

                this.grid2.Visibility = Visibility.Hidden;
            }

        }

        private void labelAllin_MouseEnter(object sender, MouseEventArgs e)
        {
            this.labelFold.Background = null;
            this.labelRaise.Background = null;
            this.labelCheck.Background = null;
            this.labelCall.Background = null;
            this.labelAllin.Background = back_hover;

            this.grid2.Visibility = Visibility.Hidden;
        }

        private void labelFold_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ServiceBet.BetSoapClient serviceBet = myService.GetBet();
            serviceBet.NewBet(playerID, "弃牌", "");
            this.Visibility = Visibility.Hidden;
            this.labelFold.Background = null;
        }

        private void labelCall_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!this.labelCall.Foreground.ToString().Equals(grayColor))
            {
                ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                serviceBet.NewBet(playerID, "跟注", "");
                this.Visibility = Visibility.Hidden;
                this.labelCall.Background = null;
            }

        }

        private void labelRaise_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!this.labelRaise.Foreground.ToString().Equals(grayColor))
            {
                this.labelFold.Background = null;
                this.labelRaise.Background = back_hover;
                this.labelCheck.Background = null;
                this.labelCall.Background = null;
                this.labelAllin.Background = null;

                this.grid2.Visibility = Visibility.Visible;
            }


        }

        private void labelCheck_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!this.labelCheck.Foreground.ToString().Equals(grayColor))
            {
                ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                serviceBet.NewBet(playerID, "看牌", "");
                this.Visibility = Visibility.Hidden;
                this.labelCheck.Background = null;
            }


        }

        private void labelAllin_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ServiceBet.BetSoapClient serviceBet = myService.GetBet();
            serviceBet.NewBet(playerID, "全下", "");
            this.Visibility = Visibility.Hidden;
            this.labelAllin.Background = null;
        }

        private void TextboxChips_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                int output;
                if (int.TryParse(this.TextboxChips.Text.ToString(), out output))
                {
                    int maxBetChips = myService.GetPlayerChip().GetMaxBetChipsForLive();

                    if (int.Parse(this.TextboxChips.Text.ToString()) <= maxBetChips)
                    {
                        MessageBox.Show("加注额太少");
                        return;
                    }


                    ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                    serviceBet.NewBet(playerID, "加注", this.TextboxChips.Text.ToString());
                    this.grid2.Visibility = Visibility.Hidden;
                    this.labelRaise.Background = null;
                    this.Visibility = Visibility.Hidden;
                }
            }
        }

    }
}
