using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Navigation;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace Lab3Project
{
    public static class SequelOperator
    {
        public static string memory = "";

        public static void Sv() {
            try
            {
                StreamWriter sw1 = new StreamWriter("usrInfo.txt");
                StreamWriter sw2 = new StreamWriter("restrictions.txt");
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "SELECT " + "*" + " FROM wdnnah";
                    SqlDataAdapter data = new SqlDataAdapter(theCommand, cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ghto = "";
                        for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                        {
                            ghto += dt.Rows[i].ItemArray[j].ToString() + " ";
                        }
                       // MessageBox.Show(ghto);
                        sw2.WriteLine(ghto);
                    }
                    sw2.Close();
                    dt.Clear();
                    theCommand = "SELECT " + "*" + " FROM persinf";
                    data = new SqlDataAdapter(theCommand,cn);
                    dt = new DataTable("Respond");
                    data.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string ghto = "";
                        for (int j = 0; j < dt.Rows[i].ItemArray.Length; j++)
                        {
                            ghto += dt.Rows[i].ItemArray[j].ToString() + " ";
                        }
                        sw1.WriteLine(ghto);
                    }
                    sw1.Close(); 
                }
                
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
               // throw;
            }
        }

        public static void emergencyAdd()
        {
            
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "insert into persinf(Logine,Pass,PersFname,PersSname, adminity, allowed) Values('new', '', 'new', 'new', 0, 1)";
                    (new SqlCommand(theCommand, cn)).ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }
        }

        public static object[] getRestrictions()
        {
            object[] obAr = new object[5];

            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "SELECT " + "*" + " FROM wdnnah";
                    SqlDataAdapter data = new SqlDataAdapter(theCommand, cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                    
                    int i = 0;
                    obAr[0] = int.Parse(dt.Rows[0].ItemArray[0].ToString());
                    obAr[1] = int.Parse(dt.Rows[0].ItemArray[1].ToString());
                    obAr[2] = bool.Parse(dt.Rows[0].ItemArray[2].ToString().ToLower());
                    obAr[3] = bool.Parse(dt.Rows[0].ItemArray[3].ToString().ToLower());
                    obAr[4] = bool.Parse(dt.Rows[0].ItemArray[4].ToString().ToLower());
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }

            return obAr;
        }

        public static bool passUpd(string log, string OldPass, string newPass)
        {
            bool isAn = false;
            memory = log;
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "SELECT " + "Logine, Pass" + " FROM persinf";
                    SqlDataAdapter data = new SqlDataAdapter(theCommand, cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i].ItemArray[0].ToString().Equals(log))
                        {
                            if (dt.Rows[i].ItemArray[1].ToString().Equals(OldPass))
                            {
                                isAn = true;
                                string theCommand2 = "UPDATE " + "persinf" + " SET " + "Pass" + " = '" + newPass + "' WHERE Logine = '" + log+"'";
                                //MessageBox.Show(theCommand);
                                (new SqlCommand(theCommand2, cn)).ExecuteNonQuery();
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }



                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }

            return isAn;
        }

        public static bool chk4permit(string log)
        {
            bool isAn = false;

            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "SELECT " + "Logine, allowed" + " FROM persinf";
                    SqlDataAdapter data = new SqlDataAdapter(theCommand, cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i].ItemArray[0].ToString().Equals(log))
                        {
                            // MessageBox.Show(dt.Rows[i].ItemArray[1].ToString());
                            if (dt.Rows[i].ItemArray[1].ToString().Equals("1") || dt.Rows[i].ItemArray[1].ToString().Equals("True"))
                            {
                                isAn = true;
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }



                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }

            return isAn;
        }

        public static bool chk4admin(string log)
        {
            bool isAn = false;

            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "SELECT " + "Logine, adminity" + " FROM persinf";
                    SqlDataAdapter data = new SqlDataAdapter(theCommand, cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i].ItemArray[0].ToString().Equals(log))
                        {
                           // MessageBox.Show(dt.Rows[i].ItemArray[1].ToString());
                            if (dt.Rows[i].ItemArray[1].ToString().Equals("1")|| dt.Rows[i].ItemArray[1].ToString().Equals("True"))
                            {
                                isAn = true;
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }



                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }

            return isAn;
        }



        public static bool auth(string log, string pass)
        {
            bool isAn = false;
            memory = log;
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "SELECT " + "Logine, Pass" + " FROM persinf";
                    SqlDataAdapter data = new SqlDataAdapter(theCommand, cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i].ItemArray[0].ToString().Equals(log))
                        {
                            if (dt.Rows[i].ItemArray[1].ToString().Equals(pass))
                            {
                                isAn = true;
                                break;
                            }
                        }
                        else
                        {
                            continue;
                        }
                    }
                    


                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }

            return isAn;
        }

        public static void updatede(string idnt,string what, string val, string InTableName, string addit) {
            idnt = "'"+idnt+"'";
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "UPDATE " + InTableName + " SET " + what + " =" + val + " WHERE "+addit+" = " + idnt;
                    //MessageBox.Show(theCommand);
                    (new SqlCommand(theCommand, cn)).ExecuteNonQuery();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }
        }

        public static void FillTheListBox(ref ComboBox lisb, string InTableName,string InRowName) {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                    string theCommand = "SELECT "+ InRowName+" FROM "+ InTableName;
                    SqlDataAdapter data = new SqlDataAdapter(theCommand, cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ComboBoxItem lbi = new ComboBoxItem();
                        lbi.Content = dt.Rows[i].ItemArray[0].ToString();
                        lisb.Items.Add(lbi);
                    }
                    

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }
        }

        public static void O5(ref DataGrid dataGrid, string theCommand) {
            try
            {
                if (cn.State == ConnectionState.Open)
                {
                   // (new SqlCommand(theCommand, cn)).ExecuteNonQuery();
                    SqlDataAdapter data = new SqlDataAdapter(theCommand,cn);
                    DataTable dt = new DataTable("Respond");
                    data.Fill(dt);
                   // dt.Rows[]
                    dataGrid.ItemsSource = dt.DefaultView;
                    
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }

        }

        public static void Update() { 
        
        }

        public static void Open(string ConnectionString) {
            try
            {
                cn = new SqlConnection();
                cn.ConnectionString = ConnectionString;
                cn.Open();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.StackTrace);
                MessageBox.Show(exc.Message);
            }
        }

        public static void Close() {
            //Sv();
            cn.Close();
        }

        public static SqlConnection cn;
    }
}
