using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
    /// UserControlSelectOld.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlSelectOld : UserControl
    {
        private MyService myService = new MyService();
        public UserControlSelectOld()
        {
            InitializeComponent();
        }

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int output;
            if (int.TryParse(this.recordID.Content.ToString(), out output))
            {
                int recordID = int.Parse(this.recordID.Content.ToString());
                new GamePlayBack(0, recordID, this.playerID.Items.Count).Show();
            }
            else
            {
                MessageBox.Show("网络连接异常");
            }

            
            
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            int output;
            if (int.TryParse(this.recordID.Content.ToString(), out output))
            {
                if (this.playerID.SelectedIndex >= 0)
                {
                    int playerID = this.playerID.SelectedIndex + 1;
                    int recordID = int.Parse(this.recordID.Content.ToString());
                    new GamePlayBack(playerID, recordID, this.playerID.Items.Count).Show();
                }
                else
                    MessageBox.Show("请选择玩家");
            }
            else
            {
                MessageBox.Show("网络连接异常");
            }

            
        }

        private void ShanChu_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            if(!this.recordID.Content.ToString().Equals(""))
            {
                if (MessageBox.Show("确定删除记录？", "删除", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (myService.GetRecord().DeleteRecord(int.Parse(this.recordID.Content.ToString())))
                    {
                        this.recordID.Content = "";
                        this.time.Visibility = Visibility.Hidden;
                        this.playerID.Visibility = Visibility.Hidden;
                        this.playerNumber.Visibility = Visibility.Hidden;
                        this.MingPai.Visibility = Visibility.Hidden;
                        this.Shijiao.Visibility = Visibility.Hidden;
                        this.jixvluzhi.Visibility = Visibility.Hidden;
                        this.ShanChu.Content = "已删除";
                    }
                }
                
            }
        }

        private void jixvluzhi_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            int output;
            if (int.TryParse(this.recordID.Content.ToString(), out output))
            {
                int recordID = int.Parse(this.recordID.Content.ToString());
                int playerNum = this.playerID.Items.Count;
                if (recordID != 0)
                {
                    myService.GetRecord().RestartRecord(recordID);

                }
                GameInput GI = new GameInput(playerNum, 0);
                GI.reRecordID = recordID;

                GI.Show();
                foreach (Window w in App.Current.Windows)
                {
                    if (w is GameResult)
                    {
                        w.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("网络连接异常");
            }
            
        }

        private void jixvluzhi_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            int output;
            if(int.TryParse(this.recordID.Content.ToString(),out output))
            {
                int recordID = int.Parse(this.recordID.Content.ToString());
                int playerNum = this.playerID.Items.Count;
                if (recordID != 0)
                {
                    myService.GetRecord().RestartRecord(recordID);

                }
                DataSet recordSet = myService.GetRecord().GetRecordByID(recordID);
                int startChips = 0;
                if (recordSet.Tables.Count != 0)
                {
                    startChips = int.Parse(recordSet.Tables[0].Rows[0]["StartChips"].ToString());
                }
                GameInput GI = new GameInput(playerNum, startChips);
                GI.reRecordID = recordID;

                GI.Show();
                foreach (Window w in App.Current.Windows)
                {
                    if (w is GameResult)
                    {
                        w.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("网络连接异常");
            }
            
        }
    }
}
