using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Windows;

namespace WSI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    public partial class MainWindow : Window
    {
        private bool isAdmin = false;

        public bool Admin
        {
            get
            {
                return isAdmin;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void administratorBtn_Click(object sender, RoutedEventArgs e)
        {

            passwordBox.Visibility = Visibility.Visible;

        }

        private void passwordCancel_Click(object sender, RoutedEventArgs e)
        {
            password.Password = "";
            passwordBox.Visibility = Visibility.Hidden;
        }

        private void passwordOk_Click(object sender, RoutedEventArgs e)
        {

            using (SqlConnection con = new SqlConnection(Database.Instance.getConnection().ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {

                        cmd.Connection = con;
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "SELECT password FROM Settings"; 
                        con.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        DataRow row = dt.Rows[0];


                    if (HashAuth.Verify(password.Password, row.Field<string>(0)))
                    {
                        isAdmin = true;
                        dictionariesManag.Visibility = Visibility.Visible;
                        password.Password = "";
                        passwordBox.Visibility = Visibility.Hidden;
                    }
                    else
                    {
                        MessageBox.Show("Błędne hasło.");
                    }

                    

                }
            }
        

            
        }
    }
}
