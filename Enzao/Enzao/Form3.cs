using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace Enzao
{
    public partial class Form3 : Form
    {
        string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=teste;";
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM admin WHERE usuario = '" + textBox1.Text + "' and senha = '" + textBox2.Text + "' ";





            MySqlConnection databaseConnection = new MySqlConnection(connectionString);



            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);



            commandDatabase.CommandTimeout = 60;



            MySqlDataReader reader;







            try



            {



                // Open the database 



                databaseConnection.Open();



                reader = commandDatabase.ExecuteReader();







                if (reader.HasRows)



                {

                    Form4 visivel = new Form4();

                    visivel.ShowDialog();

                    Application.ExitThread();





                }



                else



                {

                    MessageBox.Show("Usuario ou Senha incorretos", "Falha no login", MessageBoxButtons.OK);



                }



                // Finally close the connection 



                databaseConnection.Close();



            }



            catch (Exception ex)



            {



                // Show any error message. 



                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);



            }
        }
    }
}
