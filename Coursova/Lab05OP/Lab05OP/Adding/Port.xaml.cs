using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab05OP.Adding
{
    /// <summary>
    /// Логика взаимодействия для Port.xaml
    /// </summary>
    public partial class Port : Window
    {
        public Port()
        {
            InitializeComponent();
            LinearGradientBrush lgb2 = new LinearGradientBrush();
            lgb2.StartPoint = new Point(0, 0);
            lgb2.EndPoint = new Point(1, 1);
            GradientStop gs3 = new GradientStop(Colors.BlueViolet, 0);
            GradientStop gs4 = new GradientStop(Colors.LightBlue, 1);
            lgb2.GradientStops.Add(gs3);
            lgb2.GradientStops.Add(gs4);
            this.Background = lgb2;
            try
            {
                string str = "SELECT CountryName FROM Countries";
                OperV.GetComboBox(str, ref CB1);
                str = "SELECT CountryID FROM Countries";
                lst1 = OperV.GetList(str);
            }
            catch (Exception)
            {

                MessageBox.Show("Smth wrong");
            }
            
        }

        List<string> lst1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = "INSERT INTO tPort (PortName, PortCountryID) VALUES ('" + TB1.Text + "', " + lst1[CB1.SelectedIndex] + ")";
                OperV.GetQuery(str);
                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Smth wrong");
            }
            
        }
    }
}
