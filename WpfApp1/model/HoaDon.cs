﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_an.model
{
    class HoaDon
    {
		public HoaDon(string mahd, string ngayxuathd, float trigiahd, string makh, string manv)
		{
			MaHD = mahd;
			NgayXuatHD = ngayxuathd;
			TriGiaHD = trigiahd;
			MaKH = makh;
			MaNV = manv;
		}

		public string MaHD { get; set; }
		public string NgayXuatHD { get; set; }
		public float TriGiaHD { get; set; }
		public string MaKH { get; set; }
		public string MaNV { get; set; }

        public class Revenue
        {
            public string TenLoaiSP { get; set; }
            public double DoanhThu { get; set; }

			public string Ten
			{
				get { return TenLoaiSP; }
			}
            public double RevenueAmount
            {
                get { return DoanhThu; }  // Trả về DoanhThu (hoặc có thể tính toán khác nếu cần)
            }
        }
    }
}
