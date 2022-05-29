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

namespace Lab05OP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LinearGradientBrush lgb = new LinearGradientBrush();
            lgb.StartPoint = new Point(0, 0);
            lgb.EndPoint = new Point(1, 1);
            GradientStop gs1 = new GradientStop(Colors.LightBlue, 0);
            GradientStop gs2 = new GradientStop(Colors.Violet, 1);
            lgb.GradientStops.Add(gs1);
            lgb.GradientStops.Add(gs2);
            B1.Background = lgb;
            B2.Background = lgb;
            LinearGradientBrush lgb2 = new LinearGradientBrush();
            lgb2.StartPoint = new Point(0, 0);
            lgb2.EndPoint = new Point(1, 1);
            GradientStop gs3 = new GradientStop(Colors.BlueViolet, 0);
            GradientStop gs4 = new GradientStop(Colors.LightBlue, 1);
            lgb2.GradientStops.Add(gs3);
            lgb2.GradientStops.Add(gs4);
            this.Background = lgb2;
            string connection = "Data Source=HPPVL15;Initial Catalog=NDB;"
        + "Integrated Security=true;";
            OperV.SetConnection(connection);

        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            Client cl = new Client();
            this.Hide();
            cl.Show();
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            Owner ow = new Owner();
            this.Hide();
            ow.Show();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
