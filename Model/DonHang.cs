 class DonHang
    {
        private static int _idDonHang = 1;
        public int MaDonHang { get; private set; }
        public int MaSanPham { get; set; }
        public int SoLuongBan { get; set; }
        public string TenNguoiDat { get; set; }
        public bool TrangThaiGiaoHang { get; set; }

        public DonHang()
        {
            MaDonHang = _idDonHang++;
        }

        public override string ToString()
        {
            return $"Mã ĐH: {MaDonHang}, Mã SP: {MaSanPham}, Số lượng: {SoLuongBan}, Người đặt: {TenNguoiDat}, Trạng thái: {(TrangThaiGiaoHang ? "Đã giao" : "Đã hủy")}";
        }
    }