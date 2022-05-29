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
    /// Логика взаимодействия для VessTypes.xaml
    /// </summary>
    public partial class VessTypes : Window
    {
        public VessTypes()
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                string command = "INSERT INTO VessTypes (VessTypeName, VessCellName) VALUES ('" + TB1.Text + "','" + TB2.Text + "')";
                OperV.GetQuery(command);
            }
            catch (Exception)
            {
                MessageBox.Show("Seems like you entered incorrect data");
            }
            this.Close();
        }
    }
}
