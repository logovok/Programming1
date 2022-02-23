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

namespace WpfApp1A
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Width = 300;
            TXB.IsEnabled = false;
            initTheIt();
            
        }
        TextBox TXB = new TextBox();
       
        void initTheIt()
        {
            Brush hg = new SolidColorBrush(Color.FromRgb(28, 222, 28));
            TXB.Background = hg;
            Brush hj = new SolidColorBrush(Color.FromRgb(254, 0, 0));
            this.Title = "Just a common title";
            Grid gr = new Grid();
            gr.Height = 300;
            gr.Width = 260;
            gr.HorizontalAlignment = HorizontalAlignment.Center;
            gr.VerticalAlignment = VerticalAlignment.Bottom;
            //gr.ShowGridLines = true;
            TXB.FontSize = 30;
            int M = 4, N = 4;
            Button[,] bar = new Button[M, N];
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N - 1; j++)
                {
                    bar[i, j] = new Button();
                    bar[i, j].FontSize = 25;
                    bar[i, j].Click += olCl;
                    bar[i, j].Content = 1 + j + 3 * i;
                }
            }
            bar[3, 0].Content = ","; bar[3, 1].Content = "0"; bar[3, 2].Content = "=";
            for (int i = 0; i < M; i++)
            {
                bar[i, 3] = new Button();
                bar[i, 3].FontSize = 25;
            }
            bar[0, 3].Content = "+"; bar[1, 3].Content = "-"; bar[2, 3].Content = "*"; bar[3, 3].Content = "/";
            for (int i = 0; i < 4; i++)
            {
                bar[i, 3].Click += deed;
            }
            RowDefinition[] rd = new RowDefinition[M + 1];
            gr.RowDefinitions.Add(new RowDefinition());

            Grid.SetRow(TXB, 0);
            Grid.SetColumnSpan(TXB, 4);
            gr.Children.Add(TXB);
            rd[0] = new RowDefinition();

            ColumnDefinition[] cd = new ColumnDefinition[N];

            for (int i = 1; i < M + 1; i++)
            {
                rd[i] = new RowDefinition();
                gr.RowDefinitions.Add(rd[i]);
            }
            for (int i = 0; i < N; i++)
            {
                cd[i] = new ColumnDefinition();
                gr.ColumnDefinitions.Add(cd[i]);
            }
            for (int i = 1; i < M + 1; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Grid.SetRow(bar[i - 1, j], i);
                    Grid.SetColumn(bar[i - 1, j], j);
                }
            }
            for (int i = 1; i < M + 1; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    gr.Children.Add(bar[i - 1, j]);
                }
            }

            Grid g0 = new Grid();
            g0.Height = this.Height - 50;
            g0.Width = this.Width;
            g0.HorizontalAlignment = HorizontalAlignment.Center;
            g0.VerticalAlignment = VerticalAlignment.Center;

            g0.ColumnDefinitions.Add(new ColumnDefinition());
            g0.Children.Add(gr);
            Button exi = new Button();
            exi.Click += shut;
            exi.VerticalAlignment = VerticalAlignment.Top;
            exi.HorizontalAlignment = HorizontalAlignment.Stretch;
            exi.Height = this.Height - gr.Height - 100;
            exi.Content = "EXIT";
            exi.FontSize = 40;
            exi.Background = hj;
            Button lC = new Button(), rsC = new Button();
            lC.Content = "C"; rsC.Content = "<--";
            lC.Click += jftb; rsC.Click += jftb;
            lC.HorizontalAlignment = HorizontalAlignment.Left; rsC.HorizontalAlignment = HorizontalAlignment.Right;
            lC.VerticalAlignment = VerticalAlignment.Top; rsC.VerticalAlignment = VerticalAlignment.Top;
            lC.Height = 50; lC.Width = 130; rsC.Height = 50; rsC.Width = 130;
            lC.Margin = new Thickness(20, 50, 0, 0); rsC.Margin = new Thickness(0,50,20,0);
            g0.Children.Add(exi);
            g0.Children.Add(lC); g0.Children.Add(rsC);
            Content = g0;
            this.ResizeMode = ResizeMode.NoResize;
            Show();
        }

        private void jftb(object sendr, RoutedEventArgs raa)
        {
            if (((Button)sendr).Content.Equals("C"))
            {
                diia = -1;
                TXB.Text = "";
                adsh = "";
            }
            else
            {
                if (TXB.Text.Length>0)
                {
                    TXB.Text = TXB.Text.Remove(TXB.Text.Length - 1, 1);
                }
                else
                {
                    TXB.Text = "";
                }
                
            }
        }

        private void shut(object sendr, RoutedEventArgs raa)
        {
            WpfApp1AUTO.MainWindow mw = new WpfApp1AUTO.MainWindow();
            Hide();
            mw.Show();
        }

        private void deed(object sendr, RoutedEventArgs raa) {
            try
            {
                bool b = diia > 0 ? true : false;
                if (((Button)sendr).Content.Equals("+"))
                {
                    diia = 1;
                    adsh = TXB.Text;
                    if (b)
                    {
                        perform();
                    }
                    else
                    {
                        TXB.Text = "";
                    }

                }
                else if (((Button)sendr).Content.Equals("-"))
                {
                    diia = 2;
                    adsh = TXB.Text;
                    if (b)
                    {
                        perform();
                    }
                    else
                    {
                        TXB.Text = "";
                    }
                }
                else if (((Button)sendr).Content.Equals("*"))
                {
                    diia = 3;
                    adsh = TXB.Text;
                    if (b)
                    {
                        perform();
                    }
                    else
                    {
                        TXB.Text = "";
                    }
                }
                else if (((Button)sendr).Content.Equals("/"))
                {
                    diia = 4;
                    adsh = TXB.Text;
                    if (b)
                    {
                        perform();
                    }
                    else
                    {
                        TXB.Text = "";
                    }
                }
                else
                {
                    diia = -1;
                }

                
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.StackTrace);
            }
            
        }

        private void olCl(object sendr, RoutedEventArgs raa)
        {
            if (((Button)sendr).Content.Equals("="))
            {
                perform();
                diia = -1;
                TXB.Text = adsh;
                adsh = "";
            }
            else if (((Button)sendr).Content.Equals(","))
            {
                if (!TXB.Text.Contains(','))
                {
                    TXB.Text = TXB.Text + ",";
                }
            } else
            {
                TXB.Text = TXB.Text + ((Button)sendr).Content;
                while (TXB.Text.Length != 1 && TXB.Text[0] == '0')
                {
                    TXB.Text = TXB.Text.Remove(0, 1);
                }
            }

            
        }






        string adsh = "";
        int diia = -1;
        //
        //                       BACKGROUND
        //



        void perform()
        {

            if (diia == 1)
            {
                double dbl = double.Parse(TXB.Text) + double.Parse(adsh.Remove(0, 0));
                adsh = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }
            if (diia == 2)
            {
                double dbl = double.Parse(adsh.Remove(0, 0)) - double.Parse(TXB.Text);
                adsh = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }
            if (diia == 3)
            {
                double dbl = double.Parse(adsh.Remove(0, 0)) * double.Parse(TXB.Text);
                adsh = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }
            if (diia == 4)
            {
                if (double.Parse(TXB.Text) == 0)
                {
                    return;
                }
                double dbl = double.Parse(adsh.Remove(0, 0)) / double.Parse(TXB.Text);
                adsh = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }
            //MessageBox.Show(adsh);

        }

    }
}
