using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Forms;
using ComboBox = System.Windows.Controls.ComboBox;
using MessageBox = System.Windows.MessageBox;

namespace Do_an.dao
{
    public class NhanVien_DAO
    {
        ConnectDB db = new ConnectDB();

        public DataTable XemThongTinNhanVien()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ThongTinNhanVien", ConnectDB.getconnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        public bool ThemNhanVien(string id, string ho, string ten, string diaChi, string sdt, string gt, DateTime ngaySinh, string maCV)
        {
            SqlConnection connection = ConnectDB.getconnection();
            connection.Open();
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC ThemNhanVien @manv, @honv, @tennv, @diachi," +
                    " @sodt, @gioitinh, @ngaysinh, @macv", connection);

                cmd.Parameters.AddWithValue("@manv", id);
                cmd.Parameters.AddWithValue("@honv", ho);
                cmd.Parameters.AddWithValue("@tennv", ten);
                cmd.Parameters.AddWithValue("@diachi", diaChi);
                cmd.Parameters.AddWithValue("@sodt", sdt);
                cmd.Parameters.AddWithValue("@gioitinh", gt);
                cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = ngaySinh;
                cmd.Parameters.AddWithValue("@macv", maCV);
                db.openConnection();
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    return true;
                    
                }
                return list;
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
           
        }

    }
}
