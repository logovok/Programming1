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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Adminity : Window
    {
        public Adminity()
        {
            InitializeComponent();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            object[] obm = SequelOperator.getRestrictions();
            int i1 = (int)obm[0];
            int i2 = (int)obm[1];
            bool b1 = (bool)obm[2];
            bool b2 = (bool)obm[3];
            bool b3 = (bool)obm[4];
            //MessageBox.Show("1 = "+ b1.ToString()+"\n2 = "+b2.ToString()+"\n+3 = "+b3);
            bool beORnot2be = true;
            string erMsg = "";
            if (!(P1.Text.Length >= i1))
            {
                beORnot2be = false;
                erMsg += "Less then " + i1.ToString() + " symbols \n";
            }
            if (!(P1.Text.Length <= i2))
            {
                beORnot2be = false;
                erMsg += "Bigger then " + i2.ToString() + " symbols \n";
            }
            if (b1)
            {
                bool tmp = false;
                for (int i = 0; i < 10; i++)
                {
                    if (P1.Text.Contains(i.ToString()))
                    {
                        tmp = true; break;
                    }
                }
                if (!tmp)
                {
                    beORnot2be = false;
                    erMsg += "Not contains numbers\n";
                }
            }
            if (b2)
            {
                bool tmp2 = false;
                string tmp = "~`!@#$%^&*()-_=+";
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (P1.Text.Contains(Convert.ToString(tmp[i])))
                    {
                        tmp2 = true; break;
                    }
                }
                if (!tmp2)
                {
                    beORnot2be = false;
                    erMsg += "Not contains symbols like ~`!@#$%^&*()-_=+\n";
                }
            }
            if (b3)
            {
                bool tmp2 = false;
                string tmp = "QWERTYUIOPASDFGHJKLZXCVBNM";
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (P1.Text.Contains(Convert.ToString(tmp[i])))
                    {
                        tmp2 = true; break;
                    }
                }
                if (!tmp2)
                {
                    beORnot2be = false;
                    erMsg += "Not contains BIG SYMBOLS\n";
                }
            }
            if (!beORnot2be)
            {
                MessageBox.Show(erMsg);
            } else
            if (P1.Text.Equals(P2.Text))
            {
               bool tmp = SequelOperator.passUpd(SequelOperator.memory,PrP.Text,P1.Text);
                if (!tmp) {
                    MessageBox.Show("Wrong old password");
                }
                else
                {
                    MessageBox.Show("Password changed successfully");
                    PrP.Text = P1.Text;
                }
            }
            else
            {
                MessageBox.Show("Passwords are not same");
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SequelOperator.Sv();
            SequelOperator.Close();
            Application.Current.Shutdown();
        }
    }
}
