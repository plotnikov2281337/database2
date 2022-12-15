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
    public partial class Form5 : Form
    {
        database database = new database();
        private void createColumnsForMembers()
        {



            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "name");
            dataGridView1.Columns.Add("date_of_birth", "date_of_birth");
            dataGridView1.Columns.Add("place_of_birth", "place_of_birth");
            dataGridView1.Columns.Add("role", "role");
        }

        private void readSingleRowsForMembers(DataGridView dgv, IDataRecord records)
        {
            dgv.Rows.Add(records.GetInt32(0), records.GetString(1), records.GetDateTime(2), records.GetString(3), records.GetString(4), rowState.GetList);
        }

        private void refreshDataGridForMembers(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = $"select * from Members where ФИО = '{textBox1.Text}'";
            SqlCommand sqlCommand = new SqlCommand(query, database.getConnection());
            database.openConnection();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                readSingleRowsForMembers(dgv, reader);
            }
            reader.Close();
        }
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createColumnsForMembers();
            refreshDataGridForMembers(dataGridView1);
        }
    }
}
