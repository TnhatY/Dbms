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



        Dictionary<String, List<String>> day_shop = new Dictionary<String, List<String>>();

        Dictionary<String, Dictionary<String, List<String>>> day_staff = new Dictionary<string, Dictionary<string, List<string>>>() ;

        Dictionary<String, String> staff = new Dictionary<string, string>();
        List<String> week = new List<String>() { "Thứ 2", "Thứ 3", "Thứ 4", "Thứ 5", "Thứ 6", "Thứ 7", "Chủ nhật" };
        List<String> shift = new List<string>() { "ca 1", "ca 2", "ca 3", "cả ngày" };



        private void load_ccb1()
        {
            foreach (String item in week)
            {
                day_shop.Add(item, shift);
            }
            
            staff = nv.get_staff();
            foreach (KeyValuePair<String, String> keyValuePair in staff)
            {
                ccb_manv.Items.Add(keyValuePair.Key);
            }
            for(int i = 1; i <=5; i++)
            {
                ccb_cachca.Items.Add(i);
            }

        }
        private void loadccb2()
        {
            ccb_thushop.Items.Clear();
            ccb_noworkweek_staff.Items.Clear();
            foreach (KeyValuePair<String, List<String>> item in day_shop)
            {
                ccb_thushop.Items.Add(item.Key);
                ccb_noworkweek_staff.Items.Add(item.Key);
            }

        }
       
        private void select_manv(object sender, SelectionChangedEventArgs e)
        {
            String manv = ccb_manv.SelectedValue.ToString();
            if(manv != null)
            {
                lbl_hotennhanvien.Content = staff[manv];
            }
        }


        private void select_thu_staff(object sender, SelectionChangedEventArgs e)
        {
            if (ccb_noworkweek_staff.SelectedItem != null)
            {
                String thu = ccb_noworkweek_staff.SelectedItem.ToString();
                ccb_noworkshift_staff.Items.Clear();
                foreach (String str in day_shop[thu])
                {
                    ccb_noworkshift_staff.Items.Add(str);
                }
            }
            else
            {
                return;
            }
        }

        private void select_thu_shop(object sender, SelectionChangedEventArgs e)
        {
            if (ccb_thushop.SelectedItem != null)
            {
                String thu = ccb_thushop.SelectedItem.ToString();
                ccb_cashop.Items.Clear();
                foreach (String str in day_shop[thu])
                {
                    ccb_cashop.Items.Add(str);
                }
            }
            else
            {
                return;
            }
        }
        private void load_config(object sender, EventArgs e)
        {
            load_ccb1();
            loadccb2();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            F_Main.instance.user.Content = new UC_BangPhanCa();
        }

        private void btn_update_offday_Click(object sender, RoutedEventArgs e)
        {
            String thu = ccb_thushop.SelectedItem.ToString();
            String ca  = ccb_cashop.SelectedItem.ToString();    
            if (ca == "cả ngày")
            {
                MessageBox.Show("ok");
                day_shop.Remove(thu);
                ccb_cashop.Items.Clear();
            }
            else
            {
                day_shop[thu].Remove(ca);
                if (day_shop[thu].Count == 0)
                {
                    day_shop.Remove(thu);
                }
                ccb_cashop.Items.Clear();
            }
            loadccb2(); 
        }

        private void btn_excute_Click(object sender, RoutedEventArgs e)
        {

            MessageBox.Show("Thành công");
            F_Main.instance.user.Content = new UC_BangPhanCa();
        }

        private void btn_update_offshift_staff_Click(object sender, RoutedEventArgs e)
        {
             if(ccb_manv.SelectedItem != null)
            {
                String manv = ccb_manv.SelectedItem.ToString();
                String thu = ccb_noworkweek_staff.SelectedItem.ToString();  
                String ca = ccb_noworkshift_staff.SelectedItem.ToString();  
                if (day_staff.ContainsKey(manv))
                {
                    Dictionary<String, List<String>> keyValuePairs = day_staff[manv];
                    if (keyValuePairs.ContainsKey(thu))
                    {
                        List<String> lis = keyValuePairs[thu];
                        if (lis.Contains(ca))
                        {
                            MessageBox.Show("nhân viên đã chọn không làm ca này");
                        }
                        else
                        {
                            lis.Add(ca);
                            MessageBox.Show("Thêm thành công");
                        }
                        keyValuePairs[thu] = lis;    
                    }
                    else
                    {
                        List<String> list = new List<String>();
                        list.Add(ca);
                        keyValuePairs.Add(thu, list);
                    }
                    day_staff[manv] = keyValuePairs;
                }
                else
                {
                    List<String> list = new List<String>();
                    list.Add(ca);
                    Dictionary<String, List<String>> keyValuePairs = new Dictionary<String, List<String>>();
                    keyValuePairs.Add(thu, list);
                    day_staff.Add(manv, keyValuePairs);
                }
            }   
            else
            {
                MessageBox.Show("Chọn nhân viên !");
            }
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Lưu thành công !");
        }
    }
}
