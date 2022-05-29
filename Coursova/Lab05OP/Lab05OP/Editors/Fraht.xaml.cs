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
    /// Логика взаимодействия для Fraht.xaml
    /// </summary>
    public partial class Fraht : Window
    {
        public Fraht()
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
            OperV.GetComboBox("Select Clients.ClientFirstName + ' ' + Clients.ClientLastName From Clients, Fraht where Fraht.ClientID = Clients.ClientID;", ref CB1);
            ls1 = OperV.GetList("Select Clients.ClientID From Clients, Fraht where Fraht.ClientID = Clients.ClientID;");
            ls2 = new List<string>();
            ls3 = new List<string>();
        }

        List<string> ls1, ls2, ls3;

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB2.SelectedIndex == -1)
            {
                return;
            }
            ls3.Clear();
            CB3.Items.Clear();
            OperV.GetComboBox("Select Fraht.DateStart From Fraht where Fraht.ClientID = "+ls1[CB1.SelectedIndex]+" AND Fraht.VessID = "+ls2[CB2.SelectedIndex]+";", ref CB3);
            ls3 = OperV.GetList("Select Fraht.DateStart From Fraht where Fraht.ClientID = " + ls1[CB1.SelectedIndex] + " AND Fraht.VessID = " + ls2[CB2.SelectedIndex] + ";");
        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB1.SelectedIndex == -1)
            {
                return;
            }
            ls2.Clear();
            CB2.Items.Clear();
            OperV.GetComboBox("Select (Select Vessel.VessName From Vessel Where Vessel.VessID = Fraht.VessID) From Clients, Fraht where Fraht.ClientID = Clients.ClientID AND Fraht.ClientID = "+ls1[CB1.SelectedIndex]+";", ref CB2);
            ls2 = OperV.GetList("Select Fraht.VessID From Clients, Fraht where Fraht.ClientID = Clients.ClientID AND Fraht.ClientID = " + ls1[CB1.SelectedIndex] + ";");
        }

        string RefOday(string s)
        {
            string[] str = s.Split(' ')[0].Split('.');

            return str[2] + "." + str[1] + "." + str[0];

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CB3.SelectedIndex == -1)
            {
                MessageBox.Show("You must select all values");
                return;
            }
            string command = "Delete from Fraht Where Fraht.ClientID = " + ls1[CB1.SelectedIndex] + " AND Fraht.VessID = " + ls2[CB2.SelectedIndex] + " And Fraht.DateStart = '"+RefOday(CB3.Text) +"';";
            OperV.GetQuery(command);
            Hide();
        }
    }
}
