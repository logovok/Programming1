using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Pay4Bills.xaml
    /// </summary>
    public partial class Pay4Bills : Window
    {
        public Pay4Bills()
        {
            InitializeComponent();
            LinearGradientBrush lgb2 = new LinearGradientBrush();
            lgb2.StartPoint = new Point(0, 0);
            lgb2.EndPoint = new Point(1, 1);
            GradientStop gs3 = new GradientStop(Colors.BlueViolet, 0);
            GradientStop gs4 = new GradientStop(Colors.Gold, 1);
            lgb2.GradientStops.Add(gs3);
            lgb2.GradientStops.Add(gs4);
            this.Background = lgb2;
            string str = "";
            str = "SELECT ClientFirstName FROM Clients";
            List<string> list1 = OperV.GetList(str);
            str = "SELECT ClientLastName FROM Clients";
            List<string> list2 = OperV.GetList(str);

            for (int i = 0; i < list1.Count; i++)
            {
                ComboBoxItem cbi = new ComboBoxItem();
                cbi.Content = list1[i] + " " + list2[i];
                CB1.Items.Add(cbi);
            }
            str = "SELECT ClientID FROM Clients";
            ls1 = OperV.GetList(str);
        }

        List<string> ls1;
        private void CB1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OperV.GetDataGrid("Select Bill from Bills Where ClientID = "+ls1[CB1.SelectedIndex], ref DTGR);
            TB1.Text = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int money = int.Parse(TB1.Text);
            List<string> ls = new List<string>();
            while (money!=0)
            {
                if (OperV.GetCount2("Bills")!=0)
                {
                    ls = OperV.GetList("Select TOP(1) Bill from Bills Where ClientID = " + ls1[CB1.SelectedIndex]);
                    if (ls.Count==0)
                    {
                        MessageBox.Show("All bills paid!\n"+TB1.Text+"$ are returned to you");
                        return;
                    }
                    if (int.Parse(ls[0]) <= money)
                    {
                        money -= int.Parse(ls[0]);
                        OperV.GetQuery("Delete TOP(1) from Bills Where ClientID = " + ls1[CB1.SelectedIndex]);
                    }
                    else
                    {
                        OperV.GetQuery("Update TOP(1) Bills Set Bill = Bill - " + money + " Where ClientID = " + ls1[CB1.SelectedIndex]);
                        money = 0;
                    }
                    OperV.GetDataGrid("Select Bill from Bills Where ClientID = " + ls1[CB1.SelectedIndex], ref DTGR);
                    TB1.Text = money.ToString();
                    //Thread.Sleep(300);
                }
                else
                {
                    MessageBox.Show("You successfully payed for all bills\n"+money.ToString()+"$ are returned on your bank account");
                    break;
                }
                
            }
        }
    }
}
