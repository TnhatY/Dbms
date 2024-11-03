using Do_an.dao;
using System;
using System.Collections.Generic;
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
    public partial class UC_SuaKhachHang : Window
    {
		public string maKH { get; set; }
		public UC_SuaKhachHang(string ID)
        {
            InitializeComponent();
			maKH = ID;
        }        

		private void btnSua_Click(object sender, RoutedEventArgs e)
		{
			KhachHang_DAO khachHang_DAO = new KhachHang_DAO();
			khachHang_DAO.SuaKhachHang(maKH, sdt.Text, ten.Text, diachi.Text);
		}
	}
}
