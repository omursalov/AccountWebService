using AccountWebService.Server.Contexts;
using AccountWebService.Server.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountWebService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableCors("default")]
    public class AccountController : ControllerBase
    {
        private AccountContext _dbContext;

        public AccountController(AccountContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Get")]
        public async Task<IList<Account>> GetAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }

        [HttpPost("AddOrUpdate")]
        public async Task AddOrUpdateAsync([FromBody] Account account)
        {
            var currAccount = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == account.Id);

            if (currAccount == null)
            {
                await _dbContext.Accounts.AddAsync(account);
            }
            else
            {
                currAccount.Labels = account.Labels;
                currAccount.Type = account.Type;
                currAccount.Login = account.Login;
                currAccount.Password = account.Password;
                _dbContext.Accounts.Update(currAccount);
            }

            await _dbContext.SaveChangesAsync();
        }

        [HttpDelete("Delete")]
        public async Task DeleteAsync([FromQuery] Guid id)
        {
            var account = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.Id == id);
            if (account != null)
            {
                _dbContext.Accounts.Remove(account);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}