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
    /// GameResult.xaml 的交互逻辑
    /// </summary>
    public partial class GameResult : Window
    {
        private MyService myService = new MyService();
        private int recordID;
        private int playerNumber;

        public bool AutoClose = false;

        public GameResult(int rID,int pNum)
        {
            InitializeComponent();
            recordID = rID;
            playerNumber = pNum;

            ShowResult();


            
        }

        private int DeterminMingCi(int num,int[] all)
        {
            int minci = 1;
            for (int i = 0; i < all.Length;i++ )
            {
                if (all[i] > num)
                    minci += 1;
            }
            return minci;
        }

        private void ShowResult()
        {
            float interest1 = (float)0;
            float interest2 = (float)0;
            float interest3 = (float)0;
            float interest4 = (float)0;
            float interest5 = (float)0;

            //显示利息
            DataSet interestSet = myService.GetRecord().GetRecordByID(recordID);
            if(interestSet.Tables.Count!=0)
            {
                DataTable interestTable=interestSet.Tables[0];
                if(interestTable.Rows.Count!=0)
                {
                    interest1 = float.Parse(interestTable.Rows[0]["FirstInterest"].ToString()) ;
                    interest2 = float.Parse(interestTable.Rows[0]["SecondInterest"].ToString());
                    interest3 = float.Parse(interestTable.Rows[0]["ThirdInterest"].ToString()) ;
                    interest4 = float.Parse(interestTable.Rows[0]["FourthInterest"].ToString());
                    interest5 = float.Parse(interestTable.Rows[0]["FifthInterest"].ToString());
                    this.InterestLabel1.Content = interest1 * 100 + "%";
                    this.InterestLabel2.Content = interest2 * 100 + "%";
                    this.InterestLabel3.Content = interest3 * 100 + "%";
                    this.InterestLabel4.Content = interest4 * 100 + "%";
                    this.InterestLabel5.Content = interest5 * 100 + "%";

                }
            }
            //显示第一行玩家列表

            if(interestSet.Tables.Count!=0)
            {
                DataTable headPictureTable=interestSet.Tables[0];
                if(headPictureTable.Rows.Count!=0)
                {
                    string headPicture1 = headPictureTable.Rows[0]["HeadPicture1"].ToString();
                    string headPicture2 = headPictureTable.Rows[0]["HeadPicture2"].ToString();
                    string headPicture3 = headPictureTable.Rows[0]["HeadPicture3"].ToString();
                    string headPicture4 = headPictureTable.Rows[0]["HeadPicture4"].ToString();
                    string headPicture5 = headPictureTable.Rows[0]["HeadPicture5"].ToString();
                    string headPicture6 = headPictureTable.Rows[0]["HeadPicture6"].ToString();
                    string headPicture7 = headPictureTable.Rows[0]["HeadPicture7"].ToString();
                    string headPicture8 = headPictureTable.Rows[0]["HeadPicture8"].ToString();
                    if(playerNumber>1)
                    {
                        this.Picture1.Visibility = Visibility.Visible;
                        this.LabelName1.Visibility = Visibility.Visible;
                        this.Picture2.Visibility = Visibility.Visible;
                        this.LabelName2.Visibility = Visibility.Visible;
                    }
                    if(playerNumber>2)
                    {
                        this.Picture3.Visibility = Visibility.Visible;
                        this.LabelName3.Visibility = Visibility.Visible;
                    }
                    if (playerNumber > 3)
                    {
                        this.Picture4.Visibility = Visibility.Visible;
                        this.LabelName4.Visibility = Visibility.Visible;
                    }
                    if (playerNumber > 4)
                    {
                        this.Picture5.Visibility = Visibility.Visible;
                        this.LabelName5.Visibility = Visibility.Visible;
                    }
                    if (playerNumber > 5)
                    {
                        this.Picture6.Visibility = Visibility.Visible;
                        this.LabelName6.Visibility = Visibility.Visible;
                    }
                    if (playerNumber > 6)
                    {
                        this.Picture7.Visibility = Visibility.Visible;
                        this.LabelName7.Visibility = Visibility.Visible;
                    }
                    if (playerNumber > 7)
                    {
                        this.Picture8.Visibility = Visibility.Visible;
                        this.LabelName8.Visibility = Visibility.Visible;
                    }



                    if(headPicture1.Length!=0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/"+headPicture1+".png", UriKind.Relative));
                        this.Picture1.Source = headSource;
                    }
                    if (headPicture2.Length != 0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/" + headPicture2 + ".png", UriKind.Relative));
                        this.Picture2.Source = headSource;
                    }
                    if (headPicture3.Length != 0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/" + headPicture3 + ".png", UriKind.Relative));
                        this.Picture3.Source = headSource;
                    }
                    if (headPicture4.Length != 0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/" + headPicture4 + ".png", UriKind.Relative));
                        this.Picture4.Source = headSource;
                    }
                    if (headPicture5.Length != 0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/" + headPicture5 + ".png", UriKind.Relative));
                        this.Picture5.Source = headSource;
                    }
                    if (headPicture6.Length != 0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/" + headPicture6 + ".png", UriKind.Relative));
                        this.Picture6.Source = headSource;
                    }
                    if (headPicture7.Length != 0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/" + headPicture7 + ".png", UriKind.Relative));
                        this.Picture7.Source = headSource;
                    }
                    if (headPicture8.Length != 0)
                    {
                        BitmapImage headSource = new BitmapImage(new Uri("/Resources/Head/" + headPicture8 + ".png", UriKind.Relative));
                        this.Picture8.Source = headSource;
                    }
                }
            }

            /*RowDefinition rd = new RowDefinition();
            rd.Height = new GridLength(72, GridUnitType.Pixel);
            gridEnd.RowDefinitions.Add(rd);

            Image img = new Image();
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/line.png", UriKind.Relative));
            img.Source = imagetemp;
            img.Margin = new Thickness(0, 61, 10, 10);
            img.Stretch = Stretch.Fill;
            gridEnd.Children.Add(img);
            img.SetValue(Grid.RowProperty, 0);

            Label la = new Label();
            la.Margin = new Thickness(10, 10, 10, 17);
            la.Content = "        ";
            for (int i = 1; i <=playerNumber;i++ )
            {
                la.Content =la.Content+ "   玩家"+i;
            }
            la.FontSize = 24;
            gridEnd.Children.Add(la);
            la.SetValue(Grid.RowProperty, 0);
            */
              
            //显示表格内容

            int yuePlayer1=0;
            int yuePlayer2=0;
            int yuePlayer3=0;
            int yuePlayer4=0;
            int yuePlayer5=0;
            int yuePlayer6=0;
            int yuePlayer7=0;
            int yuePlayer8=0;

            UserControlGameResult mingci = new UserControlGameResult();
            UserControlGameResult yue = new UserControlGameResult();

            mingci.RowName.Content = "名次";
            yue.RowName.Content = "余额";

            RowDefinition mingciRow = new RowDefinition();
            mingciRow.Height = new GridLength(72, GridUnitType.Pixel);
            gridEnd.RowDefinitions.Add(mingciRow);
            RowDefinition yueRow = new RowDefinition();
            yueRow.Height = new GridLength(72, GridUnitType.Pixel);
            gridEnd.RowDefinitions.Add(yueRow);
            gridEnd.Children.Add(mingci);
            gridEnd.Children.Add(yue);
            mingci.SetValue(Grid.RowProperty,1);
            yue.SetValue(Grid.RowProperty,2);


            DataSet recordSet = myService.GetPlayerChip().GetPlayerChipsByRecordID(recordID);
            if (recordSet.Tables.Count != 0)
            {
                DataTable playerChipsTable = recordSet.Tables[0];
                if(playerChipsTable.Rows.Count>0)
                {
                    int gameID = int.Parse(playerChipsTable.Rows[0]["GameID"].ToString());
                    int gameCount = 1;
                    List<int[]> gameWinList=new List<int[]>();
                    List<int[]> gameLoanList = new List<int[]>();
                    int[] win = new int[8];
                    int[] loan = new int[8];
                    for (int i = 0; i < playerChipsTable.Rows.Count; i++)
                    {
                        
                        int playerIDtemp = int.Parse(playerChipsTable.Rows[i]["PlayerID"].ToString());
                        int loanChips = int.Parse(playerChipsTable.Rows[i]["LoanChips"].ToString());

                        int startChips = int.Parse(playerChipsTable.Rows[i]["StartChips"].ToString());
                        int betChips1 = int.Parse(playerChipsTable.Rows[i]["BetChips1"].ToString());
                        int betChips2 = int.Parse(playerChipsTable.Rows[i]["BetChips2"].ToString());
                        int betChips3 = int.Parse(playerChipsTable.Rows[i]["BetChips3"].ToString());
                        int betChips4 = int.Parse(playerChipsTable.Rows[i]["BetChips4"].ToString());
                        int gainChips = int.Parse(playerChipsTable.Rows[i]["GainChips"].ToString());
                        int jingZhuan = gainChips - betChips1 - betChips2 - betChips3 - betChips4;
                        //计算余额
                        if(playerChipsTable.Rows.Count-i>0&&playerChipsTable.Rows.Count-i<=playerNumber)
                        {
                            if (playerIDtemp == 1)
                                yuePlayer1 = startChips + jingZhuan;
                            else if (playerIDtemp == 2)
                                yuePlayer2 = startChips + jingZhuan;
                            else if (playerIDtemp == 3)
                                yuePlayer3 = startChips + jingZhuan;
                            else if (playerIDtemp == 4)
                                yuePlayer4 = startChips + jingZhuan;
                            else if (playerIDtemp == 5)
                                yuePlayer5 = startChips + jingZhuan;
                            else if (playerIDtemp == 6)
                                yuePlayer6 = startChips + jingZhuan;
                            else if (playerIDtemp == 7)
                                yuePlayer7 = startChips + jingZhuan;
                            else if (playerIDtemp == 8)
                                yuePlayer8 = startChips + jingZhuan;
                        }

                        if (gameID == int.Parse(playerChipsTable.Rows[i]["GameID"].ToString()))
                        {
                            win[playerIDtemp-1]=jingZhuan;
                            loan[playerIDtemp-1] = loanChips;
                           
                            if(i==playerChipsTable.Rows.Count-1)
                            {
                                gameWinList.Add(win);
                                gameLoanList.Add(loan);

                                
                            }
                        }
                        else
                        {
                            gameWinList.Add(win);
                            gameLoanList.Add(loan);
                            win=new int[8];
                            loan=new int[8];
                            win[playerIDtemp-1] = jingZhuan;
                            loan[playerIDtemp-1] = loanChips;

                            gameID = int.Parse(playerChipsTable.Rows[i]["GameID"].ToString());
                            gameCount += 1;

                        }
                    }
                    

                    

                    


                    //显示战局
                    int rowCount = 3;
                    int[] loanTimes = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };

                    float[] loanInterests = new float[] { interest1, interest2, interest3, interest4, interest5 };

                    float[] loanBack = new float[] { 0, 0, 0, 0, 0, 0, 0, 0 };
                    for(int i=0;i<gameWinList.Count;i++)
                    {
                        int playerWin1 = (gameWinList[i] as int[])[0];
                        int playerWin2 = (gameWinList[i] as int[])[1];
                        int playerWin3 = (gameWinList[i] as int[])[2];
                        int playerWin4 = (gameWinList[i] as int[])[3];
                        int playerWin5 = (gameWinList[i] as int[])[4];
                        int playerWin6 = (gameWinList[i] as int[])[5];
                        int playerWin7 = (gameWinList[i] as int[])[6];
                        int playerWin8 = (gameWinList[i] as int[])[7];

                        int playerLoan1=(gameLoanList[i] as int[])[0];
                        int playerLoan2 = (gameLoanList[i] as int[])[1];
                        int playerLoan3 = (gameLoanList[i] as int[])[2];
                        int playerLoan4 = (gameLoanList[i] as int[])[3];
                        int playerLoan5 = (gameLoanList[i] as int[])[4];
                        int playerLoan6 = (gameLoanList[i] as int[])[5];
                        int playerLoan7 = (gameLoanList[i] as int[])[6];
                        int playerLoan8 = (gameLoanList[i] as int[])[7];

                        if(playerLoan1>0||playerLoan2>0||playerLoan3>0||playerLoan4>0||playerLoan5>0||playerLoan6>0||playerLoan7>0||playerLoan8>0)
                        {

                            //计算 贷款应还筹码  
                            int[] playerLoan = new int[] { playerLoan1, playerLoan2, playerLoan3, playerLoan4, playerLoan5, playerLoan6, playerLoan7, playerLoan8 };
                            for (int j = 0; j < 8;j++ )
                            {
                                if(playerLoan[j]>0)
                                {
                                    loanTimes[j] += 1;
                                    if (loanTimes[j] <= 5)
                                        loanBack[j] = loanBack[j] + playerLoan[j] * (1+loanInterests[loanTimes[j]-1]);
                                    else
                                        loanBack[j] = loanBack[j] + playerLoan[j] * (1+loanInterests[4]);
                                }
                            }


                            RowDefinition loanRecordRow = new RowDefinition();
                            loanRecordRow.Height = new GridLength(72, GridUnitType.Pixel);
                            gridEnd.RowDefinitions.Add(loanRecordRow);
                            rowCount += 1;

                            UserControlGameResult loanRecord = new UserControlGameResult();
                            loanRecord.RowName.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player1.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player2.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player3.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player4.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player5.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player6.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player7.Foreground = new SolidColorBrush(Colors.Red);
                            loanRecord.Player8.Foreground = new SolidColorBrush(Colors.Red);

                            loanRecord.RowName.Content = "借款";
                            loanRecord.Player1.Content = playerLoan1+"";
                            loanRecord.Player2.Content = playerLoan2 + "";
                            if (playerNumber > 2)
                                loanRecord.Player3.Content = playerLoan3 + "";
                            if (playerNumber > 3)
                                 loanRecord.Player4.Content = playerLoan4 + "";
                            if (playerNumber > 4)
                                loanRecord.Player5.Content = playerLoan5 + "";
                            if (playerNumber > 5)
                                loanRecord.Player6.Content = playerLoan6 + "";
                            if (playerNumber > 6)
                                loanRecord.Player7.Content = playerLoan7 + "";
                            if (playerNumber > 7)
                                loanRecord.Player8.Content = playerLoan8 + "";

                            if(loanTimes[0]>0)
                            {
                                if (loanTimes[0] < 6)
                                    loanRecord.Player1.Content = loanRecord.Player1.Content.ToString() + "(" + loanInterests[loanTimes[0]-1]*100 + "%)";
                                else
                                    loanRecord.Player1.Content = loanRecord.Player1.Content + "("+loanInterests[4]*100+"%)";
                            }
                            if (loanTimes[1] > 0)
                            {
                                if (loanTimes[1] < 6)
                                    loanRecord.Player2.Content = loanRecord.Player2.Content.ToString() + "(" + loanInterests[loanTimes[1]-1] * 100 + "%)";
                                else
                                    loanRecord.Player2.Content = loanRecord.Player2.Content + "(" + loanInterests[4] * 100 + "%)";
                            }
                            if (loanTimes[2] > 0)
                            {
                                if (loanTimes[2] < 6)
                                    loanRecord.Player3.Content = loanRecord.Player3.Content.ToString() + "(" + loanInterests[loanTimes[2]-1] * 100 + "%)";
                                else
                                    loanRecord.Player3.Content = loanRecord.Player3.Content + "(" + loanInterests[4] * 100 + "%)";
                            }
                            if (loanTimes[3] > 0)
                            {
                                if (loanTimes[3] < 6)
                                    loanRecord.Player4.Content = loanRecord.Player4.Content.ToString() + "(" + loanInterests[loanTimes[3]-1] * 100 + "%)";
                                else
                                    loanRecord.Player4.Content = loanRecord.Player4.Content + "(" + loanInterests[4] * 100 + "%)";
                            }
                            if (loanTimes[4] > 0)
                            {
                                if (loanTimes[4] < 6)
                                    loanRecord.Player5.Content = loanRecord.Player5.Content.ToString() + "(" + loanInterests[loanTimes[4]-1] * 100 + "%)";
                                else
                                    loanRecord.Player5.Content = loanRecord.Player5.Content + "(" + loanInterests[4] * 100 + "%)";
                            }
                            if (loanTimes[5] > 0)
                            {
                                if (loanTimes[5] < 6)
                                    loanRecord.Player6.Content = loanRecord.Player6.Content.ToString() + "(" + loanInterests[loanTimes[5]-1] * 100 + "%)";
                                else
                                    loanRecord.Player6.Content = loanRecord.Player6.Content + "(" + loanInterests[4] * 100 + "%)";
                            }
                            if (loanTimes[6] > 0)
                            {
                                if (loanTimes[6] < 6)
                                    loanRecord.Player7.Content = loanRecord.Player7.Content.ToString() + "(" + loanInterests[loanTimes[6]-1] * 100 + "%)";
                                else
                                    loanRecord.Player7.Content = loanRecord.Player7.Content + "(" + loanInterests[4] * 100 + "%)";
                            }
                            if (loanTimes[7] > 0)
                            {
                                if (loanTimes[7] < 6)
                                    loanRecord.Player8.Content = loanRecord.Player8.Content.ToString() + "(" + loanInterests[loanTimes[7]-1] * 100 + "%)";
                                else
                                    loanRecord.Player8.Content = loanRecord.Player8.Content + "(" + loanInterests[4] * 100 + "%)";
                            }





                            gridEnd.Children.Add(loanRecord);
                            loanRecord.SetValue(Grid.RowProperty, rowCount-1);

                        }

                        RowDefinition winRecordRow = new RowDefinition();
                        winRecordRow.Height = new GridLength(72,GridUnitType.Pixel);
                        gridEnd.RowDefinitions.Add(winRecordRow);
                        rowCount += 1;

                        UserControlGameResult winRecord = new UserControlGameResult();
                        winRecord.RowName.Content = "局"+(i+1);
                        winRecord.Player1.Content = playerWin1 + "";
                        winRecord.Player2.Content = playerWin2 + "";
                        if(playerNumber>2)
                            winRecord.Player3.Content = playerWin3 + "";
                        if (playerNumber > 3)
                            winRecord.Player4.Content = playerWin4 + "";
                        if (playerNumber > 4)
                            winRecord.Player5.Content = playerWin5 + "";
                        if (playerNumber > 5)
                            winRecord.Player6.Content = playerWin6 + "";
                        if (playerNumber > 6)
                            winRecord.Player7.Content = playerWin7 + "";
                        if (playerNumber > 7)
                            winRecord.Player8.Content = playerWin8 + "";
                        gridEnd.Children.Add(winRecord);
                        winRecord.SetValue(Grid.RowProperty,rowCount-1);
                    }

                    //显示余额，名次
                    yue.Player1.Content = yuePlayer1 -loanBack[0] + "";
                    yue.Player2.Content = yuePlayer2 -loanBack[1] + "";
                    if (playerNumber > 2)
                        yue.Player3.Content = yuePlayer3 - loanBack[2] + "";
                    else
                        yuePlayer3 = -1000000000;

                    if (playerNumber > 3)
                        yue.Player4.Content = yuePlayer4 - loanBack[3] + "";
                    else
                        yuePlayer4 = -1000000000;
                    if (playerNumber > 4)
                        yue.Player5.Content = yuePlayer5 - loanBack[4] + "";
                    else
                        yuePlayer5 = -1000000000;

                    if (playerNumber > 5)
                        yue.Player6.Content = yuePlayer6 - loanBack[5] + "";
                    else
                        yuePlayer6 = -1000000000;

                    if (playerNumber > 6)
                        yue.Player7.Content = yuePlayer7 - loanBack[6] + "";
                    else
                        yuePlayer7 = -1000000000;

                    if (playerNumber > 7)
                        yue.Player8.Content = yuePlayer8 - loanBack[7] + "";
                    else
                        yuePlayer8 = -1000000000;

                    int[] allYue = new int[] { (int)(yuePlayer1 - loanBack[0]), (int)(yuePlayer2 - loanBack[1]), (int)(yuePlayer3 - loanBack[2]), (int)(yuePlayer4 - loanBack[3]), (int)(yuePlayer5 - loanBack[4]), (int)(yuePlayer6 - loanBack[5]), (int)(yuePlayer7 - loanBack[6]), (int)(yuePlayer8 - loanBack[7]) };
                    int paiMingPlayer1 = DeterminMingCi(allYue[0], allYue);
                    int paiMingPlayer2 = DeterminMingCi(allYue[1], allYue);
                    int paiMingPlayer3 = DeterminMingCi(allYue[2], allYue);
                    int paiMingPlayer4 = DeterminMingCi(allYue[3], allYue);
                    int paiMingPlayer5 = DeterminMingCi(allYue[4], allYue);
                    int paiMingPlayer6 = DeterminMingCi(allYue[5], allYue);
                    int paiMingPlayer7 = DeterminMingCi(allYue[6], allYue);
                    int paiMingPlayer8 = DeterminMingCi(allYue[7], allYue);

                    mingci.Player1.Content = paiMingPlayer1 + "";
                    mingci.Player2.Content = paiMingPlayer2 + "";
                    if (playerNumber > 2)
                        mingci.Player3.Content = paiMingPlayer3 + "";
                    if (playerNumber > 3)
                        mingci.Player4.Content = paiMingPlayer4 + "";
                    if (playerNumber > 4)
                        mingci.Player5.Content = paiMingPlayer5 + "";
                    if (playerNumber > 5)
                        mingci.Player6.Content = paiMingPlayer6 + "";
                    if (playerNumber > 6)
                        mingci.Player7.Content = paiMingPlayer7 + "";
                    if (playerNumber > 7)
                        mingci.Player8.Content = paiMingPlayer8 + "";
                        


                }
                

            }

            
        }

        private void imageclose_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void imageclose_MouseEnter(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Close_hover.png", UriKind.Relative));
            imageclose.Source = imagetemp;
        }

        private void imageclose_MouseLeave(object sender, MouseEventArgs e)
        {
            BitmapImage imagetemp = new BitmapImage(new Uri("/Resources/Close.png", UriKind.Relative));
            imageclose.Source = imagetemp;
        }

        private DispatcherTimer timer = new DispatcherTimer();
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += theout;
            timer.Start();
        }

        public void theout(object source, EventArgs e)
        {
            if(AutoClose)
            {
                DataSet newGameOperationsSet = myService.GetBet().GetBetForLive();
                if (newGameOperationsSet.Tables.Count!=0)
                {
                    if (newGameOperationsSet.Tables.Count != 0)
                    {
                        DataTable table = newGameOperationsSet.Tables[0];
                        for (int i = 0; i < table.Rows.Count; i++)
                        {
                            if (table.Rows[i]["Operation"].ToString().Equals("小盲"))
                            {
                                this.Close();

                                timer.Stop();
                                return;
                                //MessageBox.Show("close");

                            }
                        }
                    }
                }
                
            }
        }

    }
}
