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

namespace Lab3Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            string conne = "Data Source=HPPVL15;Initial Catalog=NDB;"
        + "Integrated Security=true;";
            string cnnn = @"Data Source=192.168.178.98,1433;Initial Catalog=NDB; User ID=remuse;Password=Ght0Ght0;";
            SequelOperator.Open(cnnn);
            // SequelOperator.Sv();
            //this.ResizeMode = ResizeMode.NoResize;
            //SequelOperator.Sv();
            Window1 w1 = new Window1();
            this.Hide();
            w1.Show();

        }

        int clc = 0;

        

        

        private void Window_Closed(object sender, EventArgs e)
        {
            
            SequelOperator.Close();
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String msg = "Developed by Maltsev Mykyta,\n" +
                "KP-12 \n" +
                "email - logovok093@gmail.com";
            MessageBox.Show(msg);
        }
    }
}
