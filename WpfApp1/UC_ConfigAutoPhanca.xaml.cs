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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_ConfigAutoPhanca.xaml
    /// </summary>
    public partial class UC_ConfigAutoPhanca : UserControl
    {
        public UC_ConfigAutoPhanca()
        {
            InitializeComponent();
            
        }
        private NhanVien_DAO nv = new NhanVien_DAO();


        Dictionary<String, List<String>> off_day_shop = new Dictionary<String, List<String>>();
        


        Dictionary<String, String> staff = new Dictionary<string, string>();
        List<String> week = new List<String>() { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ nhật" };
        List<String> shift = new List<string>() { "ca 1", "ca 2", "ca 3", "cả ngày" };
        private void load_ccb()
        {

        }
       
        private void select_manv(object sender, SelectionChangedEventArgs e)
        {
            String manv = ccb_manv.SelectedValue.ToString();
            if(manv != null)
            {
                lbl_hotennhanvien.Content = staff[manv];
            }
        }
       
        private void load_config(object sender, EventArgs e)
        {
            load_ccb();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            F_Main.instance.user.Content = new UC_BangPhanCa();
        }

        private void btn_update_offday_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btn_excute_Click(object sender, RoutedEventArgs e)
        {
            
            F_Main.instance.user.Content = new UC_BangPhanCa();
        }
    }
}
