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

namespace Lab3Project
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;

        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("All permisions");
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SequelOperator.O5(ref DtGr,TeBo.Text);
            SequelOperator.FillTheListBox(ref Libra, "INFORMATION_SCHEMA.TABLES", "TABLE_NAME");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SequelOperator.Sv();
            SequelOperator.Close();
            Application.Current.Shutdown();
        }


        private void ComboBox_Initialized(object sender, EventArgs e)
        {
            SequelOperator.FillTheListBox(ref Libra, "INFORMATION_SCHEMA.TABLES", "TABLE_NAME");
            SequelOperator.O5(ref DtGr, "Select Logine, PersFname, PersSname, adminity, allowed from persinf");
        }

        private void Libra_Selected(object sender, RoutedEventArgs e)
        {
        }

        private void Libra_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SequelOperator.O5(ref DtGr, "SELECT * FROM " + ((ComboBoxItem)((ComboBox)sender).SelectedItem).Content);
        }

        private void DtGr_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string tableName = Libra.SelectedIndex == -1?"persinf":((ComboBoxItem)Libra.SelectedItem).Content.ToString();
            //svd = "";
            string row = e.Column.Header.ToString();
            string addit = DtGr.Columns[0].Header.ToString();
            
            string val = "";
            if (((e.Column.GetCellContent(e.Row))).GetType().Equals((new TextBox()).GetType()))
            {
                val = "'"+((TextBox)(e.Column.GetCellContent(e.Row))).Text+"'";
            }
            else
            {
                val = (((CheckBox)(e.Column.GetCellContent(e.Row))).IsChecked.Value?1:0).ToString();
            }
            
            //((TextBox) DtGr.Columns[e.Column.DisplayIndex].GetCellContent(e.Row)).Text;
            //MessageBox.Show("Ho");
            SequelOperator.updatede(svd,row,val,tableName,addit);
            if ((DtGr.Columns[0].GetCellContent(e.Row)).GetType().Equals((new TextBox()).GetType()))
            {
                svd = ((TextBox)DtGr.Columns[0].GetCellContent(e.Row)).Text;
            }
            else
            {
                svd = ((TextBlock)DtGr.Columns[0].GetCellContent(e.Row)).Text;
            }
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            Adminity w2 = new Adminity();
            this.Hide();
            w2.Show();
        }

        private void DtGr_AddingNewItem(object sender, AddingNewItemEventArgs e)
        {
            SequelOperator.emergencyAdd();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SequelOperator.emergencyAdd();
            SequelOperator.O5(ref DtGr, "Select Logine, PersFname, PersSname, adminity, allowed from persinf");
        }

        private void DtGr_CellEditEnding_1(object sender, DataGridCellEditEndingEventArgs e)
        {

        }

        string svd = "";

        private void DtGr_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if ((DtGr.Columns[0].GetCellContent(e.Row)).GetType().Equals((new TextBox()).GetType()))
            {
                svd = ((TextBox)DtGr.Columns[0].GetCellContent(e.Row)).Text;
            }
            else
            {
                svd = ((TextBlock)DtGr.Columns[0].GetCellContent(e.Row)).Text;
            }
        }
    }
}
