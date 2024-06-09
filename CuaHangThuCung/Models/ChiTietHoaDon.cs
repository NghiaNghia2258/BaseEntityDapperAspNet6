using System;
using System.Collections.Generic;

namespace CuaHangThuCung.Models
{
    public partial class ChiTietHoaDon
    {
        public int Id { get; set; }
        public int HoaDonId { get; set; }
        public int ThuCungId { get; set; }
        public int SoLuong { get; set; }
        public decimal Gia { get; set; }

        public virtual HoaDon HoaDon { get; set; } = null!;
        public virtual ThuCung ThuCung { get; set; } = null!;
    }
}
