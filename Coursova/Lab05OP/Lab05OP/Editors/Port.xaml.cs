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
    /// Логика взаимодействия для Port.xaml
    /// </summary>
    public partial class Port : Window
    {
        public Port()
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
            ls2 = new List<string>();
            ls1 = new List<string>();
            OperV.GetComboBox("Select Countries.CountryName From Countries, tPort Where tPort.PortCountryID = Countries.CountryID", ref CB1);
            ls1 = OperV.GetList("Select Countries.CountryID From Countries, tPort Where tPort.PortCountryID = Countries.CountryID");
        }
        List<string> ls1, ls2;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string command = "UPDATE tPort SET PortName = '" + TB1.Text + "' WHERE PortID = " + ls2[CB2.SelectedIndex];
            OperV.GetQuery(command);
            ls1.Clear();
            ls2.Clear();
            CB1.Items.Clear();
            CB2.Items.Clear();
            OperV.GetComboBox("Select Countries.CountryName From Countries, tPort Where tPort.PortCountryID = Countries.CountryID", ref CB1);
            ls1 = OperV.GetList("Select Countries.CountryID From Countries, tPort Where tPort.PortCountryID = Countries.CountryID");

        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB1.SelectedIndex == -1)
            {
                return;

            }
            CB2.Items.Clear();
            ls2.Clear();
            OperV.GetComboBox("Select tPort.PortName From tPort Where tPort.PortCountryID = "+ls1[CB1.SelectedIndex]+";", ref CB2);
            ls2 = OperV.GetList("Select tPort.PortID From tPort Where tPort.PortCountryID = " + ls1[CB1.SelectedIndex] + ";");

        }
    }
}
