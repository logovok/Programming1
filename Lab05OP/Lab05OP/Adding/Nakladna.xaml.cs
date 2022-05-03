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
    static class XYZ {
        static public bool f = false;
    }
    /// <summary>
    /// Логика взаимодействия для Nakladna.xaml
    /// </summary>
    public partial class Nakladna : Window
    {
        public Nakladna()
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
            string str = "SELECT ClientFirstName FROM Clients";
            List<string> list1 = OperV.GetList(str);
            str = "SELECT ClientLastName FROM Clients";
            List<string> list2 = OperV.GetList(str);

            for (int i = 0; i < list1.Count; i++)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = list1[i] + " " + list2[i];
                ComboClient.Items.Add(cbi);
            }
            str = "SELECT ClientID FROM Clients";
            l1 = OperV.GetList(str);
            str = "SELECT PortID FROM tPort";
            l2 = OperV.GetList(str);
            str = "SELECT PortName FROM tPort";
            OperV.GetComboBox(str, ref OrigPort);
            ComboBoxItem cbi1 = new ComboBoxItem();
            cbi1.Content = "KG";
            ComboBoxItem cbi2 = new ComboBoxItem();
            cbi2.Content = "TON";
            TB3.Items.Add(cbi1);
            TB3.Items.Add(cbi2);
            l6 = OperV.GetList("SELECT VessTypeID FROM VessTypes");
            OperV.GetComboBox("SELECT VessTypeName FROM VessTypes", ref CB0);
        }
        List<string> lst1 = new List<string>();
        List<string> lst2 = new List<string>();
        List<string> lst3 = new List<string>();
        List<string> l1 = new List<string>();
        List<string> l2 = new List<string>();
        List<string> l3 = new List<string>();
        List<string> l4 = new List<string>();
        List<string> l5 = new List<string>();
        List<string> l6 = new List<string>();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TB3.SelectedIndex == -1)
            {
                return;
            }
            lst1.Add(TB1.Text);
            lst2.Add(TB2.Text);
            lst3.Add((((ComboBoxItem)TB3.SelectedItem).Content).ToString());
            TB1.Text = "";
            TB2.Text = "";
            TB3.SelectedIndex = -1;
            ListBoxItem lbis = new ListBoxItem();
            lbis.Content = lst1[lst1.Count - 1] + " " + lst2[lst2.Count - 1] + " " + lst3[lst3.Count - 1];
            LBX.Items.Add(lbis);
            //=================================
            int cells = int.Parse(OperV.GetList("Select Vessel.VessCellsNum from Vessel where VessID = " + l5[Vessel.SelectedIndex] + "; ")[0].ToString());
            int wgth = int.Parse(OperV.GetList("Select Vessel.VessMaxWeigth from Vessel where VessID = " + l5[Vessel.SelectedIndex] + "; ")[0].ToString());
            string and = " Where Vessel.VessID = RouteStops.VessID AND Vessel.VessID = " + l5[Vessel.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(l4[DepDate.SelectedIndex]) + "' AND PortOutID = " + l2[OrigPort.SelectedIndex] + "; ";
            int days = OperV.GetDays("RouteStops", "Vessel", "PortOutDate", "PortInDate", and);

            int bill = (int)(120000 * ((wgth / 140000.0) / cells) * days);

            BK.IsEnabled = true;

            PR.Text = "Price: "+ bill.ToString()+"$";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lst1.Count==0)
            {
                return;
            }
            if (LBX.SelectedIndex == -1)
            {
                lst1.RemoveAt(0);
                lst2.RemoveAt(0);
                lst3.RemoveAt(0);
                LBX.Items.RemoveAt(0);
                return;
            }
            lst1.RemoveAt(LBX.SelectedIndex);
            lst2.RemoveAt(LBX.SelectedIndex);
            lst3.RemoveAt(LBX.SelectedIndex);
            LBX.Items.RemoveAt(LBX.SelectedIndex);

        }

        string ending = "; ";
        private void ComboClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            OrigPort.IsEnabled = true;
            DestPort.IsEnabled = false;
            DepDate.IsEnabled = false;
            Vessel.IsEnabled = false;

        }

        private void OrigPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            l3.Clear();
            DestPort.Items.Clear();
            DestPort.SelectedIndex = -1;
            l4.Clear();
            DepDate.Items.Clear();
            DepDate.SelectedIndex = -1;
            l5.Clear();
            Vessel.Items.Clear();
            Vessel.SelectedIndex = -1;
            string str = "SELECT tPort.PortID from tPort, RouteStops, Vessel  Where tPort.PortID = RouteStops.PortInID and RouteStops.PortOutID = " + l2[OrigPort.SelectedIndex] + " and Vessel.VessID = RouteStops.VessID " +zok + ending;
            l3 = OperV.GetList(str);
            string str2 = "SELECT tPort.PortName from tPort, RouteStops, Vessel Where tPort.PortID = RouteStops.PortInID and RouteStops.PortOutID = " + l2[OrigPort.SelectedIndex] + " and Vessel.VessID = RouteStops.VessID " + zok + ending;
            OperV.GetComboBox(str2, ref DestPort);
            OrigPort.IsEnabled = true;
            DestPort.IsEnabled = true;
            DepDate.IsEnabled = false;
            Vessel.IsEnabled = false;
            //XYZ.f = false;
        }

        private void DestPort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrigPort.SelectedIndex == -1 || DestPort.SelectedIndex == -1 || l2.Count<=OrigPort.SelectedIndex || l3.Count <DestPort.SelectedIndex)
            {
                return;
            }
            l4.Clear();
            DepDate.Items.Clear();
            DepDate.SelectedIndex = -1;
            l5.Clear();
            Vessel.Items.Clear();
            Vessel.SelectedIndex = -1;
            string str = "SELECT PortOutDate from RouteStops, Vessel  Where PortOutID = " + l2[OrigPort.SelectedIndex]+" and PortInID = "+l3[DestPort.SelectedIndex]+ "  and Vessel.VessID = RouteStops.VessID " + zok + "; ";
            OperV.GetComboBox(str, ref DepDate);
            l4 = OperV.GetList(str);
            //MessageBox.Show(str);
            OrigPort.IsEnabled = true;
            DestPort.IsEnabled = true;
            DepDate.IsEnabled = true;
            Vessel.IsEnabled = false;
        }

        private void DepDate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                l5.Clear();
                Vessel.Items.Clear();
                Vessel.SelectedIndex = -1;
                if (OrigPort.SelectedIndex == -1 || DestPort.SelectedIndex == -1 || DepDate.SelectedIndex == -1)
                {
                   // MessageBox.Show((l2[OrigPort.SelectedIndex] + " " + l3[DestPort.SelectedIndex] + " " + DepDate.SelectedValue.ToString()));
                    return;
                }

                //MessageBox.Show((OrigPort.SelectedIndex + " " + DestPort.SelectedIndex + " " + DepDate.SelectedIndex).ToString());
                //MessageBox.Show();

                string str = "Select Vessel.VessName FROM Vessel, RouteStops Where PortOutID = " + l2[OrigPort.SelectedIndex] + " and PortInID = " + l3[DestPort.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(l4[DepDate.SelectedIndex]) + "' and Vessel.VessID = RouteStops.VessID" + zok + "; ";
                string str2 = "Select Vessel.VessID FROM Vessel, RouteStops Where PortOutID = " + l2[OrigPort.SelectedIndex] + " and PortInID = " + l3[DestPort.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(l4[DepDate.SelectedIndex]) + "' and Vessel.VessID = RouteStops.VessID" + zok + "; ";
                OperV.GetComboBox(str, ref Vessel);
                l5 = OperV.GetList(str2);
               //
               //MessageBox.Show(l5.Count.ToString());
                OrigPort.IsEnabled = true;
                DestPort.IsEnabled = true;
                DepDate.IsEnabled = true;
                Vessel.IsEnabled = true;
            }
            catch (Exception)
            {

                
            }
               
            
            
        }

        string RefactoryOfDate(string inn) {

            string[] str = inn.Split('.');
            string outt = str[1] + "." + str[0] + "." + str[2];
            return outt;
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (LBX.Items.Count == 0)
            {
                MessageBox.Show("You must add items to container");
                return;
            }

            
            
           int k1 = OperV.GetCount2("VessCell, Vessel Where VessCell.VessID = " + l5[Vessel.SelectedIndex] + " and Vessel.VessID = VessCell.VessID;");
            int k2 = int.Parse(OperV.GetList("Select Vessel.VessCellsNum from Vessel where VessID = " + l5[Vessel.SelectedIndex] + "; ")[0].ToString());
            int fraht = OperV.GetCount2("Fraht Where VessID = "+l5[Vessel.SelectedIndex]+";");
            int cells = int.Parse(OperV.GetList("Select Vessel.VessCellsNum from Vessel where VessID = " + l5[Vessel.SelectedIndex] + "; ")[0].ToString());
            int wgth = int.Parse(OperV.GetList("Select Vessel.VessMaxWeigth from Vessel where VessID = " + l5[Vessel.SelectedIndex] + "; ")[0].ToString());
            int wghtOcell = (int)wgth / cells;
            if ((k2>k1)&&(fraht == 0)&&((sumsum()/1000)<=wghtOcell)) 
            {
                if (!checkiff(cells, int.Parse(l5[Vessel.SelectedIndex]), RefactoryOfDate(l4[DepDate.SelectedIndex]), l2[OrigPort.SelectedIndex] , l3[DestPort.SelectedIndex]))
                {

                }
                string command = "INSERT INTO VessCell(VessID,CellClientID,PortFromID,PortToID, PortFromDate) VALUES (" + l5[Vessel.SelectedIndex] + "," + l1[ComboClient.SelectedIndex] + "," + l2[OrigPort.SelectedIndex] + "," + l3[DestPort.SelectedIndex] + ",'" + RefactoryOfDate(l4[DepDate.SelectedIndex]) + "'); ";
                OperV.GetQuery(command);
               GenerateCommandsForCargoTable();
                List<string> lstada = OperV.GetList("Select VessCell.VessCellID from VessCell");
                string VCID = lstada[lstada.Count - 1];
                string and = " Where Vessel.VessID = RouteStops.VessID AND Vessel.VessID = " + l5[Vessel.SelectedIndex] +" and PortOutDate = '"+ RefactoryOfDate(l4[DepDate.SelectedIndex]) + "' AND PortOutID = "+ l2[OrigPort.SelectedIndex] + "; ";
                int days = OperV.GetDays("RouteStops","Vessel","PortOutDate","PortInDate", and);
                
                int bill = (int)(120000*((wgth/140000.0)/cells)*days);
                command = "INSERT INTO Bills(ClientID, Bill) VALUES (" + l1[ComboClient.SelectedIndex] + ", " + bill + "); ";
                OperV.GetQuery(command);
                MessageBox.Show("Success");
            }
            else
            {
                if (k1>=k2)
                {
                    MessageBox.Show("Not enough free cells");
                }
                else if (fraht>0)
                {
                    MessageBox.Show("Vessel is not avaliable");
                }
                else if ((sumsum() / 1000) <= wghtOcell)
                {
                    MessageBox.Show("Too big weight");
                }
                else
                {
                    MessageBox.Show("Something wrong");
                }
            }
        }

        
        int sumsum()
        {
            
            int sum = int.MaxValue;
            try
            {
                sum = 0;
                for (int i = 0; i < lst2.Count; i++)
                {
                    if (lst3[i].Equals("KG"))
                    {
                        sum += int.Parse(lst2[i]);
                    }
                    else if (lst3[i].Equals("TON"))
                    {
                        sum += int.Parse(lst2[i]) * 1000;
                    }
                    else
                    {
                        sum = int.MaxValue;
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Problems with weight");
            }
            
            return sum;
        }
        private void Vessel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            TB1.IsEnabled = true;
            TB2.IsEnabled = true;
            TB3.IsEnabled = true;
        }

        void GenerateCommandsForCargoTable() {
            List<string> lstada = OperV.GetList("Select VessCell.VessCellID from VessCell");
            string VCID = lstada[lstada.Count - 1];
            for (int i = 0; i < lst2.Count; i++)
            {
                string command = "INSERT INTO Cargo(VessCellID, CargoName, CargoWeigth, CargoOdn) VALUES (" + VCID + ",'" + lst1[i] + "'," + lst2[i] + ",'" + lst3[i] + "'); ";
                OperV.GetQuery(command);
            }

            LBX.Items.Clear();
            lst1.Clear();
            lst2.Clear();
            lst3.Clear();
        }
        string zok = "";

        private void CB0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            zok = " AND Vessel.VessTypeID = " + l6[CB0.SelectedIndex] + " ";
            if (Vessel.SelectedIndex!=-1)
            {
                try
                {
                    l5.Clear();
                    Vessel.Items.Clear();
                    Vessel.SelectedIndex = -1;
                    if (OrigPort.SelectedIndex == -1 || DestPort.SelectedIndex == -1 || DepDate.SelectedIndex == -1)
                    {
                        // MessageBox.Show((l2[OrigPort.SelectedIndex] + " " + l3[DestPort.SelectedIndex] + " " + DepDate.SelectedValue.ToString()));
                        return;
                    }

                    //MessageBox.Show((OrigPort.SelectedIndex + " " + DestPort.SelectedIndex + " " + DepDate.SelectedIndex).ToString());
                    //MessageBox.Show();

                    string str = "Select Vessel.VessName FROM Vessel, RouteStops Where PortOutID = " + l2[OrigPort.SelectedIndex] + " and PortInID = " + l3[DestPort.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(l4[DepDate.SelectedIndex]) + "' and Vessel.VessID = RouteStops.VessID" + zok + "; ";
                    string str2 = "Select Vessel.VessID FROM Vessel, RouteStops Where PortOutID = " + l2[OrigPort.SelectedIndex] + " and PortInID = " + l3[DestPort.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(l4[DepDate.SelectedIndex]) + "' and Vessel.VessID = RouteStops.VessID" + zok + "; ";
                    OperV.GetComboBox(str, ref Vessel);
                    l5 = OperV.GetList(str2);
                    //
                    //MessageBox.Show(l5.Count.ToString());
                    OrigPort.IsEnabled = true;
                    DestPort.IsEnabled = true;
                    DepDate.IsEnabled = true;
                    Vessel.IsEnabled = true;
                }
                catch (Exception)
                {


                }
            }
        }
        bool checkiff(int cells, int vsID, string strt, string portA, string portO)
        {
            //string str1 = "SELECT VessID FROM Fraht WHERE VessID = " + lst1[CB1.SelectedIndex];

            //string str2 = "SELECT VessID FROM VessCell WHERE VessID = " + lst1[CB1.SelectedIndex];
            string stop = OperV.GetList("SELECT PortInDate From RouteStops WHERE VessID = " + vsID + " AND PortOutDate = '" + strt + "' AND PortOutID = " + portA + " AND PortInID = " + portO + "; ")[0];
            string ress = "";
            ress = " AND DateStart <= '" + stop + "' AND DateStop >= '" + strt + "'";
            string st1 = "Fraht WHERE VessID = " + vsID + ress;
            string st2 = "VessCell, RouteStops where VessCell.VessID = " + vsID + " and VessCell.VessID = RouteStops.VessID and VessCell.PortFromDate = RouteStops.PortOutDate and VessCell.PortFromID = RouteStops.PortOutID and VessCell.PortToID = RouteStops.PortInID and RouteStops.PortOutDate <= '" + stop + "' and RouteStops.PortInDate >= '" + strt + "'";
            //"and //RouteStops.PortOutDate >= '" + TB2.Text + "' and RouteStops.PortInDate <= '" + TB3.Text + "'";


            return OperV.GetCount2(st1) == 0 && OperV.GetCount2(st2) < cells;

            //return OperV.GetCount(str1, str2) == 0;

        }
    }
}
