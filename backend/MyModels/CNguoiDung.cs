using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CNguoiDung
    {
        public int MaNd { get; set; }
        public string Tennd { get; set; } = null!;
        public string Matkhau { get; set; } = null!;
        public string? Sdt { get; set; }
        public string? Diachi { get; set; }
        public string? Phuongxa { get; set; }
        public string? Tinhthanh { get; set; }
        public string Email { get; set; } = null!;
        public string? Hinh { get; set; }
        public bool? Trangthai { get; set; }

    }
}
