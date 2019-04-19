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

using System.IO.Ports;
     
namespace WpfApp1
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            dataWindow dtWindow = new dataWindow();

            dtWindow.ShowDialog();

            //SerialPort Port = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);

            //Port.DataReceived += Port_DataReceived;

            InitializeComponent();

        }

        private void Port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Log(object sender, RoutedEventArgs e)
        {
            if(UserNameBox.Text == "admin" && PasswordBox.Password == "admin")
            {
                MessageBox.Show("登陆成功");
                controlWindow ctWindow = new controlWindow();
                ctWindow.ShowDialog();
                


            }
            else
            {
                MessageBox.Show("用户名或密码错误");
            }
        }

        
    }
}
