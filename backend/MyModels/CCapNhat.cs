using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CCapNhat
    {
        public int MaCn { get; set; }
        public string MaNv { get; set; } = null!;
        public string MaSp { get; set; } = null!;
        public DateTime? Ngaycapnhat { get; set; }
    }
}
