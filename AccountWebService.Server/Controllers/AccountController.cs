using AccountWebService.Server.Contexts;
using AccountWebService.Server.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IList<Account> Get()
        {
            return _dbContext.Accounts.ToList();
        }
    }
}