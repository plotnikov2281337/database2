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

    enum rowState {
    GetList,
    GetMembers,
    }
    public partial class Form1 : Form
    {

        database database = new database();
        int selectRow;

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void createColumnsForGroups ()
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

        private void createColumnsForMembers()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "name");
            dataGridView1.Columns.Add("date_of_birth", "date_of_birth");
            dataGridView1.Columns.Add("place_of_birth", "place_of_birth");
            dataGridView1.Columns.Add("role", "role");
        }

        private void readSingleRows(DataGridView dgv, IDataRecord records)
        {
            dgv.Rows.Add(records.GetInt32(0), records.GetString(1), records.GetString(2), records.GetString(3), records.GetDateTime(4), records.GetString(5), records.GetString(6), records.GetString(7), rowState.GetList);
        }

        private void readSingleRowsForMembers(DataGridView dgv, IDataRecord records)
        {
            dgv.Rows.Add(records.GetInt32(0), records.GetString(1), records.GetDateTime(2), records.GetString(3), records.GetString(4), rowState.GetList);
        }

        private void refreshDataGrid (DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = $"select * from Music_Group";
            SqlCommand sqlCommand = new SqlCommand(query, database.getConnection());
            database.openConnection();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                readSingleRows(dgv, reader);
            }
            reader.Close();
        }

        private void refreshDataGridForMembers(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = $"select * from Members";
            SqlCommand sqlCommand = new SqlCommand(query, database.getConnection());
            database.openConnection();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                readSingleRowsForMembers(dgv, reader);
            }
            reader.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void getGroupsList (object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form4 form = new Form4();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createColumnsForGroups();
            refreshDataGrid(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            createColumnsForMembers();
            refreshDataGridForMembers(dataGridView1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 form = new Form5();
            form.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 form = new Form6();
            form.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            form.Show();
        }
    }
}
