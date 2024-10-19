using Do_an;
using Do_an.dao;
using Do_an.model;
using System.Collections.Generic;
using System.Data;

using System.Windows;
using System.Windows.Controls;
using static MaterialDesignThemes.Wpf.Theme;
using static MaterialDesignThemes.Wpf.Theme.ToolBar;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_MuaSam.xaml
    /// </summary>
    public partial class UC_MuaSam : UserControl
    {
        
      

        public UC_MuaSam()
        {
            InitializeComponent();
            DataContext = this;
        }

       
        private void DanhMuc_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            SanPham_DAO sanPham_DAO = new SanPham_DAO();
            if(F_Main.texttimkiem == null)
            {
                    List<SanPham> sp = sanPham_DAO.listSP();
                controlsanpham.ItemsSource = sp;
            }
            else
            {
                List<SanPham> sp = sanPham_DAO.timkiemSP(F_Main.texttimkiem);
                controlsanpham.ItemsSource = sp;
            }
            
        }
    }
}
