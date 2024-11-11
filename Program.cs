class Program
    {
        static void Main(string[] args)
        {
            QuanLySanPhamDonHang quanLy = new QuanLySanPhamDonHang();
            quanLy.TaiDuLieuJSON(); 
            int luaChon;
            do
            {
                Console.WriteLine("=== Quản Lý Sản Phẩm & Đơn Hàng ===");
                Console.WriteLine("1. Thêm sản phẩm");
                Console.WriteLine("2. Tìm kiếm sản phẩm theo tên");
                Console.WriteLine("3. Cập nhật sản phẩm");
                Console.WriteLine("4. Tính tổng giá trị kho hàng");
                Console.WriteLine("5. Xóa sản phẩm");
                Console.WriteLine("6. Hiển thị danh sách sản phẩm");
                Console.WriteLine("7. Sắp xếp sản phẩm theo giá tăng dần");
                Console.WriteLine("8. Sắp xếp sản phẩm theo giá giảm dần");
                Console.WriteLine("9. Sắp xếp sản phẩm theo tên");
                Console.WriteLine("10. Thêm đơn hàng");
                Console.WriteLine("11. Hiển thị danh sách đơn hàng");
                Console.WriteLine("12. Lưu dữ liệu vào JSON");
                Console.WriteLine("13. Tải dữ liệu từ JSON");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng: ");
                luaChon = int.Parse(Console.ReadLine());

                switch (luaChon)
                {
                    case 1:
                        quanLy.ThemSanPham();
                        break;
                    case 2:
                        quanLy.TimKiemSanPhamTheoTen();
                        break;
                    case 3:
                        quanLy.CapNhatSanPham();
                        break;
                    case 4:
                        quanLy.TinhTongGiaTriKhoHang();
                        break;
                    case 5:
                        quanLy.XoaSanPham();
                        break;
                    case 6:
                        quanLy.HienThiDanhSachSanPham();
                        break;
                    case 7:
                        quanLy.SapXepSanPhamTheoGiaTangDan();
                        break;
                    case 8:
                        quanLy.SapXepSanPhamTheoGiaGiamDan();
                        break;
                    case 9:
                        quanLy.SapXepSanPhamTheoTen();
                        break;
                    case 10:
                        quanLy.ThemDonHang();
                        break;
                    case 11:
                        quanLy.HienThiDanhSachDonHang();
                        break;
                    case 12:
                        quanLy.LuuDuLieuJSON();
                        break;
                    case 13:
                        quanLy.TaiDuLieuJSON();
                        break;
                    case 0:
                        Console.WriteLine("Thoát chương trình...");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }
            } while (luaChon != 0);
        }
    }