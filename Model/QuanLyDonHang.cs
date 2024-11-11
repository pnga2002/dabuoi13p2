using System.Text.Json;

class QuanLySanPhamDonHang
    {
        private List<SanPham> danhSachSanPham = new List<SanPham>();
        private List<DonHang> danhSachDonHang = new List<DonHang>();

        public void ThemSanPham()
        {
            Console.Write("Nhập tên sản phẩm: ");
            string ten = Console.ReadLine();
            Console.Write("Nhập giá bán: ");
            decimal gia = decimal.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng tồn kho: ");
            int soLuong = int.Parse(Console.ReadLine());

            danhSachSanPham.Add(new SanPham { TenSanPham = ten, GiaBan = gia, SoLuongTonKho = soLuong });
            Console.WriteLine("Thêm sản phẩm thành công.");
        }

        public void TimKiemSanPhamTheoTen()
        {
            Console.Write("Nhập tên sản phẩm để tìm: ");
            string ten = Console.ReadLine();
            var ketQua = danhSachSanPham.Where(sp => sp.TenSanPham.Contains(ten, StringComparison.OrdinalIgnoreCase)).ToList();

            ketQua.ForEach(Console.WriteLine);
        }

        public void CapNhatSanPham()
        {
            Console.Write("Nhập mã sản phẩm để cập nhật: ");
            int ma = int.Parse(Console.ReadLine());
            var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == ma);

            if (sanPham != null)
            {
                Console.Write("Nhập giá mới: ");
                sanPham.GiaBan = decimal.Parse(Console.ReadLine());
                Console.Write("Nhập số lượng tồn kho mới: ");
                sanPham.SoLuongTonKho = int.Parse(Console.ReadLine());
                Console.WriteLine("Cập nhật sản phẩm thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        public void TinhTongGiaTriKhoHang()
        {
            decimal tongGiaTri = danhSachSanPham.Sum(sp => sp.GiaBan * sp.SoLuongTonKho);
            Console.WriteLine($"Tổng giá trị kho hàng: {tongGiaTri}");
        }

        public void XoaSanPham()
        {
            Console.Write("Nhập mã sản phẩm để xóa: ");
            int ma = int.Parse(Console.ReadLine());
            var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == ma);

            if (sanPham != null)
            {
                danhSachSanPham.Remove(sanPham);
                Console.WriteLine("Xóa sản phẩm thành công.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy sản phẩm.");
            }
        }

        public void HienThiDanhSachSanPham()
        {
            danhSachSanPham.ForEach(Console.WriteLine);
        }

        public void SapXepSanPhamTheoGiaTangDan()
        {
            var sanPhamsapXep = danhSachSanPham.OrderBy(sp => sp.GiaBan).ToList();
            sanPhamsapXep.ForEach(Console.WriteLine);
        }

        public void SapXepSanPhamTheoGiaGiamDan()
        {
            var sanPhamsapXep = danhSachSanPham.OrderByDescending(sp => sp.GiaBan).ToList();
            sanPhamsapXep.ForEach(Console.WriteLine);
        }

        public void SapXepSanPhamTheoTen()
        {
            var sanPhamsapXep = danhSachSanPham.OrderBy(sp => sp.TenSanPham).ToList();
            sanPhamsapXep.ForEach(Console.WriteLine);
        }

        public void ThemDonHang()
        {
            Console.Write("Nhập mã sản phẩm: ");
            int maSP = int.Parse(Console.ReadLine());
            Console.Write("Nhập số lượng bán: ");
            int soLuong = int.Parse(Console.ReadLine());
            Console.Write("Nhập tên người đặt: ");
            string nguoiDat = Console.ReadLine();
            Console.Write("Nhập trạng thái (true: giao, false: hủy): ");
            bool trangThai = bool.Parse(Console.ReadLine());

            var sanPham = danhSachSanPham.FirstOrDefault(sp => sp.MaSanPham == maSP);
            if (sanPham != null && sanPham.SoLuongTonKho >= soLuong && trangThai)
            {
                sanPham.SoLuongTonKho -= soLuong;
                danhSachDonHang.Add(new DonHang { MaSanPham = maSP, SoLuongBan = soLuong, TenNguoiDat = nguoiDat, TrangThaiGiaoHang = trangThai });
                Console.WriteLine("Thêm đơn hàng thành công.");
            }
            else
            {
                Console.WriteLine("Không thể thêm đơn hàng. Kiểm tra số lượng hoặc trạng thái.");
            }
        }

        public void HienThiDanhSachDonHang()
        {
            danhSachDonHang.ForEach(Console.WriteLine);
        }

        public void LuuDuLieuJSON()
        {
            string jsonSanPham = JsonSerializer.Serialize(danhSachSanPham);
            File.WriteAllText("sanpham.json", jsonSanPham);
            Console.WriteLine("Dữ liệu sản phẩm đã được lưu vào JSON.");
        }

        public void TaiDuLieuJSON()
        {
            if (File.Exists("sanpham.json"))
            {
                string jsonSanPham = File.ReadAllText("sanpham.json");
                danhSachSanPham = JsonSerializer.Deserialize<List<SanPham>>(jsonSanPham);
                Console.WriteLine("Dữ liệu sản phẩm đã được tải từ JSON.");
            }
            else
            {
                Console.WriteLine("Không tìm thấy file JSON.");
            }
        }
    }
