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
    /// Логика взаимодействия для VessNameEd.xaml
    /// </summary>
    public partial class VessNameEd : Window
    {
        public VessNameEd()
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
            CB1 = OperV.GetComboBox("select VessTypes.VessTypeName from VessTypes;", ref CB1);
            ls1 = OperV.GetList("Select VessTypes.VessTypeID From VessTypes;");
        }
        List<string> ls1, ls2;
        void editNameOfVessel()
        {
            //string command = "UPDATE Vessels SET Name = '" + textBox.Text + "' WHERE ID = " + MainWindow.idOfVessel;
        }

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TB1.IsEnabled = true;
            B2.IsEnabled = true;
        }

        private void TB1_TextChanged(object sender, TextChangedEventArgs e)
        {
            B1.IsEnabled = true;
        }

        private void B1_Click(object sender, RoutedEventArgs e)
        {
            if (TB1.Text.Length == 0)
            {
                return;
            }
            string command = "UPDATE Vessel SET VessName = '" + TB1.Text + "' WHERE VessID = " + ls2[CB2.SelectedIndex];
            OperV.GetQuery(command);
        }

        private void B2_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbi = MessageBox.Show("If you will delete this vessel, all records with it would be erased", "Are you sure?", MessageBoxButton.YesNo);
            if (mbi == MessageBoxResult.Yes)
            {
                string command = "DELETE FROM Vessels WHERE VessID = " + ls2[CB2.SelectedIndex];
                OperV.GetQuery(command);
                this.Hide();
            }
            
        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB2.Items.Clear();
            ls2.Clear();
            CB2.IsEnabled = true;
            CB2 = OperV.GetComboBox("select Vessel.VessName from Vessel Where Vessel.VessTypeID = "+ls1[CB1.SelectedIndex]+";", ref CB2);
            ls2 = OperV.GetList("Select Vessel.VessID From Vessel Where Vessel.VessTypeID = " + ls1[CB1.SelectedIndex] + ";");
        }
    }
}
