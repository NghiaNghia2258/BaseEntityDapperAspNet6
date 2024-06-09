using System;
using System.Collections.Generic;

namespace CuaHangThuCung.Models
{
    public partial class Account
    {
        public Account()
        {
            KhachHangs = new HashSet<KhachHang>();
        }

        public string TenTaiKhoan { get; set; } = null!;
        public string MatKhau { get; set; } = null!;
        public string Quyen { get; set; } = null!;

        public virtual ICollection<KhachHang> KhachHangs { get; set; }
    }
}
