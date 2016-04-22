using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Media;

namespace WSI
{
    public sealed class Database
    {
        private static volatile Database instance;
        private readonly SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\tkrzy\OneDrive\Documents\Visual Studio 2015\Projects\WSI\WSI\Database.mdf;Integrated Security=True");
        private static object syncRoot = new Object();
        public static int lastId;


        private Database()
        {

        }

        public SqlConnection getConnection()
        {
            return con;
        }

        public static DataTable selectQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(Database.Instance.getConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    con.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    con.Close();
                    return dt;

                }
            }

        }

        public static Boolean insertQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(Database.Instance.getConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    con.Open();

                    cmd.ExecuteNonQuery();


                    con.Close();

                    return true;
                }
            }

        }

        public static Boolean deleteQuery(string query)
        {
            using (SqlConnection con = new SqlConnection(Database.Instance.getConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = query;
                    con.Open();

                    cmd.ExecuteNonQuery();


                    con.Close();

                    return true;
                }
            }

        }

        public static Database Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Database();
                    }
                }

                return instance;
            }
        }

    }


}
