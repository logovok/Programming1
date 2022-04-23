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
using System.Windows.Threading;

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
            //set background gradient
            LinearGradientBrush background = new LinearGradientBrush();
            background.StartPoint = new Point(0.5, 0);
            background.EndPoint = new Point(0.5, 1);
            background.GradientStops.Add(new GradientStop(Colors.LightBlue, 0));
            background.GradientStops.Add(new GradientStop(Colors.White, 1));
            this.Background = background;
            c1 = GetRandomColor();
            c2 = GetRandomColor();
            //do ChangeColor 10 times per second
            
            timer.Interval = TimeSpan.FromMilliseconds(20);
            EventHandler eventHandler = new EventHandler(timer_Tick1);
            timer.Tick += eventHandler;
            timer.Start();
        }

        private void timer_Tick1(object sender, EventArgs e)
        {
            ChangeColor();
            //throw new NotImplementedException();
        }

        DispatcherTimer timer = new DispatcherTimer();
        //create function for dynamic change of gradient color

        Color c1 = new Color();
        Color c2 = new Color();
        void ChangeColor()
        {

            c1 = SlowlyChange(c1);
            c2 = SlowlyChange(c2);
            //set background gradient
            LinearGradientBrush background = new LinearGradientBrush();
            background.StartPoint = new Point(0.5, 0);
            background.EndPoint = new Point(0.5, 1);
            background.GradientStops.Add(new GradientStop(c1, 0));
            background.GradientStops.Add(new GradientStop(c2, 1));
            this.Background = background;
        }

        //create function that gets random color
        private Color GetRandomColor()
        {
            Random random = new Random();
            return Color.FromRgb((byte)random.Next(255), (byte)random.Next(255), (byte)random.Next(255));
        }
        Random random = new Random();
        private Color SlowlyChange(Color color)
        {
            
            byte red = (byte)((color.R + (byte)(random.Next(-2,3)))%255);
            byte green = (byte)((color.G + (byte)(random.Next(-2,3))) % 255);
            byte blue = (byte)((color.B + (byte)(random.Next(-2,3))) % 255);
            return Color.FromRgb(red, green, blue);
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
            //SequelOperator.Sv();
            SequelOperator.Close();
            Application.Current.Shutdown();
        }


        private void ComboBox_Initialized(object sender, EventArgs e)
        {
            SequelOperator.FillTheListBox(ref Libra, "INFORMATION_SCHEMA.TABLES", "TABLE_NAME");
           // SequelOperator.O5(ref DtGr, "Select Logine, PersFname, PersSname, adminity, allowed from persinf");
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

       


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string wht2add = "";
            for (int i = 0; i < DtGr.Columns.Count; i++)
            {
                if (!DtGr.Columns[i].IsReadOnly)
                {
                    wht2add += DtGr.Columns[i].Header.ToString();
                    if ((i + 1) != DtGr.Columns.Count)
                    {
                        if (!DtGr.Columns[i+1].IsReadOnly)
                        {
                            wht2add += ",";
                        }
                    }
                }
                
            }
            string address = ((ComboBoxItem)Libra.SelectedItem).Content.ToString();
            SequelOperator.O5(ref DtGr, "Select * from " + address);
            SequelOperator.emergencyAdd(wht2add,address);
            SequelOperator.O5(ref DtGr, "Select * from "+address);
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
