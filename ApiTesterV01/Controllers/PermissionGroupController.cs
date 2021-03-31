using ApiTesterV01.Entities;
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
    public class PermissionGroupController : BaseController
    {

        private IPermissionGroupServices _pGroupServices;
        public PermissionGroupController(IPermissionGroupServices pGroupServices)
        {
            _pGroupServices = pGroupServices;
        }

        #region Get : All , By Id
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var pGroups = await _pGroupServices.GetAllAsync();
            return Ok(pGroups);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var pGroup = await _pGroupServices.GetPermissionGroupAsync(id);
            return Ok(pGroup);
        }
        #endregion
        #region Post
        [HttpPost]
        public async Task<IActionResult> Post(PermissionGroupViewModel model)
        {
            await _pGroupServices.AddNewAsync(model);
            return Ok();
        }
        #endregion
        #region Put
        [HttpPut]
        public async Task<IActionResult> Put(PermissionGroupViewModel model)
        {
            await _pGroupServices.UpdatePermissionGroupAsync(model);
            return Ok();
        }
        #endregion
        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pGroupServices.DeletePermissionGroupAsync(id);
            return Ok();
        }
        #endregion
    }
}

