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
using System.Windows.Shapes;
using System.Windows.Threading;
using TexasWpfApplication.Common;

namespace TexasWpfApplication.Pages
{
    /// <summary>
    /// GameLive.xaml 的交互逻辑
    /// </summary>
    public partial class GameLive : Window
    {
        private int playerNumber;

        //旁观玩家
        private int playerID = 0;

        private List<Tuple<String, String>> allPrivateCards = new List<Tuple<string, string>>();
        private List<String> allOperations = new List<string>();

        private MyService myService = new MyService();


        private List<Label> operations = new List<Label>();

        public GameLive(int playerid)
        {
            InitializeComponent();
            playerID = playerid;

            operations = new List<Label>()
            {
                Operation1,Operation2,Operation3,Operation4,
                Operation5,Operation6,Operation7,Operation8,
            };
            try
            {
                string pyerID = myService.GetAdministrator().HelloWorld();

            }
            catch
            {
                MessageBox.Show("请连接网络");
                return;
            }
        }

        private void LoadPrivateCardForPangguan()
        {
            try
            {
                string pyerID = myService.GetAdministrator().HelloWorld();

            }
            catch
            {
                return;
            }

            BitmapImage privateUnrecord = new BitmapImage(new Uri("/Resources/Cards/BACK.png", UriKind.Relative));
            var cardList = new List<Image>()
            {
                card11,card12,
                card21,card22,
                card31,card32,
                card41,card42,
                card51,card52,
                card61,card62,
                card71,card72,
                card81,card82,
            };
            foreach (var cardImage in cardList)
            {
                cardImage.Source = privateUnrecord;
            }
            ServiceCard.CardSoapClient privatecardservice = myService.GetCard();
            DataSet privateCardSet = privatecardservice.GetPrivateCardByPlayerID(playerID);
            if (privateCardSet.Tables.Count != 0)
            {
                DataTable tablePrivateCard = privateCardSet.Tables[0];
                if (tablePrivateCard.Rows.Count != 0)
                {
                    string recordcard1 = tablePrivateCard.Rows[0]["FirstCard"].ToString();
                    string recordcard2 = tablePrivateCard.Rows[0]["SecondCard"].ToString();

                    BitmapImage privaterecord1 = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                    BitmapImage privaterecord2 = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                    if (recordcard1.Length != 0)
                        privaterecord1 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard1 + ".png", UriKind.Relative));
                    if (recordcard2.Length != 0)
                        privaterecord2 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard2 + ".png", UriKind.Relative));
                    //BitmapImage privaterecord1 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard1 + ".png", UriKind.Relative));
                    //BitmapImage privaterecord2 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard2 + ".png", UriKind.Relative));
                    switch (playerID)
                    {
                        case 1:
                            this.card11.Source = privaterecord1;
                            this.card12.Source = privaterecord2;
                            break;
                        case 2:
                            this.card21.Source = privaterecord1;
                            this.card22.Source = privaterecord2;
                            break;
                        case 3:
                            this.card31.Source = privaterecord1;
                            this.card32.Source = privaterecord2;
                            break;
                        case 4:
                            this.card41.Source = privaterecord1;
                            this.card42.Source = privaterecord2;
                            break;
                        case 5:
                            this.card51.Source = privaterecord1;
                            this.card52.Source = privaterecord2;
                            break;
                        case 6:
                            this.card61.Source = privaterecord1;
                            this.card62.Source = privaterecord2;
                            break;
                        case 7:
                            this.card71.Source = privaterecord1;
                            this.card72.Source = privaterecord2;
                            break;
                        case 8:
                            this.card81.Source = privaterecord1;
                            this.card82.Source = privaterecord2;
                            break;
                    }
                }
                else
                {
                    switch (playerID)
                    {
                        case 1:
                            this.card11.Source = privateUnrecord;
                            this.card12.Source = privateUnrecord;
                            break;
                        case 2:
                            this.card21.Source = privateUnrecord;
                            this.card22.Source = privateUnrecord;
                            break;
                        case 3:
                            this.card31.Source = privateUnrecord;
                            this.card32.Source = privateUnrecord;
                            break;
                        case 4:
                            this.card41.Source = privateUnrecord;
                            this.card42.Source = privateUnrecord;
                            break;
                        case 5:
                            this.card51.Source = privateUnrecord;
                            this.card52.Source = privateUnrecord;
                            break;
                        case 6:
                            this.card61.Source = privateUnrecord;
                            this.card62.Source = privateUnrecord;
                            break;
                        case 7:
                            this.card71.Source = privateUnrecord;
                            this.card72.Source = privateUnrecord;
                            break;
                        case 8:
                            this.card81.Source = privateUnrecord;
                            this.card82.Source = privateUnrecord;
                            break;
                    }
                }
            }

        }

        public void ShowPlayer()
        {
            try
            {
                string pyerID = myService.GetAdministrator().HelloWorld();

            }
            catch
            {
                return;
            }
            picture1.Visibility = Visibility.Visible;
            Operation1.Visibility = Visibility.Visible;
            label1.Visibility = Visibility.Visible;
            yue1.Visibility = Visibility.Visible;
            card11.Visibility = Visibility.Visible;
            card12.Visibility = Visibility.Visible;
            Bet1.Visibility = Visibility.Visible;
            this.pictureBack1.Visibility = Visibility.Visible;

            this.PlayerLabel1.Visibility = Visibility.Visible;
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
            if (playerNumber >= 4)
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

        private DispatcherTimer timer = new DispatcherTimer();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += theout;
            timer.Start();
        }


        public void theout(object source, EventArgs e)
        {
            //从数据库读取privateCard，显示私牌 
            if (playerID != 0)
                LoadPrivateCardForPangguan();
            LoadDesktop();
            LoadHeadPicture();

            DeterminNextPlayer();

            if (this.Operation1.Content.ToString().Equals("弃牌"))
                this.picture1.Opacity = 0.1;
            else
                this.picture1.Opacity = 1;

            if (this.Operation2.Content.ToString().Equals("弃牌"))
                this.picture2.Opacity = 0.1;
            else
                this.picture2.Opacity = 1;

            if (this.Operation3.Content.ToString().Equals("弃牌"))
                this.picture3.Opacity = 0.1;
            else
                this.picture3.Opacity = 1;

            if (this.Operation4.Content.ToString().Equals("弃牌"))
                this.picture4.Opacity = 0.1;
            else
                this.picture4.Opacity = 1;

            if (this.Operation5.Content.ToString().Equals("弃牌"))
                this.picture5.Opacity = 0.1;
            else
                this.picture5.Opacity = 1;

            if (this.Operation6.Content.ToString().Equals("弃牌"))
                this.picture6.Opacity = 0.1;
            else
                this.picture6.Opacity = 1;

            if (this.Operation7.Content.ToString().Equals("弃牌"))
                this.picture7.Opacity = 0.1;
            else
                this.picture7.Opacity = 1;

            if (this.Operation8.Content.ToString().Equals("弃牌"))
                this.picture8.Opacity = 0.1;
            else
                this.picture8.Opacity = 1;
        }

        private void DeterminNextPlayer()
        {
            try
            {
                string pyerID = myService.GetAdministrator().HelloWorld();

            }
            catch
            {
                return;
            }

            int nextPlayerID = myService.GetBet().GetNextPlayerIDForLive1();


            if (((nextPlayerID == 0) && (!(Operation1.Content.ToString().Equals("大盲") || Operation2.Content.ToString().Equals("大盲") || Operation3.Content.ToString().Equals("大盲") || Operation4.Content.ToString().Equals("大盲") || Operation5.Content.ToString().Equals("大盲") || Operation6.Content.ToString().Equals("大盲") || Operation7.Content.ToString().Equals("大盲") || Operation8.Content.ToString().Equals("大盲")))) || nextPlayerID == -1)
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
                string playerChipsInPool = myService.GetPlayerChip().GetPlayerChipsInPoolForLive(chipsBet);

                if (chipsInPool.Length != 0)
                {
                    string[] eachChipsPlayer = playerChipsInPool.Split('&');
                    int players = eachChipsPlayer.Length;


                    string[] eachChips = chipsInPool.Split('&');
                    int pools = eachChips.Length;
                    if (pools > 1)
                    {
                        this.imageChips1.Visibility = Visibility.Visible;
                        this.ChipsInPool1.Visibility = Visibility.Visible;
                        this.ChipsInPool1.Content = eachChips[1];
                    }
                    if (pools > 2)
                    {
                        this.imageChips2.Visibility = Visibility.Visible;
                        this.ChipsInPool2.Visibility = Visibility.Visible;
                        this.ChipsInPool2.Content = eachChips[2];

                        this.chipsInPool.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChips1.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum1.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsPlayer1.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum1.Text = eachChips[1];
                        this.chipsInPool.DetailChipsPlayer1.Text = eachChipsPlayer[1];

                        this.chipsInPool.DetailChips2.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum2.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsPlayer2.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum2.Text = eachChips[2];
                        this.chipsInPool.DetailChipsPlayer2.Text = eachChipsPlayer[2];
                    }
                    if (pools > 3)
                    {
                        this.imageChips3.Visibility = Visibility.Visible;
                        this.ChipsInPool3.Visibility = Visibility.Visible;
                        this.ChipsInPool3.Content = eachChips[3];

                        this.chipsInPool.DetailChips3.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum3.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsPlayer3.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum3.Text = eachChips[3];
                        this.chipsInPool.DetailChipsPlayer3.Text = eachChipsPlayer[3];
                    }
                    if (pools > 4)
                    {
                        this.imageChips4.Visibility = Visibility.Visible;
                        this.ChipsInPool4.Visibility = Visibility.Visible;
                        this.ChipsInPool4.Content = eachChips[4];

                        this.chipsInPool.DetailChips4.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum4.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsPlayer4.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum4.Text = eachChips[4];
                        this.chipsInPool.DetailChipsPlayer4.Text = eachChipsPlayer[4];
                    }
                    if (pools > 5)
                    {
                        this.imageChips5.Visibility = Visibility.Visible;
                        this.ChipsInPool5.Visibility = Visibility.Visible;
                        this.ChipsInPool5.Content = eachChips[5];

                        this.chipsInPool.DetailChips5.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum5.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsPlayer5.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum5.Text = eachChips[5];
                        this.chipsInPool.DetailChipsPlayer5.Text = eachChipsPlayer[5];
                    }
                    if (pools > 6)
                    {
                        this.imageChips6.Visibility = Visibility.Visible;
                        this.ChipsInPool6.Visibility = Visibility.Visible;
                        this.ChipsInPool6.Content = eachChips[6];

                        this.chipsInPool.DetailChips6.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum6.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsPlayer6.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum6.Text = eachChips[6];
                        this.chipsInPool.DetailChipsPlayer6.Text = eachChipsPlayer[6];
                    }
                    if (pools > 7)
                    {
                        this.imageChips7.Visibility = Visibility.Visible;
                        this.ChipsInPool7.Visibility = Visibility.Visible;
                        this.ChipsInPool7.Content = eachChips[7];

                        this.chipsInPool.DetailChips7.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum7.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsPlayer7.Visibility = Visibility.Visible;
                        this.chipsInPool.DetailChipsNum7.Text = eachChips[7];
                        this.chipsInPool.DetailChipsPlayer7.Text = eachChipsPlayer[7];
                    }
                }
            }
            //隐藏chips气泡
            else
            {
                this.chipsInPool.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChips1.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsNum1.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsPlayer1.Visibility = Visibility.Hidden;

                this.chipsInPool.DetailChips2.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsNum2.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsPlayer2.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChips3.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsNum3.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsPlayer3.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChips4.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsNum4.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsPlayer4.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChips5.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsNum5.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsPlayer5.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChips6.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsNum6.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsPlayer6.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChips7.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsNum7.Visibility = Visibility.Hidden;
                this.chipsInPool.DetailChipsPlayer7.Visibility = Visibility.Hidden;
            }


            int xiaomangPlayerID = myService.GetBet().GetXiaoMangPlayerID();
            int damangPlayerID = myService.GetBet().GetDaMangPlayerID();
            if (xiaomangPlayerID > 0 && xiaomangPlayerID < 9)
                nextPlayerID = xiaomangPlayerID;
            if (damangPlayerID > 0 && damangPlayerID < 9)
                nextPlayerID = damangPlayerID;

            BitmapImage headBackDefault = new BitmapImage(new Uri("/Resources/HeadBack.png", UriKind.Relative));
            BitmapImage headBackActive = new BitmapImage(new Uri("/Resources/ActiveHeadBack.png", UriKind.Relative));

            if (nextPlayerID > -2)
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


            switch (nextPlayerID)
            {
                case -1:
                    this.pictureBack.Source = headBackActive;
                    break;
                case 0:
                    if (this.Operation1.Content.Equals("大盲"))
                    {
                        this.pictureBack1.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation2.Content.Equals("大盲"))
                    {
                        this.pictureBack2.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation3.Content.Equals("大盲"))
                    {
                        this.pictureBack3.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation4.Content.Equals("大盲"))
                    {
                        this.pictureBack4.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation5.Content.Equals("大盲"))
                    {
                        this.pictureBack5.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation6.Content.Equals("大盲"))
                    {
                        this.pictureBack6.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation7.Content.Equals("大盲"))
                    {
                        this.pictureBack7.Source = headBackActive;
                        return;
                    }
                    else if (this.Operation8.Content.Equals("大盲"))
                    {
                        this.pictureBack8.Source = headBackActive;
                        return;
                    }
                    this.pictureBack.Source = headBackActive;

                    break;
                case 1:
                    this.pictureBack1.Source = headBackActive;

                    break;
                case 2:
                    this.pictureBack2.Source = headBackActive;
                    break;
                case 3:
                    this.pictureBack3.Source = headBackActive;
                    break;
                case 4:
                    this.pictureBack4.Source = headBackActive;
                    break;
                case 5:
                    this.pictureBack5.Source = headBackActive;
                    break;
                case 6:
                    this.pictureBack6.Source = headBackActive;
                    break;
                case 7:
                    this.pictureBack7.Source = headBackActive;
                    break;
                case 8:
                    this.pictureBack8.Source = headBackActive;
                    break;
                default:
                    return;
            }
        }

        private void LoadHeadPicture()
        {
            try
            {
                string pyerID = myService.GetAdministrator().HelloWorld();

            }
            catch
            {
                return;
            }

            DataSet headPicSet = myService.GetRecord().GetRecordForLive();
            if (headPicSet.Tables.Count != 0)
            {
                DataTable headPictureTable = headPicSet.Tables[0];
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
                    BitmapImage headPicSourceDefault = new BitmapImage(new Uri("/Resources/Head/default.png", UriKind.Relative));
                    if (headPic1.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic1 + ".png", UriKind.Relative));
                        picture1.Source = headPicSource;
                    }
                    else
                    {
                        picture1.Source = headPicSourceDefault;
                    }

                    if (headPic2.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic2 + ".png", UriKind.Relative));
                        picture2.Source = headPicSource;
                    }
                    else
                    {
                        picture2.Source = headPicSourceDefault;
                    }

                    if (headPic3.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic3 + ".png", UriKind.Relative));
                        picture3.Source = headPicSource;
                    }
                    else
                    {
                        picture3.Source = headPicSourceDefault;
                    }

                    if (headPic4.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic4 + ".png", UriKind.Relative));
                        picture4.Source = headPicSource;
                    }
                    else
                    {
                        picture4.Source = headPicSourceDefault;
                    }

                    if (headPic5.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic5 + ".png", UriKind.Relative));
                        picture5.Source = headPicSource;
                    }
                    else
                    {
                        picture5.Source = headPicSourceDefault;
                    }

                    if (headPic6.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic6 + ".png", UriKind.Relative));
                        picture6.Source = headPicSource;
                    }
                    else
                    {
                        picture6.Source = headPicSourceDefault;
                    }

                    if (headPic7.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic7 + ".png", UriKind.Relative));
                        picture7.Source = headPicSource;
                    }
                    else
                    {
                        picture7.Source = headPicSourceDefault;
                    }

                    if (headPic8.Length != 0)
                    {
                        BitmapImage headPicSource = new BitmapImage(new Uri("/Resources/Head/" + headPic8 + ".png", UriKind.Relative));
                        picture8.Source = headPicSource;
                    }
                    else
                    {
                        picture8.Source = headPicSourceDefault;
                    }
                }


            }

        }

        private void LoadResultPrivateCard()
        {
            for (int i = 0; i < 8; i++)
            {
                if (!allOperations[i].Equals("弃牌"))
                {
                    SetPlayerPrivateCard(i + 1);
                }
            }

        }

        private void SetPlayerPrivateCard(int playerID)
        {
            if (allPrivateCards.Count >= playerID)
            {
                var tuple = allPrivateCards[playerID - 1];
                string recordcard1 = tuple.Item1;
                string recordcard2 = tuple.Item2;
                if (recordcard1 != null && recordcard2 != null)
                {
                    BitmapImage privaterecord1 = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                    BitmapImage privaterecord2 = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                    if (recordcard1.Length != 0)
                        privaterecord1 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard1 + ".png", UriKind.Relative));
                    if (recordcard2.Length != 0)
                        privaterecord2 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard2 + ".png", UriKind.Relative));
                    //BitmapImage privaterecord1 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard1 + ".png", UriKind.Relative));
                    //BitmapImage privaterecord2 = new BitmapImage(new Uri("/Resources/Cards/" + recordcard2 + ".png", UriKind.Relative));
                    switch (playerID)
                    {
                        case 1:
                            this.card11.Source = privaterecord1;
                            this.card12.Source = privaterecord2;
                            break;
                        case 2:
                            this.card21.Source = privaterecord1;
                            this.card22.Source = privaterecord2;
                            break;
                        case 3:
                            this.card31.Source = privaterecord1;
                            this.card32.Source = privaterecord2;
                            break;
                        case 4:
                            this.card41.Source = privaterecord1;
                            this.card42.Source = privaterecord2;
                            break;
                        case 5:
                            this.card51.Source = privaterecord1;
                            this.card52.Source = privaterecord2;
                            break;
                        case 6:
                            this.card61.Source = privaterecord1;
                            this.card62.Source = privaterecord2;
                            break;
                        case 7:
                            this.card71.Source = privaterecord1;
                            this.card72.Source = privaterecord2;
                            break;
                        case 8:
                            this.card81.Source = privaterecord1;
                            this.card82.Source = privaterecord2;
                            break;
                    }
                }
                else
                {
                    BitmapImage privateUnrecord = new BitmapImage(new Uri("/Resources/Cards/BACK.png", UriKind.Relative));
                    switch (playerID)
                    {
                        case 1:
                            this.card11.Source = privateUnrecord;
                            this.card12.Source = privateUnrecord;
                            break;
                        case 2:
                            this.card21.Source = privateUnrecord;
                            this.card22.Source = privateUnrecord;
                            break;
                        case 3:
                            this.card31.Source = privateUnrecord;
                            this.card32.Source = privateUnrecord;
                            break;
                        case 4:
                            this.card41.Source = privateUnrecord;
                            this.card42.Source = privateUnrecord;
                            break;
                        case 5:
                            this.card51.Source = privateUnrecord;
                            this.card52.Source = privateUnrecord;
                            break;
                        case 6:
                            this.card61.Source = privateUnrecord;
                            this.card62.Source = privateUnrecord;
                            break;
                        case 7:
                            this.card71.Source = privateUnrecord;
                            this.card72.Source = privateUnrecord;
                            break;
                        case 8:
                            this.card81.Source = privateUnrecord;
                            this.card82.Source = privateUnrecord;
                            break;
                    }
                }
            }
        }

        private void LoadDesktop()
        {
            try
            {
                string pyerID = myService.GetAdministrator().HelloWorld();

            }
            catch
            {
                return;
            }

            BitmapImage publicOld1 = new BitmapImage(new Uri("/Resources/Gray_1.png", UriKind.Relative));
            BitmapImage publicOld2 = new BitmapImage(new Uri("/Resources/Gray_2.png", UriKind.Relative));
            BitmapImage publicOld3 = new BitmapImage(new Uri("/Resources/Gray_3.png", UriKind.Relative));



            //在第一轮执行撤销操作时，显示撤消后的Player状态
            this.Operation1.Content = "等待";
            this.Operation1.Content = "等待";
            this.Operation2.Content = "等待";
            this.Operation3.Content = "等待";
            this.Operation4.Content = "等待";
            this.Operation5.Content = "等待";
            this.Operation6.Content = "等待";
            this.Operation7.Content = "等待";
            this.Operation8.Content = "等待";
            Bet1.Content = "";
            Bet2.Content = "";
            Bet3.Content = "";
            Bet4.Content = "";
            Bet5.Content = "";
            Bet6.Content = "";
            Bet7.Content = "";
            Bet8.Content = "";
            PlayerLabel1.Visibility = Visibility.Hidden;
            PlayerLabel2.Visibility = Visibility.Hidden;
            PlayerLabel3.Visibility = Visibility.Hidden;
            PlayerLabel4.Visibility = Visibility.Hidden;
            PlayerLabel5.Visibility = Visibility.Hidden;
            PlayerLabel6.Visibility = Visibility.Hidden;
            PlayerLabel7.Visibility = Visibility.Hidden;
            PlayerLabel8.Visibility = Visibility.Hidden;

            DataTable startChipsTable = new DataTable();
            DataSet set = myService.GetPlayerChip().GetStartChipsForJudgeShow();
            if (set.Tables.Count != 0)
            {
                startChipsTable = set.Tables[0];
                for (int j = 0; j < startChipsTable.Rows.Count; j++)
                {
                    int playerid = int.Parse(startChipsTable.Rows[j]["PlayerID"].ToString());
                    string startChips = startChipsTable.Rows[j]["StartChips"].ToString();
                    if (playerid == 1)
                        this.yue1.Content = startChips;
                    if (playerid == 2)
                        this.yue2.Content = startChips;
                    if (playerid == 3)
                        this.yue3.Content = startChips;
                    if (playerid == 4)
                        this.yue4.Content = startChips;
                    if (playerid == 5)
                        this.yue5.Content = startChips;
                    if (playerid == 6)
                        this.yue6.Content = startChips;
                    if (playerid == 7)
                        this.yue7.Content = startChips;
                    if (playerid == 8)
                        this.yue8.Content = startChips;

                }
            }


            //从服务器读取Operation，显示Player状态
            ServiceBet.BetSoapClient serviceBet = myService.GetBet();
            ServiceRecord.RecordSoapClient serviceRecord = myService.GetRecord();

            DataSet recordUnfinishedDS = serviceRecord.GetRecordForLive();
            if (recordUnfinishedDS.Tables.Count == 0)
                return;
            DataTable recordUnfinishedTable = recordUnfinishedDS.Tables[0];
            if (recordUnfinishedTable.Rows.Count != 0)
            {
                playerNumber = int.Parse(recordUnfinishedTable.Rows[0]["PlayerNumber"].ToString());
                ShowPlayer();

                DataSet allOperationInUnfinishedRecord = serviceBet.GetAllBetInUnfinishedRecord();
                if (allOperationInUnfinishedRecord.Tables.Count == 0)
                {
                    Bubble.Visibility = Visibility.Hidden;
                    return;
                }
                else
                {
                    if (allOperationInUnfinishedRecord.Tables[0].Rows.Count == 0)
                    {
                        Bubble.Visibility = Visibility.Hidden;
                        return;
                    }
                }


            }
            else
            {
                Bubble.Visibility = Visibility.Visible;
                Bubble.Title.Text = "无游戏";
                this.Bubble.Content.Text = "正在进行";

                //BitmapImage publicOld1 = new BitmapImage(new Uri("/Resources/Gray_1.png", UriKind.Relative));
                //BitmapImage publicOld2 = new BitmapImage(new Uri("/Resources/Gray_2.png", UriKind.Relative));
                //BitmapImage publicOld3 = new BitmapImage(new Uri("/Resources/Gray_3.png", UriKind.Relative));

                pictureBack1.Visibility = Visibility.Hidden;
                pictureBack2.Visibility = Visibility.Hidden;
                pictureBack3.Visibility = Visibility.Hidden;
                pictureBack4.Visibility = Visibility.Hidden;
                pictureBack5.Visibility = Visibility.Hidden;
                pictureBack6.Visibility = Visibility.Hidden;
                pictureBack7.Visibility = Visibility.Hidden;
                pictureBack8.Visibility = Visibility.Hidden;

                picture1.Visibility = Visibility.Hidden;
                Operation1.Visibility = Visibility.Hidden;
                label1.Visibility = Visibility.Hidden;
                yue1.Visibility = Visibility.Hidden;
                card11.Visibility = Visibility.Hidden;
                card12.Visibility = Visibility.Hidden;
                Bet1.Visibility = Visibility.Hidden;

                picture2.Visibility = Visibility.Hidden;
                Operation2.Visibility = Visibility.Hidden;
                label2.Visibility = Visibility.Hidden;
                yue2.Visibility = Visibility.Hidden;
                card21.Visibility = Visibility.Hidden;
                card22.Visibility = Visibility.Hidden;
                Bet2.Visibility = Visibility.Hidden;

                picture3.Visibility = Visibility.Hidden;
                Operation3.Visibility = Visibility.Hidden;
                label3.Visibility = Visibility.Hidden;
                yue3.Visibility = Visibility.Hidden;
                card31.Visibility = Visibility.Hidden;
                card32.Visibility = Visibility.Hidden;
                Bet3.Visibility = Visibility.Hidden;

                picture4.Visibility = Visibility.Hidden;
                Operation4.Visibility = Visibility.Hidden;
                label4.Visibility = Visibility.Hidden;
                yue4.Visibility = Visibility.Hidden;
                card41.Visibility = Visibility.Hidden;
                card42.Visibility = Visibility.Hidden;
                Bet4.Visibility = Visibility.Hidden;

                picture5.Visibility = Visibility.Hidden;
                Operation5.Visibility = Visibility.Hidden;
                label5.Visibility = Visibility.Hidden;
                yue5.Visibility = Visibility.Hidden;
                card51.Visibility = Visibility.Hidden;
                card52.Visibility = Visibility.Hidden;
                Bet5.Visibility = Visibility.Hidden;

                picture6.Visibility = Visibility.Hidden;
                Operation6.Visibility = Visibility.Hidden;
                label6.Visibility = Visibility.Hidden;
                yue6.Visibility = Visibility.Hidden;
                card61.Visibility = Visibility.Hidden;
                card62.Visibility = Visibility.Hidden;
                Bet6.Visibility = Visibility.Hidden;

                picture7.Visibility = Visibility.Hidden;
                Operation7.Visibility = Visibility.Hidden;
                label7.Visibility = Visibility.Hidden;
                yue7.Visibility = Visibility.Hidden;
                card71.Visibility = Visibility.Hidden;
                card72.Visibility = Visibility.Hidden;
                Bet7.Visibility = Visibility.Hidden;

                picture8.Visibility = Visibility.Hidden;
                Operation8.Visibility = Visibility.Hidden;
                label8.Visibility = Visibility.Hidden;
                yue8.Visibility = Visibility.Hidden;
                card81.Visibility = Visibility.Hidden;
                card82.Visibility = Visibility.Hidden;
                Bet8.Visibility = Visibility.Hidden;


                Bubble1.Visibility = Visibility.Hidden;
                Bubble2.Visibility = Visibility.Hidden;
                Bubble3.Visibility = Visibility.Hidden;
                Bubble4.Visibility = Visibility.Hidden;
                Bubble5.Visibility = Visibility.Hidden;
                Bubble6.Visibility = Visibility.Hidden;
                Bubble7.Visibility = Visibility.Hidden;
                Bubble8.Visibility = Visibility.Hidden;



                this.card1.Source = publicOld1;
                this.card2.Source = publicOld1;
                this.card3.Source = publicOld1;
                this.card4.Source = publicOld2;
                this.card5.Source = publicOld3;

                return;
            }






            DataSet operationTable = serviceBet.GetBetForLive1();
            if (operationTable.Tables.Count == 0)
                return;

            //新一轮开始时隐藏池底的筹码
            if (operationTable.Tables[0].Rows.Count == 0)
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

            //显示每一轮所下的筹码
            //DataTable betTable = operationTable.Tables[0];
            //for (int i = 0; i < betTable.Rows.Count;i++)
            //{
            //    int playerID = int.Parse(operationTable.Tables[0].Rows[i]["PlayerID"].ToString());
            //}

            //显示Player操作和筹码余额
            if (operationTable.Tables[0].Rows.Count < playerNumber)
            {
                int operationNum = operationTable.Tables[0].Rows.Count;
                if (operationNum < 8)
                    this.Operation8.Content = "等待";
            }

            for (int i = 0; i < operationTable.Tables[0].Rows.Count; i++)
            {
                int playerID = int.Parse(operationTable.Tables[0].Rows[i]["PlayerID"].ToString());
                string operation = operationTable.Tables[0].Rows[i]["Operation"].ToString();
                string chipsBet = operationTable.Tables[0].Rows[i]["ChipsBet"].ToString();
                string chipsInHand = operationTable.Tables[0].Rows[i]["ChipsInHand"].ToString();


                if (operation.Equals("加注"))
                    operation = "加至";
                //荷官 贷款后 ，把Player上的气泡隐藏
                if (operation.Equals("小盲"))
                {
                    Bubble.Visibility = Visibility.Hidden;
                    Bubble1.Visibility = Visibility.Hidden;
                    Bubble2.Visibility = Visibility.Hidden;
                    Bubble3.Visibility = Visibility.Hidden;
                    Bubble4.Visibility = Visibility.Hidden;
                    Bubble5.Visibility = Visibility.Hidden;
                    Bubble6.Visibility = Visibility.Hidden;
                    Bubble7.Visibility = Visibility.Hidden;
                    Bubble8.Visibility = Visibility.Hidden;


                }

                switch (playerID)
                {
                    case 0:
                        Bubble1.Visibility = Visibility.Hidden;
                        Bubble2.Visibility = Visibility.Hidden;
                        Bubble3.Visibility = Visibility.Hidden;
                        Bubble4.Visibility = Visibility.Hidden;
                        Bubble5.Visibility = Visibility.Hidden;
                        Bubble6.Visibility = Visibility.Hidden;
                        Bubble7.Visibility = Visibility.Hidden;
                        Bubble8.Visibility = Visibility.Hidden;
                        Bubble1.Content.Text = "";
                        Bubble2.Content.Text = "";
                        Bubble3.Content.Text = "";
                        Bubble4.Content.Text = "";
                        Bubble5.Content.Text = "";
                        Bubble6.Content.Text = "";
                        Bubble7.Content.Text = "";
                        Bubble8.Content.Text = "";

                        Bet1.Content = "";
                        Bet2.Content = "";
                        Bet3.Content = "";
                        Bet4.Content = "";
                        Bet5.Content = "";
                        Bet6.Content = "";
                        Bet7.Content = "";
                        Bet8.Content = "";

                        //荷官 操作后 气泡的显示
                        if (operation.Equals("贷款") || operation.Equals("判定"))
                        {
                            if (operation.Equals("贷款"))
                            {
                                Bubble.Visibility = Visibility.Hidden;
                                for (int j = 0; j < startChipsTable.Rows.Count; j++)
                                {
                                    int pID = int.Parse(startChipsTable.Rows[j]["PlayerID"].ToString());
                                    string loanC = startChipsTable.Rows[j]["LoanChips"].ToString();
                                    if (!loanC.Equals("0"))
                                    {
                                        switch (pID)
                                        {
                                            case 1:
                                                Bubble1.Title.Text = "借款";
                                                Bubble1.Content.Text = loanC;
                                                Bubble1.Visibility = Visibility.Visible;
                                                break;
                                            case 2:
                                                Bubble2.Title.Text = "借款";
                                                Bubble2.Content.Text = loanC;
                                                Bubble2.Visibility = Visibility.Visible;
                                                break;
                                            case 3:
                                                Bubble3.Title.Text = "借款";
                                                Bubble3.Content.Text = loanC;
                                                Bubble3.Visibility = Visibility.Visible;
                                                break;
                                            case 4:
                                                Bubble4.Title.Text = "借款";
                                                Bubble4.Content.Text = loanC;
                                                Bubble4.Visibility = Visibility.Visible;
                                                break;
                                            case 5:
                                                Bubble5.Title.Text = "借款";
                                                Bubble5.Content.Text = loanC;
                                                Bubble5.Visibility = Visibility.Visible;
                                                break;
                                            case 6:
                                                Bubble6.Title.Text = "借款";
                                                Bubble6.Content.Text = loanC;
                                                Bubble6.Visibility = Visibility.Visible;
                                                break;
                                            case 7:
                                                Bubble7.Title.Text = "借款";
                                                Bubble7.Content.Text = loanC;
                                                Bubble7.Visibility = Visibility.Visible;
                                                break;
                                            case 8:
                                                Bubble8.Title.Text = "借款";
                                                Bubble8.Content.Text = loanC;
                                                Bubble8.Visibility = Visibility.Visible;
                                                break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                DataSet tempJudge = myService.GetPlayerChip().GetLastGameResultForLive();
                                if (tempJudge.Tables.Count == 0)
                                    return;
                                DataTable lastGameResultTable = tempJudge.Tables[0];
                                Bubble.Visibility = Visibility.Hidden;

                                for (int j = 0; j < lastGameResultTable.Rows.Count; j++)
                                {
                                    int pID = int.Parse(lastGameResultTable.Rows[j]["PlayerID"].ToString());
                                    string gainC = lastGameResultTable.Rows[j]["GainChips"].ToString();
                                    if (!gainC.Equals("0"))
                                    {
                                        switch (pID)
                                        {
                                            case 1:
                                                Bubble1.Title.Text = "赢得";
                                                Bubble1.Content.Text = gainC;
                                                Bubble1.Visibility = Visibility.Visible;
                                                break;
                                            case 2:
                                                Bubble2.Title.Text = "赢得";
                                                Bubble2.Content.Text = gainC;
                                                Bubble2.Visibility = Visibility.Visible;
                                                break;
                                            case 3:
                                                Bubble3.Title.Text = "赢得";
                                                Bubble3.Content.Text = gainC;
                                                Bubble3.Visibility = Visibility.Visible;
                                                break;
                                            case 4:
                                                Bubble4.Title.Text = "赢得";
                                                Bubble4.Content.Text = gainC;
                                                Bubble4.Visibility = Visibility.Visible;
                                                break;
                                            case 5:
                                                Bubble5.Title.Text = "赢得";
                                                Bubble5.Content.Text = gainC;
                                                Bubble5.Visibility = Visibility.Visible;
                                                break;
                                            case 6:
                                                Bubble6.Title.Text = "赢得";
                                                Bubble6.Content.Text = gainC;
                                                Bubble6.Visibility = Visibility.Visible;
                                                break;
                                            case 7:
                                                Bubble7.Title.Text = "赢得";
                                                Bubble7.Content.Text = gainC;
                                                Bubble7.Visibility = Visibility.Visible;
                                                break;
                                            case 8:
                                                Bubble8.Title.Text = "赢得";
                                                Bubble8.Content.Text = gainC;
                                                Bubble8.Visibility = Visibility.Visible;
                                                break;
                                        }
                                    }
                                }


                                //判定后隐藏池底的筹码
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

                                //显示游戏结果
                                if (recordUnfinishedTable.Rows.Count != 0)
                                {
                                    bool isExit = false;
                                    foreach (Window w in App.Current.Windows)
                                    {
                                        if (w is GameResult)
                                        {
                                            isExit = true;
                                        }
                                    }
                                    if (!isExit)
                                    {
                                        int recordID = int.Parse(recordUnfinishedTable.Rows[0]["ID"].ToString());
                                        GameResult newwindow = new GameResult(recordID, playerNumber);
                                        newwindow.AutoClose = true;
                                        newwindow.Show();
                                    }

                                }

                            }

                            this.Operation1.Content = "等待";
                            this.Operation1.Content = "等待";
                            this.Operation2.Content = "等待";
                            this.Operation3.Content = "等待";
                            this.Operation4.Content = "等待";
                            this.Operation5.Content = "等待";
                            this.Operation6.Content = "等待";
                            this.Operation7.Content = "等待";
                            this.Operation8.Content = "等待";

                            //DataSet set = new ServicePlayerChip.PlayerChipSoapClient().GetStartChipsForJudgeShow();
                            //DataTable startChipsTable=set.Tables[0];
                            for (int j = 0; j < startChipsTable.Rows.Count; j++)
                            {
                                int playerid = int.Parse(startChipsTable.Rows[j]["PlayerID"].ToString());
                                string startChips = startChipsTable.Rows[j]["StartChips"].ToString();
                                if (playerid == 1)
                                    this.yue1.Content = startChips;
                                if (playerid == 2)
                                    this.yue2.Content = startChips;
                                if (playerid == 3)
                                    this.yue3.Content = startChips;
                                if (playerid == 4)
                                    this.yue4.Content = startChips;
                                if (playerid == 5)
                                    this.yue5.Content = startChips;
                                if (playerid == 6)
                                    this.yue6.Content = startChips;
                                if (playerid == 7)
                                    this.yue7.Content = startChips;
                                if (playerid == 8)
                                    this.yue8.Content = startChips;

                            }
                        }
                        else if (operation.Equals("发牌"))
                        {


                            Bubble.Visibility = Visibility.Visible;
                            Bubble.Title.Text = "发牌";
                            Bubble.Content.Text = "";

                            if (!this.Operation1.Content.ToString().Equals("弃牌") && !this.Operation1.Content.ToString().Equals("全下"))
                                this.Operation1.Content = "等待";
                            if (!this.Operation2.Content.ToString().Equals("弃牌") && !this.Operation2.Content.ToString().Equals("全下"))
                                this.Operation2.Content = "等待";
                            if (!this.Operation3.Content.ToString().Equals("弃牌") && !this.Operation3.Content.ToString().Equals("全下"))
                                this.Operation3.Content = "等待";
                            if (!this.Operation4.Content.ToString().Equals("弃牌") && !this.Operation4.Content.ToString().Equals("全下"))
                                this.Operation4.Content = "等待";
                            if (!this.Operation5.Content.ToString().Equals("弃牌") && !this.Operation5.Content.ToString().Equals("全下"))
                                this.Operation5.Content = "等待";
                            if (!this.Operation6.Content.ToString().Equals("弃牌") && !this.Operation6.Content.ToString().Equals("全下"))
                                this.Operation6.Content = "等待";
                            if (!this.Operation7.Content.ToString().Equals("弃牌") && !this.Operation7.Content.ToString().Equals("全下"))
                                this.Operation7.Content = "等待";
                            if (!this.Operation8.Content.ToString().Equals("弃牌") && !this.Operation8.Content.ToString().Equals("全下"))
                                this.Operation8.Content = "等待";

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
                                    this.ChipsInPool1.Content = eachChips[1];
                                }
                                if (pools > 2)
                                {
                                    this.imageChips2.Visibility = Visibility.Visible;
                                    this.ChipsInPool2.Visibility = Visibility.Visible;
                                    this.ChipsInPool2.Content = eachChips[2];
                                }
                                if (pools > 3)
                                {
                                    this.imageChips3.Visibility = Visibility.Visible;
                                    this.ChipsInPool3.Visibility = Visibility.Visible;
                                    this.ChipsInPool3.Content = eachChips[3];
                                }
                                if (pools > 4)
                                {
                                    this.imageChips4.Visibility = Visibility.Visible;
                                    this.ChipsInPool4.Visibility = Visibility.Visible;
                                    this.ChipsInPool4.Content = eachChips[4];
                                }
                                if (pools > 5)
                                {
                                    this.imageChips5.Visibility = Visibility.Visible;
                                    this.ChipsInPool5.Visibility = Visibility.Visible;
                                    this.ChipsInPool5.Content = eachChips[5];
                                }
                                if (pools > 6)
                                {
                                    this.imageChips6.Visibility = Visibility.Visible;
                                    this.ChipsInPool6.Visibility = Visibility.Visible;
                                    this.ChipsInPool6.Content = eachChips[6];
                                }
                                if (pools > 7)
                                {
                                    this.imageChips7.Visibility = Visibility.Visible;
                                    this.ChipsInPool7.Visibility = Visibility.Visible;
                                    this.ChipsInPool7.Content = eachChips[7];
                                }
                            }
                        }


                        break;
                    case 1:
                        this.Operation1.Content = operation;
                        this.yue1.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet1.Content = ":  " + chipsBet;
                            this.Bubble1.Content.Text = chipsBet;
                        }

                        this.Bubble1.Title.Text = operation;

                        Bubble1.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        this.Operation2.Content = operation;
                        this.yue2.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet2.Content = ":  " + chipsBet;
                            this.Bubble2.Content.Text = chipsBet;
                        }
                        this.Bubble2.Title.Text = operation;
                        Bubble2.Visibility = Visibility.Visible;
                        break;
                    case 3:
                        this.Operation3.Content = operation;
                        this.yue3.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet3.Content = ":  " + chipsBet;
                            this.Bubble3.Content.Text = chipsBet;
                        }
                        this.Bubble3.Title.Text = operation;
                        Bubble3.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        this.Operation4.Content = operation;
                        this.yue4.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet4.Content = ":  " + chipsBet;
                            this.Bubble4.Content.Text = chipsBet;
                        }
                        this.Bubble4.Title.Text = operation;
                        Bubble4.Visibility = Visibility.Visible;
                        break;
                    case 5:
                        this.Operation5.Content = operation;
                        this.yue5.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet5.Content = ":  " + chipsBet;
                            this.Bubble5.Content.Text = chipsBet;
                        }
                        this.Bubble5.Title.Text = operation;
                        Bubble5.Visibility = Visibility.Visible;
                        break;
                    case 6:
                        this.Operation6.Content = operation;
                        this.yue6.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet6.Content = ":  " + chipsBet;
                            this.Bubble6.Content.Text = chipsBet;
                        }
                        this.Bubble6.Title.Text = operation;
                        Bubble6.Visibility = Visibility.Visible;
                        break;
                    case 7:
                        this.Operation7.Content = operation;
                        this.yue7.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet7.Content = ":  " + chipsBet;
                            this.Bubble7.Content.Text = chipsBet;
                        }
                        this.Bubble7.Title.Text = operation;
                        Bubble7.Visibility = Visibility.Visible;
                        break;
                    case 8:
                        this.Operation8.Content = operation;
                        this.yue8.Content = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet8.Content = ":  " + chipsBet;
                            this.Bubble8.Content.Text = chipsBet;
                        }
                        this.Bubble8.Title.Text = operation;
                        Bubble8.Visibility = Visibility.Visible;
                        break;
                }

            }

            if (operationTable.Tables[0].Rows.Count > 0 &&
                operationTable.Tables[0].Rows[operationTable.Tables[0].Rows.Count - 1]["Operation"].ToString().Equals("判定"))
            {
                LoadResultPrivateCard();
            }
            else
            {
                allOperations.Clear();
                foreach (var item in operations)
                {
                    allOperations.Add(item.Content.ToString());
                }
                ServiceCard.CardSoapClient privatecardservice = myService.GetCard();
                allPrivateCards.Clear();
                for (int id = 0; id < 8; id++)
                {
                    DataSet privateCardSet = privatecardservice.GetPrivateCardByPlayerID(id + 1);
                    if (privateCardSet.Tables.Count != 0)
                    {
                        DataTable tablePrivateCard = privateCardSet.Tables[0];
                        if (tablePrivateCard.Rows.Count != 0)
                        {
                            string recordcard1 = tablePrivateCard.Rows[0]["FirstCard"].ToString();
                            string recordcard2 = tablePrivateCard.Rows[0]["SecondCard"].ToString();
                            allPrivateCards.Add(new Tuple<string, string>(recordcard1, recordcard2));
                        }
                        else
                        {
                            allPrivateCards.Add(new Tuple<string, string>(null, null));
                        }
                    }
                    else
                    {
                        allPrivateCards.Add(new Tuple<string, string>(null, null));
                    }
                }
            }

            //从服务器读取PublicCard，显示公共明牌
            ServiceCard.CardSoapClient serviceCard = myService.GetCard();
            DataSet publicCardTable = serviceCard.GetPublicCardForLive();
            string card1 = "";
            string card2 = "";
            string card3 = "";
            string card4 = "";
            string card5 = "";
            if (publicCardTable.Tables.Count != 0)
            {
                if (publicCardTable.Tables[0].Rows.Count != 0)
                {
                    card1 = publicCardTable.Tables[0].Rows[0]["FirstCard"].ToString();
                    card2 = publicCardTable.Tables[0].Rows[0]["SecondCard"].ToString();
                    card3 = publicCardTable.Tables[0].Rows[0]["ThirdCard"].ToString();
                    card4 = publicCardTable.Tables[0].Rows[0]["FourthCard"].ToString();
                    card5 = publicCardTable.Tables[0].Rows[0]["FifthCard"].ToString();
                }
            }

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

            //从数据库读取privateCard，显示私牌 
            //BitmapImage privateOld = new BitmapImage(new Uri("/Resources/Cards/BACK.png", UriKind.Relative));
            //card11.Source = privateOld;
            //card12.Source = privateOld;
            //ServiceCard.CardSoapClient privatecardservice = myService.GetCard();
            //DataSet privateCardSet = privatecardservice.GetPrivateCardByPlayerID(playerID);



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

        private void imageQuit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
            Application.Current.Shutdown();
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
    }
}
