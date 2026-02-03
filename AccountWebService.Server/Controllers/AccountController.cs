using AccountWebService.Server.Contexts;
using AccountWebService.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AccountWebService.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private AccountContext _dbContext;

        public AccountController(AccountContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet(Name = "Get")]
        public async Task<IList<Account>> GetAsync()
        {
            return await _dbContext.Accounts.ToListAsync();
        }
    }
}