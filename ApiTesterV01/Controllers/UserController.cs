using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Controllers
{

    public class UserController : BaseController
    {
        private IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        #region Gets : All , By Id , By UserName
        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userServices.GetAllAsync();
            return Ok(users);
        }
        /// <summary>
        /// Get UserInfo By Id 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("userId")]
        public async Task<IActionResult> GetById(string userId)
        {
            var user = await _userServices.GetUserByIdAsync(userId.Trim());
            return Ok(user);
        }
        /// <summary>
        /// Get UserInfo By  UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("userName")]
        public async Task<IActionResult> GetByUserName(string userName)
        {
           
                var user = await _userServices.GetUserByUserNameAsync(userName.Trim());
                return Ok(user);
           
        }
        #endregion

        #region Post
        /// <summary>
        /// Insert New User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(UserViewModel model)
        {
            await _userServices.AddNewAsync(model);
            return Ok();
        }
        #endregion
        #region Put
        /// <summary>
        /// Update a UserInfo By Id Or By UserName
        /// </summary>
        /// <param name="model"></param>
        /// <param name="byId"></param>
        /// <returns></returns>
        [HttpPut("byId")]
        public async Task<IActionResult> Put(UserViewModel model, bool byId = false)
        {
            if (!byId)
            {
                await _userServices.UpdateUserByUserNameAsync(model);
                return Ok();
            }
            else
            {
                await _userServices.UpdateUserByIdAsync(model);
                return Ok();
            }

        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a user By Id Or By UserName
        /// </summary>
        /// <param name="idOrUserName"></param>
        /// <param name="byId"></param>
        /// <returns></returns>
        [HttpDelete("idOrUserName/byId")]
        public async Task<IActionResult> Delete(string idOrUserName, bool byId = true)
        {
            if (!byId)
            {
                await _userServices.DeleteUserByUserNameAsync(idOrUserName.Trim());
                return Ok();
            }
            else
            {
                await _userServices.DeleteUserByIdAsync(idOrUserName.Trim());
                return Ok();
            }

        }
        #endregion



    }
}
