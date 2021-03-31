using ApiTesterV01.Data;
using ApiTesterV01.Entities;
using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Services
{
    public class RolePermissionServices : IRolePermissionServices
    {
        private readonly APITesterDBContext _context;
        private readonly IMapper _mapper;

        public RolePermissionServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<object>> GetAllAsync()
        {
            var rolePermission = await _context.RolePermission
                .Join(_context.Permission, rp => rp.PermissionId, p => p.Id, (rp, p) => new
                { rp, p })
                .Join(_context.PermissionGroups, rp => rp.p.PermissionGroupId, pg => pg.Id, (rp, pg) => new { pg, rp })
                .Join(_context.Role, rp => rp.rp.rp.RoleId, r => r.Id, (rp, r) => new
                {
                    Title = rp.rp.p.Title,
                    Rout = $" {rp.rp.p.AreaName} / {rp.rp.p.ControllerName} / {rp.rp.p.ActionName} ",
                    ActionType = rp.rp.p.ActionType,
                    RoleName = r.Name,
                    PermissionGroup = rp.pg.Title
                })
                .AsNoTracking().ToListAsync();
            return (ICollection<object>)rolePermission;
        }
        public async Task<object> GetRolePermissionByIdAsync(int rolePermissionId)
        {
            var rolePermission = await _context.RolePermission
               .Where(i => i.Id == rolePermissionId)
              .Join(_context.Permission, rp => rp.PermissionId, p => p.Id, (rp, p) => new
              { rp, p })
              .Join(_context.PermissionGroups, rp => rp.p.PermissionGroupId, pg => pg.Id, (rp, pg) => new { pg, rp })
              .Join(_context.Role, rp => rp.rp.rp.RoleId, r => r.Id, (rp, r) => new
              {
                  Title = rp.rp.p.Title,
                  Rout = $" {rp.rp.p.AreaName} / {rp.rp.p.ControllerName} / {rp.rp.p.ActionName} ",
                  ActionType = rp.rp.p.ActionType,
                  RoleName = r.Name,
                  PermissionGroup = rp.pg.Title
              })
             .AsNoTracking().SingleOrDefaultAsync();
            return rolePermission;
        }

        public async Task AddNewAsync(RolePermissionViewModel model)
        {
            var rolePermission = _mapper.Map<RolePermission>(model);
            await _context.AddAsync(rolePermission);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRolePermissionAsync(RolePermissionViewModel model)
        {
            var rolePermission = await _context.RolePermission.Where(rp => rp.Id ==model.Id).SingleOrDefaultAsync();
            if (rolePermission != null)
            {
                rolePermission.PermissionId = model.PermissionId;
                rolePermission.RoleId = model.RoleId;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRolePermissionByIdAsync(int id)
        {
            var rolePermission = await _context.RolePermission.Where(rp => rp.Id == id).SingleOrDefaultAsync();
            if (rolePermission != null)
            {
                _context.Remove(rolePermission);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteRolePermissionByRoleIdAsync(int roleId)
        {
            var rolePermissions = await _context.RolePermission.Where(rp => rp.RoleId == roleId).ToListAsync();
            if (rolePermissions.Count >  0)
            {
                _context.RemoveRange(rolePermissions);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteRolePermissionByPermissionIdAsync(int permissionId)
        {
            var rolePermissions = await _context.RolePermission.Where(rp => rp.PermissionId == permissionId).ToListAsync();
            if (rolePermissions.Count > 0)
            {
                _context.RemoveRange(rolePermissions);
                await _context.SaveChangesAsync();
            }
        }
    }
}
