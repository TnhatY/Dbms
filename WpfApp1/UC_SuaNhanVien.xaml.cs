using Do_an.config;
using Do_an.dao;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for SuaNhanVien.xaml
    /// </summary>
    public partial class UC_SuaNhanVien : Window
    {
        public string maNV { get; set; }
        SqlConnection connection = ConnectDB.getconnection();
        public UC_SuaNhanVien(string ID)
        {
            InitializeComponent();
            maNV = ID;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadEmployeeData();
            LoadComboBox();
        }

        private void LoadEmployeeData()
        {
            connection.Open();
            {
                try
                {
                    string query = "SELECT HoNV, TenNV, DiaChi, SoDT, GioiTinh, NgaySinh, MaCV FROM NhanVien WHERE MaNV = @MaNV";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", maNV);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            txtHoNV.Text = reader["HoNV"].ToString();
                            txtTenNV.Text = reader["TenNV"].ToString();
                            txtDiaChi.Text = reader["DiaChi"].ToString();
                            txtsdt.Text = reader["SoDT"].ToString();
                            txtgt.Text = reader["GioiTinh"].ToString();
                            dpNgaySinh.SelectedDate = Convert.ToDateTime(reader["NgaySinh"]);
                            cbmaCV.SelectedValue = reader["MaCV"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy nhân viên với mã: " + maNV);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void LoadComboBox()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT MaCV, TenCV FROM CongViec", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                cbmaCV.ItemsSource = dataTable.DefaultView;
                cbmaCV.DisplayMemberPath = "TenCV";
                cbmaCV.SelectedValuePath = "MaCV";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        private void bt_SuaNV_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_DAO nhanVien_DAO = new NhanVien_DAO();
            nhanVien_DAO.SuaNhanVien(maNV, txtHoNV.Text, txtTenNV.Text, txtDiaChi.Text, txtsdt.Text, txtgt.Text, dpNgaySinh.DisplayDate, cbmaCV.SelectedValue.ToString());
        }
    }
}
