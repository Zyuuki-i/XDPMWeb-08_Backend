using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CDanhGia
    {
        public int MaNd { get; set; }
        public string MaSp { get; set; } = null!;
        public string? Noidung { get; set; }
        public int? Sosao { get; set; }

    }
}
