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

namespace Lab05OP.Adding
{
    /// <summary>
    /// Логика взаимодействия для Fraht.xaml
    /// </summary>
    public partial class Fraht : Window
    {
        public Fraht()
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
            try
            {
                string str = "SELECT VessName FROM Vessel";
                OperV.GetComboBox(str, ref CB1);
                str = "SELECT ClientFirstName FROM Clients";
                List<string> list1 = OperV.GetList(str);
                str = "SELECT ClientLastName FROM Clients";
                List<string> list2 = OperV.GetList(str);

                for (int i = 0; i < list1.Count; i++)
                {
                    ComboBoxItem cbi = new ComboBoxItem();
                    cbi.Content = list1[i] + " " + list2[i];
                    CB2.Items.Add(cbi);
                }

                str = "SELECT VessID FROM Vessel";
                lst1 = OperV.GetList(str);
                str = "SELECT ClientID FROM Clients";
                lst2 = OperV.GetList(str);
            }
            catch (Exception)
            {

                MessageBox.Show("Smth wrong");
            }
            

        }
        List<string> lst1, lst2;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                setFreigth();
            }
            catch (Exception exc)
            {

                MessageBox.Show(exc.Message);
            }
            
        }

        void setFreigth() {
            if (checkiff())
            {
                string command = "INSERT INTO Fraht(VessID,ClientID,DateStart,DateStop) VALUES(" + lst1[CB1.SelectedIndex] + "," + lst2[CB2.SelectedIndex] + ",'" + TB2.Text + "','" + TB3.Text + "')";
                OperV.GetQuery(command);
                string and = " WHERE Fraht.VessID=" + lst1[CB1.SelectedIndex] + " AND Vessel.VessID = Fraht.VessID";
                int wgth = int.Parse(OperV.GetList("Select Vessel.VessMaxWeigth from Vessel where Vessel.VessID = " + lst1[CB1.SelectedIndex] + "; ")[0].ToString());
                
                
                int days = OperV.GetDays("Fraht", "Vessel", "DateStart", "DateStop", and);
                int bill = (int)(120000 * ((wgth / 140000.0)) * days);
                command = "INSERT INTO Bills(ClientID, Bill) VALUES (" + lst2[CB2.SelectedIndex] + ", " + bill + "); ";
                OperV.GetQuery(command);
                MessageBox.Show("Success");
                this.Close();
            }
            else
            {
                MessageBox.Show("This vessel is already in use");
            }

        }
        bool checkiff()
        {
            string ress = "";
            ress = " AND DateStart <= '" + TB3.Text + "' AND DateStop >= '" + TB2.Text + "'";
            string st1 = "Fraht WHERE VessID = " + lst1[CB1.SelectedIndex] + ress;
            string st2 = "VessCell, RouteStops where VessCell.VessID = " + lst1[CB1.SelectedIndex] + " and VessCell.VessID = RouteStops.VessID and VessCell.PortFromDate = RouteStops.PortOutDate and VessCell.PortFromID = RouteStops.PortOutID and VessCell.PortToID = RouteStops.PortInID and RouteStops.PortOutDate <= '"+TB3.Text+ "' and RouteStops.PortInDate >= '" + TB2.Text + "'";


            return OperV.GetCount2(st1) == 0 && OperV.GetCount2(st2) == 0;


        }
        /*
        string addDateStatementForFraht() {
            string ress = "";
            ress = " AND DateStart <= '" + TB2.Text + "' AND DateStop >= '" + TB3.Text + "'";
            return ress;
        }

        string addDateStatementForVessCell()
        {
            string ress = "";
            ress = "VessCell, RouteStops where VessCell.VessID = 1 and VessCell.VessID = RouteStops.VessID"+
"and VessCell.PortFromDate = RouteStops.PortOutDate and VessCell.PortFromID = RouteStops.PortOutID and VessCell.PortToID = RouteStops.PortInID"+
"and RouteStops.PortOutDate <= '"+TB2.Text+"' and RouteStops.PortInDate >= '"+TB3.Text+"'";
            return ress;
        } */
    }
}
