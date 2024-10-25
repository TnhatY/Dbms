using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.model
{
    public class SanPham
    {
        public string DanhMucSP { get; set; }
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string NhaCC { get; set; }
        public float GiaGoc { get; set; }
        public float GiaBan { get; set; }
        public string NgayMua { get; set; }
        public string TinhTrang { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }

        public SanPham(string masp, string tensp,float giagoc, float giaban, string hinhanh) {
            MaSP =masp;
            TenSP = tensp;
            GiaBan = giaban;
            HinhAnh = hinhanh;
            GiaGoc = giagoc;
        }
        public SanPham(string masp, string tensp, float giagoc, float giaban, string hinhanh,string ncc,string tinhtrang,string danhmuc)
        {
            MaSP = masp;
            TenSP = tensp;
            GiaBan = giaban;
            HinhAnh = hinhanh;
            GiaGoc = giagoc;
            NhaCC = ncc;
            TinhTrang = tinhtrang;
            DanhMucSP = danhmuc;
        }
        public SanPham() { }

    }
}
