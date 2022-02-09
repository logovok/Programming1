using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;

namespace WPF2Indntfyer
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();

        }

        void cheeser()
        {
            cfi = Class1.tabG[1, 8];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }
        double cfi = 2.26;
        //zomelganek
        //string auf = "";
        Stopwatch stw = new Stopwatch();
        int genEl = 1;
        void stk2danni()
        {
            
            danni.Clear();
            for (int i = 0; i < ls.Count; i++)
            {
                danni.Add(long.Parse(ls[i].Split(' ')[genEl]));
            }
        }
        double[] mItaya;

        bool peremennayaImenyLenina = true;
        void MathSpod() { //Математичне сподівання
            if (peremennayaImenyLenina)
            {
                //MessageBox.Show((danni.Count - 1).ToString());
                mItaya = new double[danni.Count-1];
                //MessageBox.Show(mItaya.Length.ToString());

            }
            else
            {
                mItaya = new double[danni.Count];
            }
            
            //mItaya = new double[danni.Count];
            for (int i = 0; i < mItaya.Length; i++)
            {
                mItaya[i] = 0;
            }
            for (int i = 0; i < mItaya.Length; i++)
            {
                
                for (int j = 0; j < mItaya.Length; j++)
                {
                    
                    if (i!=j)
                    {
                        //MessageBox.Show((peremennayaImenyLenina ? j+1  : j).ToString());
                        mItaya[i] += danni[peremennayaImenyLenina ? j+1  : j];
                    }
                }

                mItaya[i] /= mItaya.Length - 1;
            }
        }

        double[] dspr;

        void Dspr()
        { //Дисперсія

            
                dspr = new double[mItaya.Length];
           // MessageBox.Show(dspr.Length.ToString());

            for (int i = 0; i < dspr.Length; i++)
            {
                dspr[i] = 0;
            }
            for (int i = 0; i < dspr.Length; i++)
            {
                

                for (int j = 0; j < dspr.Length; j++)
                {
                   // MessageBox.Show(ls.Count.ToString());
                    if (i != j)
                    {
                        dspr[i] += (danni[peremennayaImenyLenina ? j + 1 : j] - mItaya[i]) * (danni[peremennayaImenyLenina ? j + 1 : j] - mItaya[i]);
                    }
                }
                
                dspr[i] /= dspr.Length - 2;
            }
        }

        double[] dspr2 ;

        void Dspr2() { //Середньоквадратиччне дисперсії
            dspr2 = new double[dspr.Length];
            for (int i = 0; i < dspr2.Length; i++)
            {
                dspr2[i] = Math.Sqrt(dspr[i]);
            }
        }

        double[] qfStd ;

        void QfSt() {//Коефіцієнт Стьюдента
            qfStd = new double[dspr.Length];
            for (int i = 0; i < dspr.Length; i++)
            {
                qfStd[i] = Math.Abs((danni[peremennayaImenyLenina ? i + 1 : i] - mItaya[i]) / dspr2[i]);
            }
        }

        void validateDe()
        {

            while (genEl - 1 < 9)
            {
                stk2danni(); MathSpod(); Dspr(); Dspr2(); QfSt();
                string tmp = "";
                for (int i = 0; i < ls.Count; i++)
                {

                    if (qfStd[i] < cfi)
                    {
                        if (i != 0)
                        {
                            tmp = tmp + "|" + mItaya[i] + "-" + dspr[i];
                            //ls2[i] = ls2[i]

                        }
                        else
                        {
                            tmp =  mItaya[i] + "-" + dspr[i];
                            //ls2.Add(i + "-" + mItaya[i] + "-" + dspr[i]);

                        }
                    }
                }


                danni.Clear();
                ls2.Add(tmp);
                genEl++;
            }

            sving();
            
        //HEG
        } 

        List<long> danni = new List<long>();
        List<int> kfsz = new List<int>();
        void dnch() {
            try
            {
                peremennayaImenyLenina = true;
                MathSpod(); Dspr(); Dspr2(); QfSt();
                //MessageBox.Show("Mandalee");
                List<long> tmpd = new List<long>();
                //tmpd.Add(0);
                for (int i = 0; i < qfStd.Length; i++)
                {
                    if (qfStd[i] < cfi)
                    {
                       //
                       //MessageBox.Show(qfStd.Length.ToString());
                        tmpd.Add(danni[i + 1]);
                    }
                    else
                    {
                        kfsz.Add(i);
                    }
                }
                danni.Clear();
                danni = tmpd; //MessageBox.Show(danni.Count.ToString());
                peremennayaImenyLenina = false;
                //MessageBox.Show("Mandalee");
                MathSpod(); Dspr(); Dspr2(); QfSt();
            }
            catch (Exception nix)
            {

                MessageBox.Show(nix.StackTrace);
            }
            
        }

        void lng2str() {
            dnch();
            string tmp = "";
            /*for (int i = 0; i < danni.Count; i++)
            {
                if (qfStd[i] < cfi)
                {
                    if (i == 0)
                    {
                        tmp = danni[i].ToString();
                    }
                    else
                    {
                        tmp = tmp + " " + danni[i];
                    }
                }
                else
                {
                    if (i == 0)
                    {
                        tmp = "~";
                    }
                    else
                    {
                        tmp = tmp + " " + "~";
                    }
               } 
            } */
            try
            {
                for (int i = 0; i < mItaya.Length; i++)
                {

                    if (i != 0)
                    {
                        tmp = tmp + "|";
                    }

                    if (!kfsz.Contains(i))
                    {
                        tmp = tmp + i.ToString() + " " + mItaya[i].ToString() + " " + dspr[i].ToString();
                    }
                    else
                    {
                        tmp = tmp + "~";
                    }



                }
               /* if (mItaya.Length <9)
                {
                    for (int i =9-(mItaya.Length-1); i < length; i++)
                    {

                    }
                } */
            }
            catch (Exception f35)
            {

                MessageBox.Show(f35.StackTrace);
            }
            
            danni.Clear();
            ls2.Add(tmp);
            
        }
        List<String> ls = new List<string>();
        List<String> ls2 = new List<string>();
        void sving() {
           // lng2str();
            try
            {
                StreamReader sr = new StreamReader("ml.txt");
                while (!sr.EndOfStream)
                {
                    ls2.Add(sr.ReadLine());
                }
                sr.Close();
            }
            catch (Exception)
            {
               // MessageBox.Show("ml.txt file not found", "Attention!");
            }

            try
            {
                StreamWriter sw = new StreamWriter("ml.txt");
                for (int i = 0; i < ls2.Count; i++)
                {
                    if (i==ls2.Count-1)
                    {
                        sw.Write(ls2[i]);
                    }
                    else
                    {
                        sw.WriteLine(ls2[i]);
                    }
                }
                sw.Close();
            }
            catch (Exception)
            {
                MainWindow w1 = new MainWindow();
                this.Hide();
                w1.Show();
                MessageBox.Show("Error 502", "Error");
            }

            ls2.Clear();
           // MessageBox.Show("Result saved", "Success");
        }

        int cou = 3;

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (stw.IsRunning)
            {
                stw.Stop();
            }



            danni.Add(stw.ElapsedTicks);
            stw.Reset();
            stw.Start();

            //TBo.Text = danni[danni.Count - 1].ToString();
            if (Enterance.Text.Equals("zomelganek"))
            {
                cou--;
                RMN.Text = cou.ToString()+" remaining";
                nmbot.Text = cou.ToString();
                

                
                lng2str();
                sving();
                if (cou == 0)
                {
                    //validateDe();
                    MainWindow w1 = new MainWindow();
                    this.Hide();
                    w1.Show();
                }
                else {
                    Enterance.Text = "";
                    stw.Stop();
                    stw.Reset();
                    danni.Clear();

                }
                
            }
            for (int i = 0; i < Enterance.Text.Length; i++)
            {
                if (Enterance.Text[i] != "zomelganek"[i])
                {
                    MessageBox.Show("You typed wrong symbol!!", "Error");
                    Enterance.Text = "";
                    RMN.Text = cou.ToString() + " remaining";
                    nmbot.Text = cou.ToString();
                    Enterance.Text = "";
                    stw.Stop();
                    stw.Reset();
                    danni = new List<long>();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        { 
            
        }

        private void nmbot_KeyUp(object sender, KeyEventArgs e)
        {


            if (nmbot.Text.Length != 0)
            {
                if (int.Parse(nmbot.Text) > 2)
                {
                    if (int.Parse(nmbot.Text)<12)
                    {
                        cou = int.Parse(nmbot.Text);
                        cheeser();
                    }
                    else
                    {
                        MessageBox.Show("Max = 11");
                        cou = 11;
                        cheeser();
                    }
                    
                }
                else
                {
                    cou = 3;
                    cheeser();
                }
            }
            else
            {
                cou = 3;
                cheeser();
            }

            RMN.Text = cou.ToString() + " remaining";
        }
    }
}
