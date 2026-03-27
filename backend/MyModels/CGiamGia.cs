using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CGiamGia
    {

        public string MaGg { get; set; } = null!;
        public string Tenma { get; set; } = null!;
        public string? Loaima { get; set; }
        public decimal? Dieukien { get; set; }
        public int? Phantramgiam { get; set; }
        public DateTime? Ngaybd { get; set; }
        public DateTime? Ngaykt { get; set; }
        public int? Tongsl { get; set; }

    }
}
