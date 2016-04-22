using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;

namespace WSI
{
    /// <summary>
    /// Interaction logic for management.xaml
    /// </summary>
    public partial class Management : Page
    {
        private OpenFileDialog openFile;

        public Management()
        {
            InitializeComponent();



            DictionariesList.ItemsSource = Dictionaries.getDictionariesList("comboBox");
        }

        private void loadDictionaryBtn_Click(object sender, RoutedEventArgs e)
        {
            openFile = new OpenFileDialog();
            DialogResult dialogResult = openFile.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                this.openFileTextBox.Text = openFile.FileName;
            }
        }

        private void saveDictionaryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (openFile != null)
            {

                System.IO.StreamReader file = new System.IO.StreamReader(openFile.FileName);

                if (file != null)
                {
                    string line;
                    int count = 0;

                    int dictionaryId = Dictionaries.insertDictionary(dictionaryName.Text);

                    if (dictionaryId != 0)
                    {
                        string query = "INSERT INTO Words (dictionaries_id, word) VALUES ";
                        while ((line = file.ReadLine()) != null)
                        {
                            int n;
                            if(int.TryParse(line, out n)) continue;
  

                            if (count > 0) query += ", ";

                            query += "(" + dictionaryId + ", '" + line + "')";

                            count++;

                            if (count > 900)
                            {
                                Database.insertQuery(query);
                                query = "INSERT INTO Words (dictionaries_id, word) VALUES ";
                                count = 0;
                            }
                        }
                        System.Windows.MessageBox.Show(query);
                        Database.insertQuery(query);


                        file.Close();
                    }
                }
            }
        }

        private void dictionaryName_GotFocus(object sender, RoutedEventArgs e)
        {
            ((System.Windows.Controls.TextBox) sender).Text = "";
        }

        private void deleteDictionaryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DictionariesList.SelectedItem != null)
            {
                int dictionaryId = (int) ((ComboBoxItem) DictionariesList.SelectedItem).Tag;

                Database.deleteQuery("DELETE FROM Words WHERE dictionaries_id = " + dictionaryId);

                Database.deleteQuery("DELETE FROM Dictionaries WHERE id ='" + dictionaryId + "'");

                DictionariesList.ItemsSource = Dictionaries.getDictionariesList("comboBox");

            }
        }
    }
}
