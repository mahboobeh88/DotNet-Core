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
    public class RolePermissionController : BaseController
    {
        private IRolePermissionServices _rpservices;
        public RolePermissionController(IRolePermissionServices rpservices)
        {
            _rpservices = rpservices;
        }

        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var rolePermissions = await _rpservices.GetAllAsync();
            return Ok(rolePermissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var rolePermission = await _rpservices.GetRolePermissionByIdAsync(id);
            return Ok(rolePermission);
        }

        [HttpPost]
        public async Task<IActionResult> Post(RolePermissionViewModel model)
        {
            await _rpservices.AddNewAsync(model);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(RolePermissionViewModel model)
        {
            await _rpservices.UpdateRolePermissionAsync(model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _rpservices.DeleteRolePermissionByIdAsync(id);
            return Ok();
        }
        [HttpDelete("ByRole/{roleId}")]
        public async Task<IActionResult> DeleteByRoleId(int roleId)
        {
            await _rpservices.DeleteRolePermissionByRoleIdAsync(roleId);
            return Ok();
        }
        [HttpDelete("ByPermission/{permissionId}")]
        public async Task<IActionResult> DeleteByPermissionId(int permissionId)
        {
            await _rpservices.DeleteRolePermissionByPermissionIdAsync(permissionId);
            return Ok();
        }
    }
}
