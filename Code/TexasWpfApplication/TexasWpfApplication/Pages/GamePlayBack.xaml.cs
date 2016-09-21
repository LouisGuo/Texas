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
using TexasWpfApplication.Common;

namespace TexasWpfApplication.Pages
{
    /// <summary>
    /// GamePlayBack.xaml 的交互逻辑
    /// </summary>
    public partial class GamePlayBack : Window
    {
        private MyService myService = new MyService();
        private int playerID;
        private int recordID;
        private int playerNumber;
        private DataTable operationTable;

        //记录当前步骤
        private int steps;
        private int gameID;

        public GamePlayBack(int pID, int rID, int pNum)
        {
            InitializeComponent();


            playerID = pID;
            recordID = rID;
            playerNumber = pNum;

            steps = 0;
            DataSet set = myService.GetBet().GetBetByRecordID(rID);
            if (set.Tables.Count != 0)
            {
                operationTable = set.Tables[0];
                if(operationTable.Rows.Count!=0)
                {
                    gameID = int.Parse(operationTable.Rows[steps]["GameID"].ToString());
                    LoadHeadPicture();
                }
                
            }

            try
            {
                string testWebService = new MyService().GetAdministrator().HelloWorld();
            }
            catch
            {
                MessageBox.Show("无法连接到服务器，请确保网络连接和ip(你输入的ip地址： " + App.ip + ")地址正确(正确ip地址示例：121.197.3.168:8080)");
                return;
            }
            LoadDesktop();

            ShowPlayer();

            LoadPrivateCard();


            
            
        }

        private void DeterminNextPlayer()
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

            if(steps<operationTable.Rows.Count-1)
            {
                int nextPlayerID = int.Parse(operationTable.Rows[steps+1]["PlayerID"].ToString());


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
                        //显示池底筹码

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
                        string chipsInPool = myService.GetPlayerChip().GetChipsInPoolByGameID(gameID,chipsBet);
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
        }

        private void LoadPrivateCard()
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

            BitmapImage carddefaultSource = new BitmapImage(new Uri("/Resources/Cards/Gray.png", UriKind.Relative));
            if (playerID != 0)
            {
                carddefaultSource = new BitmapImage(new Uri("/Resources/Cards/BACK.png", UriKind.Relative));
            }

            this.card11.Source = carddefaultSource;
            this.card12.Source = carddefaultSource;
            this.card21.Source = carddefaultSource;
            this.card22.Source = carddefaultSource;
            this.card31.Source = carddefaultSource;
            this.card32.Source = carddefaultSource;
            this.card41.Source = carddefaultSource;
            this.card42.Source = carddefaultSource;
            this.card51.Source = carddefaultSource;
            this.card52.Source = carddefaultSource;
            this.card61.Source = carddefaultSource;
            this.card62.Source = carddefaultSource;
            this.card71.Source = carddefaultSource;
            this.card72.Source = carddefaultSource;
            this.card81.Source = carddefaultSource;
            this.card82.Source = carddefaultSource;
            if(playerID!=0)
            {
                BitmapImage defaultForShiJiao = new BitmapImage(new Uri("/Resources/Cards/Gray.png", UriKind.Relative));
                switch (playerID)
                {
                    case 1:
                        this.card11.Source = defaultForShiJiao;
                        this.card12.Source = defaultForShiJiao;
                        break;
                    case 2:
                        this.card21.Source = defaultForShiJiao;
                        this.card22.Source = defaultForShiJiao;
                        break;
                    case 3:
                        this.card31.Source = defaultForShiJiao;
                        this.card32.Source = defaultForShiJiao;
                        break;
                    case 4:
                        this.card41.Source = defaultForShiJiao;
                        this.card42.Source = defaultForShiJiao;
                        break;
                    case 5:
                        this.card51.Source = defaultForShiJiao;
                        this.card52.Source = defaultForShiJiao;
                        break;
                    case 6:
                        this.card61.Source = defaultForShiJiao;
                        this.card62.Source = defaultForShiJiao;
                        break;
                    case 7:
                        this.card71.Source = defaultForShiJiao;
                        this.card72.Source = defaultForShiJiao;
                        break;
                    case 8:
                        this.card81.Source = defaultForShiJiao;
                        this.card82.Source = defaultForShiJiao;
                        break;
                }
            }

