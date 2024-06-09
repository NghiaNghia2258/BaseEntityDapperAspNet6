using CuaHangThuCung.Models;
using CuaHangThuCung.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CuaHangThuCung.Repository
{
    public class RepoAccount : IRepoAccount
    {
        private readonly CuaHangThuCungContext _context;

        public RepoAccount()
        {
            _context = new CuaHangThuCungContext();
        }
        public void CreateAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
        public IQueryable<Account> GetAllAccounts()
        {
            return _context.Accounts;
        }
        public Account GetAccountById(string tenTaiKhoan)
        {
            return _context.Accounts.FirstOrDefault(a => a.TenTaiKhoan == tenTaiKhoan);
        }
        public void UpdateAccount(Account account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
        }
        public void DeleteAccount(Account account)
        {
            _context.Accounts.Remove(account);
            _context.SaveChanges();
        }
    }
}
