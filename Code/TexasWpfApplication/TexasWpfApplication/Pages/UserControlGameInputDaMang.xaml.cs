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
    /// UserControlGameInputDaMang.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlGameInputDaMang : UserControl
    {
        public int playerID;
        private MyService myService = new MyService();
        public UserControlGameInputDaMang()
        {
            InitializeComponent();
        }

        private void imageOK_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK_hover.png", UriKind.Relative));
            imageOK.Source = imagetemp;
        }

        private void imageOK_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK.png", UriKind.Relative));
            imageOK.Source = imagetemp;
        }

        private void imageOK_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int output;
            if(int.TryParse(this.TextboxChips.Text.ToString(),out output))
            {
                ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                string chipsBet = this.TextboxChips.Text.ToString();
                serviceBet.NewBet(playerID, "大盲", chipsBet);
                this.Visibility = Visibility.Hidden;

                //this.TextboxChips.Text = "";
            }
            
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                int output;
                if (int.TryParse(this.TextboxChips.Text.ToString(), out output))
                {
                    ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                    string chipsBet = this.TextboxChips.Text.ToString();
                    serviceBet.NewBet(playerID, "大盲", chipsBet);
                    this.Visibility = Visibility.Hidden;

                    //this.TextboxChips.Text = "";
                }
            }
        }
    }
}
