using Do_an.config;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Do_an.dao
{
    public class NhanVien_DAO
    {
        public DataTable XemThongTinNhanVien()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM NhanVien", ConnectDB.getconnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }




        public DataTable tinhLuongNV(int nam, int thang)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = new SqlCommand("proc_TinhLuongNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Thang", thang);
                        cmd.Parameters.AddWithValue("@Nam", nam);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                return null;
            }

        }
        public DataTable timKiemNhanVien(string keyword)
        {
            using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("proc_TimKiemNhanVien", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MaNV", keyword);
                        cmd.Parameters.AddWithValue("@TenNV", keyword);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }

                }catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return null;
                }
            }
        }

        public Dictionary<String, String> get_staff()
        {
            Dictionary<String, String> rs = new Dictionary<String, String>();
            String sql = "select MaNV, HoNV, TenNV from NhanVien";
            using (SqlConnection conn = new SqlConnection(ConnectDB.connectionString))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        foreach(DataRow row in dataTable.Rows)
                        {
                            String manv = row["MaNV"].ToString();
                            String ten = row["HoNV"].ToString() + " "+ row["TenNv"].ToString();
                            rs.Add(manv, ten);  
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return rs;
                }
            }

            
            return rs;  
        }

      

        public bool ThemNhanVien(string id, string ho, string ten, string diaChi, string sdt, string gt, DateTime ngaySinh, string maCV)
        {
            SqlConnection connection = ConnectDB.getconnection();
            
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC proc_ThemNhanVien @manv, @honv, @tennv, @diachi," +
                    " @sodt, @gioitinh, @ngaysinh, @macv", connection);

                cmd.Parameters.AddWithValue("@manv", id);
                cmd.Parameters.AddWithValue("@honv", ho);
                cmd.Parameters.AddWithValue("@tennv", ten);
                cmd.Parameters.AddWithValue("@diachi", diaChi);
                cmd.Parameters.AddWithValue("@sodt", sdt);
                cmd.Parameters.AddWithValue("@gioitinh", gt);
                cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = ngaySinh;
                cmd.Parameters.AddWithValue("@macv", maCV);
                connection.Open();
               
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Thêm nhân viên thành công!");
                    connection.Close();
                return true;

            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                connection.Close();
                return false;
            }
        }

        public void XoaNhanVien(string ID)
        {
            SqlConnection connection = ConnectDB.getconnection();
            try
            {
                DialogResult result = (DialogResult)MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?",
                    "Remove Employee", (MessageBoxButton)MessageBoxButtons.YesNo, (MessageBoxImage)MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SqlCommand cmd = new SqlCommand("EXEC proc_XoaNhanVien @manv", connection);
                    cmd.Parameters.AddWithValue("@manv", ID);
                    connection.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Remove Employee", (MessageBoxButton)MessageBoxButtons.OK,
                            (MessageBoxImage)MessageBoxIcon.Information);
                        connection.Close();
                        XemThongTinNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại!", "Remove Employee", (MessageBoxButton)MessageBoxButtons.OK,
                            (MessageBoxImage)MessageBoxIcon.Error);

                        connection.Close();
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên thất bại! \n" + ex.Message, "Remove Employee", (MessageBoxButton)MessageBoxButtons.OK,
                   (MessageBoxImage)MessageBoxIcon.Error);
                }
               
            }
        }

        public bool SuaNhanVien(string id, string ho, string ten, string diaChi, string sdt, string gt, DateTime ngaySinh, string maCV)
        {
            SqlConnection connection = ConnectDB.getconnection();
           
            try
            {
                SqlCommand cmd = new SqlCommand("EXEC proc_SuaNhanVien @manv, @honv, @tennv, @diachi, @sodt, @gioitinh, @ngaysinh, @macv", connection);

                cmd.Parameters.AddWithValue("@manv", id);
                cmd.Parameters.AddWithValue("@honv", ho);
                cmd.Parameters.AddWithValue("@tennv", ten);
                cmd.Parameters.AddWithValue("@diachi", diaChi);
                cmd.Parameters.AddWithValue("@sodt", sdt);
                cmd.Parameters.AddWithValue("@gioitinh", gt);
                cmd.Parameters.Add("@ngaysinh", SqlDbType.Date).Value = ngaySinh;
                cmd.Parameters.AddWithValue("@macv", maCV);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Sửa thông tin thành công");
                return true;
               
                    
                
            }
            catch(SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                connection.Close();
                return false;
            }
        }

        public void them_CaLamViec(String manv, String maclv, DateTime ngaylam, String giobatdau, String giokethuc)
        {
            String sqlStr = $"exec them_CaLamViec {manv},  {maclv}, {ngaylam}, {giobatdau}, {giokethuc}";
            try
            {
                SqlConnection conn = ConnectDB.getconnection();
                conn.Open();
                SqlCommand command = new SqlCommand(sqlStr, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
        public void xoa_CalamViec(String manv, String maclv)
        {
            String sqlStr = $"exec xoa_calamviec {manv},  {maclv}";
            try
            {
                SqlConnection conn = ConnectDB.getconnection();
                conn.Open();
                SqlCommand command = new SqlCommand(sqlStr, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 229)
                {
                    MessageBox.Show("Bạn không có quyền truy cập");
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
            }
        }
        
    }
}

