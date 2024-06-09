using System;
using System.Collections.Generic;

namespace CuaHangThuCung.Models
{
    public partial class KhachHang
    {
        public KhachHang()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int Id { get; set; }
        public string Ten { get; set; } = null!;
        public string Sdt { get; set; } = null!;
        public string Diachi { get; set; } = null!;
        public string Taikhoan { get; set; } = null!;

        public virtual Account TaikhoanNavigation { get; set; } = null!;
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
