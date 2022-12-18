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
    public partial class Form2 : Form
    {
        database database = new database();
        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();

            var name = textBox1.Text;
            var type = textBox7.Text;
            var country = textBox6.Text;
            DateTime year_create;
            var alboms = textBox2.Text;
            var members = textBox8.Text;

                DateTime.TryParse($"{textBox9.Text}.{textBox3.Text}.{textBox5.Text}", out year_create);
            Console.WriteLine($"{ year_create.Day}.{ year_create.Month}.{ year_create.Year}");
                if (name != null && type != null) {
                    var query = $"INSERT INTO Music_Group (Название, Вид, Страна, [Год создания], Альбомы, Состав) VALUES ('{name}', '{type}', '{country}', '{year_create.Day}.{year_create.Month}.{year_create.Year}', '{alboms}', '{members}')";

                    var command = new SqlCommand(query, database.getConnection());
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Hide();
                }
            
            database.closeConnection();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
