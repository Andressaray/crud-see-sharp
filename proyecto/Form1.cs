using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace proyecto
{
    public partial class Form1 : Form
    {
        String email = "";
        String password = "";
        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=prueba; Uid=root; Pwd=;");
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Login(String email, String password, Boolean method)
        {
            try
            {
                String datos = "";
                connection.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd =  new MySqlCommand("SELECT id FROM users WHERE email = '"+email+"' AND password = '"+password+"';",connection);
                reader = cmd.ExecuteReader();
                if (method)
                {
                    while (reader.Read())
                    {
                        datos += reader.GetString(0) + "\n";
                    }
                    if (datos.Length == 0)
                    {
                        MessageBox.Show("Algunos datos no coinciden, vuelve a intentarlo");
                    }
                    else
                    {
                        MessageBox.Show(datos);
                        this.Hide();
                    }
                }
                else
                {
                    Application.OpenForms["Form2"].Close();
                }
                Form3 home = new Form3();
                home.Show();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            email = textBox1.Text;
            password = textBox2.Text;
            Login(email, password, true);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 login = new Form2();
            this.Hide();
            login.Show();
        }
    }
}
