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
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
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
            CB1 = OperV.GetComboBox("Select Countries.CountryName From Countries;", ref CB1);
            ls1 = OperV.GetList("Select Countries.CountryID From Countries;");
            ls2 = new List<string>();
        }
        List<string> ls1, ls2;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CB2.SelectedIndex == -1)
            {
                MessageBox.Show("You must select origin country");
                return;
            }
            if (CB1.SelectedIndex == -1)
            {
                MessageBox.Show("You must select customer");
                return;
            }
            if (TB1.Text.Length == 0 || TB2.Text.Length == 0)
            {
                MessageBox.Show("You must enter new names");
                return;
            }
            string command = "UPDATE Clients SET ClientFirstName = '" + TB1.Text + "', ClientLastName = '" + TB2.Text + "', ClientCountryID = "+ls1[CB1.SelectedIndex]+" WHERE ClientID = " + ls2[CB2.SelectedIndex] + ";";
            OperV.GetQuery(command);
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (CB2.SelectedIndex == -1)
            {
                MessageBox.Show("You must select origin country");
                return;
            }
            if (CB1.SelectedIndex == -1)
            {
                MessageBox.Show("You must select customer");
                return;
            }
            MessageBoxResult mbi = MessageBox.Show("If you will delete this client, all related records would be erased", "Are you sure?", MessageBoxButton.YesNo);
            if (mbi == MessageBoxResult.Yes)
            {
                if (!OperV.GetList("Select count(1) from Bills where ClientID = " + ls2[CB2.SelectedIndex])[0].Equals("0")) {
                    MessageBox.Show("You can't delete this client, because he has unpaid bills");
                    return;
                }
                string command = "DELETE FROM Clients WHERE ClientID = " + ls2[CB2.SelectedIndex];
                OperV.GetQuery(command);
                this.Hide();
            }            
        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB2.Items.Clear();
            ls2.Clear();
            CB2.IsEnabled = true;
            CB2 = OperV.GetComboBox("Select Clients.ClientFirstName +' '+ Clients.ClientLastName From Clients WHERE ClientCountryID = "+ls1[CB1.SelectedIndex]+";", ref CB2);
            ls2 = OperV.GetList("Select Clients.ClientID From Clients WHERE ClientCountryID = " + ls1[CB1.SelectedIndex] + ";");
        }
    }
}
