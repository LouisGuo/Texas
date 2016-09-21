using System;
using System.Collections.Generic;
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
using TexasWpfApplication.Common;

namespace TexasWpfApplication.Pages
{
    /// <summary>
    /// UserControlGameInput1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlGameInput1 : UserControl
    {
        public int playerID;
        public int startChips;

        private MyService myService = new MyService();
        private string[] cardType = new string[] { "H","S","D","C"};

        public UserControlGameInput1()
        {
            InitializeComponent();

            DataSet recordSet = myService.GetRecord().GetRecordForLive();
            if (recordSet.Tables.Count != 0)
            {
                DataTable recordTable = recordSet.Tables[0];
                if (recordTable.Rows.Count != 0)
                {

                    int playerNum = int.Parse(recordTable.Rows[0]["PlayerNumber"].ToString());
                    this.GainChips1.IsEnabled = true;
                    this.GainChips2.IsEnabled = true;
                    this.LoanChips1.IsEnabled = true;
                    this.LoanChips2.IsEnabled = true;

                    string[] mingci = new string[] { "一", "二", "三", "四", "五", "六", "七", "八" };
                    foreach (UIElement c in this.grid2.Children)
                    {
                        if(c is ComboBox)
                        {
                            ComboBox cb = c as ComboBox;
                            for (int j = 0; j < playerNum; j++)
                            {
                                ComboBoxItem item = new ComboBoxItem();
                                item.Content = mingci[j];
                                cb.Items.Add(item);
                            }
                        }
                    }


                    if (playerNum > 2)
                    {
                        this.GainChips3.IsEnabled = true;
                        this.LoanChips3.IsEnabled = true;
                    }
                    if (playerNum > 3)
                    {
                        this.GainChips4.IsEnabled = true;
                        this.LoanChips4.IsEnabled = true;
                    }
                    if (playerNum > 4)
                    {
                        this.GainChips5.IsEnabled = true;
                        this.LoanChips5.IsEnabled = true;
                    }
                    if (playerNum > 5)
                    {
                        this.GainChips6.IsEnabled = true;
                        this.LoanChips6.IsEnabled = true;
                    }
                    if (playerNum > 6)
                    {
                        this.GainChips7.IsEnabled = true;
                        this.LoanChips7.IsEnabled = true;
                    }
                    if (playerNum > 7)
                    {
                        this.GainChips8.IsEnabled = true;
                        this.LoanChips8.IsEnabled = true;
                    }
                        
                }
            }
            
        }

        
        public string GetCardName(string input)
        {
            if (input.Length != 3)
                return "";
            else
            {
                string head = input.Substring(0,1);
                string body = input.Substring(1,2);
                int output = -1;
                if (int.TryParse(body,out output))
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

        private void imageOK1_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK_hover.png", UriKind.Relative));
            imageOK1.Source = imagetemp;
        }

        private void imageOK1_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK.png", UriKind.Relative));
            imageOK1.Source = imagetemp;
        }

        public string GetCardName(int typeID,int numberID)
        {
            string result = "";
            if(typeID>-1&&typeID<4&&numberID>-1&&numberID<13)
            {
                result=result+cardType[typeID];
                if(numberID>8)
                {
                    result = result + (numberID+1);
                }
                else if(numberID<9)
                {
                    result = result + "0" + (numberID + 1);
                }
            }
            return result;

        }

        private void imageOK1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            ServiceCard.CardSoapClient serviceCard = myService.GetCard();
            ServiceBet.BetSoapClient serviceBet = myService.GetBet();
            string card1 = GetCardName(this.PublicCard1.SelectedIndex,this.PublicCard1_Copy.SelectedIndex);
            string card2 = GetCardName(this.PublicCard2.SelectedIndex, this.PublicCard2_Copy.SelectedIndex);
            string card3 = GetCardName(this.PublicCard3.SelectedIndex, this.PublicCard3_Copy.SelectedIndex);
            string card4 = GetCardName(this.PublicCard4.SelectedIndex, this.PublicCard4_Copy.SelectedIndex);
            string card5 = GetCardName(this.PublicCard5.SelectedIndex, this.PublicCard5_Copy.SelectedIndex);

            bool result = true;
            if (!card1.Equals("格式错误") && !card1.Equals("") && !card2.Equals("格式错误") && !card2.Equals("") && !card3.Equals("格式错误") && !card3.Equals("") && (card4.Equals("格式错误") || card4.Equals("")) && (card5.Equals("格式错误") || card5.Equals("")))
            {
                if (PublicCard1.IsEnabled)
                {
                    result = result && serviceCard.DealFirstThreePublicCard(card1, card2, card3);

                    serviceBet.NewBet(0, "发牌", "1");
                }
                
               
            }
            if (!card1.Equals("格式错误") && !card1.Equals("") && !card2.Equals("格式错误") && !card2.Equals("") && !card3.Equals("格式错误") && !card3.Equals("") && (!card4.Equals("格式错误") && !card4.Equals("")) && (card5.Equals("格式错误") || card5.Equals("")))
            {
                if (PublicCard4.IsEnabled)
                {
                    result = result && serviceCard.DealFourthPublicCard(card4);
                    serviceBet.NewBet(0, "发牌", "2");
                }
                
            }
            if (!card1.Equals("格式错误") && !card1.Equals("") && !card2.Equals("格式错误") && !card2.Equals("") && !card3.Equals("格式错误") && !card3.Equals("") && (!card4.Equals("格式错误") && !card4.Equals("")) && (!card5.Equals("格式错误") && !card5.Equals("")))
            {
                if (PublicCard5.IsEnabled)
                {
                    result = result && serviceCard.DealFifthPublicCard(card5);
                    serviceBet.NewBet(0, "发牌", "3");
                }
                
            }
            if(result)
            {
                this.grid1.Visibility = Visibility.Hidden;
                this.b1.Background = null;
                this.Visibility = Visibility.Hidden;

            }
        }

