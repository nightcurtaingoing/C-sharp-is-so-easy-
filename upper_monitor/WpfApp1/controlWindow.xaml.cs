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
using System.Windows.Shapes;

using System.IO.Ports;



namespace WpfApp1
{
    /// <summary>
    /// controlWindow.xaml 的交互逻辑
    /// </summary>
    public partial class controlWindow : Window
    {
        private bool isLighting = false;
        private bool isHavingPort = false;
        private byte[] Head = new byte[1] { 0xee };
        private byte[] OpenCommand = new byte[1] { 0x01 };
        private byte[] CloseCommand = new byte[1] { 0x81 };
        SerialPort controlPort = new SerialPort();

        public controlWindow()
        {
            
            InitializeComponent();
            putUP.IsEnabled = false;

        }

        private void Light_Click(object sender, RoutedEventArgs e)
        {
            
            
            isHavingPort = cheakPort(controlPort);
            if(isHavingPort)
            {
                putUP.IsEnabled = true;
                light.IsEnabled = false;
                isLighting = true;
                ball.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF10FD10"));
                controlPort.Open();
                controlPort.Write(Head, 0, 1);
                controlPort.Write(OpenCommand, 0, 1);
                controlPort.Close();
            }
            





        }

        private void PutUP_Click(object sender, RoutedEventArgs e)
        {
            if(isHavingPort)
            {
                putUP.IsEnabled = false;
                light.IsEnabled = true;
                isLighting = false;
                ball.Fill = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDCC7C7"));
                controlPort.Open();
                controlPort.Write(Head, 0, 1);
                controlPort.Write(CloseCommand, 0, 1);
                controlPort.Close();

            }
            
        }

        private bool cheakPort(SerialPort MyPort)
        {
            string Buffer;
            int i;
            for (i = 1; i < 20; i++)
            {
                try
                {
                    Buffer = "COM" + i.ToString();
                    MyPort.PortName = Buffer;
                    MyPort.Open();
                    MyPort.Close();
                    break;
                }
                catch
                {

                }
            }
            if (i == 20)
            {
                MessageBox.Show("串口未连接");
                //this.DialogResult = true;
                return false;

            }
            else
                return true;
            
        }

       
    }
}
