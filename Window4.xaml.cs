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
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }
        bool operStop = true;
        int irrr = 0;
        public void operate() {
            if (!operStop)
            {
                return;
            }
            operStop = false;
            numsh++;
            gameUpd();
            compsDo();
            
            
            
            operStop = true;
        }
        public int[,] gameStat = { { -1, -1, -1 }, { -1, -1, -1 }, { -1, -1, -1 } };
        public void gameUpd()
        {
            //Активується після натискання кнопки на клавіатурі
            //
            //Оновлює дані у масиві із комбо-боксів
            
            gameStat[0, 0] = GC1.SelectedIndex;
            gameStat[0, 1] = GC2.SelectedIndex;
            gameStat[0, 2] = GC3.SelectedIndex;
            gameStat[1, 0] = GC4.SelectedIndex;
            gameStat[1, 1] = GC5.SelectedIndex;
            gameStat[1, 2] = GC6.SelectedIndex;
            gameStat[2, 0] = GC7.SelectedIndex;
            gameStat[2, 1] = GC8.SelectedIndex;
            gameStat[2, 2] = GC9.SelectedIndex;


        }
        bool GHOD = true;
        public int gameWinCheck() {
            while (!GHOD)
            {

            }
            GHOD = false;
            if (gameStat[0, 0] != -1 && gameStat[0, 1] != -1 && gameStat[0,2] != -1)
            {
                if (gameStat[0, 0] == gameStat[0, 1] && gameStat[0, 1] == gameStat[0, 2])
                {
                    GameEnd(gameStat[0, 0]);
                    GHOD = true;
                    return gameStat[0, 0];
                }
            }
            if (gameStat[1, 0] != -1 && gameStat[1, 1] != -1 && gameStat[1, 2] != -1)
            {
                if (gameStat[1, 0] == gameStat[1, 1] && gameStat[1, 1] == gameStat[1, 2])
                {
                    GameEnd(gameStat[1, 0]);
                    GHOD = true;
                    return gameStat[1, 0];
                }
            }
            if (gameStat[2, 0] != -1 && gameStat[2, 1] != -1 && gameStat[2, 2] != -1)
            {
                if (gameStat[2, 0] == gameStat[2, 1] && gameStat[2, 1] == gameStat[2, 2])
                {
                    GameEnd(gameStat[2, 0]);
                    GHOD = true;
                    return gameStat[2, 0];
                }
            }


            //

            if (gameStat[0, 0] != -1&& gameStat[1, 0] != -1 && gameStat[2, 0] != -1)
            {
                if (gameStat[0, 0] == gameStat[1, 0] && gameStat[1, 0] == gameStat[2, 0])
                {
                    GameEnd(gameStat[2, 0]);
                    GHOD = true;
                    return gameStat[2, 0];
                }
            }

            if (gameStat[0, 1] != -1 && gameStat[1, 1] != -1 && gameStat[2, 1] != -1)
            {
                if (gameStat[0, 1] == gameStat[1, 1] && gameStat[1, 1] == gameStat[2, 1])
                {
                    GameEnd(gameStat[2, 1]);
                    GHOD = true;
                    return gameStat[2, 1];
                }
            }

            if (gameStat[0, 2] != -1 && gameStat[1, 2] != -1 && gameStat[2, 2] != -1)
            {
                if (gameStat[0, 2] == gameStat[1, 2] && gameStat[1, 2] == gameStat[2, 2])
                {
                    GameEnd(gameStat[2, 2]);
                    GHOD = true;
                    return gameStat[2, 2];
                }
            }

            //

            if (gameStat[0, 0] != -1 && gameStat[1, 1] != -1 && gameStat[2, 2] != -1)
            {
                if (gameStat[0, 0] == gameStat[1, 1] && gameStat[1, 1] == gameStat[2, 2])
                {
                    GameEnd(gameStat[0, 0]);
                    GHOD = true;
                    return gameStat[0, 0];
                }
            }

            if (gameStat[2, 0] != -1 && gameStat[1, 1] != -1 && gameStat[0, 2] != -1)
            {
                if (gameStat[2, 0] == gameStat[1, 1] && gameStat[1, 1] == gameStat[0, 2])
                {
                    GameEnd(gameStat[2, 0]);
                    GHOD = true;
                    return gameStat[2, 0];
                }
            }
            GHOD = true;
            return int.MaxValue;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            Hide();
            mw.Show();
        }
        bool chW = true;
        public bool chkWpsp(int hg) {
            //if (!chW) return;
            chW = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gameStat[i, j] == -1) {
                        //hg = 1 if strike and = 0 if defence
                        gameStat[i, j] = hg; // Looking what is going to happend if we place X here
                        FDB.Visibility = Visibility.Hidden;
                        if (gameWinCheck() == hg)
                        {
                            GameMakeHod(i, j);
                            //
                            FDB.Visibility = Visibility.Visible;
                            return true;
                        }
                        else
                        {
                            //Setting -1 back
                            gameStat[i, j] = -1;
                            FDB.Content = "";
                            FDB.Visibility = Visibility.Visible;
                            
                        }


                    }
                }
            }
            chW = true;
            return false;
        }

        public void GameMakeHod(int i, int j){
            if (i == 0)
            {
                if (j == 0)
                {
                    GC1.SelectedItem = GC1.Items[1]; gameStat[i, j] = 1; return;
                }
                if (j == 1)
                {
                    GC2.SelectedItem = GC2.Items[1]; gameStat[i, j] = 1; return;
                }
                if (j == 2)
                {
                    GC3.SelectedItem = GC3.Items[1]; gameStat[i, j] = 1; return;
                }
            }
            if (i == 1)
            {
                if (j == 0)
                {
                    GC4.SelectedItem = GC4.Items[1]; gameStat[i, j] = 1; return;
                }
                if (j == 1)
                {
                    GC5.SelectedItem = GC5.Items[1]; gameStat[i, j] = 1; return;
                }
                if (j == 2)
                {
                    GC6.SelectedItem = GC6.Items[1]; gameStat[i, j] = 1; return;
                }
            }
            if (i == 2)
            {
                if (j == 0)
                {
                    GC7.SelectedItem = GC7.Items[1]; gameStat[i, j] = 1; return;
                }
                if (j == 1)
                {
                    GC8.SelectedItem = GC8.Items[1]; gameStat[i, j] = 1; return;
                }
                if (j == 2)
                {
                    GC9.SelectedItem = GC9.Items[1]; gameStat[i, j] = 1; return;
                }
            }
        }
        //
        int numsh = 0;
        public void compsDo()
        {
            bool b = chkWpsp(1);
            //ProveryaemNaPobedu
            if(!b)chkWpsp(0);
            //Proveryaem na vozmozhnoe porazheniye
            numsh++;
            if (numsh == 9) numsh = 0;
            
        }
        Random r = new Random();
        int at1 = 0, at2 = 0;
        void Attack1() {
            if (gameStat[at1,at2]==-1)
            {
                
                if (r.Next(1,100)<=49)//Можно было рандомить и сразу в GameMakeHod
                {
                    if (r.Next(1, 100) <= 49)
                    {
                        at1 = 0; at2 = 0;
                        GameMakeHod(0, 0);
                    }
                    else
                    {
                        at1 = 0; at2 = 2;
                        GameMakeHod(0, 2);
                    }
                }
                else
                {
                    if (r.Next(1, 100) <= 49)
                    {
                        at1 = 2; at2 = 0;
                        GameMakeHod(2, 0);
                    }
                    else
                    {
                        at1 = 2; at2 = 2;
                        GameMakeHod(2, 2);
                    }
                }
            }
            else 
            {
                if (gameStat[2 - at1, 2 - at2]==-1)
                {
                    GameMakeHod(2 - at1, 2 - at2);
                }
                else
                {
                    GameMakeHod(1, 1);
                }
               
            }
        }

        void Attack2() {
            operStop = false;
            if (gameStat[1,1]==-1)
            {
            GameMakeHod(1, 1);
            } else
            //case1
            if (gameStat[0,1]==0)
            {
                GameMakeHod(2, 0);
            }
            else if (gameStat[1, 2] == 0)
            {
                GameMakeHod(0, 0);
            }
            else if (gameStat[1, 0] == 0)
            {
                GameMakeHod(2, 2);
            }
            else if (gameStat[2, 1] == 0)
            {
                GameMakeHod(0, 2);
            }
            else if (gameStat[0,0]==0)
            {
                GameMakeHod(2,2);
            }
            else if (gameStat[0, 2] == 0)
            {
                GameMakeHod(2, 0);
            }
            else if (gameStat[2, 0] == 0)
            {
                GameMakeHod(0, 2);
            }
            else if (gameStat[2, 2] == 0)
            {
                GameMakeHod(0, 0);
            }
            else
            {
                operStop = true;
            }
            //
        }

        public void GameEnd(int i) {
           // FDB.Content = i==0? "You win!!":"You lost..";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            numsh = 0;
        }

        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
        bool mainSwitch = true;

        
        private void GC1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC3_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC4_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC5_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC6_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC7_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC8_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void GC9_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            operate();
            mainSwitch = !mainSwitch;
        }

        private void Informer_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Attack2();
        }
    }
}