            DataSet privateCardset = myService.GetCard().GetPrivateCardByGameID(gameID);
            if(privateCardset.Tables.Count!=0)
            {
                DataTable privateCardTable=privateCardset.Tables[0];
                if(playerID==0)
                {
                    for(int i=0;i<privateCardTable.Rows.Count;i++)
                    {
                        int thisPID=int.Parse(privateCardTable.Rows[i]["PlayerID"].ToString());
                        string prCard1=privateCardTable.Rows[i]["FirstCard"].ToString();
                        string prCard2 = privateCardTable.Rows[i]["SecondCard"].ToString();
                        BitmapImage cardSources1 = new BitmapImage(new Uri("/Resources/Cards/" + prCard1 + ".png", UriKind.Relative));
                        BitmapImage cardSources2 = new BitmapImage(new Uri("/Resources/Cards/" + prCard2 + ".png", UriKind.Relative));
                        if(prCard1.Length==0)
                            cardSources1 = new BitmapImage(new Uri("/Resources/Cards/Gray.png", UriKind.Relative));
                        if (prCard1.Length == 0)
                            cardSources2 = new BitmapImage(new Uri("/Resources/Cards/Gray.png", UriKind.Relative));
                        switch (thisPID)
                        {
                            case 1:
                                this.card11.Source = cardSources1;
                                this.card12.Source = cardSources2;
                                break;
                            case 2:
                               this.card21.Source = cardSources1;
                                this.card22.Source = cardSources2;
                                break;
                            case 3:
                                this.card31.Source = cardSources1;
                                this.card32.Source = cardSources2;
                                break;
                            case 4:
                                this.card41.Source = cardSources1;
                                this.card42.Source = cardSources2;
                                break;
                            case 5:
                                this.card51.Source = cardSources1;
                                this.card52.Source = cardSources2;
                                break;
                            case 6:
                                this.card61.Source = cardSources1;
                                this.card62.Source = cardSources2;
                                break;
                            case 7:
                                this.card71.Source = cardSources1;
                                this.card72.Source = cardSources2;
                                break;
                            case 8:
                                this.card81.Source = cardSources1;
                                this.card82.Source = cardSources2;
                                break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < privateCardTable.Rows.Count; i++)
                    {
                        
                        int thisPID = int.Parse(privateCardTable.Rows[i]["PlayerID"].ToString());
                        if(thisPID==playerID)
                        {
                            string prCard1 = privateCardTable.Rows[i]["FirstCard"].ToString();
                            string prCard2 = privateCardTable.Rows[i]["SecondCard"].ToString();

                            BitmapImage cardSources1 = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                            BitmapImage cardSources2 = new BitmapImage(new Uri("/Resources/Gray.png", UriKind.Relative));
                            if (prCard1.Length != 0)
                                cardSources1 = new BitmapImage(new Uri("/Resources/Cards/" + prCard1 + ".png", UriKind.Relative));
                            if (prCard2.Length != 0)
                                cardSources2 = new BitmapImage(new Uri("/Resources/Cards/" + prCard2 + ".png", UriKind.Relative));


                            //BitmapImage cardSources1 = new BitmapImage(new Uri("/Resources/Cards/" + prCard1 + ".png", UriKind.Relative));
                            //BitmapImage cardSources2 = new BitmapImage(new Uri("/Resources/Cards/" + prCard2 + ".png", UriKind.Relative));
                            if (prCard1.Length == 0)
                                cardSources1 = new BitmapImage(new Uri("/Resources/Cards/Gray.png", UriKind.Relative));
                            if (prCard1.Length == 0)
                                cardSources2 = new BitmapImage(new Uri("/Resources/Cards/Gray.png", UriKind.Relative));
                            switch (thisPID)
                            {
                                case 1:
                                    this.card11.Source = cardSources1;
                                    this.card12.Source = cardSources2;
                                    break;
                                case 2:
                                    this.card21.Source = cardSources1;
                                    this.card22.Source = cardSources2;
                                    break;
                                case 3:
                                    this.card31.Source = cardSources1;
                                    this.card32.Source = cardSources2;
                                    break;
                                case 4:
                                    this.card41.Source = cardSources1;
                                    this.card42.Source = cardSources2;
                                    break;
                                case 5:
                                    this.card51.Source = cardSources1;
                                    this.card52.Source = cardSources2;
                                    break;
                                case 6:
                                    this.card61.Source = cardSources1;
                                    this.card62.Source = cardSources2;
                                    break;
                                case 7:
                                    this.card71.Source = cardSources1;
                                    this.card72.Source = cardSources2;
                                    break;
                                case 8:
                                    this.card81.Source = cardSources1;
                                    this.card82.Source = cardSources2;
                                    break;
                            }
                        }
                        
                    }
                }
            }
            else
            {
                
            }
        }

