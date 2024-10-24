﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.config
{
    public  class ConnectDB
    {
        public static SqlDataAdapter adapter;
        public static SqlCommand cmd;
        public static string connectionString = @"Data Source=localhost;Initial Catalog=CUA_HANG_DO_CU;Persist Security Info=True;User ID=sa;Password=123456";


        public static SqlConnection getconnection()
        {
            return new SqlConnection(connectionString);
        }
        public DataTable getAllData(string query)
        {
           
            try
            {
                DataTable dataTable = new DataTable();
                using (SqlConnection con = ConnectDB.getconnection())
                {
                    con.Open();
                    adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(dataTable);
                    con.Close();
                }

                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }
                return dataTable;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


    }
}
