using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using MySql;
using MySql.Data.MySqlClient;

namespace proyecto
{
    public partial class Form3 : Form
    {
        private readonly DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
        public string users { get; set; }
        MySqlConnection connection = new MySqlConnection("Server=localhost; Database=prueba; Uid=root; Pwd=;");
        
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void getUsers()
        {
            connection.Open();
            MySqlDataReader reader = null;
            MySqlCommand cmd = new MySqlCommand("SELECT id, name, lastname, phone, email  FROM users", connection);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                btn.Name = "Delete";
                btn.Text = "Delete";
                btn.FlatStyle = FlatStyle.Flat;
                btn.DefaultCellStyle.BackColor = Color.Red;
                dataGridView1.Columns.Add("id", "id");
                dataGridView1.Columns.Add("name", "name");
                dataGridView1.Columns.Add("lastname", "lastname");
                dataGridView1.Columns.Add("email", "email");
                dataGridView1.Columns.Add("phone", "phone");
 
                dataGridView1.Columns.Insert(5, btn);
                int i = 0;
                while (reader.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = reader["id"];
                    dataGridView1.Rows[i].Cells[1].Value = reader["name"];
                    dataGridView1.Rows[i].Cells[2].Value = reader["lastname"];
                    dataGridView1.Rows[i].Cells[3].Value = reader["email"];
                    dataGridView1.Rows[i].Cells[4].Value = reader["phone"];
                    dataGridView1.Rows[i].Cells[5].Value = "x" + reader["id"];
                    i++;
                }
                reader.Close();
            }
            connection.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            getUsers();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string message = "¿Deseas eliminar a ese usuario?";
                    string title = "Eliminar usuario";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    DialogResult result = MessageBox.Show(message, title, buttons);
                    if (result == DialogResult.Yes)
                    {
                        connection.Open();
                        String id = dataGridView1.SelectedRows[0].Cells["Delete"].Value.ToString();
                        id = id.Substring(1);
                        MySqlDataReader reader = null;
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM users WHERE id = '" + id + "';", connection);
                        reader = cmd.ExecuteReader();
                        MessageBox.Show("Eliminado con exito");
                        dataGridView1.Rows.Clear();
                        connection.Close();
                        getUsers();
                    }
                    else
                    {
                        MessageBox.Show("No has eliminado nada, tranquilo bro");
                    }
                }
                else
                {
                    MessageBox.Show("No has seleccionado a un usuario para eliminar");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
                MessageBox.Show("No se pudo eliminar");
            }
            
        }
    }
}
