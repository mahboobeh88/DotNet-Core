using ApiTesterV01.ISevices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Controllers
{
    
    public class UserTokenController : BaseController
    {
        private IUserTokenServices _userTokenServices;
        public UserTokenController(IUserTokenServices userTokenServices)
        {
            _userTokenServices = userTokenServices;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(Guid userId)
        {
            var user = await _userTokenServices.GetByUserIdAsync(userId);
            if (user == null) return BadRequest("User Not Found!");
            return Ok(user);
        }

        
    }
}
