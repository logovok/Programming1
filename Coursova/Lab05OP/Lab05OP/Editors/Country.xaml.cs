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

namespace Lab05OP.Editors
{
    /// <summary>
    /// Логика взаимодействия для Country.xaml
    /// </summary>
    public partial class Country : Window
    {
        public Country()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
            LinearGradientBrush lgb2 = new LinearGradientBrush();
            lgb2.StartPoint = new Point(0, 0);
            lgb2.EndPoint = new Point(1, 1);
            GradientStop gs3 = new GradientStop(Colors.BlueViolet, 0);
            GradientStop gs4 = new GradientStop(Colors.LightBlue, 1);
            lgb2.GradientStops.Add(gs3);
            lgb2.GradientStops.Add(gs4);
            this.Background = lgb2;
            OperV.GetComboBox("Select Countries.CountryName From Countries", ref CB1);
            ls1 = OperV.GetList("Select Countries.CountryID From Countries");
        }
        List<string> ls1;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CB1.SelectedIndex == -1)
            {
                MessageBox.Show("Select smth");
                return;
            }
            string command = "Delete From Countries Where CountryID = " + ls1[CB1.SelectedIndex];
            OperV.GetQuery(command);
            ls1.Clear(); CB1.Items.Clear();
            OperV.GetComboBox("Select Countries.CountryName From Countries", ref CB1);
            ls1 = OperV.GetList("Select Countries.CountryID From Countries");

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CB1.SelectedIndex == -1)
            {
                MessageBox.Show("Select smth");
                return;
            }
            string command = "Update Countries Set CountryName = '" + TB1.Text + "' Where CountryID = " + ls1[CB1.SelectedIndex];
            OperV.GetQuery(command);
            ls1.Clear(); CB1.Items.Clear();
            OperV.GetComboBox("Select Countries.CountryName From Countries", ref CB1);
            ls1 = OperV.GetList("Select Countries.CountryID From Countries");
        }
    }
}
