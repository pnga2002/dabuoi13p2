 class SanPham
    {
        private static int _idSanPham = 1;
        public int MaSanPham { get; private set; }
        public string TenSanPham { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTonKho { get; set; }

        public SanPham()
        {
            MaSanPham = _idSanPham++;
        }

        public override string ToString()
        {
            return $"Mã SP: {MaSanPham}, Tên: {TenSanPham}, Giá: {GiaBan}, Số lượng tồn kho: {SoLuongTonKho}";
        }
    }