using System;
using System.Collections.Generic;
using System.Diagnostics;
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
namespace WPF2Indntfyer
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            ching.SelectedItem = ching.Items[1];
            for (int i = 0; i < 9; i++)
            {
               // danni[i] = new List<long>();
                
            }
            dcou = cou;
            try
            {
                StreamReader str = new StreamReader("ml.txt");
                while (!str.EndOfStream)
                {
                    lk.Add(str.ReadLine());
                }
            }
            catch (Exception)
            {

                throw;
            }
            try
            {
                StreamReader sr = new StreamReader("stat.txt");

                string f = sr.ReadLine();
                zn1 = int.Parse(f.Split(' ')[0]);
                zn2 = int.Parse(f.Split(' ')[1]);
                zn3 = int.Parse(f.Split(' ')[2]);
                sr.Close();
                PMLKK.Text = "Pomylka 1 rodu = " + ((double)zn1 / (zn1 + zn2 + zn3)).ToString() + "\n" +
                "Pomylka 2 rodu = " + ((double)zn2 / (zn1 + zn2 + zn3)).ToString();

            }
            catch (Exception)
            {


            }
        }
        int zn3 = 0;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            this.Hide();
            mw.Show();
        }
        double nK = 3.18;
        int posit = 0, negat = 0;
        bool dspron = true;
        List<string> lk = new List<string>();

        void aunth() {
            try
            {
                StreamReader sr = new StreamReader("ml.txt");
                /*string ht = "";
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < 9; i++)
                    {
                        ht = sr.ReadLine();
                        for (int j = 0; j < ht.Split('|').Length; j++)
                        {
                            if (!ht.Split("|")[j].Equals(""))
                            {
                                //MessageBox.Show(double.Parse(ht.Split("|")[j].Split('-')[0]).ToString());
                                iaE1.Add(double.Parse(ht.Split("|")[j].Split(' ')[0]));
                                iaE2.Add(double.Parse(ht.Split("|")[j].Split(' ')[1]));
                            }
                            
                        }
                        //iaE[i].Add();
                    }
                }*/

                for (int i = 0; i < lk.Count; i++)
                {
                    string[] wwi = lk[i].Split('|');
                    for (int j = 0; j < wwi.Length; j++)
                    {
                        if (wwi[j].Length>3)
                        {
                            double bS = 0, tT = 0;
                            
                            bS = Math.Sqrt(8.0 * (dspr[int.Parse(wwi[j].Split(' ')[0])] + double.Parse(wwi[j].Split(' ')[2])) / 17.0);
                            tT = Math.Abs(double.Parse(wwi[j].Split(' ')[1]) - mItaya[int.Parse(wwi[j].Split(' ')[0])]) / bS;
                            tT = tT * Math.Sqrt(9 / 2);
                            if (tT < nK)
                            {
                               // MessageBox.Show(posit.ToString());
                                posit++;
                            }
                            else
                            {
                                negat++;
                            }
                            if (Math.Max(dspr[j], double.Parse(wwi[j].Split(' ')[2]))/ Math.Min(dspr[j], double.Parse(wwi[j].Split(' ')[2])) < 6.03)
                            {
                                dspron = false;
                            }
                        }
                        
                    }
                }
               // MessageBox.Show(posit.ToString());
               // MessageBox.Show(negat.ToString());
                //string[] tmr = new string[9];
                // double bS = 0, tT = 0;
                //int ij = 0;

                // if (posit!=0)
                //{
                //  tbP.Text = "P = " + (posit).ToString();
                //}

            }
            catch (Exception op)
            {

                MessageBox.Show(op.StackTrace, "Err");
            }
        }

        Stopwatch stw = new Stopwatch();

        List<long> danni = new List<long>();
        int mains = 0;

        double[] mItaya = new double[9];

        void cheeser() {
            nK = Class1.tabG[ching.SelectedIndex,8];
        }

        /*  void auf() {
              for (int i = 0; i < dcou; i++)
              {
                  for (int h = 0; h < iaE1[mains].Count; h++)
                  {
                      double S = Math.Sqrt((8) * (dspr[i] + iaE2[mains][h]) / (2 * 8 - 1));
                      double Tr = Math.Abs(iaE1[mains][h] - mItaya[i]) / (S * Math.Sqrt(8 / 2));
                      //Tr = Tr ;
                      if (Tr < nK)
                      {
                          //MessageBox.Show(Tr.ToString());
                          posit++;
                      }
                      else
                      {
                          //Разобраться с мейнс, возможно, на z заменить
                          negat++;
                      }
                  }

              }
          } */
        
        void MathSpod()
        {
            cheeser();

            for (int i = 0; i < 9; i++)
            {
                mItaya[i] = 0;
            }

           /* try
            {
                mains = 0;
                
                for (int z = 0; z < 9; z++)
                {
                    mItaya = new double[dcou];
                    for (int i = 0; i < mItaya.Length; i++)
                    {
                        mItaya[i] = 0;
                    }
                    for (int i = 0; i < dcou; i++)
                    {
                        for (int j = 0; j < dcou; j++)
                        {

                            if (i != j)
                            {
                                mItaya[i] += danni[j];
                            }
                        }
                        mItaya[i] /= dcou - 1;
                    }
                    dspr = new double[dcou];
                    for (int i = 0; i < dspr.Length; i++)
                    {
                        dspr[i] = 0;
                    }
                    for (int i = 0; i < dcou; i++)
                    {
                        for (int j = 0; j < dcou; j++)
                        {

                            if (i != j)
                            {
                                dspr[i] += (danni[j][mains + 1] - mItaya[i]) * (danni[j][mains + 1] - mItaya[i]);
                            }
                        }
                        mItaya[i] /= dcou - 2;
                    }
                    for (int i = 0; i < dcou; i++)
                    {
                        for (int h = 0; h < iaE1[mains].Count; h++)
                        {
                            double S = Math.Sqrt((dcou - 1) * (dspr[i] + iaE2[mains][h]) / (2 * dcou - 1));
                            double Tr = Math.Abs(iaE1[mains][h] - mItaya[i]) / (S * Math.Sqrt(dcou / 2));
                            //Tr = Tr ;
                            if (Tr < nK)
                            {
                                //MessageBox.Show(Tr.ToString());
                                posit++;
                            }
                            else
                            {
                                 //Разобраться с мейнс, возможно, на z заменить
                                negat++;
                            }
                        }
                        
                    }

                    mains++;
                }
               //MessageBox.Show(posit.ToString());
                //MessageBox.Show(negat.ToString());//почему при н > 3 так много негат

                //реализовать коэф

                if (posit != 0)
                {
                    tbP.Text = "P = " + ((double)posit / (posit + negat)).ToString();
                }
            }
            catch (Exception ghto)
            {

                MessageBox.Show(ghto.StackTrace);
            } */

            

            
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {

                    if (i != j)
                    {
                        mItaya[i] += danni[j + 1];
                    }
                }

                mItaya[i] /= 8;
            } 
        }

        double[] dspr = new double[9];

        void Dspr()
        { //Дисперсія
            for (int i = 0; i < dspr.Length; i++)
            {
                dspr[i] = 0;
            }
            for (int i = 0; i < 9; i++)
            {

                for (int j = 0; j < 9; j++)
                {

                    if (i != j)
                    {
                        dspr[i] += (danni[j + 1] - mItaya[i]) * (danni[j + 1] - mItaya[i]);
                    }
                }

                dspr[i] /= 7;
            }
        }

        void sving() {

            try
            {
                MathSpod();

                Dspr();

                aunth();
            }
            catch (Exception c)
            {

                MessageBox.Show(c.StackTrace);
            }
           


        }
        int zn1 = 0, zn2 = 0;
        void checkChecker() {
            byte pmlk = 255;
            MessageBoxResult mbi = MessageBox.Show("Were you auntheficated?", "Question", MessageBoxButton.YesNo);
            if (mbi == MessageBoxResult.Yes)
            {
                mbi = MessageBox.Show("Was it a mistake?", "Question", MessageBoxButton.YesNo);
                if (mbi == MessageBoxResult.Yes)
                {
                    pmlk = 1;
                }
            }
            else
            {
                mbi = MessageBox.Show("Was it a mistake?", "Question", MessageBoxButton.YesNo);
                if (mbi == MessageBoxResult.Yes)
                {
                    pmlk = 2;
                }
            }
            if (pmlk<3)
            {

                if (pmlk == 1)
                {
                    zn1++;
                }
                else
                {
                    zn2++;
                }
                
            }
            else
            {
                zn3++;
            }
            try
            {

                StreamWriter sw = new StreamWriter("stat.txt");
                sw.WriteLine(zn1.ToString() + " " + zn2.ToString()+" "+zn3.ToString());

                sw.Close();
            }
            catch (Exception)
            {


            }
            PMLKK.Text = "Pomylka 1 rodu = " + ((double)zn1 / (zn1 + zn2 + zn3)).ToString() + "\n" +
                "Pomylka 2 rodu = " + ((double)zn2 / (zn1 + zn2 + zn3)).ToString();
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (stw.IsRunning)
            {
                stw.Stop();
            }



            danni.Add(stw.ElapsedTicks);//Exception Tyt
            stw.Reset();
            stw.Start();

            //TBo.Text = danni[danni.Count - 1].ToString();
            if (Enterance.Text.Equals("zomelganek"))
            {
                mains++;
                cou--;
                //MessageBox.Show("Starting processing if the information. Please wait.", "Attention");
                sving();
                tbP.Text = "P = " + (posit > 0 ? ((double)posit) / (posit + negat) : 0);
                posit = 0; negat = 0;
                dse.Text = dspron ? "Odnoridni dyspersii" : "Neodnoridni dyspersii";
                dspron = true;
                checkChecker();
                if (cou < 1)
                {
                    Enterance.IsEnabled = false;
                    RMN.Text = "Done";
                    nmbot.Text = "0";
                    
                    //aunth();
                    //MathSpod();
                    // MainWindow w1 = new MainWindow();
                    // this.Hide();
                    // w1.Show();
                }
                else
                {
                    
                    RMN.Text = cou.ToString() + " remaining";
                    nmbot.Text = cou.ToString();
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
        int dcou;
        int cou = 3;

       

        private void ching_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          // MessageBox.Show("juio9iuyh");
        }

        private void nmbot_KeyUp(object sender, KeyEventArgs e)
        {
            if (nmbot.Text.Length!=0)
            {
                if (int.Parse(nmbot.Text) > 2)
                {
                    if (int.Parse(nmbot.Text) < 12)
                    {
                        cou = int.Parse(nmbot.Text);
                        dcou = cou;
                    }
                    else
                    {
                        MessageBox.Show("Max = 11");
                        cou = 11;
                        dcou = cou;
                    }

                    
                    
                }
                else
                {
                    cou = 3;
                    dcou = cou;
                }
            }
            else
            {
                cou = 3;
                dcou = cou;
            }

            RMN.Text = cou.ToString() + " remaining";
        }
    }
}
