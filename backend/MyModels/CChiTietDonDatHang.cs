using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CChiTietDonDatHang
    {
        public int MaDdh { get; set; }
        public string MaSp { get; set; } = null!;
        public int Soluong { get; set; }
        public decimal Gia { get; set; }
        public decimal? Thanhtien { get; set; }

    }
}
