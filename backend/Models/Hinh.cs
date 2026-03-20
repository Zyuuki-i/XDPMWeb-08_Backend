using System;
using System.Collections.Generic;

namespace backend.Models
{
    public partial class Hinh
    {
        public int MaHinh { get; set; }
        public string MaSp { get; set; } = null!;
        public string? Tenhinh { get; set; }

        public virtual SanPham MaSpNavigation { get; set; } = null!;
    }
}
