using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace database2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            database.openConnection();
            var name = textBox1.Text;
            DateTime date;
            var placeOfBird = textBox3.Text;
            var role = textBox4.Text;
            DateTime.TryParse($"{textBox5.Text}.{textBox6.Text}.{textBox2.Text}", out date);
            try
            {
                var query = $"INSERT INTO Members (ФИО, [Дата рождения], [Место рождения], [Роль в группе]) VALUES ('{name}', '{date.Day}.{date.Month}.{date.Year}', '{placeOfBird}', '{role}')";

                var command = new SqlCommand(query, database.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            } catch {
                MessageBox.Show("Запись не создана", "Провал", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            database.closeConnection();
        }

        database database = new database();
       
    }
}
