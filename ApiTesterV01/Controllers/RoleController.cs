using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ApiTesterV01.Controllers
{
    [AllowAnonymous]
    public class RoleController : BaseController
    {
        private IRoleServices _roleServices;
        public RoleController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }



        #region Get : All , By Id
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var roles = await _roleServices.GetAllAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _roleServices.GetRoleAsync(id);
            return Ok(role);
        }
        #endregion
        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(RoleViewModel model)
        {
            await _roleServices.AddNewAsync(model);
            return Ok();
        }
        #endregion
        #region Put
        [HttpPut]
        public async Task<IActionResult> Put(RoleViewModel model)
        {
            await _roleServices.UpdateRoleAsync(model);
            return Ok();
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _roleServices.DeleteRoleAsync(id);
            return Ok();
        }
        #endregion


    }
}
