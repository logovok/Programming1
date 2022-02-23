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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent(); inn();
        }
        void inn() {
            
            GridLengthConverter GLC = new GridLengthConverter();
            Grid gr = new Grid();
            gr.ShowGridLines = true;
            RowDefinition[] rd = new RowDefinition[5];
            TextBlock tb1 = new TextBlock();
            tb1.Text = "Розробив Мальцев микита Ігорович";
            tb1.HorizontalAlignment = HorizontalAlignment.Stretch;
            tb1.VerticalAlignment = VerticalAlignment.Stretch;
            tb1.FontSize = 25;
            TextBlock tb2 = new TextBlock();
            tb2.Text = "КП-12";
            tb2.HorizontalAlignment = HorizontalAlignment.Stretch;
            tb2.VerticalAlignment = VerticalAlignment.Stretch;
            tb2.FontSize = 25;
            TextBlock tb3 = new TextBlock();
            tb3.Text = "23.02.2022";
            tb3.FontSize = 25;
            tb3.HorizontalAlignment = HorizontalAlignment.Stretch;
            tb3.VerticalAlignment = VerticalAlignment.Stretch;

            rd[0] = new RowDefinition(); rd[4] = new RowDefinition();
            rd[0].Height = (GridLength)GLC.ConvertFrom("2*");
            rd[4].Height = (GridLength)GLC.ConvertFrom("2*");
            for (int i = 1; i < 4; i++)
            {
                rd[i] = new RowDefinition();
                rd[i].Height = (GridLength)GLC.ConvertFrom("1*");
            }
            for (int i = 0; i < 5; i++)
            {
                gr.RowDefinitions.Add(rd[i]);
            }
            Button b = new Button();
            b.Content = "EXIT";
            b.Click += shut;
            b.HorizontalAlignment = HorizontalAlignment.Stretch; b.VerticalAlignment = VerticalAlignment.Stretch;
            b.Visibility = Visibility.Visible;
            b.FontSize = 30;
            Brush hj = new SolidColorBrush(Color.FromRgb(0, 200, 200));
            b.Background = hj;
            Grid.SetRow(tb1, 1);
            gr.Children.Add(tb1);
            Grid.SetRow(tb2, 2);
            gr.Children.Add(tb2);
            Grid.SetRow(tb3, 3);
            gr.Children.Add(tb3);
            Grid.SetRow(b,4);
            gr.Children.Add(b);

            this.Content = gr;
            Show();
           
            
        }
        private void shut(object sendr, RoutedEventArgs raa)
        {
            WpfApp1AUTO.MainWindow mw = new WpfApp1AUTO.MainWindow();
            Hide();
            mw.Show();
        }
    }
}
