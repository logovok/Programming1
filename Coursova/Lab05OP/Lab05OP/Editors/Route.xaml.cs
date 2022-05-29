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
    /// Логика взаимодействия для Route.xaml
    /// </summary>
    public partial class Route : Window
    {
        public Route()
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
            OperV.GetComboBox("Select Vessel.VessName From Vessel", ref CB1);
            ls1 = OperV.GetList("Select Vessel.VessID From Vessel");
            ls2 = OperV.GetList("Select tPort.PortID from tPort");
            OperV.GetComboBox("Select tPort.PortName from tPort", ref CB2);
            lss1 = new List<string>();
            lss2 = new List<string>();
            lss3 = new List<string>();
            lss4 = new List<string>();
        }
        List<string> ls1, ls2, ls3, ls4;

        string RefactoryOfDate(string s)
        {
            string[] ss = s.Split('.');
            return ss[2] + "." + ss[1] + "." + ss[0];
        }
        string ing2 = "";
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            DTGR.ItemsSource = null;
            
            
            OperV.GetDataGrid(
                "SELECT (SELECT TOP(1) tPort.PortName FROM tPort WHERE tPort.PortID = RouteStops.PortOutID) as 'Origin port', " +
" (SELECT TOP(1) tPort.PortName FROM tPort WHERE tPort.PortID = RouteStops.PortInID) as 'Destenation port', " +
" RouteStops.PortOutDate as 'Departure date', RouteStops.PortInDate as 'Arrival date' " +
ing2,ref DTGR);
            lss1.Clear();
            lss2.Clear();
            lss3.Clear();
            lss4.Clear();
            lss1 = OperV.GetList("SELECT RouteStops.PortOutID " + ing2);
            lss2 = OperV.GetList("SELECT RouteStops.PortInID" + ing2);
            lss3 = OperV.GetList("SELECT RouteStops.PortOutDate " + ing2);
            lss4 = OperV.GetList("SELECT RouteStops.PortInDate " + ing2);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (slc == -1)
            {
                MessageBox.Show("Select smth");
            }
            deleteSelected();
         /*   if (prtFrom == null)
            {

            }
            else
            {
                string command = "UPDATE RouteStops SET PortInID = " + ls2[CB2.SelectedIndex] + ", PortInDate= '" + RefactoryOfDate(DT1.Text) + "WHERE VessID = " + ls1[CB1.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(prtFrom) + "'";
                OperV.GetQuery(command);
                command = "INSERT INTO RouteStops (VessID, PortOutID, PortOutDate, PortInID, PortInDate) VALUES (" + ls1[CB1.SelectedIndex] + ", " + ls2[CB2.SelectedIndex] + ", '" + RefactoryOfDate(DT1.Text) + "', " + prtTo + ", '" + RefactoryOfDate(DT1.Text) + "');";
            }*/
        }

        string prtFrom, prtTo, dtOut, dtIn;

        void vvi() {
            ing2 = " FROM RouteStops, Vessel " +
  " Where Vessel.VessID = RouteStops.VessID and Vessel.VessID = " + ls1[CB1.SelectedIndex] +
  " Order by RouteStops.PortOutDate; ";
            DTGR.ItemsSource = null;


            OperV.GetDataGrid(
                "SELECT (SELECT TOP(1) tPort.PortName FROM tPort WHERE tPort.PortID = RouteStops.PortOutID) as 'Origin port', " +
" (SELECT TOP(1) tPort.PortName FROM tPort WHERE tPort.PortID = RouteStops.PortInID) as 'Destenation port', " +
" RouteStops.PortOutDate as 'Departure date', RouteStops.PortInDate as 'Arrival date' " +
ing2, ref DTGR);
            lss1.Clear();
            lss2.Clear();
            lss3.Clear();
            lss4.Clear();
            lss1 = OperV.GetList("SELECT RouteStops.PortOutID " + ing2);
            lss2 = OperV.GetList("SELECT RouteStops.PortInID" + ing2);
            lss3 = OperV.GetList("SELECT RouteStops.PortOutDate " + ing2);
            lss4 = OperV.GetList("SELECT RouteStops.PortInDate " + ing2);
            slc = -1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (slc==-1)
            {
                MessageBox.Show("Select smth");
            }
            insertAfter();
        }

        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            vvi();
        }

        int slc;
        List<string> lss1, lss2, lss3, lss4;

         
        void deleteSelected() {
            if (slc == -1)
            {
                return;
            }
            string command = "";
            if (slc == lss1.Count-1 || slc == 0)
            {
                command = "DELETE FROM VessCell WHERE VessID = " + ls1[CB1.SelectedIndex] + " and PortFromDate = '" + RefactoryOfDate(lss3[slc].Split(' ')[0]) + "'";
                OperV.GetQuery(command);
                command = "DELETE FROM RouteStops WHERE VessID = " + ls1[CB1.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(lss3[slc].Split(' ')[0]) + "'";                          
                OperV.GetQuery(command);
                vvi();
                return;
            }
            command = "DELETE FROM VessCell WHERE VessID = " + ls1[CB1.SelectedIndex] + " and PortFromDate = '" + RefactoryOfDate(lss3[slc].Split(' ')[0]) + "'";
            OperV.GetQuery(command);
            command = "DELETE FROM RouteStops WHERE VessID = " + ls1[CB1.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(lss3[slc].Split(' ')[0]) + "'";
            OperV.GetQuery(command);
            command = "UPDATE RouteStops SET PortInID = " + lss2[slc] + ", PortInDate= '" + RefactoryOfDate(lss4[slc].Split(' ')[0]) + "' WHERE VessID = " + ls1[CB1.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(lss3[slc - 1].Split(' ')[0]) + "'";
            OperV.GetQuery(command);
            vvi();
        }

        void insertAfter() {
            string command = "";

            if (!checkiff(RefactoryOfDate(DT1.Text), RefactoryOfDate(DT2.Text), RefactoryOfDate(DT3.Text)))
            {
                MessageBox.Show("Collision of dates");
                return;
            }


            if (slc == -1)
            {
                MessageBox.Show("Select smth");
                return;
            }

            if (slc!=lss2.Count)
            {
                if (ls2[CB2.SelectedIndex].Equals(lss1[slc]) || ls2[CB2.SelectedIndex].Equals(lss2[slc]))
                {
                    MessageBox.Show("Select another port");
                    return;
                }
                command = "UPDATE RouteStops SET PortInID = " + ls2[CB2.SelectedIndex] + ", PortInDate= '" + RefactoryOfDate(DT1.Text) + "' WHERE VessID = " + ls1[CB1.SelectedIndex] + " and PortOutDate = '" + RefactoryOfDate(lss3[slc].Split(' ')[0]) + "'";
                OperV.GetQuery(command);
                command = "INSERT INTO RouteStops (VessID, PortOutID, PortOutDate, PortInID, PortInDate) VALUES (" + ls1[CB1.SelectedIndex] + ", " + ls2[CB2.SelectedIndex] + ", '" + RefactoryOfDate(DT2.Text) + "', " + lss2[slc] + ", '" + RefactoryOfDate(DT3.Text) + "');";
                OperV.GetQuery(command);
                vvi();
            }
            else
            {
                MessageBox.Show("You should add a new route instead");
            }
        }

        
        bool checkiff(string date1, string date2, string date3) {
            if (OperV.GetCount2("RouteStops", " WHERE PortOutDate <= '"+date3+"' AND PortInDate >= '"+date1+"'")!=1)
            {
                MessageBox.Show("Date collision");
                return false;
            }
            
            
            
            string[] st1 = date1.Split('.');
            string[] st2 = date2.Split('.');
            if ((int.Parse(st1[0]) > int.Parse(st2[0])) || (int.Parse(st1[1]) > int.Parse(st2[1])) || (int.Parse(st1[2]) > int.Parse(st2[2])))
            {
                return false;
            }

            st1 = date2.Split('.');
            st2 = date3.Split('.');
            if ((int.Parse(st1[0]) > int.Parse(st2[0])) || (int.Parse(st1[1]) > int.Parse(st2[1])) || (int.Parse(st1[2]) > int.Parse(st2[2])))
            {
                return false;
            }
            //RefactoryOfDate(lss3[slc].Split(' ')[0]
            
            st2 = date1.Split('.');
            st1 = RefactoryOfDate(lss3[slc].Split(' ')[0]).Split('.');  
            if ((int.Parse(st1[0]) > int.Parse(st2[0])) || (int.Parse(st1[1]) > int.Parse(st2[1])) || (int.Parse(st1[2]) > int.Parse(st2[2])))
            {
                return false;
            }
            st2 = RefactoryOfDate(lss4[slc].Split(' ')[0]).Split('.');
            st1 =   date3.Split('.');
            if ((int.Parse(st1[0]) > int.Parse(st2[0])) || (int.Parse(st1[1]) > int.Parse(st2[1])) || (int.Parse(st1[2]) > int.Parse(st2[2])))
            {
                return false;
            }
            return true;
        }
        private void DTGR_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            slc = DTGR.SelectedIndex;
            if (slc<0)
            {
                return;
            }
            if (DTGR.SelectedIndex!=0)
            {
                prtFrom = lss1[DTGR.SelectedIndex - 1];
                dtOut = lss3[DTGR.SelectedIndex - 1];

            }
            else
            {
                prtFrom = null;
                dtOut = null;
            }

            prtTo = lss2[DTGR.SelectedIndex];
                dtIn = lss4[DTGR.SelectedIndex];

            //MessageBox.Show(DTGR.ItemsSource.);
            //s1 = DTGR.Items.GetItemAt(DTGR.SelectedIndex).GetType == typeof(TextBox)?
        }
    }
}
