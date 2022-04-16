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

namespace Lab3Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            SequelOperator.Open("Data Source=HPPVL15;Initial Catalog=MailDBase;"
        + "Integrated Security=true;");
            SequelOperator.Sv();
            this.ResizeMode = ResizeMode.NoResize;
            //Window1 w1 = new Window1();
            //this.Hide();
            //w1.Show();

        }

        int clc = 0;

        private void UsrButt_Click(object sender, RoutedEventArgs e)
        {
            clc++;
            if (log.Text.Length > 0)
            {

                if (SequelOperator.auth(log.Text, pas.Text))
                {
                    if (SequelOperator.chk4permit(log.Text))
                    {
                        Adminity w2 = new Adminity();
                        this.Hide();
                        w2.Show();
                        clc--;
                    }
                    else
                    {
                        MessageBox.Show("Banned"); 
                    }
                    
                } else
                {
                        MessageBox.Show("Login or password incorrect");
                }
            }
            else
            {
                    MessageBox.Show("Too smal login");
            }
            if (clc>2)
            {
                SequelOperator.Close();
                Application.Current.Shutdown();
            }
        }

        private void AdminButt_Click(object sender, RoutedEventArgs e)
        {
            clc++;
            if (log.Text.Length > 0)
            {

                if (SequelOperator.auth(log.Text, pas.Text))
                {
                    if (SequelOperator.chk4permit(log.Text))
                    {
                        if (SequelOperator.chk4admin(log.Text))
                        {
                            Window1 w1 = new Window1();
                            w1.Show();
                            this.Hide();
                            clc--;
                        }
                        else { MessageBox.Show("Not an admin"); }
                        
                    }
                    else
                    {
                        MessageBox.Show("Banned");
                    }

                }
                else
                {
                    MessageBox.Show("Login or password incorrect");
                }
            }
            else
            {
                MessageBox.Show("Too smal login");
            }
            /*if (log.Text.Length>0)
            {
                if (SequelOperator.auth(log.Text, pas.Text) && SequelOperator.chk4admin(log.Text) && SequelOperator.chk4permit(log.Text))
                {
                    
                    
                }

                else
                {
                    MessageBox.Show("Login or password incorrect");
                    //MessageBox.Show(SequelOperator.auth(log.Text, pas.Text).ToString()+"-=-=-=-"+ SequelOperator.chk4admin(log.Text));
                }


            }
            else
            {
                if (!SequelOperator.chk4permit(log.Text))
                {
                    MessageBox.Show("Banned!");
                }
                if (!SequelOperator.chk4admin(log.Text))
                {
                    MessageBox.Show("Not admin!");
                }

                if (!(log.Text.Length > 0))
                {
                    MessageBox.Show("Too smal login");
                }
            } */
            if (clc > 2)
            {
                SequelOperator.Close();
                Application.Current.Shutdown();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            
            SequelOperator.Close();
            Application.Current.Shutdown();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String msg = "Developed by Maltsev Mykyta,\n" +
                "KP-12 \n" +
                "email - logovok093@gmail.com";
            MessageBox.Show(msg);
        }
    }
}
