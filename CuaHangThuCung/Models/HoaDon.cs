using System;
using System.Collections.Generic;

namespace CuaHangThuCung.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int Id { get; set; }
        public string TenKh { get; set; } = null!;
        public int KhachhangId { get; set; }
        public DateTime NgayTao { get; set; }
        public string Trangthai { get; set; } = null!;
        public decimal Tonggiatri { get; set; }

        public virtual KhachHang Khachhang { get; set; } = null!;
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
