using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CLoaiSanPham
    {
        public string MaLoai { get; set; } = null!;
        public string Tenloai { get; set; } = null!;
        public string? Mota { get; set; }
    }
}
