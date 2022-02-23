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
using System.IO;

namespace WpfApp1A
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            Width = 300;
            Title = "Base4Base";
            u();
            try
            {
                StreamReader sr = new StreamReader("base.txt");
                while (!sr.EndOfStream)
                {
                    ls.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (Exception)
            {


            }
        }
        TextBox[] tbArr = {new TextBox(), new TextBox(), new TextBox() };
        void u() {
            tbArr[0].Text = "Id of student";
            tbArr[0].FontSize = 30;
            tbArr[1].Text = "Name and Surname";
            tbArr[1].FontSize = 20;
            tbArr[2].Text = "Additional info";
            
            Grid gr = new Grid();
            gr.ShowGridLines = true;
            gr.HorizontalAlignment = HorizontalAlignment.Stretch;
            gr.VerticalAlignment = VerticalAlignment.Stretch;
            RowDefinition rd1 = new RowDefinition();            GridLengthConverter GLC = new GridLengthConverter();
            rd1.Height = (GridLength)GLC.ConvertFrom("6*");
            gr.RowDefinitions.Add(rd1);
                Grid ngr = new Grid();
                ngr.HorizontalAlignment = HorizontalAlignment.Stretch;
                ngr.VerticalAlignment = VerticalAlignment.Stretch;
            RowDefinition[] nRd = { new RowDefinition(), new RowDefinition(), new RowDefinition() };
            for (int i = 0; i < nRd.Length; i++)
            {
                nRd[i].Height = (GridLength)GLC.ConvertFrom("1*");
                ngr.RowDefinitions.Add(nRd[i]);
                Grid.SetRow(tbArr[i],i);
                ngr.Children.Add(tbArr[i]);
            }
            Grid.SetRow(ngr,0);
            gr.Children.Add(ngr);
            Grid jfB = new Grid();
            RowDefinition rf1 = new RowDefinition();
            rf1.Height = (GridLength)GLC.ConvertFrom("1*");
            gr.RowDefinitions.Add(rf1);
            jfB.HorizontalAlignment = HorizontalAlignment.Stretch;
            jfB.VerticalAlignment = VerticalAlignment.Stretch;
            ColumnDefinition cd1 = new ColumnDefinition();
            ColumnDefinition cd2 = new ColumnDefinition();
            cd1.Width = (GridLength)GLC.ConvertFrom("1*");
            cd2.Width = (GridLength)GLC.ConvertFrom("1*");
            jfB.ColumnDefinitions.Add(cd1); jfB.ColumnDefinitions.Add(cd2);
            Button b1 = new Button();
            b1.Content = "Add";
            b1.Click += oper;
            b1.FontSize = 28;
            Button b2 = new Button();
            b2.Content = "Remove";
            b2.Click += oper;
            b2.FontSize = 28;
            Grid.SetColumn(b1, 0);
            jfB.Children.Add(b1);
            Grid.SetColumn(b2, 1);
            jfB.Children.Add(b2);
            Grid.SetRow(jfB, 1);
            gr.Children.Add(jfB);
            RowDefinition rf2 = new RowDefinition();
            rf2.Height = (GridLength)GLC.ConvertFrom("1*");
            gr.RowDefinitions.Add(rf2);
            Button exB = new Button();
            exB.Content = "EXIT";
            exB.Click += shut;
            exB.FontSize = 28;
            Grid.SetRow(exB, 2);
            gr.Children.Add(exB);
            Content = gr;
            Show();
        }
        private void shut(object sendr, RoutedEventArgs raa)
        {
            try
            {
                StreamWriter sw = new StreamWriter("base.txt");
                for (int i = 0; i < ls.Count; i++)
                {
                    if (i==ls.Count-1)
                    {
                        sw.Write(ls[i]);
                    }
                    else
                    {
                        sw.WriteLine(ls[i]);
                    }
                }
                sw.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("RecError");
            }
            WpfApp1AUTO.MainWindow mw = new WpfApp1AUTO.MainWindow();
            Hide();
            mw.Show();
        }
        List<string> ls = new List<string>();
        void addf() {
            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Split('|')[0].Equals(tbArr[0].Text))
                {
                    ls.RemoveAt(i);
                    ls.Add(tbArr[0].Text + "|"+tbArr[1].Text + "|"+ tbArr[2].Text);
                    return;
                }
            }
            ls.Add(tbArr[0].Text + "|" + tbArr[1].Text + "|" + tbArr[2].Text);
        }
        void remf() {
            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Split('|')[0].Equals(tbArr[0].Text))
                {
                    ls.RemoveAt(i);
                    return;
                }
            }
        }
        private void oper(object sendr, RoutedEventArgs raa)
        {
            if (((Button)sendr).Content.ToString().Length == 3)
            {
                addf();
            }
            else
            {
                remf();
            }
            
        }
    }
}
