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
    /// Логика взаимодействия для zvks.xaml
    /// </summary>
    public partial class zvks : Window
    {
        public zvks()
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
                string c = "SELECT Clients.ClientFirstName + ' ' + Clients.ClientLastName as 'Name',Count(Cargo.VessCellID) as 'Number of goods in cells', Vessel.VessName as 'Vessel name', (Select tPort.PortName FROM tPort where tPort.PortID = VessCell.PortFromID) as 'Port of departure',(Select tPort.PortName FROM tPort where tPort.PortID = VessCell.PortToID) as 'Destenation port', VessCell.PortFromDate" +
   " FROM Clients, Vessel, Cargo, VessCell" +
   " Where VessCell.VessID = Vessel.VessID AND VessCell.CellClientID = Clients.ClientID AND Cargo.VessCellID = VessCell.VessCellID AND VessCell.PortFromDate >= '" + TB.Text + "'" +
   " Group by VessCell.PortFromDate, Clients.ClientFirstName, ClientLastName, Vessel.VessName, VessCell.PortFromID, VessCell.PortToID";
                OperV.GetDataGrid(c, ref DG);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
        }
    }
}
