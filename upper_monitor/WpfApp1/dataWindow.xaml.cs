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
    /// dataWindow.xaml 的交互逻辑
    /// </summary>
    public partial class dataWindow : Window
    {
        private SerialPort dataPort = new SerialPort("COM5",9600,Parity.None);
        
        public dataWindow()
        {
            dataPort.StopBits = StopBits.One;
            InitializeComponent();
            dataPort.DataReceived += DataPort_DataReceived;
        }

        private void DataPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            
            bt1.Content = "RE";
            dataPort.Open();
            MessageBox.Show(dataPort.ReadLine());
            dataPort.Close();
            throw new NotImplementedException();
        }
    }
}
