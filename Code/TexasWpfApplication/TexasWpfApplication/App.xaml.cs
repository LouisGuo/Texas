using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using TexasWpfApplication.Common;


namespace TexasWpfApplication
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private Display display = new Display();
        public static string ip = "";
        private string path = AppDomain.CurrentDomain.BaseDirectory;

        private DispatcherTimer timer = new DispatcherTimer();

        private string changeDisplayConfig = "";
        private void App_Startup(object sender, StartupEventArgs e)
        {
            

            if (!File.Exists(path + "Server.ini"))
            {
                FileStream aFile = new FileStream(path + "Server.ini", FileMode.OpenOrCreate);
                StreamWriter sw = new StreamWriter(aFile);
                sw.WriteLine("ip=121.197.3.168:8080".Trim());
                sw.WriteLine("ChangeDisplay=true".Trim());
                sw.Close();
            }
            try
            {
                StreamReader fs = new StreamReader(path + "Server.ini");
                //ip = fs.ReadLine();
                string line = fs.ReadLine();
                while(line!=null)
                {
                    string[] config = line.Split('=');
                    if(config.Length==2)
                    {
                        if(config[0].ToLower().Equals("ip"))
                            ip=config[1].Trim();
                        if (config[0].ToLower().Equals("ChangeDisplay".ToLower()))
                            changeDisplayConfig = config[1].Trim();
                    }
                    line = fs.ReadLine();
                }

                fs.Close();
            }
            catch
            {

            }

            
            try
            {
                string testWebService = new MyService().GetAdministrator().HelloWorld();
            }
            catch
            {
                MessageBox.Show("无法连接到服务器，请确保网络连接和ip(你输入的ip地址： " + ip + ")地址正确(正确ip地址示例：121.197.3.168:8080)");
                //Application.Current.Shutdown();
                return;
            }
            if(changeDisplayConfig.ToLower().Equals("true"))
                display.ChangeDisplay();


            
            //timer.Interval = TimeSpan.FromSeconds(0.5);
            //timer.Tick += theout;
            //timer.Start();



            
        }

        public void theout(object source, EventArgs e)
        {
            try
            {
                string testWebService = new MyService().GetAdministrator().HelloWorld();
            }
            catch
            {
                MessageBox.Show("无法连接到服务器，请确保网络连接和ip(你输入的ip地址： " + ip + ")地址正确(正确ip地址示例：121.197.3.168:8080)");
                Application.Current.Shutdown();
                return;
            }
        }


        private void App_Exit(object sender, EventArgs e)
        {

            if (changeDisplayConfig.ToLower().Equals("true"))
                display.ResetDisplay();
        }

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("ERROR: 请到根目录Log文件夹下查看异常信息");
            if (!Directory.Exists(path+"Log"))
            {
                Directory.CreateDirectory(path+"Log");
            }
            DateTime now = DateTime.Now;
            string logpath = path+"Log//"+string.Format(@"Exception {0}-{1}-{2} {3}时{4}分{5}秒.log", now.Year, now.Month, now.Day,now.Hour,now.Minute,now.Second);
            System.IO.File.AppendAllText(logpath, string.Format("\r\n----------------------{0}--------------------------\r\n", now.ToString("yyyy-MM-dd HH:mm:ss")));
            System.IO.File.AppendAllText(logpath, e.Exception+"");
            System.IO.File.AppendAllText(logpath, "\r\n");
            System.IO.File.AppendAllText(logpath, e.Handled+"");
            System.IO.File.AppendAllText(logpath, "\r\n");
            System.IO.File.AppendAllText(logpath, "\r\n----------------------footer--------------------------\r\n");
        }


    }
}
