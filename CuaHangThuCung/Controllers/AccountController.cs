using CuaHangThuCung.Models;
using CuaHangThuCung.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shares.ApiResult;

namespace CuaHangThuCung.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IRepoAccount _accountService;

        public AccountController(IRepoAccount accountService)
        {
            _accountService = accountService;
        }

        // GET: api/account
        [HttpGet]
        public IActionResult GetAllAccounts()
        {
            var accounts = _accountService.GetAllAccounts();
            var result = new ApiSuccessResult<IEnumerable<Account>>(accounts);
            result.FetchedRecordsCount = accounts.Count();

            return Ok(result);
        }

        // GET: api/account/{tenTaiKhoan}
        [HttpGet("{tenTaiKhoan}")]
        public IActionResult GetAccount(string tenTaiKhoan)
        {
            var account = _accountService.GetAccountById(tenTaiKhoan);

            if (account == null)
            {
                return NotFound(new ApiResult(false, "Account not found", 404));
            }

            return Ok(new ApiSuccessResult<Account>(account));
        }

        // POST: api/account
        [HttpPost]
        public IActionResult CreateAccount(Account account)
        {
            _accountService.CreateAccount(account);
            return Ok(new ApiSuccessResult<Account>(account, 201, "Account created successfully"));
        }

        // PUT: api/account/{tenTaiKhoan}
        [HttpPut("{tenTaiKhoan}")]
        public IActionResult UpdateAccount(string tenTaiKhoan, Account account)
        {
            var existingAccount = _accountService.GetAccountById(tenTaiKhoan);

            if (existingAccount == null)
            {
                return NotFound(new ApiResult(false, "Account not found", 404));
            }

            existingAccount.MatKhau = account.MatKhau;
            existingAccount.Quyen = account.Quyen;

            _accountService.UpdateAccount(existingAccount);

            return Ok(new ApiSuccessResult<Account>(existingAccount, 200, "Account updated successfully"));
        }

        // DELETE: api/account/{tenTaiKhoan}
        [HttpDelete("{tenTaiKhoan}")]
        public IActionResult DeleteAccount(string tenTaiKhoan)
        {
            var account = _accountService.GetAccountById(tenTaiKhoan);

            if (account == null)
            {
                return NotFound(new ApiResult(false, "Account not found", 404));
            }

            _accountService.DeleteAccount(account);

            return Ok(new ApiSuccessResult<Account>(account, 200, "Account deleted successfully"));
        }
    }
}

