using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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
        public static bool isAdmin = false;


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
            DataTable result = Database.selectQuery("SELECT password FROM Settings");
            DataRow row = result.Rows[0];


            if (HashAuth.Verify(password.Password, row.Field<string>(0)))
            {
                isAdmin = true;
                dictionariesManag.Visibility = Visibility.Visible;
                password.Password = "";
                passwordBox.Visibility = Visibility.Hidden;
                administratorBtn.Visibility = Visibility.Hidden;
            }
            else
            {
                MessageBox.Show("Błędne hasło.");
            }

        }

        private void startHacking_Click(object sender, RoutedEventArgs e)
        {

            DataTable result = Database.selectQuery("SELECT word FROM Words WHERE dictionaries_id = 47 ORDER BY word ASC");
            DataRowCollection rows = result.Rows;

            List<string> dictionaries = new List<string>();


            if (rows.Count > 0)
            {

                foreach (DataRow row in rows)
                {
                    dictionaries.Add(row[0].ToString());
                }

            }

            int i=0, czas=1;
            string hackingWord = hackingWordTextBox.Password;
            string nieodgadniete = "Próba złamania hasła zakończyła się niepowodzeniem";


            Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            while (hackingWord!=dictionaries[i]){



                if (i < (dictionaries.Count - 1))
                    i++;
                else
                    break;

            }

            string elapsedTime = stopwatch.Elapsed.ToString();




            for (int ii = 0; dictionaries[ii] != hackingWord; ii++)
            {
                if (ii < dictionaries.Count - 1) continue;
                else break;

            }



            if (hackingWord == dictionaries[i])
                MessageBox.Show("Hasło zostało złamane \n Wynik: " + dictionaries[i] + "\n Przeszuke słowa: " + i + "\n Czas łamania: " + elapsedTime + "s");
            else
                MessageBox.Show(nieodgadniete);
        }
    }
}
