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
    /// Логика взаимодействия для Owner.xaml
    /// </summary>
    public partial class Owner : Window
    {
        public Owner()
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
            fillComboBox();
            LinearGradientBrush lgb = new LinearGradientBrush();
            lgb.StartPoint = new Point(0, 0);
            lgb.EndPoint = new Point(1, 1);
            GradientStop gs1 = new GradientStop(Colors.LightBlue, 0);
            GradientStop gs2 = new GradientStop(Colors.Violet, 1);
            lgb.GradientStops.Add(gs1);
            lgb.GradientStops.Add(gs2);
            B11.Background = lgb;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sw==-1)
            {
                return;
            }
            if (sw == 0)
            {
                switch (CB.SelectedIndex)
                {
                    case 0:
                        Adding.Countries ac = new Adding.Countries();
                        ac.Show();
                        break;
                    case 1:
                        Adding.Port ac1 = new Adding.Port();
                        ac1.Show();
                        break;
                    case 2:
                        Adding.VessTypes ac2 = new Adding.VessTypes();
                        ac2.Show();
                        break;
                    case 3:
                        Adding.Vess ac3 = new Adding.Vess();
                        ac3.Show();
                        break;
                    case 4:
                        Adding.Clients ac4 = new Adding.Clients();
                        ac4.Show();
                        break;
                    case 5:
                        Adding.RouteSetter ac5 = new Adding.RouteSetter();
                        ac5.Show();
                        break;

                }
            }
            else if (sw == 1)
            {
                switch (CB2.SelectedIndex)
                {
                    case 0:
                        Views.Fleet fl = new Views.Fleet();
                        fl.Show();
                        break;
                    case 1:
                        Views.OwnersSee4Bills osb = new Views.OwnersSee4Bills();
                        osb.Show();
                        break;
                    case 2:
                        Views.zvks zvks = new Views.zvks();
                        zvks.Show();
                        break;


                }
            }
            else if (sw == 2) {
                switch (CB3.SelectedIndex)
                {
                    case 0:
                        Editors.VessNameEd vsd = new Editors.VessNameEd();
                        vsd.Show();
                        break;
                    case 1:
                        Editors.Client ecl = new Editors.Client();
                        ecl.Show();
                        break;
                    case 2:
                        Editors.Route ecr = new Editors.Route();
                        ecr.Show();
                        break;
                    case 3:
                        Editors.Country cnt = new Editors.Country();
                        cnt.Show();
                        break;
                    case 4:
                        Editors.Port prt = new Editors.Port();
                        prt.Show();
                        break;
                    case 5:
                        Editors.Fraht frh = new Editors.Fraht();
                        frh.Show();
                        break;


                }
            }
            
        }

        void fillComboBox()
        {
            CB.Items.Add("Add country");
            CB.Items.Add("Add ports");
            CB.Items.Add("Add vessel types");
            CB.Items.Add("Add vessels");
            CB.Items.Add("Add clients");
            CB.Items.Add("Add route");
            CB2.Items.Add("See vessel loaded");
            CB2.Items.Add("See unpaid bills");
            CB2.Items.Add("See orders");
            CB3.Items.Add("Vessel");
            CB3.Items.Add("Client");
            CB3.Items.Add("Route");
            CB3.Items.Add("Country");
            CB3.Items.Add("Port");
            CB3.Items.Add("Fraht");
        }

        private void CLI(object sender, EventArgs e)
        {

            Application.Current.Shutdown();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }
        int sw = -1, countiff = 0;
        private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (countiff == 0)
            {
                sw = 0;
                if (CB2.SelectedIndex != -1)
                {
                    countiff++;
                }
                if (CB3.SelectedIndex != -1)
                {
                    countiff++;
                }
                CB2.SelectedIndex = -1;
                CB3.SelectedIndex = -1;
            }
            else
            {
                countiff--;
            }
            
        }

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (countiff == 0)
            {
                if (CB.SelectedIndex != -1)
                {
                    countiff++;
                }
                if (CB3.SelectedIndex != -1)
                {
                    countiff++;
                }
                sw = 1;
                CB.SelectedIndex = -1;
                CB3.SelectedIndex = -1;
            }
            else
            {
                countiff--;
            }
        }

        private void CB3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (countiff == 0)
            {
                if (CB2.SelectedIndex != -1)
                {
                    countiff++;
                }
                if (CB.SelectedIndex != -1)
                {
                    countiff++;
                }
                sw = 2;
                CB.SelectedIndex = -1;
                CB2.SelectedIndex = -1;
            }
            else
            {
                countiff--;
            }
            
        }
    }
}
