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
    /// SelectOld.xaml 的交互逻辑
    /// </summary>
    public partial class SelectOld : Window
    {
        private MyService myService = new MyService();
        private int currentPage;
        private int recordNumber;
        private int sumPage;
        public SelectOld()
        {
            InitializeComponent();


            try
            {
                string testWebService = new MyService().GetAdministrator().HelloWorld();
            }
            catch
            {
                MessageBox.Show("无法连接到服务器，请确保网络连接和ip(你输入的ip地址： " + App.ip + ")地址正确(正确ip地址示例：121.197.3.168:8080)");
                return;
            }

            //this.Page1.Foreground = new SolidColorBrush(Color.FromRgb(21, 115, 155));
            this.Page1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            currentPage = 1;
            ShowRecords(currentPage);
            
            
        }

        private void ShowPages()
        {
            recordNumber = myService.GetRecord().getRecordsNumber();
            if (recordNumber % 7 != 0)
                sumPage = recordNumber / 7 + 1;
            else
                sumPage = recordNumber / 7;

            if (sumPage >= 4)
                this.Page5.Content = sumPage + "";
            else
            {
                if (sumPage > 0)
                    this.Page1.Content = "1";
                else
                    this.Page1.Content = "";

                if (sumPage > 1)
                    this.Page2.Content = "2";
                else
                    this.Page2.Content = "";

                if (sumPage > 2)
                    this.Page3.Content = "3";
                else
                    this.Page3.Content = "";

                this.Page4.Content = "";
                this.Page5.Content = "";
            }

            if (sumPage == 1)
            {
                this.Page1.Visibility = Visibility.Hidden;
                this.PageStart.Visibility = Visibility.Hidden;
                this.PagePre.Visibility = Visibility.Hidden;
                this.PageNext.Visibility = Visibility.Hidden;
                this.PageEnd.Visibility = Visibility.Hidden;
            }
                
        }

        private void ShowRecords(int page)
        {
            ShowPages();

            this.recordItem1.Visibility = Visibility.Hidden;
            this.recordItem2.Visibility = Visibility.Hidden;
            this.recordItem3.Visibility = Visibility.Hidden;
            this.recordItem4.Visibility = Visibility.Hidden;
            this.recordItem5.Visibility = Visibility.Hidden;
            this.recordItem6.Visibility = Visibility.Hidden;
            this.recordItem7.Visibility = Visibility.Hidden;
            this.recordItem1.time.Visibility = Visibility.Visible;
            this.recordItem1.playerNumber.Visibility = Visibility.Visible;
            this.recordItem1.playerID.Visibility = Visibility.Visible;
            this.recordItem1.MingPai.Visibility = Visibility.Visible;
            this.recordItem1.Shijiao.Visibility = Visibility.Visible;
            this.recordItem1.jixvluzhi.Visibility = Visibility.Visible;
            this.recordItem1.ShanChu.Content = "删除";
            this.recordItem2.time.Visibility = Visibility.Visible;
            this.recordItem2.playerNumber.Visibility = Visibility.Visible;
            this.recordItem2.playerID.Visibility = Visibility.Visible;
            this.recordItem2.MingPai.Visibility = Visibility.Visible;
            this.recordItem2.Shijiao.Visibility = Visibility.Visible;
            this.recordItem2.jixvluzhi.Visibility = Visibility.Visible;
            this.recordItem2.ShanChu.Content = "删除";
            this.recordItem3.time.Visibility = Visibility.Visible;
            this.recordItem3.playerNumber.Visibility = Visibility.Visible;
            this.recordItem3.playerID.Visibility = Visibility.Visible;
            this.recordItem3.MingPai.Visibility = Visibility.Visible;
            this.recordItem3.Shijiao.Visibility = Visibility.Visible;
            this.recordItem3.jixvluzhi.Visibility = Visibility.Visible;
            this.recordItem3.ShanChu.Content = "删除";
            this.recordItem4.time.Visibility = Visibility.Visible;
            this.recordItem4.playerNumber.Visibility = Visibility.Visible;
            this.recordItem4.playerID.Visibility = Visibility.Visible;
            this.recordItem4.MingPai.Visibility = Visibility.Visible;
            this.recordItem4.Shijiao.Visibility = Visibility.Visible;
            this.recordItem4.jixvluzhi.Visibility = Visibility.Visible;
            this.recordItem4.ShanChu.Content = "删除";
            this.recordItem5.time.Visibility = Visibility.Visible;
            this.recordItem5.playerNumber.Visibility = Visibility.Visible;
            this.recordItem5.playerID.Visibility = Visibility.Visible;
            this.recordItem5.MingPai.Visibility = Visibility.Visible;
            this.recordItem5.Shijiao.Visibility = Visibility.Visible;
            this.recordItem5.jixvluzhi.Visibility = Visibility.Visible;
            this.recordItem5.ShanChu.Content = "删除";
            this.recordItem6.time.Visibility = Visibility.Visible;
            this.recordItem6.playerNumber.Visibility = Visibility.Visible;
            this.recordItem6.playerID.Visibility = Visibility.Visible;
            this.recordItem6.MingPai.Visibility = Visibility.Visible;
            this.recordItem6.Shijiao.Visibility = Visibility.Visible;
            this.recordItem6.jixvluzhi.Visibility = Visibility.Visible;
            this.recordItem6.ShanChu.Content = "删除";
            this.recordItem7.time.Visibility = Visibility.Visible;
            this.recordItem7.playerNumber.Visibility = Visibility.Visible;
            this.recordItem7.playerID.Visibility = Visibility.Visible;
            this.recordItem7.MingPai.Visibility = Visibility.Visible;
            this.recordItem7.Shijiao.Visibility = Visibility.Visible;
            this.recordItem7.jixvluzhi.Visibility = Visibility.Visible;
            this.recordItem7.ShanChu.Content = "删除";


            this.recordItem1.playerID.Items.Clear();
            this.recordItem2.playerID.Items.Clear();
            this.recordItem3.playerID.Items.Clear();
            this.recordItem4.playerID.Items.Clear();
            this.recordItem5.playerID.Items.Clear();
            this.recordItem6.playerID.Items.Clear();
            this.recordItem7.playerID.Items.Clear();
            DataSet recordset=myService.GetRecord().GetRecordsByPage(page);
            if(recordset.Tables.Count!=0)
            {
                DataTable table = recordset.Tables[0];
                int count=table.Rows.Count;
                if(count>0)
                {
                    this.recordItem1.Visibility = Visibility.Visible;
                    this.recordItem1.time.Content=table.Rows[0]["Time"].ToString();
                    int playerNumber = int.Parse(table.Rows[0]["PlayerNumber"].ToString());
                    this.recordItem1.playerNumber.Content = playerNumber + "人";
                    
                    for(int i=1;i<=playerNumber;i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = "第"+i+"组";
                        this.recordItem1.playerID.Items.Add(item);
                    }
                    this.recordItem1.recordID.Content=table.Rows[0]["ID"].ToString();
                }
                if (count > 1)
                {
                    this.recordItem2.Visibility = Visibility.Visible;
                    this.recordItem2.time.Content = table.Rows[1]["Time"].ToString();
                    int playerNumber = int.Parse(table.Rows[1]["PlayerNumber"].ToString());
                    this.recordItem2.playerNumber.Content = playerNumber + "人";
                    for (int i = 1; i <= playerNumber; i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = "第" + i + "组";
                        this.recordItem2.playerID.Items.Add(item);
                    }
                    this.recordItem2.recordID.Content = table.Rows[1]["ID"].ToString();
                }
                if (count > 2)
                {
                    this.recordItem3.Visibility = Visibility.Visible;
                    this.recordItem3.time.Content = table.Rows[2]["Time"].ToString();
                    int playerNumber = int.Parse(table.Rows[2]["PlayerNumber"].ToString());
                    this.recordItem3.playerNumber.Content = playerNumber + "人";
                    for (int i = 1; i <= playerNumber; i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = "第" + i + "组";
                        this.recordItem3.playerID.Items.Add(item);
                    }
                    this.recordItem3.recordID.Content = table.Rows[2]["ID"].ToString();
                }
                if (count > 3)
                {
                    this.recordItem4.Visibility = Visibility.Visible;
                    this.recordItem4.time.Content = table.Rows[3]["Time"].ToString();
                    int playerNumber = int.Parse(table.Rows[3]["PlayerNumber"].ToString());
                    this.recordItem4.playerNumber.Content = playerNumber + "人";
                    for (int i = 1; i <= playerNumber; i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = "第" + i + "组";
                        this.recordItem4.playerID.Items.Add(item);
                    }
                    this.recordItem4.recordID.Content = table.Rows[3]["ID"].ToString();
                }
                if (count > 4)
                {
                    this.recordItem5.Visibility = Visibility.Visible;
                    this.recordItem5.time.Content = table.Rows[4]["Time"].ToString();
                    int playerNumber = int.Parse(table.Rows[4]["PlayerNumber"].ToString());
                    this.recordItem5.playerNumber.Content = playerNumber + "人";
                    for (int i = 1; i <= playerNumber; i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = "第" + i + "组";
                        this.recordItem5.playerID.Items.Add(item);
                    }
                    this.recordItem5.recordID.Content = table.Rows[4]["ID"].ToString();
                }
                if (count > 5)
                {
                    this.recordItem6.Visibility = Visibility.Visible;
                    this.recordItem6.time.Content = table.Rows[5]["Time"].ToString();
                    int playerNumber = int.Parse(table.Rows[5]["PlayerNumber"].ToString());
                    this.recordItem6.playerNumber.Content = playerNumber + "人";
                    for (int i = 1; i <= playerNumber; i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = "第" + i + "组";
                        this.recordItem6.playerID.Items.Add(item);
                    }
                    this.recordItem6.recordID.Content = table.Rows[5]["ID"].ToString();
                }
                if (count > 6)
                {
                    this.recordItem7.Visibility = Visibility.Visible;
                    this.recordItem7.time.Content = table.Rows[6]["Time"].ToString();
                    int playerNumber = int.Parse(table.Rows[6]["PlayerNumber"].ToString());
                    this.recordItem7.playerNumber.Content = playerNumber + "人";
                    for (int i = 1; i <= playerNumber; i++)
                    {
                        ComboBoxItem item = new ComboBoxItem();
                        item.Content = "第" + i + "组";
                        this.recordItem7.playerID.Items.Add(item);
                    }
                    this.recordItem7.recordID.Content = table.Rows[6]["ID"].ToString();
                }
            }

            //显示分页结果
            this.Page5.Foreground = new SolidColorBrush(Color.FromRgb(21, 115, 155));
            this.Page3.Foreground = new SolidColorBrush(Color.FromRgb(21, 115, 155));
            this.Page2.Foreground = new SolidColorBrush(Color.FromRgb(21, 115, 155));
            this.Page1.Foreground = new SolidColorBrush(Color.FromRgb(21, 115, 155));

            if(sumPage>=4)
            {
                if(sumPage-currentPage<=3)
                {
                    this.Page5.Content = sumPage + "";
                    this.Page3.Content = sumPage - 1 + "";
                    this.Page2.Content = sumPage - 2 + "";
                    this.Page1.Content = sumPage - 3 + "";

                    if (currentPage == sumPage)
                        this.Page5.Foreground = new SolidColorBrush(Color.FromRgb(0,0,0));
                    else if(currentPage==sumPage-1)
                        this.Page3.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    else if (currentPage == sumPage - 2)
                        this.Page2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    else if (currentPage == sumPage - 3)
                        this.Page1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
                else
                {
                    this.Page5.Content = sumPage + "";
                    this.Page3.Content = currentPage + 2 + "";
                    this.Page2.Content = currentPage + 1 + "";
                    this.Page1.Content = currentPage + "";

                    this.Page1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                }
            }
            else
            {
                if(currentPage==1)
                    this.Page1.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                else if(currentPage==2)
                    this.Page2.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                else if(currentPage==3)
                    this.Page3.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0)); 
                else if(currentPage==4)
                    this.Page5.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
            
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

        private void Label_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentPage = 1;
            ShowRecords(currentPage);
        }

        private void Label_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            

            currentPage = sumPage;
            ShowRecords(currentPage);
        }

        private void Label_MouseLeftButtonUp_2(object sender, MouseButtonEventArgs e)
        {
            if(currentPage>1)
            {
                currentPage -= 1;
                ShowRecords(currentPage);
            }
        }

        private void Label_MouseLeftButtonUp_3(object sender, MouseButtonEventArgs e)
        {
            if(currentPage < sumPage)
            {
                currentPage += 1;
                ShowRecords(currentPage);
            }
        }

        private void Page1_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentPage = int.Parse(this.Page1.Content.ToString());
            ShowRecords(currentPage);
        }

        private void Page2_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentPage = int.Parse(this.Page2.Content.ToString());
            ShowRecords(currentPage);
        }

        private void Page3_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentPage = int.Parse(this.Page3.Content.ToString());
            ShowRecords(currentPage);
        }

        private void Page5_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            currentPage = int.Parse(this.Page5.Content.ToString());
            ShowRecords(currentPage);
        }
    }
}
