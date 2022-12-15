﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database2
{
	internal class database
	{
		SqlConnection sqlConnection = new SqlConnection(@"Data Source=HOME-PC\MSSQL;Initial Catalog=music_group;Integrated Security=True");

		public void openConnection()
		{
			if (sqlConnection.State == System.Data.ConnectionState.Closed)
			{
				sqlConnection.Open();
			}
		}

		public void closeConnection()
		{
			if (sqlConnection.State == System.Data.ConnectionState.Open)
			{
				sqlConnection.Close();
			}
		}

		public SqlConnection getConnection()
		{
			return sqlConnection;
		}
	}
}