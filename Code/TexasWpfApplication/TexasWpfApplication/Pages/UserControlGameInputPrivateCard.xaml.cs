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
    /// UserControlGameInputPrivateCard.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlGameInputPrivateCard : UserControl
    {
        public int playerID;
        private MyService myService = new MyService();
        public UserControlGameInputPrivateCard()
        {
            InitializeComponent();
            this.PrivateCard1.Focus();
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
            if ((!this.CardName1.Content.ToString().Equals("")) && (!this.CardName2.Content.ToString().Equals("")) && (!this.CardName1.Content.ToString().Equals("格式错误")) && (!this.CardName2.Content.ToString().Equals("格式错误")))
            {
                ServiceCard.CardSoapClient serviceCard = myService.GetCard();
                string firstPrivateCard = this.PrivateCard1.Text.ToString();
                string secondPrivateCard = this.PrivateCard2.Text.ToString();

                serviceCard.DealPrivateCard(playerID, firstPrivateCard, secondPrivateCard);

                this.Visibility = Visibility.Hidden;
            }
        }

        private void PrivateCard1_TextChanged(object sender, TextChangedEventArgs e)
        {
            string card = GetCardName(this.PrivateCard1.Text.ToString());
            if (card.Equals(""))
            {
                if (CardName1 != null)
                    this.CardName1.Content = "格式错误";
            }
            else
            {
                if (CardName1 != null)
                {
                    this.CardName1.Content = card;
                    this.PrivateCard2.Focus();
                }
                    
            }
        }

        private void PrivateCard2_TextChanged(object sender, TextChangedEventArgs e)
        {
            string card = GetCardName(this.PrivateCard2.Text.ToString());
            if (card.Equals(""))
            {
                if (CardName2 != null)
                    this.CardName2.Content = "格式错误";
            }
            else
            {
                if (CardName2 != null)
                    this.CardName2.Content = card;
            }
        }


        public string GetCardName(string input)
        {
            if (input.Length != 3)
                return "";
            else
            {
                string head = input.Substring(0, 1);
                string body = input.Substring(1, 2);
                int output = -1;
                if (int.TryParse(body, out output))
                {
                    if (head.ToUpper().Equals("H") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "红桃" + int.Parse(body);
                    }
                    else if (head.ToUpper().Equals("D") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "方块" + int.Parse(body);
                    }
                    else if (head.ToUpper().Equals("S") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "黑桃" + int.Parse(body);
                    }
                    else if (head.ToUpper().Equals("C") && int.Parse(body) < 14 && int.Parse(body) > 0)
                    {
                        return "梅花" + int.Parse(body);
                    }
                    else
                        return "";
                }
                else
                    return "";

            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                if ((!this.CardName1.Content.ToString().Equals("")) && (!this.CardName2.Content.ToString().Equals("")) && (!this.CardName1.Content.ToString().Equals("格式错误")) && (!this.CardName2.Content.ToString().Equals("格式错误")))
                {
                    ServiceCard.CardSoapClient serviceCard = myService.GetCard();
                    string firstPrivateCard = this.PrivateCard1.Text.ToString();
                    string secondPrivateCard = this.PrivateCard2.Text.ToString();

                    serviceCard.DealPrivateCard(playerID, firstPrivateCard, secondPrivateCard);

                    this.Visibility = Visibility.Hidden;
                }
                
            }
        }
    }
}
