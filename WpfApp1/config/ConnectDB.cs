using System;
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
        public static string connectionString = @"Data Source=DESKTOP-LAN03PN;Initial Catalog=CUA_HANG_DO_CU;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";


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
            catch 
            {
                return null;
            }
        }

        public void openConnection()
        {
            //if (con == null)
            //{
            //    con = new SqlConnection(connectionString);
            //}

            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
        }

        public void closeConnection()
        {
            //if (con != null && con.State == ConnectionState.Open)
            //{
            //    con.Close();
            //}
        }
    }
}
