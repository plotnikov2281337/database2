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
    public partial class DeleteAlbom : Form
    {
        database database = new database();
        public DeleteAlbom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            database.openConnection();
            try
            {
                var command = new SqlCommand($"delete from Alboms where Название = '{textBox1.Text}'", database.getConnection());
                command.ExecuteNonQuery();
                MessageBox.Show("Запись удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Hide();
            } catch
            {
                MessageBox.Show("Неудалось удалить запись", "Провал", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
