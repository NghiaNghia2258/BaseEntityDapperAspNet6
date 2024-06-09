using System;
using System.Collections.Generic;

namespace CuaHangThuCung.Models
{
    public partial class ThuCung
    {
        public ThuCung()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        public int Id { get; set; }
        public string Tieude { get; set; } = null!;
        public string Src { get; set; } = null!;
        public string Loai { get; set; } = null!;
        public decimal Gia { get; set; }
        public int Conlai { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Gioitinh { get; set; } = null!;

        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
