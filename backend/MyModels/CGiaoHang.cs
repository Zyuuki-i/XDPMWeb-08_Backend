using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CGiaoHang
    {
        public int MaGh { get; set; }
        public int MaDdh { get; set; }
        public string MaNv { get; set; } = null!;
        public DateTime? Ngaybd { get; set; }
        public DateTime? Ngaykt { get; set; }
        public decimal? Tongthu { get; set; }
        public string? Trangthai { get; set; }

    }
}
