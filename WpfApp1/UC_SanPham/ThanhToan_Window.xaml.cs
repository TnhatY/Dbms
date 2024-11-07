using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;
using System.Data.Entity;
using Do_an.config;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for ThanhToan_Window.xaml
    /// </summary>
    public partial class ThanhToan_Window : Window
    {
        public ThanhToan_Window()
        {
            InitializeComponent();
        }
     
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
          
            float giaBan = 0;
            spmua.ItemsSource = null;
            ConnectDB database = new ConnectDB();
            try
            {
                List<UC_SP_ThanhToan> list = new List<UC_SP_ThanhToan>();
                DataTable dt = new DataTable();
                string sql1 = $"select * from SanPham Where MaSP='{masp.Text}'";
                dt = database.getAllData(sql1);
                foreach (DataRow dr in dt.Rows)
                {
                    UC_SP_ThanhToan uC_SP_ThanhToan = new UC_SP_ThanhToan();
                    uC_SP_ThanhToan.tensp.Text = dr["TenSP"].ToString();
                    uC_SP_ThanhToan.giaban.Text = dr["GiaBan"].ToString();
                    giaBan += float.Parse(dr["GiaBan"].ToString());
                    uC_SP_ThanhToan.tinhtrang.Text = dr["TinhTrang"].ToString();
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(dr["HinhAnh"].ToString(), UriKind.RelativeOrAbsolute);
                    bitmap.EndInit();
                    uC_SP_ThanhToan.hinhanhsp.Source = bitmap;
                    list.Add(uC_SP_ThanhToan);
                    uC_SP_ThanhToan.ButtonClicked += themVoucher_Click;
                }
                spmua.ItemsSource= list;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            float tongThanToan = giaBan;
            
            giaban1.Text = tongthanhtoan.Text = tongthanhtoan1.Text = tongThanToan.ToString();
        }
       
        private void themVoucher_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void btnMua_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanh toán thành công");
            TaoHoaDon taoHoaDon = new TaoHoaDon();
            taoHoaDon.masp.Text = masp.Text;
            taoHoaDon.txtTrigiahd.Text = tongthanhtoan.Text;
            taoHoaDon.Show();
            this.Hide();
        }
        
        private void thoat_Click(object sender, RoutedEventArgs e)
        {
          
            Close();
        }
    }
}
