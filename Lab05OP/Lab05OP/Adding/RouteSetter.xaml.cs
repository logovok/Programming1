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
    /// Логика взаимодействия для RouteSetter.xaml
    /// </summary>
    public partial class RouteSetter : Window
    {
        public RouteSetter()
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
            lst1 = OperV.GetList("SELECT VessTypeID FROM VessTypes");
            OperV.GetList("SELECT VessTypeID FROM VessTypes");
            OperV.GetComboBox("SELECT VessTypeName FROM VessTypes", ref CB0);
            lst3 = OperV.GetList("SELECT PortID FROM tPort");
            OperV.GetComboBox("SELECT PortName FROM tPort", ref CB2);
            lst4 = OperV.GetList("SELECT PortID FROM tPort");
            OperV.GetComboBox("SELECT PortName FROM tPort", ref CB3);
            cntL1 = new List<string>();
            cntL2 = new List<string>();
            cntL3 = new List<string>();
            cntL4 = new List<string>();
            lst2 = new List<string>();
        }
        List<string> lst1, lst2, lst3, lst4;
        List<string> cntL1, cntL2, cntL3, cntL4;

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            if (CB1.SelectedIndex!=-1)
            {
                
                if (OperV.GetCount2("RouteStops", " WHERE PortOutDate<= '" + cntL4[cntL4.Count - 1] + "' AND PortInDate>= '" + cntL3[0] + "' AND RouteStops.VessID = " + lst2[CB1.SelectedIndex]) == 0)
                {
                    for (int i = 0; i < cntL1.Count; i++)
                    {
                        string command = "INSERT INTO RouteStops(VessID, PortOutID, PortInID, PortOutDate, PortInDate) VALUES (" + lst2[CB1.SelectedIndex] + ", " + lst3[int.Parse(cntL1[i])] + ", " + lst4[int.Parse(cntL2[i])] + ", '" + cntL3[i] + "', '" + cntL4[i] + "')";
                        
                        OperV.GetQuery(command);
                    }
                }
                else
                {
                    MessageBox.Show("Collision, check existing routes");
                    //MessageBox.Show((OperV.GetCount2("RouteStops", "WHERE PortOutDate >= "+"'"+"" + cntL3[0] + "" + "'" + " AND PortInDate <= " + "'" + "" + cntL4[cntL4.Count - 1] + "" + "'" + " AND VessID = " + lst2[CB1.SelectedIndex])).ToString());
                    //MessageBox.Show(cntL3[0]+" "+cntL4[cntL4.Count-1]);
                }
               
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (cntL1.Count>1)
            {
                CB2.SelectedIndex = int.Parse(cntL2[cntL2.Count - 1]);
                cntL1.RemoveAt(cntL1.Count - 1);
                cntL2.RemoveAt(cntL2.Count - 1);
                cntL3.RemoveAt(cntL3.Count - 1);
                cntL4.RemoveAt(cntL4.Count - 1);
                LBX.Items.RemoveAt(LBX.Items.Count - 1);
                CB2.IsEnabled = false;
            }
            else if (cntL1.Count == 1)
            {
                cntL1.RemoveAt(cntL1.Count - 1);
                cntL2.RemoveAt(cntL2.Count - 1);
                cntL3.RemoveAt(cntL3.Count - 1);
                cntL4.RemoveAt(cntL4.Count - 1);
                LBX.Items.RemoveAt(LBX.Items.Count - 1);
                CB2.IsEnabled = true;
            }
            
            
        }

        bool CheckIfFirstDateIsSmallerThenSecond(string[] date1, string[] date2)
        {
            if (date1.Length == date2.Length && date2.Length == 3)
            {
                if (int.Parse(date1[0]) < int.Parse(date2[0]))
                {
                    return true;
                }
                else if (int.Parse(date1[1]) < int.Parse(date2[1]))
                {
                    return true;
                }
                else if(int.Parse(date1[2]) < int.Parse(date2[2]))
                {
                    return true;
                }
            }
            return false;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string[] s1 = TB1.Text.Split('.');
            string[] s2 = TB2.Text.Split('.');
            if (s1.Length == s2.Length && s2.Length == 3)
            {
                if (s1[0].Length == 4 && s2[0].Length ==4)
                {
                    if (CheckIfFirstDateIsSmallerThenSecond(s1,s2))
                    {
                        if (CB0.SelectedIndex!=-1 && CB1.SelectedIndex!=-1 && CB2.SelectedIndex!=-1 && CB3.SelectedIndex != -1)
                        {
                            if (cntL1.Count == 0)
                            {
                                cntL1.Add(CB2.SelectedIndex.ToString());
                                cntL2.Add(CB3.SelectedIndex.ToString());
                                cntL3.Add(TB1.Text);
                                cntL4.Add(TB2.Text);
                                ListBoxItem lbi = new ListBoxItem();
                                lbi.Content = "From " + CB2.SelectedValue.ToString() + " to " + CB3.SelectedValue.ToString() + " from " + cntL3[cntL3.Count - 1] + " to " + cntL4[cntL4.Count - 1];
                                LBX.Items.Add(lbi);
                                int tmpi = CB3.SelectedIndex;
                                CB3.SelectedIndex = -1;
                                CB2.SelectedIndex = tmpi;
                                CB2.IsEnabled = false;
                                TB1.Text = "";
                                TB2.Text = "";
                            }
                            else if (CheckIfFirstDateIsSmallerThenSecond(cntL4[cntL4.Count-1].Split('.'), s1))
                            {
                                cntL1.Add(CB2.SelectedIndex.ToString());
                                cntL2.Add(CB3.SelectedIndex.ToString());
                                cntL3.Add(TB1.Text);
                                cntL4.Add(TB2.Text);
                                ListBoxItem lbi = new ListBoxItem();
                                lbi.Content = "From " + CB2.SelectedValue.ToString() + " to " + CB3.SelectedValue.ToString() + " from " + cntL3[cntL3.Count - 1] + " to " + cntL4[cntL4.Count - 1];
                                LBX.Items.Add(lbi);
                                CB2.SelectedIndex = (int)CB3.SelectedIndex;
                                CB2.IsEnabled = false;
                                CB3.SelectedIndex = -1;
                                TB1.Text = "";
                                TB2.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Date of departure is earlier than arrival");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("You must select all fields");
                        }
                    }
                    else
                    {
                        MessageBox.Show("First date must be less than second date");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect date format");
                }
            }
            else
            {
                MessageBox.Show("Incorrect date format");
            }
            
        }

        private void CB2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB2.SelectedIndex == CB3.SelectedIndex && CB2.SelectedIndex != -1 && CB3.SelectedIndex != -1&&CB2.IsEnabled)
            
            {
                ((ComboBox)sender).SelectedIndex = -1;
                MessageBox.Show("Ports can't be the same");
            }
        }

        private void CB0_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lst2.Clear();
            lst2 = OperV.GetList("SELECT VessID FROM Vessel WHERE VessTypeID = " + lst1[CB0.SelectedIndex]);
            CB1.Items.Clear();
            CB1.SelectedIndex = -1;
            OperV.GetComboBox("SELECT VessName FROM Vessel WHERE VessTypeID = " + lst1[CB0.SelectedIndex], ref CB1);
            CB1.IsEnabled = true;
        }
    }
}
