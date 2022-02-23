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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            genGr();
        }
        Grid Mgr = new Grid();

        ComboBox[,] LsB = new ComboBox[5, 5];
        Grid LfGr = new Grid(), RiGr = new Grid();
        void genGr() {
            Title = "Tic Tac - Title special";
            
            try
            {
                
            Mgr.VerticalAlignment = VerticalAlignment.Stretch;
            Mgr.HorizontalAlignment = HorizontalAlignment.Stretch;
                Mgr.Height = Height - 20;
            Mgr.Width = Width - 20;

            ColumnDefinition rd1 = new ColumnDefinition();
            ColumnDefinition rd2 = new ColumnDefinition();
            GridLengthConverter GLC = new GridLengthConverter();
            rd1.Width = (GridLength)GLC.ConvertFrom("4*");
            rd2.Width = (GridLength)GLC.ConvertFrom("2*");

            LfGr.HorizontalAlignment = HorizontalAlignment.Stretch;
            LfGr.VerticalAlignment = VerticalAlignment.Stretch;

            RiGr.HorizontalAlignment = HorizontalAlignment.Stretch;
            RiGr.VerticalAlignment = VerticalAlignment.Stretch;
                
            Button b = new Button();
            b.Height = 50;
            b.Content = "EXIT";
            b.Click += shut;
            b.HorizontalAlignment = HorizontalAlignment.Stretch; b.VerticalAlignment = VerticalAlignment.Center;
            b.Visibility = Visibility.Visible;
            b.FontSize = 30;
                Brush hj = new SolidColorBrush(Color.FromRgb(254, 0, 0));
                b.Background = hj;
                
                
                //RiGr.Children.Add(b);
                //RiGr.ShowGridLines = true;
                TextBlock tb = new TextBlock();
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Stretch;
            tb.Text = "Tic Tac"; tb.FontSize = 50;
            tb.FontStyle = FontStyles.Oblique;
            Mgr.ColumnDefinitions.Add(rd1); Mgr.ColumnDefinitions.Add(rd2);

            Grid.SetColumn(LfGr,0); Grid.SetColumn(RiGr, 1);

                RowDefinition[] rdd = { new RowDefinition(), new RowDefinition() };
                rdd[0].Height = (GridLength)GLC.ConvertFrom("2*");
                rdd[1].Height = (GridLength)GLC.ConvertFrom("4*");

                RiGr.RowDefinitions.Add(rdd[0]);
            RiGr.RowDefinitions.Add(rdd[1]);
            RiGr.ShowGridLines = true;
            Grid.SetRow(b, 1);
            RiGr.Children.Add(b);
            Grid.SetRow(tb, 0);
            RiGr.Children.Add(tb);
                RowDefinition[] rdd2 = { new RowDefinition(), new RowDefinition() };
                rdd2[0].Height = (GridLength)GLC.ConvertFrom("2*");
                rdd2[1].Height = (GridLength)GLC.ConvertFrom("4*");

                LfGr.RowDefinitions.Add(rdd2[0]);
                LfGr.RowDefinitions.Add(rdd2[1]);
                Grid mstd = new Grid();
                mstd.VerticalAlignment = VerticalAlignment.Stretch;
                mstd.HorizontalAlignment = HorizontalAlignment.Stretch;

                Grid.SetRow(mstd, 1);
                LfGr.Children.Add(mstd);

                
                RowDefinition[] goo = new RowDefinition[5];
                ColumnDefinition[] coo = new ColumnDefinition[5];
                for (int i = 0; i < 5; i++)
                {
                    goo[i] = new RowDefinition();
                    goo[i].Height = (GridLength)GLC.ConvertFrom("5*");
                    coo[i] = new ColumnDefinition();
                    coo[i].Width = (GridLength)GLC.ConvertFrom("5*");
                    mstd.RowDefinitions.Add(goo[i]);
                    mstd.ColumnDefinitions.Add(coo[i]);
                }
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        ComboBoxItem lI1 = new ComboBoxItem();
                        lI1.Content = "X";
                        lI1.FontSize = 30;
                        ComboBoxItem lI2 = new ComboBoxItem();
                        lI2.Content = "O";
                        lI2.FontSize = 30;
                        LsB[i, j] = new ComboBox();
                        LsB[i, j].Items.Add(lI1);
                        LsB[i, j].Items.Add(lI2);
                        LsB[i, j].FontSize = 30;
                        Grid.SetRow(LsB[i, j],i);
                        Grid.SetColumn(LsB[i, j],j);
                        mstd.Children.Add(LsB[i, j]);
                    }
                }
                Button bRst = new Button();
                bRst.Content = "Reset";
                bRst.Click += RsT;
                bRst.FontSize = 50;
                bRst.VerticalAlignment = VerticalAlignment.Stretch;
                bRst.HorizontalAlignment = HorizontalAlignment.Stretch;
                Grid.SetRow(bRst, 0);
                LfGr.Children.Add(bRst);

                Mgr.Children.Add(LfGr); Mgr.Children.Add(RiGr);
            Mgr.ShowGridLines = true;

            Content = Mgr;
            Show();
            }
            catch (Exception eee)
            {

                MessageBox.Show(eee.StackTrace);
            }
        }
        private void RsT(object sendr, RoutedEventArgs raa)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    LsB[i, j].SelectedIndex = -1;
                }
            }
        }
        private void shut(object sendr, RoutedEventArgs raa)
        {
            WpfApp1AUTO.MainWindow mw = new WpfApp1AUTO.MainWindow();
            Hide();
            mw.Show();
        }
    }
}
