using ApiTesterV01.Common;
using ApiTesterV01.ISevices;
using ApiTesterV01.Models;

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace ApiTesterV01.Services
{
    public class AuthServices : IAuthServices
    {
        private IUserServices _userServices;
        private IUserTokenServices _userTokenServices;
        private AuthUtility _authUtility;
        public AuthServices(IUserServices userServices, IUserTokenServices userTokenServices, AuthUtility authUtility)
        {
            _userServices = userServices;
            _userTokenServices = userTokenServices;
            _authUtility = authUtility;
        }

        public async Task<object> LoginAsync(LoginViewModel model)
        {
            var user = await _userServices.GetUserByUserNamePasswordAsync(model.UserName, model.Password);
            if (user == null) throw null;
            var result = await CreateNewToken(user);
            return result;
        }

        public async Task<object> CreateNewToken(UserViewModel model)
        {
            var userTokenInfo = await UserTokenManagementAsync(model);
          
            var token = _authUtility.GenerateNewToken(model.Id);
            return new { Token = token, refreshToken = userTokenInfo.RefreshToken, User = model.Id };
        }

        public async Task<UserTokenViewModel> UserTokenManagementAsync(UserViewModel model)
        {
            var userTokenInfo = new UserTokenViewModel
            {
                UserId = model.Id,
                GenerationDate = DateTime.Now,
                IsValid = true,
                RefreshToken = Guid.NewGuid().ToString()
            };
            var userToken = await _userTokenServices.GetByUserIdAsync(model.Id);
            if (userToken == null)
            {
                await _userTokenServices.AddNewAsync(userTokenInfo);
            }
            else
            {
                try
                {
                    await _userTokenServices.UpdateRefreshTokenByUserIdAsync(userTokenInfo);
                }
                catch (Exception ex)
                {
                    var s = ex.Message;
                    throw;
                }
               
            }
            return userTokenInfo;
        }

        public async Task<object> CreateNewTokenWithRToken(Guid userId, string refreshToken)
        {
            var userToken = await _userTokenServices.GetByUserIdAsync(userId);

            if (userToken == null)
                throw new ExternalException( "Token Is Not Valid" , 1);  
            if (userToken.RefreshToken.Trim() != refreshToken.Trim())
                throw new ExternalException( "RefreshToken Is not Valid" , 2);
            if (userToken.GenerationDate.AddMinutes(15) < DateTime.Now)
                throw new ExternalException("RefreshToken Is Expired" , 3);
            
            var userTokenInfo = new UserTokenViewModel
            {
                UserId = userId,
                GenerationDate = DateTime.Now,
                IsValid = true,
                RefreshToken = Guid.NewGuid().ToString()
            };
            await _userTokenServices.UpdateRefreshTokenByUserIdAsync(userTokenInfo);
            return userTokenInfo;
        }
    }
}
