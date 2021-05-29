using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace proyecto
{
    public partial class Form2 : Form
    {
        String name = "";
        String lastname = "";
        String email = "";
        String password = "";
        String phone = "";
        String id = "";
        Form1 vLogin = new Form1();
        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=prueba; Uid=root; Pwd=;");
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String datos = "";
                id = textBox6.Text;
                name = textBox3.Text;
                lastname = textBox4.Text;
                phone = textBox5.Text;
                email = textBox1.Text;
                password = textBox2.Text;
                connection.Open();
                MySqlDataReader reader = null;
                MySqlCommand cmd = new MySqlCommand("INSERT INTO users (id, name, lastname, phone, email, password)" +
                " VALUES ('" + id + "','" + name + "','" + lastname + "','" + phone + "','" + email + "','" + password + "');", connection);
                reader = cmd.ExecuteReader();
                MessageBox.Show("Te has registrado con exito");
                vLogin.Login(email, password, false);
                connection.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            vLogin.Show();
        }
    }
}
