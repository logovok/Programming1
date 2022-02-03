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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            iinit();
        }
       
        
        List<String> str = new List<string>();
        void iinit() {
            try
            {
                StreamReader sr = new StreamReader("111.txt");
                while (!sr.EndOfStream)
                {
                    
                        str.Add(sr.ReadLine());
                    
                }
            }
            catch (Exception)
            {
            }
        }



        void TTnWr() {
            
           
            try
            {
                StreamWriter sw = new StreamWriter("111.txt");
                for (int i = 0; i < str.Count; i++)
                {

                    
                    if (i!=str.Count-1)
                    {
                        sw.WriteLine(str[i]);
                    }
                    else
                    {
                        sw.Write(str[i]);
                    }
                    
                }
                sw.Close();
            }
            catch (Exception e)
            {
               // BTN1.Content = e.StackTrace;
                //throw;
            }
        }

         

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // sw.Close();
            //sr.Close();
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }

        private void BTN1_Click(object sender, RoutedEventArgs e)
        {
            str.Add(TB1.Text+"|"+TB2.Text+"|"+TB3.Text);
            if (!CHB1.IsChecked.Value)
            {
                TTnWr();
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            TTnWr();
        }

        private void BTN2_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < str.Count; i++)
            {
                if (str[i].Split('|')[0].Equals(TB1.Text))
                {
                    str.Remove(str[i]);
                }
            }
            if (!CHB1.IsChecked.Value)
            {
                TTnWr();
                
            }
            
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
