﻿using Do_an.config;
using Do_an.dao;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_KhachHang.xaml
    /// </summary>
    public partial class UC_NhanVien : System.Windows.Controls.UserControl
    {
        public UC_NhanVien()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public DataTable XemDanhMucNhanVien()
        {
            SqlCommand cmd = new SqlCommand("SELECT * FROM ThongTinNhanVien", ConnectDB.getconnection());
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            return dataTable;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dg_NhanVien.ItemsSource = XemDanhMucNhanVien().DefaultView;
        }

        private void btnTimkiem_Click(object sender, RoutedEventArgs e)
        {
            if(txttimkiem.Text.Length == 0) {
                System.Windows.MessageBox.Show("Chưa nhập thông tin tìm kiếm");
            }
            else
            {
                NhanVien_DAO nhanVien_DAO = new NhanVien_DAO();
                dg_NhanVien.ItemsSource = nhanVien_DAO.timKiemNhanVien(txttimkiem.Text).DefaultView;
            }
        }
        private void Dg_NhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_NhanVien.SelectedItem != null)
            {
                var firstColumn = dg_NhanVien.SelectedCells[0];
                var firstColumnValue = ((TextBlock)firstColumn.Column.GetCellContent(firstColumn.Item)).Text;
                maNV.Text = firstColumnValue;
            }
        }

        private void btnThemNhanVien_Click(object sender, RoutedEventArgs e)
        {
            UC_ThemNhanVien UC_themNhanVien = new UC_ThemNhanVien();
            UC_themNhanVien.ShowDialog();
            this.UserControl_Loaded(sender,e);  
        }
        string ID;
        private void btnSuaNhanVien_Click(object sender, RoutedEventArgs e)
        {
            UC_SuaNhanVien UC_suaNhanVien = new UC_SuaNhanVien(ID);
            UC_suaNhanVien.ShowDialog();
            this.UserControl_Loaded(sender, e);
        }

        private void dg_NhanVien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dg_NhanVien.SelectedItem != null)
            {
                var nhanVien = dg_NhanVien.SelectedItem;
                DataRowView rowView = (DataRowView)dg_NhanVien.SelectedItem;
                string maNV = rowView["MaNV"].ToString();
                ID = maNV;
            }
        }

        private void btnXoaNhanVien_Click(object sender, RoutedEventArgs e)
        {
            NhanVien_DAO nhanVien_DAO = new NhanVien_DAO();
            nhanVien_DAO.XoaNhanVien(ID);
        }

        private void btn_calamviec_Click(object sender, RoutedEventArgs e)
        {
            if (dg_NhanVien.SelectedItem != null)
            {
                UC_DanhSachCaLam uc_listCalam = new UC_DanhSachCaLam(ID);
                F_Main.instance.user.Content = uc_listCalam;
            }

        }

        private void btn_bangphanca_Click(object sender, RoutedEventArgs e)
        {
            F_Main.instance.user.Content = new UC_BangPhanCa();
        }
    }
}