        private void imageOK2_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK_hover.png", UriKind.Relative));
            imageOK2.Source = imagetemp;
        }

        private void imageOK2_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK.png", UriKind.Relative));
            imageOK2.Source = imagetemp;
        }

        private void imageOK2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {

                this.PublicCard1.SelectedIndex = -1;
                this.PublicCard1_Copy.SelectedIndex = -1;
                this.PublicCard2.SelectedIndex = -1;
                this.PublicCard2_Copy.SelectedIndex = -1;
                this.PublicCard3.SelectedIndex = -1;
                this.PublicCard3_Copy.SelectedIndex = -1;
                this.PublicCard4.SelectedIndex = -1;
                this.PublicCard4_Copy.SelectedIndex = -1;
                this.PublicCard5.SelectedIndex = -1;
                this.PublicCard5_Copy.SelectedIndex = -1;

                ServicePlayerChip.PlayerChipSoapClient servicePlayerChip = myService.GetPlayerChip();
                ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                int gainChips1 = this.GainChips1.SelectedIndex + 1;
                int gainChips2 = this.GainChips2.SelectedIndex + 1;
                int gainChips3 = this.GainChips3.SelectedIndex + 1;
                int gainChips4 = this.GainChips4.SelectedIndex + 1;
                int gainChips5 = this.GainChips5.SelectedIndex + 1;
                int gainChips6 = this.GainChips6.SelectedIndex + 1;
                int gainChips7 = this.GainChips7.SelectedIndex + 1;
                int gainChips8 = this.GainChips8.SelectedIndex + 1;

                servicePlayerChip.JudgeWinner(gainChips1, gainChips2, gainChips3, gainChips4, gainChips5, gainChips6, gainChips7, gainChips8);
                //serviceBet.NewBet(0,"判定","");

                this.b2.Background = null;
                this.grid2.Visibility = Visibility.Hidden;
                this.Visibility = Visibility.Hidden;

                this.GainChips1.SelectedIndex = -1;
                this.GainChips2.SelectedIndex = -1;
                this.GainChips3.SelectedIndex = -1;
                this.GainChips4.SelectedIndex = -1;
                this.GainChips5.SelectedIndex = -1;
                this.GainChips6.SelectedIndex = -1;
                this.GainChips7.SelectedIndex = -1;
                this.GainChips8.SelectedIndex = -1;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }

            
        }

        private void imageOK3_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK_hover.png", UriKind.Relative));
            imageOK3.Source = imagetemp;
        }

        private void imageOK3_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/OK.png", UriKind.Relative));
            imageOK3.Source = imagetemp;
        }

        private void imageOK3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                int loanchips1 = int.Parse(this.LoanChips1.Text.ToString());
                int loanchips2 = int.Parse(this.LoanChips2.Text.ToString());
                int loanchips3 = int.Parse(this.LoanChips3.Text.ToString());
                int loanchips4 = int.Parse(this.LoanChips4.Text.ToString());
                int loanchips5 = int.Parse(this.LoanChips5.Text.ToString());
                int loanchips6 = int.Parse(this.LoanChips6.Text.ToString());
                int loanchips7 = int.Parse(this.LoanChips7.Text.ToString());
                int loanchips8 = int.Parse(this.LoanChips8.Text.ToString());

                ServicePlayerChip.PlayerChipSoapClient servicePlayerChips = myService.GetPlayerChip();
                ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                servicePlayerChips.NewLoan(loanchips1, loanchips2, loanchips3, loanchips4, loanchips5, loanchips6, loanchips7, loanchips8);
                serviceBet.NewBet(0, "贷款", "");

                this.grid3.Visibility = Visibility.Hidden;
                this.b3.Background = null;
                this.Visibility = Visibility.Hidden;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
            


        }

        private void SetComboxState(ComboBox combox,ComboBox combox_copy,string cardName)
        {
            if(cardName.Length==3)
            {
                combox_copy.SelectedIndex = int.Parse(cardName.Substring(1,2))-1;

                for(int i=0;i<4;i++)
                {
                    if(cardName.Substring(0,1).Equals(cardType[i]))
                    {
                        combox.SelectedIndex = i;
                    }
                }
            }
        }

        public void SetPublicCardState()
        {
            

            this.grid1.Visibility = Visibility.Visible;
            this.grid2.Visibility = Visibility.Hidden;
            this.grid3.Visibility = Visibility.Hidden;
            this.b1.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
            };
            this.b2.Background = null;
            this.b3.Background = null;

            ServiceCard.CardSoapClient serviceCard = myService.GetCard();
            DataSet ds = serviceCard.GetPublicCardForLive();
            if (ds.Tables.Count == 0)
                return;
            DataTable table = ds.Tables[0];
            string publicCard1 = table.Rows[0]["FirstCard"].ToString();
            string publicCard2 = table.Rows[0]["SecondCard"].ToString();
            string publicCard3 = table.Rows[0]["ThirdCard"].ToString();
            string publicCard4 = table.Rows[0]["FourthCard"].ToString();
            string publicCard5 = table.Rows[0]["FifthCard"].ToString();
            this.PublicCard1.IsEnabled = false;
            this.PublicCard2.IsEnabled = false;
            this.PublicCard3.IsEnabled = false;
            this.PublicCard4.IsEnabled = false;
            this.PublicCard5.IsEnabled = false;
            this.PublicCard1_Copy.IsEnabled = false;
            this.PublicCard2_Copy.IsEnabled = false;
            this.PublicCard3_Copy.IsEnabled = false;
            this.PublicCard4_Copy.IsEnabled = false;
            this.PublicCard5_Copy.IsEnabled = false;

            if (publicCard1.Length != 0 && publicCard2.Length != 0 && publicCard3.Length != 0)
            {
                SetComboxState(this.PublicCard1, this.PublicCard1_Copy, publicCard1);
                SetComboxState(this.PublicCard2, this.PublicCard2_Copy, publicCard2);
                SetComboxState(this.PublicCard3, this.PublicCard3_Copy, publicCard3);
            }
            if (publicCard4.Length != 0)
                SetComboxState(this.PublicCard4, this.PublicCard4_Copy, publicCard4);
            if (publicCard5.Length != 0)
                SetComboxState(this.PublicCard5, this.PublicCard5_Copy, publicCard5);

            if (publicCard1.Length != 3||publicCard2.Length != 3||publicCard3.Length != 3)
            {
                this.PublicCard1.IsEnabled = true;
                this.PublicCard2.IsEnabled = true;
                this.PublicCard3.IsEnabled = true;
                this.PublicCard1_Copy.IsEnabled = true;
                this.PublicCard2_Copy.IsEnabled = true;
                this.PublicCard3_Copy.IsEnabled = true;
            }
            else if (publicCard1.Length == 3 && publicCard2.Length == 3 && publicCard3.Length == 3 && publicCard4.Length != 3)
            {
                this.PublicCard4.IsEnabled = true;
                this.PublicCard4_Copy.IsEnabled = true;
            }
            else if (publicCard4.Length == 3 && publicCard2.Length == 3 && publicCard3.Length == 3 && publicCard4.Length == 3 && publicCard5.Length != 3)
            {
                this.PublicCard5.IsEnabled = true;
                this.PublicCard5_Copy.IsEnabled = true;

            }


            
        }

        private void b1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.PublicCard1.SelectedIndex = -1;
            this.PublicCard1_Copy.SelectedIndex = -1;
            this.PublicCard2.SelectedIndex = -1;
            this.PublicCard2_Copy.SelectedIndex = -1;
            this.PublicCard3.SelectedIndex = -1;
            this.PublicCard3_Copy.SelectedIndex = -1;
            this.PublicCard4.SelectedIndex = -1;
            this.PublicCard4_Copy.SelectedIndex = -1;
            this.PublicCard5.SelectedIndex = -1;
            this.PublicCard5_Copy.SelectedIndex = -1;

            SetPublicCardState();
            //ServiceCard.CardSoapClient serviceCard = myService.GetCard();
            //DataSet ds = serviceCard.GetPublicCardForLive();
            //DataTable table = ds.Tables[0];
            //string publicCard1 = table.Rows[0]["FirstCard"].ToString();
            //string publicCard2 = table.Rows[0]["SecondCard"].ToString();
            //string publicCard3 = table.Rows[0]["ThirdCard"].ToString();
            //string publicCard4 = table.Rows[0]["FourthCard"].ToString();
            //string publicCard5 = table.Rows[0]["FifthCard"].ToString();
            //this.PublicCard1.IsEnabled = false;
            //this.PublicCard2.IsEnabled = false;
            //this.PublicCard3.IsEnabled = false;
            //this.PublicCard4.IsEnabled = false;
            //this.PublicCard5.IsEnabled = false;

            //this.PublicCard1.Text = publicCard1;
            //this.PublicCard2.Text = publicCard2;
            //this.PublicCard3.Text = publicCard3;
            //this.PublicCard4.Text = publicCard4;
            //this.PublicCard5.Text = publicCard5;

            //if (publicCard1.Length != 3)
            //{
            //    this.PublicCard1.IsEnabled = true;
            //    this.PublicCard2.IsEnabled = true;
            //    this.PublicCard3.IsEnabled = true;
            //    this.CardName1.Content = "";
            //    this.CardName2.Content = "";
            //    this.CardName3.Content = "";
            //    this.CardName4.Content = "";
            //    this.CardName5.Content = "";
            //}
            //if (publicCard1.Length == 3 && publicCard4.Length != 3)
            //{
            //    this.PublicCard4.IsEnabled = true;
            //}
            //if (publicCard4.Length == 3 && publicCard5.Length != 3)
            //{
            //    this.PublicCard5.IsEnabled = true;
            //}


            //this.grid1.Visibility = Visibility.Visible;
            //this.grid2.Visibility = Visibility.Hidden;
            //this.grid3.Visibility = Visibility.Hidden;
            //this.b1.Background = new ImageBrush
            //{
            //    ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
            //};
            //this.b2.Background = null;
            //this.b3.Background = null;

            //if (this.PublicCard3.IsEnabled)
            //    this.PublicCard1.Focus();
            //else if (this.PublicCard4.IsEnabled)
            //    this.PublicCard4.Focus();
            //else if (this.PublicCard5.IsEnabled)
            //    this.PublicCard5.Focus();
        }


        private void b2_MouseEnter(object sender, MouseEventArgs e)
        {
            this.GainChips1.SelectedIndex = -1;
            this.GainChips2.SelectedIndex = -1;
            this.GainChips3.SelectedIndex = -1;
            this.GainChips4.SelectedIndex = -1;
            this.GainChips5.SelectedIndex = -1;
            this.GainChips6.SelectedIndex = -1;
            this.GainChips7.SelectedIndex = -1;
            this.GainChips8.SelectedIndex = -1;
            this.grid1.Visibility = Visibility.Hidden;
            this.grid2.Visibility = Visibility.Visible;
            this.grid3.Visibility = Visibility.Hidden;
            this.b1.Background = null;
            this.b2.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
            };
            this.b3.Background = null;
            this.GainChips1.Focus();
        }


        private void b3_MouseEnter(object sender, MouseEventArgs e)
        {
            this.LoanChips1.Text = "0";
            this.LoanChips2.Text = "0";
            this.LoanChips3.Text = "0";
            this.LoanChips4.Text = "0";
            this.LoanChips5.Text = "0";
            this.LoanChips6.Text = "0";
            this.LoanChips7.Text = "0";
            this.LoanChips8.Text = "0";
            
            this.grid1.Visibility = Visibility.Hidden;
            this.grid2.Visibility = Visibility.Hidden;
            this.grid3.Visibility = Visibility.Visible;
            this.b1.Background = null;
            this.b2.Background = null;
            this.b3.Background = new ImageBrush
            {
                ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
            };

            this.LoanChips1.Focus();
        }

   

        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Enter)
            {
                if(grid1.Visibility==Visibility.Visible)
                {
                    ServiceCard.CardSoapClient serviceCard = myService.GetCard();
                    ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                    string card1 = GetCardName(this.PublicCard1.SelectedIndex, this.PublicCard1_Copy.SelectedIndex);
                    string card2 = GetCardName(this.PublicCard2.SelectedIndex, this.PublicCard2_Copy.SelectedIndex);
                    string card3 = GetCardName(this.PublicCard3.SelectedIndex, this.PublicCard3_Copy.SelectedIndex);
                    string card4 = GetCardName(this.PublicCard4.SelectedIndex, this.PublicCard4_Copy.SelectedIndex);
                    string card5 = GetCardName(this.PublicCard5.SelectedIndex, this.PublicCard5_Copy.SelectedIndex);

                    bool result = true;
                    if (!card1.Equals("格式错误") && !card1.Equals("") && !card2.Equals("格式错误") && !card2.Equals("") && !card3.Equals("格式错误") && !card3.Equals("") && (card4.Equals("格式错误") || card4.Equals("")) && (card5.Equals("格式错误") || card5.Equals("")))
                    {
                        if (PublicCard1.IsEnabled)
                        {
                            result = result && serviceCard.DealFirstThreePublicCard(this.PublicCard1.Text.ToString(), this.PublicCard2.Text.ToString(), this.PublicCard3.Text.ToString());

                            serviceBet.NewBet(0, "发牌", "1");
                        }


                    }
                    if (!card1.Equals("格式错误") && !card1.Equals("") && !card2.Equals("格式错误") && !card2.Equals("") && !card3.Equals("格式错误") && !card3.Equals("") && (!card4.Equals("格式错误") && !card4.Equals("")) && (card5.Equals("格式错误") || card5.Equals("")))
                    {
                        if (PublicCard4.IsEnabled)
                        {
                            result = result && serviceCard.DealFourthPublicCard(this.PublicCard4.Text.ToString());
                            serviceBet.NewBet(0, "发牌", "2");
                        }

                    }
                    if (!card1.Equals("格式错误") && !card1.Equals("") && !card2.Equals("格式错误") && !card2.Equals("") && !card3.Equals("格式错误") && !card3.Equals("") && (!card4.Equals("格式错误") && !card4.Equals("")) && (!card5.Equals("格式错误") && !card5.Equals("")))
                    {
                        if (PublicCard5.IsEnabled)
                        {
                            result = result && serviceCard.DealFifthPublicCard(this.PublicCard5.Text.ToString());
                            serviceBet.NewBet(0, "发牌", "3");
                        }

                    }
                    if (result)
                    {
                        this.grid1.Visibility = Visibility.Hidden;
                        this.b1.Background = null;
                        this.Visibility = Visibility.Hidden;

                    }
                }
                else if(grid2.Visibility==Visibility.Visible)
                {
                    try
                    {
                        this.PublicCard1.SelectedIndex = -1;
                        this.PublicCard1_Copy.SelectedIndex = -1;
                        this.PublicCard2.SelectedIndex = -1;
                        this.PublicCard2_Copy.SelectedIndex = -1;
                        this.PublicCard3.SelectedIndex = -1;
                        this.PublicCard3_Copy.SelectedIndex = -1;
                        this.PublicCard4.SelectedIndex = -1;
                        this.PublicCard4_Copy.SelectedIndex = -1;
                        this.PublicCard5.SelectedIndex = -1;
                        this.PublicCard5_Copy.SelectedIndex = -1;

                        ServicePlayerChip.PlayerChipSoapClient servicePlayerChip = myService.GetPlayerChip();
                        ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                        int gainChips1 = this.GainChips1.SelectedIndex + 1;
                        int gainChips2 = this.GainChips2.SelectedIndex + 1;
                        int gainChips3 = this.GainChips3.SelectedIndex + 1;
                        int gainChips4 = this.GainChips4.SelectedIndex + 1;
                        int gainChips5 = this.GainChips5.SelectedIndex + 1;
                        int gainChips6 = this.GainChips6.SelectedIndex + 1;
                        int gainChips7 = this.GainChips7.SelectedIndex + 1;
                        int gainChips8 = this.GainChips8.SelectedIndex + 1;

                        servicePlayerChip.JudgeWinner(gainChips1, gainChips2, gainChips3, gainChips4, gainChips5, gainChips6, gainChips7, gainChips8);
                        //serviceBet.NewBet(0,"判定","");

                        this.b2.Background = null;
                        this.grid2.Visibility = Visibility.Hidden;
                        this.Visibility = Visibility.Hidden;
                    }
                    catch
                    {
                        MessageBox.Show("格式错误");
                    }
                }
                else if(grid3.Visibility==Visibility.Visible)
                {
                    try
                    {
                        int loanchips1 = int.Parse(this.LoanChips1.Text.ToString());
                        int loanchips2 = int.Parse(this.LoanChips2.Text.ToString());
                        int loanchips3 = int.Parse(this.LoanChips3.Text.ToString());
                        int loanchips4 = int.Parse(this.LoanChips4.Text.ToString());
                        int loanchips5 = int.Parse(this.LoanChips5.Text.ToString());
                        int loanchips6 = int.Parse(this.LoanChips6.Text.ToString());
                        int loanchips7 = int.Parse(this.LoanChips7.Text.ToString());
                        int loanchips8 = int.Parse(this.LoanChips8.Text.ToString());

                        ServicePlayerChip.PlayerChipSoapClient servicePlayerChips = myService.GetPlayerChip();
                        ServiceBet.BetSoapClient serviceBet = myService.GetBet();
                        servicePlayerChips.NewLoan(loanchips1, loanchips2, loanchips3, loanchips4, loanchips5, loanchips6, loanchips7, loanchips8);
                        serviceBet.NewBet(0, "贷款", "");

                        this.grid3.Visibility = Visibility.Hidden;
                        this.b3.Background = null;
                        this.Visibility = Visibility.Hidden;
                    }
                    catch
                    {
                        MessageBox.Show("格式错误");
                    }
                }
            }
        }

        private void LoanChips1_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips1.Text.ToString()) > startChips)
                    LoanChips1.Text = "" + startChips;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
        }

        private void LoanChips2_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips2.Text.ToString()) > startChips)
                    LoanChips2.Text = "" + startChips;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
        }

        private void LoanChips3_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips3.Text.ToString()) > startChips)
                    LoanChips3.Text = "" + startChips;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
        }

        private void LoanChips4_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips4.Text.ToString()) > startChips)
                    LoanChips4.Text = "" + startChips;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
        }

        private void LoanChips5_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips5.Text.ToString()) > startChips)
                    LoanChips5.Text = "" + startChips;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
        }

        private void LoanChips6_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips6.Text.ToString()) > startChips)
                    LoanChips6.Text = "" + startChips;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
        }

        private void LoanChips7_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips7.Text.ToString()) > startChips)
                    LoanChips7.Text = "" + startChips;
            }
            catch
            {
                MessageBox.Show("格式错误");
            }
        }

        private void LoanChips8_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (int.Parse(LoanChips8.Text.ToString()) > startChips)
                    LoanChips8.Text = "" + startChips;
            }
            catch  
            {
                MessageBox.Show("格式错误");
            }
        }

        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            if(this.PublicCard1.IsEnabled==true)
            {
                this.PublicCard4.SelectedIndex = -1;
                this.PublicCard5.SelectedIndex = -1;
            }
            else if(this.PublicCard4.IsEnabled==true)
            {
                this.PublicCard5.SelectedIndex = -1;
            }

        }


    }
}
