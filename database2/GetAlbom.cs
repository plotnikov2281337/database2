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
    public partial class GetAlbom : Form
    {
        database database = new database();
        public GetAlbom()
        {
            InitializeComponent();
        }

        private void readSingleRowsForAlboms(DataGridView dgv, IDataRecord records)
        {
            dgv.Rows.Add(records.GetInt32(0), records.GetString(1), records.GetDateTime(2), records.GetString(3), records.GetString(4), records.GetString(5), rowState.GetList);
        }

        private void createColumnsForAlboms()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("id", "id");
            dataGridView1.Columns.Add("name", "name");
            dataGridView1.Columns.Add("date_of_create", "date_of_create");
            dataGridView1.Columns.Add("musics", "musics");
            dataGridView1.Columns.Add("group", "group");
            dataGridView1.Columns.Add("link", "link");
        }
        private void refreshDataGridForAlboms(DataGridView dgv)
        {
            dgv.Rows.Clear();
            string query = $"select * from Alboms where Название = '{textBox1.Text}'";
            SqlCommand sqlCommand = new SqlCommand(query, database.getConnection());
            database.openConnection();
            SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                readSingleRowsForAlboms(dgv, reader);
            }
            reader.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            createColumnsForAlboms();
            refreshDataGridForAlboms(dataGridView1);
        }
    }
}