        private void LoadHeadPicture()
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

            DataSet headPicSet = myService.GetRecord().GetRecordByID(recordID);
            if (headPicSet.Tables.Count != 0)
            {
                DataTable headPictureTable = headPicSet.Tables[0];
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


        private void ButtonGameResult_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            new GameResult(recordID,playerNumber).Show();
        }

        private void ButtonPreGame_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int preGameFirstStep = 0;
            for(int i=0;i<operationTable.Rows.Count;i++)
            {
                int gameIDtemp = int.Parse(operationTable.Rows[i]["GameID"].ToString());
                if(gameID-1>gameIDtemp)
                {
                    preGameFirstStep += 1;
                }
            }
            if(steps!=0)
            {
                steps = preGameFirstStep;
                LoadDesktop();
            }
            else
            {
                MessageBox.Show("已是第一局");
            }
        }

        private void ButtonPreStep_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (steps > 0)
            {
                steps -= 1;
                LoadDesktop();
            }
            else
            {
                MessageBox.Show("已是第一步");
            }
                
        }

        private void ButtonNextStep_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (steps < operationTable.Rows.Count - 1)
            {
                steps += 1;
                LoadDesktop();
            }
            else
                MessageBox.Show("已是最后一步");
        }

        private void ButtonNextGame_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int thisGameStepsLeft = 0;
            for (int i = 0; i < operationTable.Rows.Count; i++)
            {
                int gameIDtemp = int.Parse(operationTable.Rows[i]["GameID"].ToString());
                if (gameID == gameIDtemp&&steps<i)
                {
                    thisGameStepsLeft += 1;
                }
            }
            int tempSteps = 0;
            tempSteps =steps + thisGameStepsLeft +1;
            if (tempSteps >= operationTable.Rows.Count)
                MessageBox.Show("已是最后一局游戏");
            else
            {
                steps = tempSteps;
                LoadDesktop();
            }
            
        }

        private void ButtonHome_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //new SelectOld().Show();
            this.Close();
        }

        private void LoadDesktop()
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

             

            if (operationTable.Rows.Count == 0)
                return; 

               
            //隐藏池底的筹码
            if (gameID != int.Parse(operationTable.Rows[steps]["GameID"].ToString()))
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


            gameID=int.Parse(operationTable.Rows[steps]["GameID"].ToString());
            DataSet set = myService.GetPlayerChip().GetStartChipsByGameID(gameID);
            if (set.Tables.Count == 0)
                return;
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



            //显示Player操作和筹码余额
            for (int i = 0; i <= steps; i++)
            {
                int playerID = int.Parse(operationTable.Rows[i]["PlayerID"].ToString());
                string operation = operationTable.Rows[i]["Operation"].ToString();
                string chipsBet = operationTable.Rows[i]["ChipsBet"].ToString();
                string chipsInHand = operationTable.Rows[i]["ChipsInHand"].ToString();


                if (operation.Equals("加注"))
                    operation = "加至";
                //荷官 贷款后 ，把Player上的气泡隐藏
                if (operation.Equals("小盲"))
                {
                    BitmapImage publicOld1 = new BitmapImage(new Uri("/Resources/Gray_1.png", UriKind.Relative));
                    BitmapImage publicOld2 = new BitmapImage(new Uri("/Resources/Gray_2.png", UriKind.Relative));
                    BitmapImage publicOld3 = new BitmapImage(new Uri("/Resources/Gray_3.png", UriKind.Relative));
                    this.card1.Source = publicOld1;
                    this.card2.Source = publicOld1;
                    this.card3.Source = publicOld1;
                    this.card4.Source = publicOld2;
                    this.card5.Source = publicOld3;
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

                        Bet1.Text = "";
                        Bet2.Text = "";
                        Bet3.Text = "";
                        Bet4.Text = "";
                        Bet5.Text = "";
                        Bet6.Text = "";
                        Bet7.Text = "";
                        Bet8.Text = "";

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
                                DataSet tempJudge = myService.GetPlayerChip().GetGameResultByGameID(gameID);
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
                            }

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
                        }
                        else if (operation.Equals("发牌"))
                        {


                            Bubble.Visibility = Visibility.Visible;
                            Bubble.Title.Text = "发牌";
                            Bubble.Content.Text = "";

                            string fapaiZhangshu=operationTable.Rows[i]["ChipsBet"].ToString();
                            DataSet gameset = myService.GetGame().GetGameByGameID(gameID);
                            if(gameset.Tables.Count!=0)
                            {
                                DataTable gameTable = gameset.Tables[0];
                                string publiccard1=gameTable.Rows[0]["FirstCard"].ToString();
                                string publiccard2 = gameTable.Rows[0]["SecondCard"].ToString();
                                string publiccard3 = gameTable.Rows[0]["ThirdCard"].ToString();
                                string publiccard4 = gameTable.Rows[0]["FourthCard"].ToString();
                                string publiccard5 = gameTable.Rows[0]["FifthCard"].ToString();
                                BitmapImage cardSource1 = new BitmapImage(new Uri("/Resources/Cards/" + publiccard1 + ".png", UriKind.Relative));
                                BitmapImage cardSource2 = new BitmapImage(new Uri("/Resources/Cards/" + publiccard2 + ".png", UriKind.Relative));
                                BitmapImage cardSource3 = new BitmapImage(new Uri("/Resources/Cards/" + publiccard3 + ".png", UriKind.Relative));
                                BitmapImage cardSource4 = new BitmapImage(new Uri("/Resources/Cards/" + publiccard4 + ".png", UriKind.Relative));
                                BitmapImage cardSource5 = new BitmapImage(new Uri("/Resources/Cards/" + publiccard5 + ".png", UriKind.Relative));

                                BitmapImage publicOld1 = new BitmapImage(new Uri("/Resources/Gray_1.png", UriKind.Relative));
                                BitmapImage publicOld2 = new BitmapImage(new Uri("/Resources/Gray_2.png", UriKind.Relative));
                                BitmapImage publicOld3 = new BitmapImage(new Uri("/Resources/Gray_3.png", UriKind.Relative));
                                if(fapaiZhangshu.Equals("1"))
                                {
                                    this.card1.Source = cardSource1;
                                    this.card2.Source = cardSource2;
                                    this.card3.Source = cardSource3;
                                    this.card4.Source = publicOld2;
                                    this.card5.Source = publicOld3;
                                }
                                else if(fapaiZhangshu.Equals("2"))
                                {
                                    this.card1.Source = cardSource1;
                                    this.card2.Source = cardSource2;
                                    this.card3.Source = cardSource3;
                                    this.card4.Source = cardSource4;
                                    this.card5.Source = publicOld3;
                                }
                                else if(fapaiZhangshu.Equals("3"))
                                {
                                    this.card1.Source = cardSource1;
                                    this.card2.Source = cardSource2;
                                    this.card3.Source = cardSource3;
                                    this.card4.Source = cardSource4;
                                    this.card5.Source = cardSource5;
                                }
                            }
                            

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

                            
                        }


                        break;
                    case 1:
                        this.Operation1.Text = operation;
                        this.yue1.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet1.Text = ":  " + chipsBet;
                            this.Bubble1.Content.Text = chipsBet;
                        }
                        this.Bubble1.Title.Text = operation;
                        Bubble1.Visibility = Visibility.Visible;
                        break;
                    case 2:
                        this.Operation2.Text = operation;
                        this.yue2.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet2.Text = ":  " + chipsBet;
                            this.Bubble2.Content.Text = chipsBet;
                        }
                        this.Bubble2.Title.Text = operation;
                        Bubble2.Visibility = Visibility.Visible;
                        break;
                    case 3:
                        this.Operation3.Text = operation;
                        this.yue3.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet3.Text = ":  " + chipsBet;
                            this.Bubble3.Content.Text = chipsBet;
                        }
                        this.Bubble3.Title.Text = operation;
                        Bubble3.Visibility = Visibility.Visible;
                        break;
                    case 4:
                        this.Operation4.Text = operation;
                        this.yue4.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet4.Text = ":  " + chipsBet;
                            this.Bubble4.Content.Text = chipsBet;
                        }
                        this.Bubble4.Title.Text = operation;
                        Bubble4.Visibility = Visibility.Visible;
                        break;
                    case 5:
                        this.Operation5.Text = operation;
                        this.yue5.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet5.Text = ":  " + chipsBet;
                            this.Bubble5.Content.Text = chipsBet;
                        }
                        this.Bubble5.Title.Text = operation;
                        Bubble5.Visibility = Visibility.Visible;
                        break;
                    case 6:
                        this.Operation6.Text = operation;
                        this.yue6.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet6.Text = ":  " + chipsBet;
                            this.Bubble6.Content.Text = chipsBet;
                        }
                        this.Bubble6.Title.Text = operation;
                        Bubble6.Visibility = Visibility.Visible;
                        break;
                    case 7:
                        this.Operation7.Text = operation;
                        this.yue7.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet7.Text = ":  " + chipsBet;
                            this.Bubble7.Content.Text = chipsBet;
                        }
                        this.Bubble7.Title.Text = operation;
                        Bubble7.Visibility = Visibility.Visible;
                        break;
                    case 8:
                        this.Operation8.Text = operation;
                        this.yue8.Text = chipsInHand;
                        if (!(operation.Equals("弃牌") || operation.Equals("看牌")))
                        {
                            Bet8.Text = ":  " + chipsBet;
                            this.Bubble8.Content.Text = chipsBet;
                        }
                        this.Bubble8.Title.Text = operation;
                        Bubble8.Visibility = Visibility.Visible;
                        break;
                }

            }
            LoadPrivateCard();
            DeterminNextPlayer();
        }

        private void ButtonPreGame_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Pre_Game_hover.png", UriKind.Relative));
            ButtonPreGame.Source = imagetemp;
        }

        private void ButtonPreGame_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Pre_Game.png", UriKind.Relative));
            ButtonPreGame.Source = imagetemp;
        }

        private void ButtonPreStep_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Pre_Step_hover.png", UriKind.Relative));
            ButtonPreStep.Source = imagetemp;
        }

        private void ButtonPreStep_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Pre_Step.png", UriKind.Relative));
            ButtonPreStep.Source = imagetemp;
        }

        private void ButtonNextStep_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Next_Step_hover.png", UriKind.Relative));
            ButtonNextStep.Source = imagetemp;
        }

        private void ButtonNextStep_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Next_Step.png", UriKind.Relative));
            ButtonNextStep.Source = imagetemp;
        }

        private void ButtonNextGame_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Next_Game_hover.png", UriKind.Relative));
            ButtonNextGame.Source = imagetemp;
        }


        private void ButtonNextGame_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Next_Game.png", UriKind.Relative));
            ButtonNextGame.Source = imagetemp;
        }

        private void ButtonHome_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Home_hover.png", UriKind.Relative));
            ButtonHome.Source = imagetemp;
        }

        private void ButtonHome_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Home.png", UriKind.Relative));
            ButtonHome.Source = imagetemp;
        }

        private void ButtonGameResult_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Result_hover.png", UriKind.Relative));
            ButtonGameResult.Source = imagetemp;
        }

        private void ButtonGameResult_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Result.png", UriKind.Relative));
            ButtonGameResult.Source = imagetemp;
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
            if(e.Key==Key.Left)
            {
                if (steps > 0)
                {
                    steps -= 1;
                    LoadDesktop();
                }
                else
                {
                    MessageBox.Show("已是第一步");
                }
            }
            if(e.Key==Key.Right)
            {
                if (steps < operationTable.Rows.Count - 1)
                {
                    steps += 1;
                    LoadDesktop();
                }
                else
                    MessageBox.Show("已是最后一步");
            }
            if(e.Key==Key.Up)
            {
                int preGameFirstStep = 0;
                for (int i = 0; i < operationTable.Rows.Count; i++)
                {
                    int gameIDtemp = int.Parse(operationTable.Rows[i]["GameID"].ToString());
                    if (gameID - 1 > gameIDtemp)
                    {
                        preGameFirstStep += 1;
                    }
                }
                if (steps != 0)
                {
                    steps = preGameFirstStep;
                    LoadDesktop();
                }
                else
                {
                    MessageBox.Show("已是第一局");
                }
            }
            if(e.Key==Key.Down)
            {
                int thisGameStepsLeft = 0;
                for (int i = 0; i < operationTable.Rows.Count; i++)
                {
                    int gameIDtemp = int.Parse(operationTable.Rows[i]["GameID"].ToString());
                    if (gameID == gameIDtemp && steps < i)
                    {
                        thisGameStepsLeft += 1;
                    }
                }
                int tempSteps = 0;
                tempSteps = steps + thisGameStepsLeft + 1;
                if (tempSteps >= operationTable.Rows.Count)
                    MessageBox.Show("已是最后一局游戏");
                else
                {
                    steps = tempSteps;
                    LoadDesktop();
                }
            }
        }

       
    }
}
