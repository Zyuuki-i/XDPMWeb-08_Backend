namespace backend.MyModels
{
    public class MDonDatHang
    {
        public int MaDdh { get; set; }
        public int MaNd { get; set; }
        public string? MaNv { get; set; }
        public string? Nguoinhan { get; set; }
        public string? Sdt { get; set; }
        public string Diachi { get; set; } = null!;
        public string? Phuongxa { get; set; }
        public string? Tinhthanh { get; set; }
        public DateTime? Ngaydat { get; set; }
        public decimal? Tongtien { get; set; }
        public string Trangthai { get; set; } = null!;
        public string? TtThanhtoan { get; set; }
        public string? Phuongthuc { get; set; }

        public List<CChiTietDonDatHang>? chiTietDonDatHangs { get; set; }
    }
}
