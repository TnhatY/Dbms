using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Do_an
{
    /// <summary>
    /// Interaction logic for UC_Thongke.xaml
    /// </summary>
    public partial class UC_Thongke : UserControl
    {
        public UC_Thongke()
        {
            InitializeComponent();
           
        }
     
        private void CartesianChart_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadChartData();
        }
        private void LoadChartData()
        {
           
        }
    }
}
