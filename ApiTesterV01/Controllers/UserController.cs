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
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userServices.GetAllAsync();
            if (users.Count() >=1) return Ok(users);
            return Ok();
        }
        /// <summary>
        /// Get UserInfo By Id 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("userId")]
        public async Task<IActionResult> GetByIdAsync(string userId)
        {
            var user = await _userServices.GetUserByIdAsync(userId.Trim());
            if (user != null) return Ok(user);
            return Ok();
        }
        /// <summary>
        /// Get UserInfo By  UserName
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [HttpGet("ByUserName/{userName}")]
        public async Task<IActionResult> GetByUserNameAsync(string userName)
        {

            var user = await _userServices.GetUserByUserNameAsync(userName.Trim());
            if (user != null) return Ok(user);
            return Ok();
        }
        [HttpGet("ByUsePass/{userName} , {password}")]
        public async Task<IActionResult> GetByUsePassAsync(string userName , string password)
        {

            var user = await _userServices.GetUserByUserNamePasswordAsync(userName.Trim() , password);
            if (user != null) return Ok(user);
            return BadRequest("Invalid UserName Or Password!");

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
        /// Update a UserInfo By UserName
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ByUserName/")]
        public async Task<IActionResult> PutByUserNameAsync(UserViewModel model)
        {
            await _userServices.UpdateUserByUserNameAsync(model);
            return Ok();

        }
        /// <summary>
        /// Update a UserInfo By Id Or By UserName
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("ById/")]
        public async Task<IActionResult> Put(UserViewModel model)
        {
            await _userServices.UpdateUserByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a user By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(string id)
        {
            await _userServices.DeleteUserByIdAsync(id.Trim());
            return Ok();

        }
        /// <summary>
        /// Delete a user By UserName
        /// </summary>
        /// <param name="userNamde"></param>
        /// <returns></returns>
        [HttpDelete("ByUserName/{userNamde}")]
        public async Task<IActionResult> Delete(string userNamde)
        {

            await _userServices.DeleteUserByUserNameAsync(userNamde.Trim());
            return Ok();
        }
        #endregion


    }
}
