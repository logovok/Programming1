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

namespace Lab05OP.Views
{
    /// <summary>
    /// Логика взаимодействия для Nakld.xaml
    /// </summary>
    public partial class Nakld : Window
    {
        public Nakld()
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
            ls1 = new List<string>();
            ls2 = new List<string>();
            ls3 = new List<string>();
            ls1.Clear();
            CB1.Items.Clear();
            OperV.GetComboBox("SELECT Clients.ClientFirstName + ' ' + Clients.ClientLastName FROM Clients", ref CB1);
            ls1 = OperV.GetList("SELECT Clients.ClientID FROM Clients");
        }

        List<string> ls1, ls2, ls3;

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB3.Items.Clear();
            ls3.Clear();
            if (CB2.SelectedIndex == -1)
            {
                return;
            }
            OperV.GetComboBox("Select VessCell.VessCellID From VessCell Where VessCell.CellClientID = "+ls1[CB1.SelectedIndex]+" AND VessCell.VessID = "+ls2[CB2.SelectedIndex]+";", ref CB3);
            ls3 = OperV.GetList("Select VessCell.VessCellID From VessCell Where VessCell.CellClientID = " + ls1[CB1.SelectedIndex] + " AND VessCell.VessID = " + ls2[CB2.SelectedIndex] + ";");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string command = "Delete TOP(1) From VessCell Where VessCell.VessCellID = " + ls3[CB3.SelectedIndex] + ";";
            OperV.GetQuery(command);
            ls1.Clear();
            CB1.Items.Clear();
            OperV.GetComboBox("SELECT Clients.ClientFirstName + ' ' + Clients.ClientLastName FROM Clients", ref CB1);
            ls1 = OperV.GetList("SELECT Clients.ClientID FROM Clients");
        }

        private void CB3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB3.SelectedIndex == -1)
            {
                DTGR.ItemsSource = null;
                TB1.Text = "From"; TB2.Text = "At"; TB3.Text = "To"; TB4.Text = "At";
                return;
            }
            DTGR.ItemsSource = null;
            TB1.Text ="From " + OperV.GetList("Select (Select TOP(1) tPort.PortName From tPort Where tPort.PortID = VessCell.PortFromID) From VessCell WHERE VessCell.VessCellID = "+ls3[CB3.SelectedIndex]+";")[0];
            TB2.Text ="At "+ OperV.GetList("Select TOP(1) VessCell.PortFromDate From VessCell Where VessCell.VessCellID= " + ls3[CB3.SelectedIndex] + ";")[0].Split(' ')[0];
            TB3.Text ="To "+ OperV.GetList("Select (Select tPort.PortName From tPort Where tPort.PortID = RouteStops.PortInID) From VessCell, RouteStops Where VessCell.VessCellID= " + ls3[CB3.SelectedIndex] + " AND VessCell.VessID = RouteStops.VessID And VessCell.PortFromDate = RouteStops.PortOutDate;")[0];
            TB4.Text ="At "+ OperV.GetList("Select RouteStops.PortInDate From VessCell, RouteStops Where VessCell.VessCellID= " + ls3[CB3.SelectedIndex] + " AND VessCell.VessID = RouteStops.VessID And VessCell.PortFromDate = RouteStops.PortOutDate;")[0].Split(' ')[0];
            OperV.GetDataGrid("Select Cargo.CargoName as 'Name of cargo', Cargo.CargoWeigth as 'Weigth', CargoOdn as 'Measuring units' From Cargo Where Cargo.VessCellID = " + ls3[CB3.SelectedIndex] + ";", ref DTGR);
        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            CB2.Items.Clear();
            ls2.Clear();
            if (CB1.SelectedIndex == -1)
            {
                return;
            }
            OperV.GetComboBox("Select Vessel.VessName From Vessel, VessCell, Clients "+
" Where Vessel.VessID = VessCell.VessID AND VessCell.VessCellID = ClientID AND VessCell.CellClientID = " + ls1[CB1.SelectedIndex]+"; " , ref CB2);
            ls2 = OperV.GetList("Select Vessel.VessID From Vessel, VessCell, Clients "+
" Where Vessel.VessID = VessCell.VessID AND VessCell.VessCellID = ClientID AND VessCell.CellClientID = " + ls1[CB1.SelectedIndex] + "; ");
        }
    }
}
