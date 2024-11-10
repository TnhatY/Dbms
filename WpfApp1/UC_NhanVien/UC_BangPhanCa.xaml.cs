
using Do_an.dao;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static MaterialDesignThemes.Wpf.Theme;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_BangPhanCa.xaml
    /// </summary>
    public partial class UC_BangPhanCa : UserControl
    {
        public UC_BangPhanCa()
        {
            InitializeComponent();
        }

        public void load_datagrid(object sender, EventArgs e)
        {
            CaLam_Dao caLam_Dao = new CaLam_Dao();
            this.datagrid.ItemsSource = caLam_Dao.get_thoikhoabieu().DefaultView;
        }

        private void btn_phancatudong_Click(object sender, RoutedEventArgs e)
        {
            F_Main.instance.user.Content = new UC_ConfigAutoPhanca();
        }
    }
}
