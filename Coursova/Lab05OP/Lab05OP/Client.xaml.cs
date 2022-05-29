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

namespace Lab05OP
{
    /// <summary>
    /// Логика взаимодействия для Client.xaml
    /// </summary>
    public partial class Client : Window
    {
        public Client()
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
            LinearGradientBrush lgb = new LinearGradientBrush();
            lgb.StartPoint = new Point(0, 0);
            lgb.EndPoint = new Point(1, 1);
            GradientStop gs1 = new GradientStop(Colors.LightBlue, 0);
            GradientStop gs2 = new GradientStop(Colors.Violet, 1);
            lgb.GradientStops.Add(gs1);
            lgb.GradientStops.Add(gs2);
            B11.Background = lgb;
            fillComboBox();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            switch (CB.SelectedIndex)
            {
                case 0:
                    Adding.Fraht adding1 = new Adding.Fraht();
                    adding1.Show();
                    break;
                case 1:
                    Adding.Nakladna adding = new Adding.Nakladna();
                    adding.Show();
                    break;
                case 2:
                    Adding.Pay4Bills pay4Bills = new Adding.Pay4Bills();
                    pay4Bills.Show();
                    break;
                case 3:
                    Adding.Clients cli = new Adding.Clients();
                    cli.Show();
                    break;
                case 4:
                    Views.Fleet fleet = new Views.Fleet();
                    fleet.Show();
                    break;
                case 5:
                    Views.Nakld nkj = new Views.Nakld();
                    nkj.Show();
                    break;

            }
        }

        void fillComboBox()
        {
            CB.Items.Add("Rent vessel");
            CB.Items.Add("Create cargo");
            CB.Items.Add("Pay");
            CB.Items.Add("New client");
            CB.Items.Add("See free vessels");
            CB.Items.Add("See nakladnaya");

        }

        private void CLI(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Button_Click_123(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }
    }
}
