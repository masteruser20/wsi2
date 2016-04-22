using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WSI
{
    /// <summary>
    /// Interaction logic for dictionaries.xaml
    /// </summary>

    public partial class Dictionaries : Page
    {
        private int dictionaryId = 0;

        public Dictionaries()
        {
            InitializeComponent();

            dictionariesList.ItemsSource = Dictionaries.getDictionariesList("list");
            wordsList.ItemsSource = getWordsList();


        }


        public static dynamic getDictionariesList(string type)
        {

            DataTable result = Database.selectQuery("SELECT id, name FROM Dictionaries");
            DataRowCollection rows = result.Rows;

            dynamic dictionaries = new List();

            if (type == "list")
            {

                dictionaries = new List<ListBoxItem>();



                if (rows.Count > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        dictionaries.Add(new ListBoxItem() {Tag = row[0], Content = row[1]});
                    }

                }

            } else if (type == "comboBox")
            {
                
                dictionaries = new List<ComboBoxItem>();

                if (rows.Count > 0)
                {
                    foreach (DataRow row in rows)
                    {
                        dictionaries.Add(new ComboBoxItem() { Tag = row[0], Content = row[1] });
                    }

                }
            }

            return dictionaries;
        }

        private List<string> getWordsList()
        {

            DataTable result = Database.selectQuery("SELECT word FROM Words WHERE dictionaries_id = " + dictionaryId + " ORDER BY word ASC");
            DataRowCollection rows = result.Rows;

            List<string> dictionaries = new List<string>();

            if (rows.Count > 0)
            {

                foreach (DataRow row in rows)
                {
                    dictionaries.Add(row[0].ToString());
                }

            }


            return dictionaries;
        }

        private void LoadDictionaryBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (dictionariesList.SelectedItem != null)
            {
                ListBoxItem lBox = (ListBoxItem) dictionariesList.SelectedItem;
                dictionaryId = (int) (lBox.Tag);


                wordsList.ItemsSource = getWordsList();


                MessageBox.Show("Wybrany słownik to: " + lBox.Content);
            }
        }

        public static int insertDictionary(string name)
        {
            if (Database.insertQuery("INSERT INTO Dictionaries (name) VALUES ('" + name + "')"))
            {

                DataTable dt = Database.selectQuery("SELECT id FROM Dictionaries ORDER BY ID DESC");

                return (int)dt.Rows[0].Field<int>("id");
            }

            return 0;
        }

        private void refreshDictionaries_Click(object sender, RoutedEventArgs e)
        {
            dictionariesList.ItemsSource = Dictionaries.getDictionariesList("list");
            wordsList.ItemsSource = getWordsList();

        }

        private void addWord_Click(object sender, RoutedEventArgs e)
        {
            if (newWord.Text.Length > 0 && dictionaryId > 0)
            {
                Database.insertQuery("INSERT INTO Words (dictionaries_id, word) VALUES (" + dictionaryId + ", '" + newWord.Text + "')");
                wordsList.ItemsSource = getWordsList();
            }
        }

        private void deleteWord_Click(object sender, RoutedEventArgs e)
        {
            if (dictionaryId > 0 && wordsList.SelectedItem != null && MainWindow.isAdmin)
            {
                Database.deleteQuery("DELETE FROM Words WHERE word = '" + wordsList.SelectedItem + "'");
                wordsList.ItemsSource = getWordsList();

            }
        }
    }


}
