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

        [HttpPost("Add")]
        public async Task AddAsync([FromBody] Account account)
        {
            await _dbContext.Accounts.AddAsync(account);
            await _dbContext.SaveChangesAsync();
        }

        [HttpPost("Update")]
        public async Task UpdateAsync([FromBody] Account account)
        {
            _dbContext.Accounts.Update(account);
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