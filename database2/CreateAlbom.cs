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
    public partial class CreateAlbom : Form
    {
        database database = new database();
        public CreateAlbom()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
            var name = textBox1.Text;
            DateTime date;
            var musics = textBox2.Text;
            var group = textBox6.Text;
            var link = textBox7.Text;
            DateTime.TryParse($"{textBox4.Text}.{textBox5.Text}.{textBox3.Text}", out date);
            try
            {
                var query = $"INSERT INTO Alboms (Название, [Дата создания], [Музыкальные произведения], Группа, Ссылка) VALUES ('{name}', '{date.Day}.{date.Month}.{date.Year}', '{musics}', '{group}', '{link}')";

                var command = new SqlCommand(query, database.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись создана", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            } catch {
                MessageBox.Show("Запись не создана", "Провал", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            database.closeConnection();
        }
    }
}
