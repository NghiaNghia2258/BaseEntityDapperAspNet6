using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CuaHangThuCung.Models
{
    public partial class CuaHangThuCungContext : DbContext
    {
        public CuaHangThuCungContext()
        {
        }

        public CuaHangThuCungContext(DbContextOptions<CuaHangThuCungContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<KhachHang> KhachHangs { get; set; } = null!;
        public virtual DbSet<ThuCung> ThuCungs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-BOC9JRS\\SQLEXPRESS;Initial Catalog=CuaHangThuCung;Integrated Security=True;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.TenTaiKhoan)
                    .HasName("PK__Account__4A8306F55FC75BA7");

                entity.ToTable("Account");

                entity.Property(e => e.TenTaiKhoan)
                    .HasMaxLength(50)
                    .HasColumnName("tenTaiKhoan");

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(50)
                    .HasColumnName("matKhau");

                entity.Property(e => e.Quyen)
                    .HasMaxLength(50)
                    .HasColumnName("quyen");
            });

            modelBuilder.Entity<ChiTietHoaDon>(entity =>
            {
                entity.ToTable("ChiTietHoaDon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Gia)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("gia");

                entity.Property(e => e.HoaDonId).HasColumnName("hoaDonId");

                entity.Property(e => e.SoLuong).HasColumnName("soLuong");

                entity.Property(e => e.ThuCungId).HasColumnName("thuCungId");

                entity.HasOne(d => d.HoaDon)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.HoaDonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_HoaDon");

                entity.HasOne(d => d.ThuCung)
                    .WithMany(p => p.ChiTietHoaDons)
                    .HasForeignKey(d => d.ThuCungId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietHoaDon_ThuCung");
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.ToTable("HoaDon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KhachhangId).HasColumnName("khachhangId");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("date")
                    .HasColumnName("ngayTao");

                entity.Property(e => e.TenKh)
                    .HasMaxLength(100)
                    .HasColumnName("tenKH");

                entity.Property(e => e.Tonggiatri)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("tonggiatri");

                entity.Property(e => e.Trangthai)
                    .HasMaxLength(50)
                    .HasColumnName("trangthai");

                entity.HasOne(d => d.Khachhang)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.KhachhangId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_KhachHang");
            });

            modelBuilder.Entity<KhachHang>(entity =>
            {
                entity.ToTable("KhachHang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(255)
                    .HasColumnName("diachi");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .HasColumnName("sdt");

                entity.Property(e => e.Taikhoan)
                    .HasMaxLength(50)
                    .HasColumnName("taikhoan");

                entity.Property(e => e.Ten)
                    .HasMaxLength(100)
                    .HasColumnName("ten");

                entity.HasOne(d => d.TaikhoanNavigation)
                    .WithMany(p => p.KhachHangs)
                    .HasForeignKey(d => d.Taikhoan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KhachHang_Account");
            });

            modelBuilder.Entity<ThuCung>(entity =>
            {
                entity.ToTable("ThuCung");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Conlai).HasColumnName("conlai");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("created_at");

                entity.Property(e => e.Gia)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("gia");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(10)
                    .HasColumnName("gioitinh");

                entity.Property(e => e.Loai)
                    .HasMaxLength(50)
                    .HasColumnName("loai");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Src)
                    .HasMaxLength(255)
                    .HasColumnName("src");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(100)
                    .HasColumnName("tieude");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("updated_at");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
