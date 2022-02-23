using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1AUTO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            initTheIt();

        }

        private void w1c(object sendr, RoutedEventArgs raa) {
            if (((Button)sendr).Content.Equals("EXIT"))
            {
                Application.Current.Shutdown();
            }
            if (((Button)sendr).Content.Equals("Calc"))
            {
                WpfApp1A.Window1 w1 = new WpfApp1A.Window1();
                Hide();
                w1.Show();
            }
            else if (((Button)sendr).Content.Equals("TicTac"))
            {
                WpfApp1A.Window2 w2 = new WpfApp1A.Window2();
                Hide();
                w2.Show();
            }
            else if (((Button)sendr).Content.Equals("Info"))
            {
                WpfApp1A.Window3 w2 = new WpfApp1A.Window3();
                Hide();
                w2.Show();
            }
            else if (((Button)sendr).Content.Equals("Base")) {
                WpfApp1A.Window4 w2 = new WpfApp1A.Window4();
                Hide();
                w2.Show();
            }


        }

        

        Button[] arB = { new Button(), new Button(), new Button(), new Button(), new Button() };
        void initTheIt() {
            Brush hj = new SolidColorBrush(Color.FromRgb(0,0,0));
            Background = hj;
            Grid gr = new Grid();
            Brush yl = new LinearGradientBrush(Color.FromRgb(229, 15, 252), Color.FromRgb(252,237,15),35);
            gr.Background = yl;
            gr.Height = Height-50;
            gr.Width = Width-50;
            gr.VerticalAlignment = VerticalAlignment.Center;
            gr.HorizontalAlignment = HorizontalAlignment.Center;
            //gr.ShowGridLines = true;
            
            RowDefinition[] rd = new RowDefinition[7];
            ColumnDefinition[] cd = new ColumnDefinition[2];
            GridLengthConverter GLC = new GridLengthConverter();
            for (int i = 0; i < rd.Length; i++)
            {
                rd[i] = new RowDefinition();
               
                gr.RowDefinitions.Add(rd[i]);
            }
            for (int i = 0; i < cd.Length; i++)
            {
                cd[i] = new ColumnDefinition();
                cd[i].Width = (GridLength)GLC.ConvertFrom(i != 0 ? "4*" : "1*");
                gr.ColumnDefinitions.Add(cd[i]);
            }

            arB[0].Content = "Base"; arB[1].Content = "Calc"; arB[2].Content = "TicTac";
            arB[3].Content = "Info"; arB[4].Content = "EXIT";

            arB[0].Click += w1c; arB[1].Click += w1c; arB[2].Click += w1c;
            arB[3].Click += w1c; arB[4].Click += w1c;



            for (int i = 0; i < arB.Length; i++)
            {
                Grid.SetRow(arB[i],i+1);
                Grid.SetColumn(arB[i],0);
                gr.Children.Add(arB[i]);
            }
            this.Content = gr;
            Show();
        }
    }
}
