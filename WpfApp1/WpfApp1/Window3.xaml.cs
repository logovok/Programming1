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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }
        //17 NUMs MAX

        //string addish = "";
        

        void perform()
        {
            
            if (diia == 1)
            {
                double dbl = double.Parse(TXB.Text) + double.Parse(adsh.Text.Remove(0, 0));
                adsh.Text = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }
            if (diia ==2)
            {
                double dbl = double.Parse(adsh.Text.Remove(0, 0)) - double.Parse(TXB.Text);
                adsh.Text = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }
            if (diia == 3)
            {
                double dbl = double.Parse(adsh.Text.Remove(0, 0)) * double.Parse(TXB.Text);
                adsh.Text = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }
            if (diia == 4)
            {
                if (double.Parse(TXB.Text)==0)
                {
                    return;
                }
                double dbl = double.Parse(adsh.Text.Remove(0, 0)) / double.Parse(TXB.Text);
                adsh.Text = string.Format("{0:C3}", dbl.ToString());
                TXB.Text = "";
            }

        }

        void test() {
            if (TXB.Text.IndexOf(',')==TXB.Text.Length-1)
            {
                TXB.Text = TXB.Text.Remove(TXB.Text.Length-1,1);
            }
            if (TXB.Text.Contains(','))
            {
                double ch = double.Parse(TXB.Text);
                TXB.Text =string.Format("{0:C0}", ch.ToString());
            }
            else
            {
                long ch = long.Parse(TXB.Text);
                TXB.Text = ch.ToString();
            }
            
        }

        void oper() {

            while (TXB.Text.Length != 1 && TXB.Text[0] == '0')
            {
            TXB.Text = TXB.Text.Remove(0, 1);
            }


        }

        byte diia = 255;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void BP1_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "1";
            oper();
            //test();
        }

        private void BP2_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "2";
            oper();
        }

        private void BP3_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "3";
            oper();
        }

        private void BP4_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "4";
            oper();
        }

        private void BP5_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "5";
            oper();
        }

        private void BP6_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "6";
            oper();
        }

        

        private void BP7_Click_1(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "7";
            oper();
        }

        private void BP8_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "8";
            oper();
        }

        

        private void BP9_Click_1(object sender, RoutedEventArgs e)
        {
            TXB.Text = TXB.Text + "9";
            oper();
        }

        private void BP0_Click(object sender, RoutedEventArgs e)
        {
            if (TXB.Text.Length==0)
            {
                TXB.Text = "0";
                return;

            }
            if (TXB.Text[TXB.Text.Length-1]!='0'|| TXB.Text.Length>1)
            {
                TXB.Text = TXB.Text + "0";
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!TXB.Text.Contains(','))
            {
                TXB.Text = TXB.Text + ",";
            }
            
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (TXB.Text.Length < 2)
            {
                TXB.Text = "0";
            }
            else { 
                TXB.Text = TXB.Text.Remove(TXB.Text.Length - 1, 1);
                 }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            TXB.Text = "0";
            adsh.Text = "";
            diia = 255;
        }

        

        private void BPpl_Click(object sender, RoutedEventArgs e)
        {
            ADTB.Text = "+";
            if (TXB.Text.Equals(""))
            {
                diia = 1;
                return;
            }
            if (adsh.Text.Equals(""))
            {
                adsh.Text =  TXB.Text;
                TXB.Text = "";
               
            }
            else
            {
                perform();
            }
            diia = 1;
        }

        private void BPmn_Click(object sender, RoutedEventArgs e)
        {
            ADTB.Text = "|";
            if (TXB.Text.Equals(""))
            {
                diia = 2;
                return;
            }
            if (adsh.Text.Equals(""))
            {
                adsh.Text =  TXB.Text;
                TXB.Text = "";
            }
            else
            {
                perform();
            }
            diia = 2;
        }

        private void BPum_Click(object sender, RoutedEventArgs e)
        {
            ADTB.Text = "*";
            if (TXB.Text.Equals(""))
            {
                diia = 3;
                return;
            }
            if (adsh.Text.Equals(""))
            {
                adsh.Text = TXB.Text;
                TXB.Text = "";
            }
            else
            {
                perform();
            }
            diia = 3;
        }

        private void BPdn_Click(object sender, RoutedEventArgs e)
        {
            ADTB.Text = "\"";
            if (TXB.Text.Equals(""))
            {
                diia = 4;
                return;
            }
            if (adsh.Text.Equals(""))
            {
                adsh.Text = TXB.Text;
                TXB.Text = "";
            }
            else
            {
                perform();
            }
            diia = 4;
        }

        private void BPdrn_Click(object sender, RoutedEventArgs e)
        {

            if (!TXB.Text.Equals(""))
            {
                perform();
            }
            
            TXB.Text = adsh.Text;
            adsh.Text = "";
            diia = 255;
        }
    }
}
