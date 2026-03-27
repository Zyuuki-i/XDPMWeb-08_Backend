using System;
using System.Collections.Generic;

namespace backend.MyModels
{
    public partial class CNhaSanXuat
    {

        public string MaNsx { get; set; } = null!;
        public string Tennsx { get; set; } = null!;
        public string? Diachi { get; set; }
        public string? Sdt { get; set; }
        public string? Email { get; set; }

    }
}
