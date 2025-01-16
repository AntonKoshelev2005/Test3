using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WW.Forms.Admin
{
    public partial class BD : Form
    {
        public BD()
        {
            InitializeComponent();
            LoadTableNames();
        }

        private void BD_Load(object sender, EventArgs e)
        {
           
        }
        private void LoadTableNames()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(Connect.conStr))
                {
                    con.Open();
                    using (var cmd = new MySqlCommand("SHOW TABLES;", con))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboBD.Items.Add(reader[0].ToString());
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Не удалось подключиться к базе данных. Ошибка {ex.Message}", "ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключиться к базе данных. Ошибка {ex.Message}", "ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonImport_Click(object sender, EventArgs e)
        {
            if (comboBD.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите таблицу из списка.");
                return;
            }

            string selectedTable = comboBD.SelectedItem.ToString();

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    ImportCsvToDatabase(filePath, selectedTable);
                }
            }
        }
        private void ImportCsvToDatabase(string filePath, string tableName)
        {
            int importedRecordsCount = 0;

            try
            {
                using (MySqlConnection con = new MySqlConnection(Connect.conStr))
                {
                    con.Open();

                    using (StreamReader reader = new StreamReader(filePath, Encoding.GetEncoding(1251)))
                    {
                        string line;
                        // Skip header
                        reader.ReadLine();

                        // Get column count from table
                        int columnCount = GetColumnCount(con, tableName);

                        while ((line = reader.ReadLine()) != null)
                        {
                            string[] values = line.Split(';');

                            // Check for parameter count mismatch
                            if (values.Length != columnCount)
                            {
                                MessageBox.Show($"Parameter count mismatch: expected {columnCount}, but got {values.Length}.");
                                return;
                            }

                            // Create SQL insert command
                            var insertCommand = new MySqlCommand($"INSERT INTO {tableName} VALUES ({string.Join(",", values.Select(v => $"'{v}'"))});", con);
                            insertCommand.ExecuteNonQuery();
                            importedRecordsCount++;
                        }
                    }
                }

                MessageBox.Show($"Successfully imported {importedRecordsCount} records.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing data: {ex.Message}");
            }
        }
        private int GetColumnCount(MySqlConnection con, string tableName)
        {
            var getColumnCountCommand = new MySqlCommand($"DESCRIBE {tableName}", con);
            int columnCount = 0;
            using (var reader = getColumnCountCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    columnCount++;
                }
            }
            return columnCount;
        }

        private void comboBD_TextChanged(object sender, EventArgs e)
        {
            buttonImport.Enabled = comboBD.Text != null;
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        string conString = $@"host=127.0.0.1;uid=root;pwd=root;";
        private void buttonBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                string backupPath = "Backup\\structure.sql";
                string databaseName = "home001";
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();
                    MySqlCommand cmdDrop = new MySqlCommand($"DROP DATABASE IF EXISTS `{databaseName}`;", con);
                    cmdDrop.ExecuteNonQuery();

                    MySqlCommand cmdCreate = new MySqlCommand($"CREATE DATABASE `{databaseName}`;", con);
                    cmdCreate.ExecuteNonQuery();

                    MySqlCommand cmdUse = new MySqlCommand($"USE `{databaseName}`;", con);
                    cmdUse.ExecuteNonQuery();
                    string script = File.ReadAllText(backupPath);
                    MySqlScript sqlScript = new MySqlScript(con, script);
                    sqlScript.Execute();

                    con.Close();
                }
                MessageBox.Show("Востановление прошло успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonBackUpFull_Click(object sender, EventArgs e)
        {
            try
            {
                string backupPath = "Backup\\home004.sql";
                string databaseName = "home001";
                using (MySqlConnection con = new MySqlConnection(conString))
                {
                    con.Open();

                    MySqlCommand cmdUse = new MySqlCommand($"USE `{databaseName}`;", con);
                    cmdUse.ExecuteNonQuery();
                    string script = File.ReadAllText(backupPath);
                    MySqlScript sqlScript = new MySqlScript(con, script);
                    sqlScript.Execute();

                    con.Close();
                }
                MessageBox.Show("Востановление прошло успешно");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
