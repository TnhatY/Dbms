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
    /// Interaction logic for UC_DanhSachCaLam.xaml
    /// </summary>
    public partial class UC_DanhSachCaLam : UserControl
    {
        public String manv = "";
        public UC_DanhSachCaLam(String ID)
        {
            InitializeComponent();
            this.manv = ID; 

        }
        
        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void load(Object sender, RoutedEventArgs e)
        { 
            
        }

        private void Button_add(object sender, RoutedEventArgs e)
        {
            ThemCaLam_Window add = new ThemCaLam_Window();  
            add.ShowDialog();
        }

        private void Button_remove(object sender, RoutedEventArgs e)
        {
               
        }
    }
}
