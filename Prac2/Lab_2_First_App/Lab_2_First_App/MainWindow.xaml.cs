using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Lab_2_First_App
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static DispatcherTimer dT;
        static int Radius = 30;
        static int PointCount = 5;
        static Polygon myPolygon = new Polygon();
        static List<Ellipse> EllipseArray = new List <Ellipse>();
        static PointCollection pC = new PointCollection();

        public MainWindow()
        {
            dT = new DispatcherTimer();

            InitializeComponent();
            InitPoints();
            InitPolygon();
            fGenIndOpoi();
            dT = new DispatcherTimer();
            dT.Tick += new EventHandler(OneStep);
            dT.Interval = new TimeSpan(0, 0, 0, 0, 1000);            
        }

        private void InitPoints()
        {
            Random rnd = new Random();
            pC.Clear();
            EllipseArray.Clear();

            for (int i = 0; i < PointCount; i++)
            {
                Point p = new Point();

                p.X = rnd.Next(Radius, (int)(0.75*MainWin.Width)-3*Radius);
                p.Y = rnd.Next(Radius, (int)(0.90*MainWin.Height-3*Radius));                
                pC.Add(p);
            }

            for (int i = 0; i < PointCount; i++)
            { 
                Ellipse el = new Ellipse();

                el.StrokeThickness = 2;
                el.Height = el.Width = Radius;
                el.Stroke = Brushes.Black;
                el.Fill = Brushes.LightBlue;
                EllipseArray.Add(el); 
            }            
        }

        private void InitPolygon()
        {
            myPolygon.Stroke = System.Windows.Media.Brushes.Black;            
            myPolygon.StrokeThickness = 2;            
        }

        private void PlotPoints()
        {            
            for (int i=0; i<PointCount; i++)
            {
                Canvas.SetLeft(EllipseArray[i], pC[i].X - Radius/2);
                Canvas.SetTop(EllipseArray[i], pC[i].Y - Radius/2);
                MyCanvas.Children.Add(EllipseArray[i]);
            }
        }


        private void PlotWay(int [] BestWayIndex)
        {
            PointCollection Points = new PointCollection();

            for (int i = 0; i < BestWayIndex.Length; i++)
                Points.Add(pC[BestWayIndex[i]]);

            myPolygon.Points = Points;
            MyCanvas.Children.Add(myPolygon);
        }

        private void VelCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;
                        
            dT.Interval = new TimeSpan(0,0,0,0,Convert.ToInt16(item.Content));
        }

        private void StopStart_Click(object sender, RoutedEventArgs e)
        {
            if (dT.IsEnabled)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
            }
            else
            {                
                NumElemCB.IsEnabled = false;
                dT.Start();
            }
        }

        private void NumElemCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox CB = (ComboBox)e.Source;
            ListBoxItem item = (ListBoxItem)CB.SelectedItem;

            PointCount = Convert.ToInt32(item.Content);
            InitPoints();
            InitPolygon();
            populations.Clear();
            lngS.Clear();
            fGenIndOpoi();
        }

        private void OneStep(object sender, EventArgs e)
        {
            MyCanvas.Children.Clear();
            //InitPoints();
            PlotPoints();
            maineAy();
            PlotWay(GetBestWay());

        }
        int sum_summa = int.MaxValue;
        int count_counter = 0;
        void check_checker(int value) {
            if (sum_summa>value)
            {
                sum_summa = value;
                count_counter = 0;
            }
            else
            {
                count_counter++;
            }

            if (count_counter>3*PointCount)
            {
                dT.Stop();
                NumElemCB.IsEnabled = true;
                MessageBox.Show("Its almost the best way");
                count_counter = 0;
            }
        }

        Random rnd = new Random();
        int countOfPopulations = 30;
        List<int[]> populations = new List<int[]>();
        List<int> lngS = new List<int>();

        int[] otbor() {//Возвращает массив индексов элементов популяции наименьшей длинны
            int[] res = new int[countOfPopulations ];
            List<int> inOEX = new List<int>();
            //List<int[]> onOEX = new List<int[]>();
            for (int i = 0; i < res.Length; i++)
            {
                
                int tmp = 0;
                while (inOEX.Contains(tmp)) { tmp++; }
                for (int g = 0; g < lngS.Count; g++)
                {
                    if (lngS[g]<lngS[tmp]&&!inOEX.Contains(g))
                    {
                        tmp = g;
                        //
                    }
                }
                /* for (int j = 0; j < pC.Count; j++)
                 {
                     if (lngS[tmp]>lngS[i]&&(!inOEX.Contains(i)))
                     {
                         tmp = i;
                     }
                 } */
                //
                
                //
                res[i] = tmp;
                inOEX.Add(tmp);
                
            }
            /*string ghto = "";
            for (int i = 0; i < res.Length; i++)
            {
                ghto = ghto + res[i] + "|";
            }
            MessageBox.Show(ghto); */
            return res;
        }
        double chansOmutation = 0.7;
        int[] mutator(int[] inn) {

            if (rnd.NextDouble()<chansOmutation)
            {
                int cf1 = rnd.Next(0, inn.Length), cf2 = rnd.Next(0, inn.Length);//, tmp = inn[Math.Min(cf1, cf2)] ;
                /*
                for (int i = Math.Min(cf1, cf2); i < Math.Max(cf1, cf2); i++)
                {
                    inn[i] = inn[i + 1];
                }
                inn[Math.Max(cf1, cf2)] = tmp; */
                int[] aA = new int[Math.Abs(cf1-cf2)];
                for (int i = Math.Min(cf1, cf2); i < Math.Max(cf1, cf2); i++)
                {
                    aA[i - Math.Min(cf1, cf2)] = inn[i];
                }
                Array.Reverse(aA);
                for (int i = Math.Min(cf1, cf2); i < Math.Max(cf1, cf2); i++)
                {
                    inn[i] = aA[i - Math.Min(cf1, cf2)];
                }
            }
            return inn;
        }

        void crossAndMutate(int[] ind) {
            int cro = 0;
            
            for (int jj = 0;  jj<ind.Length&& cro < countOfPopulations; jj++)
            {
                for (int i = 0;  i< ind.Length && cro < countOfPopulations; i++)
                {
                    //jj = rnd.Next(0, countOfPopulations);
                    //i = rnd.Next(0, countOfPopulations);
                    
                    /*if (jj==i)
                    {
                        if ((i + 1) == PointCount)
                        {
                            i++; break;
                        }
                        else
                        {
                            i++;
                        }
                        
                    } */
                    //MessageBox.Show(i.ToString() + " " + jj.ToString());
                    f35++;
                    int p1 = rnd.Next(0, PointCount), p2 = rnd.Next(0, PointCount);
                    int[] dch1 = new int[PointCount * 2], dch2 = new int[PointCount * 2];
                   // int c1 = 0, c2 = 0, c3 = 0;
                    for (int iii = 0; iii < PointCount; iii++)
                    {
                        //MessageBox.Show(iii.ToString());
                        dch1[iii <= p1 ? iii : iii + PointCount - p2 - 1] = populations[ind[jj]][iii];
                        dch1[iii <= p2 ? iii + p1 +1 : iii + PointCount] = populations[ind[i]][iii];
                       
                        
                        //dch1[iii <= p1 ? iii + p2 + 1 : iii + pC.Count] = populations[ind[jj]][iii];
                        dch2[iii <= p2 ? iii : iii + PointCount - p1 - 1] = populations[ind[i]][iii];
                        dch2[iii <= p1 ? iii + p2 + 1 : iii + PointCount] = populations[ind[jj]][iii];//
                    }
                    /*  while (c1 < p1) //криво добавляет(ток 1вую часть)
                      {
                          dch1[c1] = populations[ind[jj]][c1];
                          c1++;
                      }
                      while (c2 < p2)
                      {
                          dch2[c2] = populations[ind[i]][c2];
                          c2++;
                      }
                      c3 = c1;
                      while (c2 < pC.Count)
                      {
                          dch1[c3] = populations[ind[i]][c2];
                          c3++; c2++;
                      }
                      c3 = c2;
                      while (c1 < pC.Count)
                      {
                          dch2[c3] = populations[ind[jj]][c1];
                          c3++; c1++;
                      }*/
                    dch1 = trim(dch1); dch2 = trim(dch2);
                    dch1 = mutator(dch1); dch2 = mutator(dch2);
                    //MessageBox.Show((cro + " " + countOfPopulations).ToString());
                    if (cro < countOfPopulations)
                    {
                        if (getLngOfCurrPoinSet(dch1) < lngS[cro])
                        {
                            
                            populations[cro] = dch1;
                            lngS[cro] = getLngOfCurrPoinSet(dch1);
                            cro++;

                        }
                        else
                        {
                           // MessageBox.Show((getLngOfCurrPoinSet(dch1) +" "+ lngS[cro]).ToString());
                        }
                        
                    }
                    
                    if (cro < countOfPopulations)
                    {
                        if (getLngOfCurrPoinSet(dch2) < lngS[cro])
                        {
                            //MessageBox.Show((getLngOfCurrPoinSet(dch2) + " " + lngS[cro]).ToString());
                            populations[cro] = dch2;
                            lngS[cro] = getLngOfCurrPoinSet(dch2);
                            cro++;

                        }
                    }


                    //neWpopulations.Add(dch1); neWpopulations.Add(dch2);
                    // neWlngS.Add(getLngOfCurrPoinSet(dch1));
                    // neWlngS.Add(getLngOfCurrPoinSet(dch2));
                }
            }
            //populations.Clear(); populations = neWpopulations;
            //lngS.Clear(); lngS = neWlngS;
            
        }

        int[] trim(int[] inr) {
            List<int> lL = new List<int>();
            for (int i = 0; i < inr.Length; i++)
            {
                if (!lL.Contains(inr[i]))
                {
                    lL.Add(inr[i]);
                }
            }
            return lL.ToArray();
        }
        
        void otladka() {
            string s = "";
            for (int i = 0; i < populations[0].Length; i++)
            {
                s = s + populations[0][i] + " ";
            }
            MessageBox.Show(s);
            MessageBox.Show(lngS.Count.ToString());
        }

        void fGenIndOpoi() {
            lngS.Clear();

            for (int ii = 0; ii < countOfPopulations; ii++)
            {
                int[] res = new int[PointCount];
                for (int i = 0; i < res.Length; i++)
                {
                    res[i] = i;
                }
                for (int i = 0; i < res.Length * 2; i++)
                {
                    int i1 = rnd.Next(0, res.Length), i2 = rnd.Next(0, res.Length);
                    int k = res[i1];
                    res[i1] = res[i2];
                    res[i2] = k;
                }
                populations.Add(res);
                lngS.Add(getLngOfCurrPoinSet(res));
            }
            //
            //otladka();
        }

        int getLngOfCurrPoinSet(int[] indexes) {
            int lenGth = lngBtwPnt(pC[indexes[0]], pC[indexes[indexes.Length-1]]);
            for (int i = 0; i < indexes.Length-1; i++)
            {
                lenGth += lngBtwPnt(pC[indexes[i]], pC[indexes[i+1]]);
            }
            return lenGth;
        }



        int lngBtwPnt(Point p1, Point p2) {
            return (int)Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }
        bool bill = true;
        void maineAy() {
            int[] jkl = otbor();
            try
            {
                //otladka();
                
                crossAndMutate(jkl);
                check_checker(lngS[jkl[0]]);
                //MessageBox.Show(lngS[jkl[0]].ToString());

            }
            catch (Exception uil)
            {

                //
                // otladka();
                MessageBox.Show(uil.StackTrace);
               // MessageBox.Show("BACHOK");
            }
            

        }
        int f35 = 0;
        private int[] GetBestWay()
        {
          /*  Random rnd = new Random();
            int[] way = new int[PointCount];

            for (int i = 0; i < PointCount; i++)
                way[i] = i;

            for (int s = 0; s < 2 * PointCount; s++)
            {
                int i1, i2, tmp;

                i1 = rnd.Next(PointCount);
                i2 = rnd.Next(PointCount);
                tmp = way[i1];
                way[i1] = way[i2];
                way[i2] = tmp;
            } */

            return populations[otbor()[0]];
        }
    }
}