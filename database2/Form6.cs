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
    public partial class Form6 : Form
    {
        database database = new database();
        public Form6()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            database.openConnection();
            var command = new SqlCommand($"delete from Music_Group where Название = '{textBox1.Text}'", database.getConnection());
            command.ExecuteNonQuery();
            MessageBox.Show("Запись удалена", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
