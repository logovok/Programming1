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
    /// Логика взаимодействия для Fleet.xaml
    /// </summary>
    public partial class Fleet : Window
    {
        public Fleet()
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
                string query = "Select Vessel.VessName as 'Name of vessel', Clients.ClientFirstName as 'First name', Clients.ClientLastName as 'Last name', Fraht.DateStart as 'From', Fraht.DateStop as 'To' From Vessel, Clients, Fraht" +
" Where Vessel.VessID = Fraht.VessID and Clients.ClientID = Fraht.ClientID AND Fraht.DateStart <= '" + TB2.Text + "' AND Fraht.DateStop >='" + TB1.Text + "'";
                OperV.GetDataGrid(query, ref DTGR);
                query = "Select Vessel.VessName as 'Vessel name', VessTypes.VessTypeName, Count(1) as 'Number of cells in use', VessCellsNum - Count(1) as 'Free cels' From Vessel, VessTypes, VessCell, RouteStops " +
                    "Where VessCell.VessID = Vessel.VessID AND RouteStops.PortOutID = VessCell.PortFromID AND RouteStops.PortInID = VessCell.PortToID " +
                    "AND RouteStops.PortOutDate <='" + TB2.Text + "' AND RouteStops.PortInDate>='" + TB1.Text + "' AND Vessel.VessID = RouteStops.VessID" +
                    " AND VessCell.PortFromDate = RouteStops.PortOutDate AND VessTypes.VessTypeID = Vessel.VessTypeID Group by Vessel.VessName, VessTypes.VessTypeName, VessCellsNum";
                OperV.GetDataGrid(query, ref DTGR2);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                MessageBox.Show(exc.StackTrace);
            }
           
        }

       
    }
}
