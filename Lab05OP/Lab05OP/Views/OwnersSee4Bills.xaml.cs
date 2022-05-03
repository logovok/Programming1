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
    /// Логика взаимодействия для OwnersSee4Bills.xaml
    /// </summary>
    public partial class OwnersSee4Bills : Window
    {
        public OwnersSee4Bills()
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
            OperV.GetDataGrid("SELECT ClientFirstName +' '+ ClientLastName as 'Name', SUM(Bills.Bill) as '$ not paid yet' From Clients,Bills WHERE Clients.ClientID = Bills.ClientID Group by ClientFirstName,ClientLastName", ref DG);
        }
    }
}
