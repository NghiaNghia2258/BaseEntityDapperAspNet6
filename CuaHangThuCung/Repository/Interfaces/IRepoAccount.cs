using CuaHangThuCung.Models;

namespace CuaHangThuCung.Repository.Interfaces
{
    public interface IRepoAccount
    {
        void CreateAccount(Account account);
        void DeleteAccount(Account account);
        Account GetAccountById(string tenTaiKhoan);
        IQueryable<Account> GetAllAccounts();
        void UpdateAccount(Account account);
    }
}
