using ApiTesterV01.Common;
using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ApiTesterV01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthServices _authservices;
        private readonly AuthUtility _authUtility;
        private IUserTokenServices _userTokenServices;
        public AuthController(IAuthServices authservices, AuthUtility authUtility, IUserTokenServices userTokenServices)
        {
            _authservices = authservices;
            _authUtility = authUtility;
            _userTokenServices = userTokenServices;
        }

        [HttpPost]
        public async Task<IActionResult> Post(LoginViewModel model)
        {
            var result = await _authservices.LoginAsync(model);
            return Ok(result);
        }


        [HttpPost("{refreshToken}")]
        public async Task<IActionResult> PostNewToken(string refreshToken)
        {

            Guid userId;
            if (!Guid.TryParse(User.Claims.Where(q => q.Type == "user").SingleOrDefault().Value, out userId))
                return BadRequest("Token Is not Valid");
            try
            {
                var userTokenInfo = await _authservices.CreateNewTokenWithRToken(userId, refreshToken);
                return Ok(userTokenInfo);
            }
            catch (ExternalException ex)
            {
                return BadRequest($"Error {ex.ErrorCode} : {ex.Message}");
            }
            catch (Exception)
            {
                return BadRequest("There is an error");
            }

        }
    }
}
