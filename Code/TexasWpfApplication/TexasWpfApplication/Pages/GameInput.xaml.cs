using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// GameInput.xaml 的交互逻辑
    /// </summary>
    public partial class GameInput : Window
    {
        private int playerNumber;
        private int startChips;
        public int reRecordID=0;

        private MyService myService = new MyService();

        public GameInput(int playerNum,int startCh)
        {
            InitializeComponent();
            this.lineornot.Title.Text = "无网络";

            playerNumber = playerNum;
            startChips = startCh;
            ShowPlayer();

            this.heguan.startChips = startChips;
            
        }

        public void ShowPlayer()
        {
            picture1.Visibility = Visibility.Visible;
            Operation1.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            yue1.Visibility = Visibility.Visible;
            card11.Visibility = Visibility.Visible;
            card12.Visibility = Visibility.Visible;
            Bet1.Visibility = Visibility.Visible;
            this.pictureBack1.Visibility = Visibility.Visible;

            this.PlayerLabel1.Visibility = Visibility.Visible;

            yue1.Text = startChips.ToString();
            yue2.Text = startChips.ToString();
            yue3.Text = startChips.ToString();
            yue4.Text = startChips.ToString();
            yue5.Text = startChips.ToString();
            yue6.Text = startChips.ToString();
            yue7.Text = startChips.ToString();
            yue8.Text = startChips.ToString();
            if (playerNumber >= 2)
            {
                picture2.Visibility = Visibility.Visible;
                Operation2.Visibility = Visibility.Visible;
                label2.Visibility = Visibility.Visible;
                yue2.Visibility = Visibility.Visible;
                card21.Visibility = Visibility.Visible;
                card22.Visibility = Visibility.Visible;
                Bet2.Visibility = Visibility.Visible;
                this.pictureBack2.Visibility = Visibility.Visible;

                this.PlayerLabel2.Visibility = Visibility.Visible;
            }
            if (playerNumber >= 3)
            {
                picture3.Visibility = Visibility.Visible;
                Operation3.Visibility = Visibility.Visible;
                label3.Visibility = Visibility.Visible;
                yue3.Visibility = Visibility.Visible;
                card31.Visibility = Visibility.Visible;
                card32.Visibility = Visibility.Visible;
                Bet3.Visibility = Visibility.Visible;
                this.pictureBack3.Visibility = Visibility.Visible;

                this.PlayerLabel3.Visibility = Visibility.Visible;
            }
            if(playerNumber>=4)
            {
                picture4.Visibility = Visibility.Visible;
                Operation4.Visibility = Visibility.Visible;
                label4.Visibility = Visibility.Visible;
                yue4.Visibility = Visibility.Visible;
                card41.Visibility = Visibility.Visible;
                card42.Visibility = Visibility.Visible;
                Bet4.Visibility = Visibility.Visible;
                this.pictureBack4.Visibility = Visibility.Visible;

                this.PlayerLabel4.Visibility = Visibility.Visible;
            }
            if (playerNumber >= 5)
            {
                picture5.Visibility = Visibility.Visible;
                Operation5.Visibility = Visibility.Visible;
                label5.Visibility = Visibility.Visible;
                yue5.Visibility = Visibility.Visible;
                card51.Visibility = Visibility.Visible;
                card52.Visibility = Visibility.Visible;
                Bet5.Visibility = Visibility.Visible;
                this.pictureBack5.Visibility = Visibility.Visible;

                this.PlayerLabel5.Visibility = Visibility.Visible;
            }
            if (playerNumber >= 6)
            {
                picture6.Visibility = Visibility.Visible;
                Operation6.Visibility = Visibility.Visible;
                label6.Visibility = Visibility.Visible;
                yue6.Visibility = Visibility.Visible;
                card61.Visibility = Visibility.Visible;
                card62.Visibility = Visibility.Visible;
                Bet6.Visibility = Visibility.Visible;
                this.pictureBack6.Visibility = Visibility.Visible;

                this.PlayerLabel6.Visibility = Visibility.Visible;
            }
            if (playerNumber >= 7)
            {
                picture7.Visibility = Visibility.Visible;
                Operation7.Visibility = Visibility.Visible;
                label7.Visibility = Visibility.Visible;
                yue7.Visibility = Visibility.Visible;
                card71.Visibility = Visibility.Visible;
                card72.Visibility = Visibility.Visible;
                Bet7.Visibility = Visibility.Visible;
                this.pictureBack7.Visibility = Visibility.Visible;

                this.PlayerLabel7.Visibility = Visibility.Visible;
            }
            if (playerNumber >= 8)
            {
                picture8.Visibility = Visibility.Visible;
                Operation8.Visibility = Visibility.Visible;
                label8.Visibility = Visibility.Visible;
                yue8.Visibility = Visibility.Visible;
                card81.Visibility = Visibility.Visible;
                card82.Visibility = Visibility.Visible;
                Bet8.Visibility = Visibility.Visible;
                this.pictureBack8.Visibility = Visibility.Visible;

                this.PlayerLabel8.Visibility = Visibility.Visible;
            }

        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            heguan.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
        }

        private void Image_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            playerxiazhu.playerID = 1;
            playerxiazhu.Visibility = Visibility.Visible;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(760, 160, 0, 0);
        }

        private void Image_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            playerxiazhuopsite.playerID = 2;
            playerxiazhuopsite.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Margin = new Thickness(602, 152, 0, 0);
        }

        private void Image_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            playerxiazhuopsite.playerID = 3;
            playerxiazhuopsite.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Margin = new Thickness(598, 442, 0, 0);
        }

        private void Image_MouseLeftButtonUp_4(object sender, MouseButtonEventArgs e)
        {
            playerxiazhu.playerID = 4;
            playerxiazhu.Visibility = Visibility.Visible;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(734, 599, -16, -17);
        }

        private void Image_MouseLeftButtonUp_5(object sender, MouseButtonEventArgs e)
        {
            playerxiazhu.playerID = 5;
            playerxiazhu.Visibility = Visibility.Visible;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(386, 599, 0, -17);
        }

        private void Image_MouseLeftButtonUp_6(object sender, MouseButtonEventArgs e)
        {
            playerxiazhu.playerID = 6;
            playerxiazhu.Visibility = Visibility.Visible;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(138, 503, 0, 0);
        }

        private void Image_MouseLeftButtonUp_7(object sender, MouseButtonEventArgs e)
        {
            playerxiazhu.playerID = 7;
            playerxiazhu.Visibility = Visibility.Visible;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(126, 205, 0, 0);
        }

        private void Image_MouseLeftButtonUp_8(object sender, MouseButtonEventArgs e)
        {
            playerxiazhu.playerID = 8;
            playerxiazhu.Visibility = Visibility.Visible;
            heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(346, 106, 0, 0);
        }

        private void Image_MouseLeftButtonUp_9(object sender, MouseButtonEventArgs e)
        {
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Visibility = Visibility.Hidden;
        }

        private void Image_MouseLeftButtonUp_10(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 1;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(586, 124, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }

        private void Image_MouseLeftButtonUp_11(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 2;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(728, 174, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }

        private void Image_MouseLeftButtonUp_12(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 3;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(728, 305, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }

        private void Image_MouseLeftButtonUp_13(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 4;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(598, 368, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }

        private void Image_MouseLeftButtonUp_14(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 5;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(285, 380, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }

        private void Image_MouseLeftButtonUp_15(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 6;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(123, 319, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }

        private void Image_MouseLeftButtonUp_16(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 7;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(106, 174, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }

        private void Image_MouseLeftButtonUp_17(object sender, MouseButtonEventArgs e)
        {
            privateCard.playerID = 8;
            privateCard.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            heguan.Visibility = Visibility.Hidden;
            privateCard.Margin = new Thickness(235, 130, 0, 0);
            this.privateCard.PrivateCard1.Text = "";
            this.privateCard.PrivateCard2.Text = "";
            this.privateCard.CardName1.Content = "";
            this.privateCard.CardName2.Content = "";
            this.privateCard.PrivateCard1.Focus();
        }


        private DispatcherTimer timer= new DispatcherTimer();
        private DispatcherTimer timer1 = new DispatcherTimer();
        private DispatcherTimer timer2 = new DispatcherTimer();
        private DispatcherTimer timer3 = new DispatcherTimer();
        private DispatcherTimer timerOffLine = new DispatcherTimer(); 
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            double frequence = 1.5;

            
            timer.Interval = TimeSpan.FromSeconds(frequence);
            timer.Tick += theout;
            timer.Start();

            timer1.Interval = TimeSpan.FromSeconds(frequence);
            timer1.Tick += theout1;
            timer1.Start();

            timer2.Interval = TimeSpan.FromSeconds(frequence); 
            timer2.Tick += theout2;
            timer2.Start();

            timer3.Interval = TimeSpan.FromSeconds(frequence);
            timer3.Tick += theout3;
            timer3.Start();

            timerOffLine.Interval = TimeSpan.FromSeconds(frequence);
            timerOffLine.Tick += timerOff;
            
        }

        private void timerOff(object source, EventArgs e)
        {
            try
            {
                string testWebService = new MyService().GetAdministrator().HelloWorld();

                this.lineornot.Visibility = Visibility.Hidden;
                timerOffLine.Stop();
                StartAllTimer();
            }
            catch
            {
                this.lineornot.Visibility = Visibility.Visible;
                this.playerxiazhu.Visibility = Visibility.Hidden;
                this.playerxiazhuopsite.Visibility = Visibility.Hidden;
                this.damang.Visibility = Visibility.Hidden;
                this.xiaomang.Visibility = Visibility.Hidden;
                this.heguan.Visibility = Visibility.Hidden;
                this.privateCard.Visibility = Visibility.Hidden;
            }
        }

        public void theout2(object source, EventArgs e)
        {
            try
            {
                LoadHeadPicture();
            }
            catch
            {
                StopAllTimer();
            }
            
        }

        private void StartAllTimer()
        {
            timer.Start();
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        private void StopAllTimer()
        {
            timer.Stop();
            timer1.Stop();
            timer2.Stop();
            timer3.Stop();
            this.lineornot.Visibility = Visibility.Visible;
            timerOffLine.Start();
        }

        public void theout3(object source, EventArgs e)
        {
            try
            {
                LoadCard();
            }
            catch
            {
                StopAllTimer();
                
            }
            
        }

        public void theout1(object source, EventArgs e)
        {
            try
            {
                DeterminDaXiaomang();
            }
            catch
            {
                StopAllTimer();
            }
            
        }

        public void theout(object source, EventArgs e)
        {
            try
            {
                //DeterminDaXiaomang();
                LoadDesktop();

                //LoadHeadPicture();
                DeterminNextPlayer();

                if (int.Parse(this.yue1.Text.ToString()) < 0 || int.Parse(this.yue2.Text.ToString()) < 0 || int.Parse(this.yue3.Text.ToString()) < 0 || int.Parse(this.yue4.Text.ToString()) < 0 || int.Parse(this.yue5.Text.ToString()) < 0 || int.Parse(this.yue6.Text.ToString()) < 0 || int.Parse(this.yue7.Text.ToString()) < 0 || int.Parse(this.yue8.Text.ToString()) < 0)
                {
                    MessageBox.Show("余额已不足");
                    myService.GetBet().UndoPreOperation();
                }

                if (this.Operation1.Text.ToString().Equals("弃牌"))
                    this.picture1.Opacity = 0.1;
                else
                    this.picture1.Opacity = 1;

                if (this.Operation2.Text.ToString().Equals("弃牌"))
                    this.picture2.Opacity = 0.1;
                else
                    this.picture2.Opacity = 1;

                if (this.Operation3.Text.ToString().Equals("弃牌"))
                    this.picture3.Opacity = 0.1;
                else
                    this.picture3.Opacity = 1;

                if (this.Operation4.Text.ToString().Equals("弃牌"))
                    this.picture4.Opacity = 0.1;
                else
                    this.picture4.Opacity = 1;

                if (this.Operation5.Text.ToString().Equals("弃牌"))
                    this.picture5.Opacity = 0.1;
                else
                    this.picture5.Opacity = 1;

                if (this.Operation6.Text.ToString().Equals("弃牌"))
                    this.picture6.Opacity = 0.1;
                else
                    this.picture6.Opacity = 1;

                if (this.Operation7.Text.ToString().Equals("弃牌"))
                    this.picture7.Opacity = 0.1;
                else
                    this.picture7.Opacity = 1;

                if (this.Operation8.Text.ToString().Equals("弃牌"))
                    this.picture8.Opacity = 0.1;
                else
                    this.picture8.Opacity = 1;
            }
            catch
            {
                StopAllTimer();
            }
            
            




        }

        private void LoadCard()
        {
            //从服务器读取PublicCard，显示公共明牌
            ServiceCard.CardSoapClient serviceCard = myService.GetCard();
            DataSet publicCardTable = serviceCard.GetPublicCardForLive();
            if(publicCardTable.Tables.Count!=0)
            {
                if(publicCardTable.Tables[0].Rows.Count!=0)
                {
                    string card1 = publicCardTable.Tables[0].Rows[0]["FirstCard"].ToString();
                    string card2 = publicCardTable.Tables[0].Rows[0]["SecondCard"].ToString();
                    string card3 = publicCardTable.Tables[0].Rows[0]["ThirdCard"].ToString();
                    string card4 = publicCardTable.Tables[0].Rows[0]["FourthCard"].ToString();
                    string card5 = publicCardTable.Tables[0].Rows[0]["FifthCard"].ToString();
                    BitmapImage publicOld1 = new BitmapImage(new Uri("/Resources/Gray_1.png", UriKind.Relative));
                    BitmapImage publicOld2 = new BitmapImage(new Uri("/Resources/Gray_2.png", UriKind.Relative));
                    BitmapImage publicOld3 = new BitmapImage(new Uri("/Resources/Gray_3.png", UriKind.Relative));
                    if (card1.Length == 3)
                    {
                        BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Cards/" + card1 + ".png", UriKind.Relative));
                        this.card1.Source = imagetemp;
                    }
                    else
                        this.card1.Source = publicOld1;
                    if (card2.Length == 3)
                    {
                        BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Cards/" + card2 + ".png", UriKind.Relative));
                        this.card2.Source = imagetemp;
                    }
                    else
                        this.card2.Source = publicOld1;
                    if (card3.Length == 3)
                    {
                        BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Cards/" + card3 + ".png", UriKind.Relative));
                        this.card3.Source = imagetemp;
                    }
                    else
                        this.card3.Source = publicOld1;
                    if (card4.Length == 3)
                    {
                        BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Cards/" + card4 + ".png", UriKind.Relative));
                        this.card4.Source = imagetemp;
                    }
                    else
                        this.card4.Source = publicOld2;
                    if (card5.Length == 3)
                    {
                        BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Cards/" + card5 + ".png", UriKind.Relative));
                        this.card5.Source = imagetemp;
                    }
                    else
                        this.card5.Source = publicOld3;
                }
            }
            

            //从数据库读取privateCard，显示私牌 
            BitmapImage privateOld = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
            card11.Source = privateOld;
            card12.Source = privateOld;
            card21.Source = privateOld;
            card22.Source = privateOld;
            card31.Source = privateOld;
            card32.Source = privateOld;
            card41.Source = privateOld;
            card42.Source = privateOld;
            card51.Source = privateOld;
            card52.Source = privateOld;
            card61.Source = privateOld;
            card62.Source = privateOld;
            card71.Source = privateOld;
            card72.Source = privateOld;
            card81.Source = privateOld;
            card82.Source = privateOld;
            DataSet privateCardTable = serviceCard.GetPrivateCardForLive();
            if(privateCardTable.Tables.Count!=0)
            {
                if(privateCardTable.Tables[0].Rows.Count!=0)
                {
                    for (int i = 0; i < privateCardTable.Tables[0].Rows.Count; i++)
                    {
                        int playerID = int.Parse(privateCardTable.Tables[0].Rows[i]["PlayerID"].ToString());
                        string firstCard = privateCardTable.Tables[0].Rows[i]["FirstCard"].ToString();
                        string secondCard = privateCardTable.Tables[0].Rows[i]["SecondCard"].ToString();

                        BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                        BitmapImage imagetemp2 = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                        if (firstCard.Length != 0)
                            imagetemp = new BitmapImage(new Uri("/Resources/Cards/" + firstCard + ".png", UriKind.Relative));
                        if (secondCard.Length != 0)
                            imagetemp2 = new BitmapImage(new Uri("/Resources/Cards/" + secondCard + ".png", UriKind.Relative));
                        switch (playerID)
                        {
                            case 1:
                                card11.Source = imagetemp;
                                card12.Source = imagetemp2;
                                break;
                            case 2:
                                card21.Source = imagetemp;
                                card22.Source = imagetemp2;
                                break;
                            case 3:
                                card31.Source = imagetemp;
                                card32.Source = imagetemp2;
                                break;
                            case 4:
                                card41.Source = imagetemp;
                                card42.Source = imagetemp2;
                                break;
                            case 5:
                                card51.Source = imagetemp;
                                card52.Source = imagetemp2;
                                break;
                            case 6:
                                card61.Source = imagetemp;
                                card62.Source = imagetemp2;
                                break;
                            case 7:
                                card71.Source = imagetemp;
                                card72.Source = imagetemp2;
                                break;
                            case 8:
                                card81.Source = imagetemp;
                                card82.Source = imagetemp2;
                                break;
                        }
                    }
                }
            }
            


            //实时显示publicCard到桌面
            if (this.heguan.grid1.Visibility == Visibility.Visible)
            {
                BitmapImage s1 = new BitmapImage(new Uri("/Resources/Gray_1.png", UriKind.Relative));
                BitmapImage s2 = new BitmapImage(new Uri("/Resources/Gray_2.png", UriKind.Relative));
                BitmapImage s3 = new BitmapImage(new Uri("/Resources/Gray_3.png", UriKind.Relative));

                string carName1 = this.heguan.GetCardName(this.heguan.PublicCard1.SelectedIndex, this.heguan.PublicCard1_Copy.SelectedIndex);
                string carName2 = this.heguan.GetCardName(this.heguan.PublicCard2.SelectedIndex, this.heguan.PublicCard2_Copy.SelectedIndex);
                string carName3 = this.heguan.GetCardName(this.heguan.PublicCard3.SelectedIndex, this.heguan.PublicCard3_Copy.SelectedIndex);
                string carName4 = this.heguan.GetCardName(this.heguan.PublicCard4.SelectedIndex, this.heguan.PublicCard4_Copy.SelectedIndex);
                string carName5 = this.heguan.GetCardName(this.heguan.PublicCard5.SelectedIndex, this.heguan.PublicCard5_Copy.SelectedIndex);


                myService.GetCard().DealFirstTwoPublicCard(carName1, carName2);

                if (!carName1.Equals("格式错误") && !carName1.Equals(""))
                {
                    BitmapImage cardtemp = new BitmapImage(new Uri("/Resources/Cards/" + carName1 + ".png", UriKind.Relative));
                    this.card1.Source = cardtemp;
                }
                else
                    this.card1.Source = s1;
                if (!carName2.Equals("格式错误") && !carName2.Equals(""))
                {
                    BitmapImage cardtemp = new BitmapImage(new Uri("/Resources/Cards/" + carName2 + ".png", UriKind.Relative));
                    this.card2.Source = cardtemp;
                }
                else
                    this.card2.Source = s1;
                if (!carName3.Equals("格式错误") && !carName3.Equals(""))
                {
                    BitmapImage cardtemp = new BitmapImage(new Uri("/Resources/Cards/" + carName3 + ".png", UriKind.Relative));
                    this.card3.Source = cardtemp;
                }
                else
                    this.card3.Source = s1;
                //if (!carName4.Equals("格式错误") && !carName4.Equals(""))
                //{
                //    BitmapImage cardtemp = new BitmapImage(new Uri("/Resources/Cards/" + carName4 + ".png", UriKind.Relative));
                //    this.card4.Source = cardtemp;
                //}
                //else
                //    this.card4.Source = s2;
                //if (!carName5.Equals("格式错误") && !carName5.Equals(""))
                //{
                //    BitmapImage cardtemp = new BitmapImage(new Uri("/Resources/Cards/" + carName5 + ".png", UriKind.Relative));
                //    this.card5.Source = cardtemp;
                //}
                //else
                //    this.card5.Source = s3;
            }
        }

        private void SetHeGuanGainComboxState()
        {
            this.heguan.GainChips1.IsEnabled=(!this.Operation1.Text.ToString().Equals("弃牌"))&&this.Operation1.Visibility==Visibility.Visible;
            this.heguan.GainChips2.IsEnabled = (!this.Operation2.Text.ToString().Equals("弃牌")) && this.Operation2.Visibility == Visibility.Visible;
            this.heguan.GainChips3.IsEnabled = (!this.Operation3.Text.ToString().Equals("弃牌")) && this.Operation3.Visibility == Visibility.Visible;
            this.heguan.GainChips4.IsEnabled = (!this.Operation4.Text.ToString().Equals("弃牌")) && this.Operation4.Visibility == Visibility.Visible;
            this.heguan.GainChips5.IsEnabled = (!this.Operation5.Text.ToString().Equals("弃牌")) && this.Operation5.Visibility == Visibility.Visible;
            this.heguan.GainChips6.IsEnabled = (!this.Operation6.Text.ToString().Equals("弃牌")) && this.Operation6.Visibility == Visibility.Visible;
            this.heguan.GainChips7.IsEnabled = (!this.Operation7.Text.ToString().Equals("弃牌")) && this.Operation7.Visibility == Visibility.Visible;
            this.heguan.GainChips8.IsEnabled = (!this.Operation8.Text.ToString().Equals("弃牌")) && this.Operation8.Visibility == Visibility.Visible;
        }

        private void DeterminNextPlayer()
        {
            int nextPlayerID = myService.GetBet().GetNextPlayerIDForLive1();



            if(((nextPlayerID==0)&&(!(Operation1.Text.ToString().Equals("大盲")||Operation2.Text.ToString().Equals("大盲")||Operation3.Text.ToString().Equals("大盲")||Operation4.Text.ToString().Equals("大盲")||Operation5.Text.ToString().Equals("大盲")||Operation6.Text.ToString().Equals("大盲")||Operation7.Text.ToString().Equals("大盲")||Operation8.Text.ToString().Equals("大盲"))))||nextPlayerID==-1)
            {
                string chipsBet = "";
                string s1 = "pack://application:,,,/Resources/Gray_1.png";
                string s2 = "pack://application:,,,/Resources/Gray_2.png";
                string s3 = "pack://application:,,,/Resources/Gray_3.png";
                if (card1.Source.ToString() == s1 && card4.Source.ToString() == s2 && card5.Source.ToString() == s3)
                {
                    chipsBet = "1";
                }
                if (card1.Source.ToString() != s1 && card4.Source.ToString() == s2 && card5.Source.ToString() == s3)
                {
                    chipsBet = "2";
                }
                if (card1.Source.ToString() != s1 && card4.Source.ToString() != s2 && card5.Source.ToString() == s3)
                {
                    chipsBet = "3";
                }
                if (card1.Source.ToString() != s1 && card4.Source.ToString() != s2 && card5.Source.ToString() != s3)
                {
                    chipsBet = "";
                }

                //显示池底的筹码
                string chipsInPool = myService.GetPlayerChip().GetChipsInPoolForLive(chipsBet);
                if (chipsInPool.Length != 0)
                {
                    string[] eachChips = chipsInPool.Split('&');
                    int pools = eachChips.Length;
                    if (pools > 1)
                    {
                        this.imageChips1.Visibility = Visibility.Visible;
                        this.ChipsInPool1.Visibility = Visibility.Visible;
                        this.ChipsInPool1.Text = eachChips[1];
                    }
                    if (pools > 2)
                    {
                        this.imageChips2.Visibility = Visibility.Visible;
                        this.ChipsInPool2.Visibility = Visibility.Visible;
                        this.ChipsInPool2.Text = eachChips[2];
                    }
                    if (pools > 3)
                    {
                        this.imageChips3.Visibility = Visibility.Visible;
                        this.ChipsInPool3.Visibility = Visibility.Visible;
                        this.ChipsInPool3.Text = eachChips[3];
                    }
                    if (pools > 4)
                    {
                        this.imageChips4.Visibility = Visibility.Visible;
                        this.ChipsInPool4.Visibility = Visibility.Visible;
                        this.ChipsInPool4.Text = eachChips[4];
                    }
                    if (pools > 5)
                    {
                        this.imageChips5.Visibility = Visibility.Visible;
                        this.ChipsInPool5.Visibility = Visibility.Visible;
                        this.ChipsInPool5.Text = eachChips[5];
                    }
                    if (pools > 6)
                    {
                        this.imageChips6.Visibility = Visibility.Visible;
                        this.ChipsInPool6.Visibility = Visibility.Visible;
                        this.ChipsInPool6.Text = eachChips[6];
                    }
                    if (pools > 7)
                    {
                        this.imageChips7.Visibility = Visibility.Visible;
                        this.ChipsInPool7.Visibility = Visibility.Visible;
                        this.ChipsInPool7.Text = eachChips[7];
                    }
                }
            }




            int maxBetChips = 0;
            int nextPlayerAllBetChips=0;
            int nextPlayerTurnsLeftChips=0;
            if(nextPlayerID==0)
            {
                int tempPlayerID=0;
                if (this.Operation1.Text.Equals("大盲"))
                    tempPlayerID = 1;
                else if (this.Operation2.Text.Equals("大盲"))
                    tempPlayerID = 2;
                else if (this.Operation3.Text.Equals("大盲"))
                    tempPlayerID = 3;
                else if (this.Operation4.Text.Equals("大盲"))
                    tempPlayerID = 4;
                else if (this.Operation5.Text.Equals("大盲"))
                    tempPlayerID = 5;
                else if (this.Operation6.Text.Equals("大盲"))
                    tempPlayerID = 6;
                else if (this.Operation7.Text.Equals("大盲"))
                    tempPlayerID = 7;
                else if (this.Operation8.Text.Equals("大盲"))
                    tempPlayerID = 8;

                if(tempPlayerID>0&&tempPlayerID<9)
                {
                    maxBetChips = myService.GetPlayerChip().GetMaxBetChipsForLive();
                    nextPlayerAllBetChips = myService.GetPlayerChip().GetTurnsBetChipsForNextPlayer(tempPlayerID);
                    nextPlayerTurnsLeftChips = myService.GetPlayerChip().GetTurnsLeftBetChipsForNextPlayer(tempPlayerID);
                    if (nextPlayerAllBetChips < maxBetChips)
                    {
                        this.playerxiazhu.labelCheck.Foreground = new SolidColorBrush(Colors.Gray);
                        this.playerxiazhuopsite.labelCheck.Foreground = new SolidColorBrush(Colors.Gray);
                    }
                    else
                    {
                        this.playerxiazhu.labelCheck.Foreground = new SolidColorBrush(Colors.White);
                        this.playerxiazhuopsite.labelCheck.Foreground = new SolidColorBrush(Colors.White);
                    }

                    if (nextPlayerTurnsLeftChips <= maxBetChips)
                    {
                        this.playerxiazhu.labelCall.Foreground = new SolidColorBrush(Colors.Gray);
                        this.playerxiazhu.labelRaise.Foreground = new SolidColorBrush(Colors.Gray);
                        this.playerxiazhuopsite.labelCall.Foreground = new SolidColorBrush(Colors.Gray);
                        this.playerxiazhuopsite.labelRaise.Foreground = new SolidColorBrush(Colors.Gray);
                    }
                    else
                    {
                        this.playerxiazhu.labelCall.Foreground = new SolidColorBrush(Colors.White);
                        this.playerxiazhu.labelRaise.Foreground = new SolidColorBrush(Colors.White);
                        this.playerxiazhuopsite.labelCall.Foreground = new SolidColorBrush(Colors.White);
                        this.playerxiazhuopsite.labelRaise.Foreground = new SolidColorBrush(Colors.White);
                    }
                }
            }
            else if(nextPlayerID>0&&nextPlayerID<9)
            {
                maxBetChips = myService.GetPlayerChip().GetMaxBetChipsForLive();
                nextPlayerAllBetChips = myService.GetPlayerChip().GetTurnsBetChipsForNextPlayer(nextPlayerID);
                nextPlayerTurnsLeftChips = myService.GetPlayerChip().GetTurnsLeftBetChipsForNextPlayer(nextPlayerID);

                


                //if (nextPlayerAllBetChips < maxBetChips)
                //{
                //    this.playerxiazhu.labelCheck.Foreground = new SolidColorBrush(Colors.Gray);
                //    this.playerxiazhuopsite.labelCheck.Foreground = new SolidColorBrush(Colors.Gray);
                //}
                //else
                //{
                //    this.playerxiazhu.labelCheck.Foreground = new SolidColorBrush(Colors.White);
                //    this.playerxiazhuopsite.labelCheck.Foreground = new SolidColorBrush(Colors.White);
                //}

                if(nextPlayerTurnsLeftChips<=maxBetChips)
                {
                    this.playerxiazhu.labelCall.Foreground = new SolidColorBrush(Colors.Gray);
                    this.playerxiazhu.labelRaise.Foreground = new SolidColorBrush(Colors.Gray);
                    this.playerxiazhuopsite.labelCall.Foreground = new SolidColorBrush(Colors.Gray);
                    this.playerxiazhuopsite.labelRaise.Foreground = new SolidColorBrush(Colors.Gray);
                }
                else
                {
                    this.playerxiazhu.labelCall.Foreground = new SolidColorBrush(Colors.White);
                    this.playerxiazhu.labelRaise.Foreground = new SolidColorBrush(Colors.White);
                    this.playerxiazhuopsite.labelCall.Foreground = new SolidColorBrush(Colors.White);
                    this.playerxiazhuopsite.labelRaise.Foreground = new SolidColorBrush(Colors.White);
                }

                if (maxBetChips == 0)
                {
                    this.playerxiazhu.labelCheck.Foreground = new SolidColorBrush(Colors.White);
                    this.playerxiazhuopsite.labelCheck.Foreground = new SolidColorBrush(Colors.White);

                    this.playerxiazhuopsite.labelCall.Foreground = new SolidColorBrush(Colors.Gray);

                    this.playerxiazhu.labelRaise.Content = "  3 Bet(加注)";
                    this.playerxiazhuopsite.labelRaise.Content = "  3 Bet(加注)";
                }
                else
                {
                    this.playerxiazhu.labelCheck.Foreground = new SolidColorBrush(Colors.Gray);
                    this.playerxiazhuopsite.labelCheck.Foreground = new SolidColorBrush(Colors.Gray);

                    this.playerxiazhuopsite.labelCall.Foreground = new SolidColorBrush(Colors.White);

                    this.playerxiazhu.labelRaise.Content = "  3 Raise(加注)";
                    this.playerxiazhuopsite.labelRaise.Content = "  3 Raise(加注)";
                }


            }
            



            BitmapImage headBackDefault = new BitmapImage(new Uri("/Resources/HeadBack.png", UriKind.Relative));
            BitmapImage headBackActive = new BitmapImage(new Uri("/Resources/ActiveHeadBack.png", UriKind.Relative));

            //仅剩余一名玩家，切有allin的玩家
            if(nextPlayerID==-100)
            {
                string s1 = "pack://application:,,,/Resources/Gray_1.png";
                string s2 = "pack://application:,,,/Resources/Gray_2.png";
                string s3 = "pack://application:,,,/Resources/Gray_3.png";
                if (card1.Source.ToString() != s1 && card4.Source.ToString() != s2 && card5.Source.ToString() != s3)
                {
                    this.heguan.Visibility = Visibility.Visible;
                    this.heguan.grid2.Visibility = Visibility.Visible;
                    SetHeGuanGainComboxState();
                    this.heguan.grid1.Visibility = Visibility.Hidden;
                    this.heguan.grid3.Visibility = Visibility.Hidden;
                    this.pictureBack.Source = headBackActive;

                    this.heguan.b2.Background = new ImageBrush
                    {
                        ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
                    };

                    this.heguan.b1.Background = null;
                    this.heguan.b3.Background = null;
                }
                else
                {
                    this.heguan.Visibility = Visibility.Visible;
                    this.heguan.grid1.Visibility = Visibility.Visible;
                    this.heguan.grid2.Visibility = Visibility.Hidden;
                    this.heguan.grid3.Visibility = Visibility.Hidden;

                    this.heguan.SetPublicCardState();
                }
            }

            if(nextPlayerID>-2)
            {
                this.pictureBack.Source = headBackDefault;
                this.pictureBack1.Source = headBackDefault;
                this.pictureBack2.Source = headBackDefault;
                this.pictureBack3.Source = headBackDefault;
                this.pictureBack4.Source = headBackDefault;
                this.pictureBack5.Source = headBackDefault;
                this.pictureBack6.Source = headBackDefault;
                this.pictureBack7.Source = headBackDefault;
                this.pictureBack8.Source = headBackDefault;
            }
            
            
            switch(nextPlayerID)
            {
                case -1:
                    this.heguan.Visibility = Visibility.Visible;
                    this.heguan.grid2.Visibility = Visibility.Visible;
                    SetHeGuanGainComboxState();
                    this.heguan.grid1.Visibility = Visibility.Hidden;
                    this.heguan.grid3.Visibility = Visibility.Hidden;
                    this.pictureBack.Source = headBackActive;

                    this.heguan.b2.Background = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
                        };

                        this.heguan.b1.Background = null;
                        this.heguan.b3.Background = null;
                    break;
                case 0:
                    if(this.Operation1.Text.Equals("大盲"))
                    {
                        playerxiazhuopsite.playerID = 1;
                        playerxiazhuopsite.Visibility = Visibility.Visible;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhu.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Margin = new Thickness(380, 100, 0, 0);

                        this.pictureBack1.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation2.Text.Equals("大盲"))
                    {
                        playerxiazhuopsite.playerID = 2;
                        playerxiazhuopsite.Visibility = Visibility.Visible;
                        playerxiazhu.Visibility = Visibility.Hidden;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Margin = new Thickness(602, 152, 0, 0);

                        this.pictureBack2.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation3.Text.Equals("大盲"))
                    {
                        playerxiazhuopsite.playerID = 3;
                        playerxiazhuopsite.Visibility = Visibility.Visible;
                        playerxiazhu.Visibility = Visibility.Hidden;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Margin = new Thickness(598, 442, 0, 0);

                        this.pictureBack3.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation4.Text.Equals("大盲"))
                    {
                        playerxiazhu.playerID = 4;
                        playerxiazhu.Visibility = Visibility.Visible;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Visibility = Visibility.Hidden;
                        playerxiazhu.Margin = new Thickness(734, 599, -16, -17);

                        this.pictureBack4.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation5.Text.Equals("大盲"))
                    {
                        playerxiazhu.playerID = 5;
                        playerxiazhu.Visibility = Visibility.Visible;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Visibility = Visibility.Hidden;
                        playerxiazhu.Margin = new Thickness(386, 599, 0, -17);

                        this.pictureBack5.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation6.Text.Equals("大盲"))
                    {
                        playerxiazhu.playerID = 6;
                        playerxiazhu.Visibility = Visibility.Visible;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Visibility = Visibility.Hidden;
                        playerxiazhu.Margin = new Thickness(138, 503, 0, 0);

                        this.pictureBack6.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation7.Text.Equals("大盲"))
                    {
                        playerxiazhu.playerID = 7;
                        playerxiazhu.Visibility = Visibility.Visible;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Visibility = Visibility.Hidden;
                        playerxiazhu.Margin = new Thickness(126, 205, 0, 0);

                        this.pictureBack7.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation8.Text.Equals("大盲"))
                    {
                        playerxiazhu.playerID = 8;
                        playerxiazhu.Visibility = Visibility.Visible;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Visibility = Visibility.Hidden;
                        playerxiazhu.Margin = new Thickness(346, 106, 0, 0);

                        this.pictureBack8.Source = headBackActive;
                        return;
                    }
                    BitmapImage publicOld1 = new BitmapImage(new Uri("/Resources/Gray_1.png", UriKind.Relative));
                    BitmapImage publicOld2 = new BitmapImage(new Uri("/Resources/Gray_2.png", UriKind.Relative));
                    BitmapImage publicOld3 = new BitmapImage(new Uri("/Resources/Gray_3.png", UriKind.Relative));
                    string s1 = "pack://application:,,,/Resources/Gray_1.png";
                    string s2 = "pack://application:,,,/Resources/Gray_2.png";
                    string s3 = "pack://application:,,,/Resources/Gray_3.png";
                    if (card1.Source.ToString() == s1 || card4.Source.ToString() == s2 || card5.Source.ToString() == s3)
                    {
                        this.heguan.Visibility = Visibility.Visible;
                        this.heguan.grid1.Visibility = Visibility.Visible;
                        this.heguan.grid2.Visibility = Visibility.Hidden;
                        this.heguan.grid3.Visibility = Visibility.Hidden;

                        this.heguan.SetPublicCardState();
                    }
                    else
                    {
                        this.heguan.Visibility = Visibility.Visible;
                        this.heguan.grid2.Visibility = Visibility.Visible;
                        SetHeGuanGainComboxState();
                        this.heguan.grid1.Visibility = Visibility.Hidden;
                        this.heguan.grid3.Visibility = Visibility.Hidden;

                        this.heguan.b2.Background = new ImageBrush
                        {
                            ImageSource = new BitmapImage(new Uri("pack://application:,,,/Resources/SelectedText.png"))
                        };

                        this.heguan.b1.Background = null;
                        this.heguan.b3.Background = null;
                    }

                    this.pictureBack.Source = headBackActive;

                    break;
                case 1:
                    playerxiazhuopsite.playerID = 1;
                        playerxiazhuopsite.Visibility = Visibility.Visible;
                        //heguan.Visibility = Visibility.Hidden;
                        playerxiazhu.Visibility = Visibility.Hidden;
                        playerxiazhuopsite.Margin = new Thickness(380, 100, 0, 0);

                        this.pictureBack1.Source = headBackActive;

                    break;
                case 2:
                    playerxiazhuopsite.playerID = 2;
                    playerxiazhuopsite.Visibility = Visibility.Visible;
                    playerxiazhu.Visibility = Visibility.Hidden;
                    //heguan.Visibility = Visibility.Hidden;
                    playerxiazhuopsite.Margin = new Thickness(602, 152, 0, 0);

                    this.pictureBack2.Source = headBackActive;
                    break;
                case 3:
                    playerxiazhuopsite.playerID = 3;
            playerxiazhuopsite.Visibility = Visibility.Visible;
            playerxiazhu.Visibility = Visibility.Hidden;
            //heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Margin = new Thickness(598, 442, 0, 0);

            this.pictureBack3.Source = headBackActive;
                    break;
                case 4:
                    playerxiazhu.playerID = 4;
            playerxiazhu.Visibility = Visibility.Visible;
            //heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(734, 599, -16, -17);

            this.pictureBack4.Source = headBackActive;
                    break;
                case 5:
                    playerxiazhu.playerID = 5;
            playerxiazhu.Visibility = Visibility.Visible;
            //heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(386, 599, 0, -17);

            this.pictureBack5.Source = headBackActive;
                    break;
                case 6:
                    playerxiazhu.playerID = 6;
            playerxiazhu.Visibility = Visibility.Visible;
            //heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(138, 503, 0, 0);

            this.pictureBack6.Source = headBackActive;
                    break;
                case 7:
                    playerxiazhu.playerID = 7;
            playerxiazhu.Visibility = Visibility.Visible;
            //heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(126, 205, 0, 0);

            this.pictureBack7.Source = headBackActive;
                    break;
                case 8:
                    playerxiazhu.playerID = 8;
            playerxiazhu.Visibility = Visibility.Visible;
            //heguan.Visibility = Visibility.Hidden;
            playerxiazhuopsite.Visibility = Visibility.Hidden;
            playerxiazhu.Margin = new Thickness(346, 106, 0, 0);

            this.pictureBack8.Source = headBackActive;
                    break;
                default:
                    return;
            }
        }

        private void LoadHeadPicture()
        {
            DataSet headPicSet = myService.GetRecord().GetRecordForLive();
            if (headPicSet.Tables.Count != 0)
            {
                DataTable headPictureTable = headPicSet.Tables[0];
                if(headPictureTable.Rows.Count!=0)
                {
                    string headPic1 = headPictureTable.Rows[0]["HeadPicture1"].ToString();
                    string headPic2 = headPictureTable.Rows[0]["HeadPicture2"].ToString();
                    string headPic3 = headPictureTable.Rows[0]["HeadPicture3"].ToString();
                    string headPic4 = headPictureTable.Rows[0]["HeadPicture4"].ToString();
                    string headPic5 = headPictureTable.Rows[0]["HeadPicture5"].ToString();
                    string headPic6 = headPictureTable.Rows[0]["HeadPicture6"].ToString();
                    string headPic7 = headPictureTable.Rows[0]["HeadPicture7"].ToString();
                    string headPic8 = headPictureTable.Rows[0]["HeadPicture8"].ToString();
                    if (headPic1.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic1 + ".png", UriKind.Relative));
                        picture1.Source = headPicSource;
                    }
                    if (headPic2.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic2 + ".png", UriKind.Relative));
                        picture2.Source = headPicSource;
                    }
                    if (headPic3.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic3 + ".png", UriKind.Relative));
                        picture3.Source = headPicSource;
                    }
                    if (headPic4.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic4 + ".png", UriKind.Relative));
                        picture4.Source = headPicSource;
                    }
                    if (headPic5.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic5 + ".png", UriKind.Relative));
                        picture5.Source = headPicSource;
                    }
                    if (headPic6.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic6 + ".png", UriKind.Relative));
                        picture6.Source = headPicSource;
                    }
                    if (headPic7.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic7 + ".png", UriKind.Relative));
                        picture7.Source = headPicSource;
                    }
                    if (headPic8.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic8 + ".png", UriKind.Relative));
                        picture8.Source = headPicSource;
                    }
                }
                

            }

        }

        private void LoadDesktop()
        {
            //从服务器读取Operation，显示Player状态
            ServiceBet.BetSoapClient serviceBet = myService.GetBet();

            //在第一轮执行撤销操作时，显示撤消后的Player状态
            this.Operation1.Text = "等待";
            this.Operation1.Text = "等待";
            this.Operation2.Text = "等待";
            this.Operation3.Text = "等待";
            this.Operation4.Text = "等待";
            this.Operation5.Text = "等待";
            this.Operation6.Text = "等待";
            this.Operation7.Text = "等待";
            this.Operation8.Text = "等待";
            Bet1.Text = "";
            Bet2.Text = "";
            Bet3.Text = "";
            Bet4.Text = "";
            Bet5.Text = "";
            Bet6.Text = "";
            Bet7.Text = "";
            Bet8.Text = "";
            DataSet set = myService.GetPlayerChip().GetStartChipsForJudgeShow();
            if(set.Tables.Count==0)
            {
                return;
            }
            DataTable startChipsTable = set.Tables[0];
            for (int j = 0; j < startChipsTable.Rows.Count; j++)
            {
                int playerid = int.Parse(startChipsTable.Rows[j]["PlayerID"].ToString());
                string startChips = startChipsTable.Rows[j]["StartChips"].ToString();
                if (playerid == 1)
                    this.yue1.Text = startChips;
                if (playerid == 2)
                    this.yue2.Text = startChips;
                if (playerid == 3)
                    this.yue3.Text = startChips;
                if (playerid == 4)
                    this.yue4.Text = startChips;
                if (playerid == 5)
                    this.yue5.Text = startChips;
                if (playerid == 6)
                    this.yue6.Text = startChips;
                if (playerid == 7)
                    this.yue7.Text = startChips;
                if (playerid == 8)
                    this.yue8.Text = startChips;

            }



            DataSet operationTable = serviceBet.GetBetForLive();

            if (operationTable.Tables.Count == 0)
                return;

            //显示每一轮所下的筹码
            //DataTable betTable = operationTable.Tables[0];
            //for (int i = 0; i < betTable.Rows.Count;i++)
            //{
            //    int playerID = int.Parse(operationTable.Tables[0].Rows[i]["PlayerID"].ToString());
            //}

            //新一轮开始时隐藏池底的筹码
            if(operationTable.Tables[0].Rows.Count==0)
            {
                this.ChipsInPool1.Visibility = Visibility.Hidden;
                this.ChipsInPool2.Visibility = Visibility.Hidden;
                this.ChipsInPool3.Visibility = Visibility.Hidden;
                this.ChipsInPool4.Visibility = Visibility.Hidden;
                this.ChipsInPool5.Visibility = Visibility.Hidden;
                this.ChipsInPool6.Visibility = Visibility.Hidden;
                this.ChipsInPool7.Visibility = Visibility.Hidden;
                this.imageChips1.Visibility = Visibility.Hidden;
                this.imageChips2.Visibility = Visibility.Hidden;
                this.imageChips3.Visibility = Visibility.Hidden;
                this.imageChips4.Visibility = Visibility.Hidden;
                this.imageChips5.Visibility = Visibility.Hidden;
                this.imageChips6.Visibility = Visibility.Hidden;
                this.imageChips7.Visibility = Visibility.Hidden;
            }

            for(int i=0;i<operationTable.Tables[0].Rows.Count;i++)
            {
                int playerID = int.Parse(operationTable.Tables[0].Rows[i]["PlayerID"].ToString());
                string operation = operationTable.Tables[0].Rows[i]["Operation"].ToString();
                string chipsBet = operationTable.Tables[0].Rows[i]["ChipsBet"].ToString();
                string chipsInHand = operationTable.Tables[0].Rows[i]["ChipsInHand"].ToString();


               switch(playerID)
               {
                   case 0:
                       Bet1.Text = "";
                       Bet2.Text = "";
                       Bet3.Text = "";
                       Bet4.Text = "";
                       Bet5.Text = "";
                       Bet6.Text = "";
                       Bet7.Text = "";
                       Bet8.Text = "";
                       if (operation.Equals("贷款") || operation.Equals("判定"))
                       {
                           

                           this.Operation1.Text = "等待";
                           this.Operation1.Text = "等待";
                           this.Operation2.Text = "等待";
                           this.Operation3.Text = "等待";
                           this.Operation4.Text = "等待";
                           this.Operation5.Text = "等待";
                           this.Operation6.Text = "等待";
                           this.Operation7.Text = "等待";
                           this.Operation8.Text = "等待";
                           
                           //DataSet set = new ServicePlayerChip.PlayerChipSoapClient().GetStartChipsForJudgeShow();
                           //DataTable startChipsTable=set.Tables[0];
                           for(int j=0;j<startChipsTable.Rows.Count;j++)
                           {
                               int playerid = int.Parse(startChipsTable.Rows[j]["PlayerID"].ToString());
                               string startChips=startChipsTable.Rows[j]["StartChips"].ToString();
                               if (playerid == 1)
                                   this.yue1.Text = startChips;
                               if (playerid == 2)
                                   this.yue2.Text = startChips;
                               if (playerid == 3)
                                   this.yue3.Text = startChips;
                               if (playerid == 4)
                                   this.yue4.Text = startChips;
                               if (playerid == 5)
                                   this.yue5.Text = startChips;
                               if (playerid == 6)
                                   this.yue6.Text = startChips;
                               if (playerid == 7)
                                   this.yue7.Text = startChips;
                               if (playerid == 8)
                                   this.yue8.Text = startChips;

                           }
                       }
                       else if(operation.Equals("发牌"))
                       {
                           if (!this.Operation1.Text.ToString().Equals("弃牌") && !this.Operation1.Text.ToString().Equals("全下"))
                               this.Operation1.Text = "等待";
                           if (!this.Operation2.Text.ToString().Equals("弃牌") && !this.Operation2.Text.ToString().Equals("全下"))
                               this.Operation2.Text = "等待";
                           if (!this.Operation3.Text.ToString().Equals("弃牌") && !this.Operation3.Text.ToString().Equals("全下"))
                               this.Operation3.Text = "等待";
                           if (!this.Operation4.Text.ToString().Equals("弃牌") && !this.Operation4.Text.ToString().Equals("全下"))
                               this.Operation4.Text = "等待";
                           if (!this.Operation5.Text.ToString().Equals("弃牌") && !this.Operation5.Text.ToString().Equals("全下"))
                               this.Operation5.Text = "等待";
                           if (!this.Operation6.Text.ToString().Equals("弃牌") && !this.Operation6.Text.ToString().Equals("全下"))
                               this.Operation6.Text = "等待";
                           if (!this.Operation7.Text.ToString().Equals("弃牌") && !this.Operation7.Text.ToString().Equals("全下"))
                               this.Operation7.Text = "等待";
                           if (!this.Operation8.Text.ToString().Equals("弃牌") && !this.Operation8.Text.ToString().Equals("全下"))
                               this.Operation8.Text = "等待";

                           //显示池底的筹码
                           string chipsInPool = myService.GetPlayerChip().GetChipsInPoolForLive(chipsBet);
                           if (chipsInPool.Length != 0)
                           {
                               string[] eachChips = chipsInPool.Split('&');
                               int pools = eachChips.Length;
                               if (pools > 1)
                               {
                                   this.imageChips1.Visibility = Visibility.Visible;
                                   this.ChipsInPool1.Visibility = Visibility.Visible;
                                   this.ChipsInPool1.Text = eachChips[1];
                               }
                               if (pools > 2)
                               {
                                   this.imageChips2.Visibility = Visibility.Visible;
                                   this.ChipsInPool2.Visibility = Visibility.Visible;
                                   this.ChipsInPool2.Text = eachChips[2];
                               }
                               if (pools > 3)
                               {
                                   this.imageChips3.Visibility = Visibility.Visible;
                                   this.ChipsInPool3.Visibility = Visibility.Visible;
                                   this.ChipsInPool3.Text = eachChips[3];
                               }
                               if (pools > 4)
                               {
                                   this.imageChips4.Visibility = Visibility.Visible;
                                   this.ChipsInPool4.Visibility = Visibility.Visible;
                                   this.ChipsInPool4.Text = eachChips[4];
                               }
                               if (pools > 5)
                               {
                                   this.imageChips5.Visibility = Visibility.Visible;
                                   this.ChipsInPool5.Visibility = Visibility.Visible;
                                   this.ChipsInPool5.Text = eachChips[5];
                               }
                               if (pools > 6)
                               {
                                   this.imageChips6.Visibility = Visibility.Visible;
                                   this.ChipsInPool6.Visibility = Visibility.Visible;
                                   this.ChipsInPool6.Text = eachChips[6];
                               }
                               if (pools > 7)
                               {
                                   this.imageChips7.Visibility = Visibility.Visible;
                                   this.ChipsInPool7.Visibility = Visibility.Visible;
                                   this.ChipsInPool7.Text = eachChips[7];
                               }
                           }

                       }
                       
                       
                       break;
                   case 1 :
                       this.Operation1.Text = operation;
                       this.yue1.Text = chipsInHand;
                       if(!(operation.Equals("弃牌")||operation.Equals("看牌")))
                           Bet1.Text = ":  " + chipsBet;
                       break;
                   case 2:
                       this.Operation2.Text = operation;
                       this.yue2.Text = chipsInHand;
                       if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                           Bet2.Text = ":  " + chipsBet;
                       break;
                   case 3:
                       this.Operation3.Text = operation;
                       this.yue3.Text = chipsInHand;
                       if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                           Bet3.Text = ":  " + chipsBet;
                       break;
                   case 4:
                       this.Operation4.Text = operation;
                       this.yue4.Text = chipsInHand;
                       if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                           Bet4.Text = ":  " + chipsBet;
                       break;
                   case 5:
                       this.Operation5.Text = operation;
                       this.yue5.Text = chipsInHand;
                       if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                           Bet5.Text = ":  " + chipsBet;
                       break;
                   case 6:
                       this.Operation6.Text = operation;
                       this.yue6.Text = chipsInHand;
                       if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                           Bet6.Text = ":  " + chipsBet;
                       break;
                   case 7:
                       this.Operation7.Text = operation;
                       this.yue7.Text = chipsInHand;
                       if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                           Bet7.Text = ":  " + chipsBet;
                       break;
                   case 8:
                       this.Operation8.Text = operation;
                       this.yue8.Text = chipsInHand;
                       if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                           Bet8.Text = ":  " + chipsBet;
                       break;
               }
               
            }

            

        }

        //确定大小盲的位置
        private void DeterminDaXiaomang()
        {
            BitmapImage headBackDefault = new BitmapImage(new Uri("/Resources/HeadBack.png", UriKind.Relative));
            BitmapImage headBackActive = new BitmapImage(new Uri("/Resources/ActiveHeadBack.png", UriKind.Relative));

            ServiceBet.BetSoapClient serviceBet = myService.GetBet();
            int xiaomangPlayerID = serviceBet.GetXiaoMangPlayerID();
            int damangPlayerID = serviceBet.GetDaMangPlayerID();
            //if(xiaomangPlayerID==-1)
            //{
            //    this.heguan.Visibility = Visibility.Visible;
            //    this.heguan.grid2.Visibility = Visibility.Visible;
            //    this.heguan.grid1.Visibility = Visibility.Hidden;
            //    this.heguan.grid3.Visibility = Visibility.Hidden;
            //}
            if (xiaomangPlayerID > 0&&xiaomangPlayerID<9)
            {
                

                this.pictureBack.Source = headBackDefault;
                this.pictureBack1.Source = headBackDefault;
                this.pictureBack2.Source = headBackDefault;
                this.pictureBack3.Source = headBackDefault;
                this.pictureBack4.Source = headBackDefault;
                this.pictureBack5.Source = headBackDefault;
                this.pictureBack6.Source = headBackDefault;
                this.pictureBack7.Source = headBackDefault;
                this.pictureBack8.Source = headBackDefault;

                this.xiaomang.Visibility = Visibility.Visible;
                this.damang.Visibility = Visibility.Hidden;
                //this.heguan.Dispatcher.Invoke(new Action(() => { this.heguan.Visibility = Visibility.Hidden; }));
                this.privateCard.Visibility = Visibility.Hidden;
                this.playerxiazhu.Visibility = Visibility.Hidden;
                this.playerxiazhuopsite.Visibility = Visibility.Hidden;

                switch (xiaomangPlayerID)
                {
                    case 1:
                        xiaomang.playerID = 1;
                        this.xiaomang.Margin = new Thickness(654, 0, 0, 0);

                        this.pictureBack1.Source = headBackActive;
                        break;
                    case 2:
                        xiaomang.playerID = 2;
                        this.xiaomang.Margin = new Thickness(864, 79, 0, 0);

                        this.pictureBack2.Source = headBackActive;
                        break;
                    case 3:
                        xiaomang.playerID = 3;
                        this.xiaomang.Margin = new Thickness(864, 373, 0, 0);

                        this.pictureBack3.Source = headBackActive;
                        break;
                    case 4:
                        xiaomang.playerID = 4;
                        this.xiaomang.Margin = new Thickness(627, 478, 0, 0);

                        this.pictureBack4.Source = headBackActive;
                        break;
                    case 5:
                        xiaomang.playerID = 5;
                        this.xiaomang.Margin = new Thickness(268, 486, 0, 0);

                        this.pictureBack5.Source = headBackActive;
                        break;
                    case 6:
                        xiaomang.playerID = 6;
                        this.xiaomang.Margin = new Thickness(24, 376, 0, 0);

                        this.pictureBack6.Source = headBackActive;
                        break;
                    case 7:
                        xiaomang.playerID = 7;
                        this.xiaomang.Margin = new Thickness(24, 83, 0, 0);

                        this.pictureBack7.Source = headBackActive;
                        break;
                    case 8:
                        xiaomang.playerID = 8;
                        this.xiaomang.Margin = new Thickness(235, 0, 0, 0);

                        this.pictureBack8.Source = headBackActive;
                        break;
                    default:
                        this.xiaomang.Visibility = Visibility.Hidden; 
                        break;
                }
                //this.xiaomang.textboxChips.Focus();
            }
            else
                this.xiaomang.Visibility = Visibility.Hidden;
            if (damangPlayerID != 0)
            {
                this.pictureBack.Source = headBackDefault;
                this.pictureBack1.Source = headBackDefault;
                this.pictureBack2.Source = headBackDefault;
                this.pictureBack3.Source = headBackDefault;
                this.pictureBack4.Source = headBackDefault;
                this.pictureBack5.Source = headBackDefault;
                this.pictureBack6.Source = headBackDefault;
                this.pictureBack7.Source = headBackDefault;
                this.pictureBack8.Source = headBackDefault;

                this.xiaomang.Visibility = Visibility.Hidden;
                this.damang.Visibility = Visibility.Visible;
                //this.heguan.Dispatcher.Invoke(new Action(() => { this.heguan.Visibility = Visibility.Hidden; }));
                this.privateCard.Visibility = Visibility.Hidden; 
                this.playerxiazhu.Visibility = Visibility.Hidden;
                this.playerxiazhuopsite.Visibility = Visibility.Hidden;

                switch (damangPlayerID)
                {
                    case 1:
                        damang.playerID = 1;
                        this.damang.Margin = new Thickness(654, 0, 0, 0);

                        this.pictureBack1.Source = headBackActive;
                        break;
                    case 2:
                        damang.playerID = 2;
                        this.damang.Margin = new Thickness(864, 79, 0, 0);

                        this.pictureBack2.Source = headBackActive;
                        break;
                    case 3:
                        damang.playerID = 3;
                        this.damang.Margin = new Thickness(864, 373, 0, 0);

                        this.pictureBack3.Source = headBackActive;
                        break;
                    case 4:
                        damang.playerID = 4;
                        this.damang.Margin = new Thickness(627, 478, 0, 0);

                        this.pictureBack4.Source = headBackActive;
                        break;
                    case 5:
                        damang.playerID = 5;
                        this.damang.Margin = new Thickness(268, 486, 0, 0);

                        this.pictureBack5.Source = headBackActive;
                        break;
                    case 6:
                        damang.playerID = 6;
                        this.damang.Margin = new Thickness(24, 376, 0, 0);

                        this.pictureBack6.Source = headBackActive;
                        break;
                    case 7:
                        damang.playerID = 7;
                        this.damang.Margin = new Thickness(24, 83, 0, 0);

                        this.pictureBack7.Source = headBackActive;
                        break;
                    case 8:
                        damang.playerID = 8;
                        this.damang.Margin = new Thickness(235, 0, 0, 0);

                        this.pictureBack8.Source = headBackActive;
                        break;
                    default:
                        this.damang.Visibility = Visibility.Hidden;
                        break;
                }
                int damangChips = serviceBet.GetDaMangChips();
                this.damang.TextboxChips.Text = "" + damangChips;
                //this.damang.TextboxChips.Focus();
            }
            else
                this.damang.Visibility = Visibility.Hidden;

            

        }
       

        private void imageBack_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Undo_hover.png", UriKind.Relative));
            imageBack.Source = imagetemp;
        }

        private void imageBack_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Undo.png", UriKind.Relative));
            imageBack.Source = imagetemp;
        }

        private void imageQuit_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Quit_hover.png", UriKind.Relative));
            imageQuit.Source = imagetemp;
        }

        private void imageQuit_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Quit.png", UriKind.Relative));
            imageQuit.Source = imagetemp;
        }

        private void imageBack_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ServiceBet.BetSoapClient serviceBet = myService.GetBet();

                DataSet operationDS = serviceBet.GetBetForLive();


                bool result = serviceBet.UndoPreOperation();

                if (operationDS.Tables.Count != 0)
                {
                    DataTable dt = operationDS.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        if (dt.Rows[dt.Rows.Count - 1]["Operation"].ToString().Equals("发牌") && dt.Rows[dt.Rows.Count - 1]["ChipsBet"].ToString().Equals("1"))
                        {
                            this.heguan.PublicCard1.SelectedIndex = -1;
                            this.heguan.PublicCard1_Copy.SelectedIndex = -1;
                            this.heguan.PublicCard2.SelectedIndex = -1;
                            this.heguan.PublicCard2_Copy.SelectedIndex = -1;
                            this.heguan.PublicCard3.SelectedIndex = -1;
                            this.heguan.PublicCard3_Copy.SelectedIndex = -1;

                        }
                    }
                }
                if (!result)
                    MessageBox.Show("无已完成操作");
            }
            catch
            {

            }
            
        }

       

        private void imageQuit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            
            if (MessageBox.Show("确定结束记录？", "结束", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    StopAllTimer();
                    new MyService().GetRecord().FinishRecord();
                    new AdminMenu().Show();
                    this.Close();
                }
                catch
                {
                    StopAllTimer();
                    new AdminMenu().Show();
                    this.Close();
                }
            }

        }


        private BitmapImage back = new BitmapImage(new Uri("/Resources/HeadBack.png", UriKind.Relative));
        private BitmapImage backHove = new BitmapImage(new Uri("/Resources/HeadBack_hover.png", UriKind.Relative));

        private void pictureBack_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack.Source = backHove;
        }

        private void pictureBack_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack.Source = back;
        }

        private void pictureBack1_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack1.Source = backHove;
        }

        private void pictureBack1_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack1.Source = back;
        }

        private void pictureBack2_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack2.Source = backHove;
        }

        private void pictureBack2_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack2.Source = back;
        }

        private void pictureBack3_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack3.Source = backHove;
        }

        private void pictureBack3_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack3.Source = back;
        }

        private void pictureBack4_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack4.Source = backHove;
        }

        private void pictureBack4_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack4.Source = back;
        }

        private void pictureBack5_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack5.Source = backHove;
        }

        private void pictureBack5_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack5.Source = back;
        }

        private void pictureBack6_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack6.Source = backHove;
        }

        private void pictureBack6_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack6.Source = back;
        }

        private void pictureBack7_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack7.Source = backHove;
        }

        private void pictureBack7_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack7.Source = back;
        }

        private void pictureBack8_MouseEnter(object sender, MouseEventArgs e)
        {
            this.pictureBack8.Source = backHove;
        }

        private void pictureBack8_MouseLeave(object sender, MouseEventArgs e)
        {
            this.pictureBack8.Source = back;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key==Key.Space)
            {
                ServiceBet.BetSoapClient serviceBet = myService.GetBet();

                DataSet operationDS = serviceBet.GetBetForLive();


                bool result = serviceBet.UndoPreOperation();

                if (operationDS.Tables.Count != 0)
                {
                    DataTable dt = operationDS.Tables[0];
                    if (dt.Rows.Count != 0)
                    {
                        if (dt.Rows[dt.Rows.Count - 1]["Operation"].ToString().Equals("发牌") && dt.Rows[dt.Rows.Count - 1]["ChipsBet"].ToString().Equals("1"))
                        {
                            this.heguan.PublicCard1.SelectedIndex = -1;
                            this.heguan.PublicCard1_Copy.SelectedIndex = -1;
                            this.heguan.PublicCard2.SelectedIndex = -1;
                            this.heguan.PublicCard2_Copy.SelectedIndex = -1;
                            this.heguan.PublicCard3.SelectedIndex = -1;
                            this.heguan.PublicCard3_Copy.SelectedIndex = -1;

                        }
                    }
                }
                if (!result)
                    MessageBox.Show("无已完成操作");
            }
        }
    }
}
