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
    public partial class Form4 : Form
    {
        database database = new database();
        public Form4()
        {
            InitializeComponent();
        }

        private void createColumnsForGroups()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "name");
            dataGridView1.Columns.Add("type", "type");
            dataGridView1.Columns.Add("country", "country");
            dataGridView1.Columns.Add("year_create", "year create");
            dataGridView1.Columns.Add("musics", "musics");
            dataGridView1.Columns.Add("alboms", "alboms");
            dataGridView1.Columns.Add("members", "members");
        }

        private void readSingleRows(DataGridView dgv, IDataRecord records)
        {
            dgv.Rows.Add(records.GetInt32(0), records.GetString(1), records.GetString(2), records.GetString(3), records.GetDateTime(4), records.GetString(5), records.GetString(6), records.GetString(7), rowState.GetList);
        }
        private void refreshDataGrid(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = $"select * from Music_Group where Название = '{textBox1.Text}'";
            SqlCommand sqlCommand = new SqlCommand(query, database.getConnection());
            database.openConnection();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                readSingleRows(dgv, reader);
            }
            reader.Close();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            createColumnsForGroups();
            refreshDataGrid(dataGridView1);
        }
    }
}
