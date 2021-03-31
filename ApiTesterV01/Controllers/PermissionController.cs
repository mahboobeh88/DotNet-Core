using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Controllers
{
    [AllowAnonymous]
    public class PermissionController : BaseController
    {
        private IPermissionServices _permissionServices;
        public PermissionController(IPermissionServices permissionServices)
        {
            _permissionServices = permissionServices;
        }

        #region Get : All , By Id
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var permissions = await _permissionServices.GetAllAsync();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var permission = await _permissionServices.GetPermissionAsync(id);
            return Ok(permission);
        }
        #endregion
        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(PermissionViewModel model)
        {
             await _permissionServices.AddNewAsync(model);
            return Ok();
        }
        #endregion
        #region Put
        [HttpPut]
        public async Task<IActionResult> Put(PermissionViewModel model)
        {
            await _permissionServices.UpdatePermissionAsync(model);
            return Ok();
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _permissionServices.DeletePermissionAsync(id);
            return Ok();
        }
        #endregion
    }
}
