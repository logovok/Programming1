using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Lab05OP
{
    internal class OperV
    {
        static SqlConnection cl = new SqlConnection();

        static public void GetQuery(string query)
        {
            cl.Open();
            SqlCommand cmd = new SqlCommand(query, cl);
            try
            {

                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                System.Windows.MessageBox.Show(e.Message);
            }
            cl.Close();
        }
        static public void SetConnection(string connectionString)
        {
            cl.ConnectionString = connectionString;
        }
        static public DataTable GetData(string query)
        {
            cl.Open();
            SqlCommand cmd = new SqlCommand(query, cl);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cl.Close();
            return dt;
        }
        static public int GetCount2(string table)
        {
            string query = "SELECT COUNT(1) FROM " + table;
            cl.Open();
            SqlCommand cmd = new SqlCommand(query, cl);
            int count = (int)cmd.ExecuteScalar();
            cl.Close();
            return count;
        }
        static public int GetCount2(string table, string where)
        {
            string query = "SELECT COUNT(1) FROM " + table + " " + where;
            cl.Open();
            SqlCommand cmd = new SqlCommand(query, cl);
            int count = (int)cmd.ExecuteScalar();
            cl.Close();
            return count;
        }
        static public DataGrid GetDataGrid(string query, ref DataGrid dg)
        {
            DataTable dt = GetData(query);
            dg.ItemsSource = dt.DefaultView;
            return dg;
        }

        static public Grid GetGrid(DataGrid dg)
        {
            Grid g = new Grid();
            g.Children.Add(dg);
            return g;
        }

        static public ComboBox GetComboBox(string query, ref ComboBox cb)
        {
            DataTable dt = GetData(query);
            foreach (DataRow row in dt.Rows)
            {
                if (!cb.Items.Contains(row[0]))
                {
                    cb.Items.Add(row[0]);
                }
            }
            return cb;
        }

        static public List<string> GetList(string query)
        {
            List<string> list = new List<string>();
            DataTable dt = GetData(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(row[0].ToString());
            }
            return list;
        }

        static public int GetCount(string query1, string query2)
        {
            int count = 0;
            DataTable dt = GetData(query1);
            count += dt.Rows.Count;
            dt = GetData(query2);
            count += dt.Rows.Count;
            return count;
        }
        static public int GetDays(string table1, string table2, string column1, string column2, string and)
        {
            string query = "SELECT DATEDIFF(day, " + table1 + "."+column1+", " + table1 + "."+column2+") FROM " + table1 + ", " + table2+" "+ and;
            cl.Open();
            SqlCommand cmd = new SqlCommand(query, cl);
            int count = (int)cmd.ExecuteScalar();
            cl.Close();
            return count;
        }
    }
}
