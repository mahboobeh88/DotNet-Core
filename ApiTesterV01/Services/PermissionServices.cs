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
    public class PermissionServices : IPermissionServices
    {
        private readonly APITesterDBContext _context;
        private readonly IMapper _mapper;
        public PermissionServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<PermissionViewModel>> GetAllAsync()
        {
            var permission = await _context.Permission.AsNoTracking().ToListAsync();
            var permissionModel = _mapper.Map<ICollection<PermissionViewModel>>(permission);
            return permissionModel;
        }
        public async Task<PermissionViewModel> GetPermissionAsync(int id)
        {
            var permission = await _context.Permission.Where(p => p.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var permissionModel = _mapper.Map<PermissionViewModel>(permission);
            return permissionModel;
        }

        public async Task AddNewAsync(PermissionViewModel model)
        {
            var permission = _mapper.Map<Permission>(model);
            await _context.AddAsync(permission);
            await _context.SaveChangesAsync();

        }
        public async Task UpdatePermissionAsync(PermissionViewModel model)
        {
            var permission = await _context.Permission.Where(r => r.Id == model.Id).SingleOrDefaultAsync();
            if (permission != null)
            {
                permission.Title = model.Title;
                permission.ShowInMenu = model.ShowInMenu;
                permission.AreaName = model.AreaName.Trim();
                permission.ControllerName = model.ControllerName.Trim();
                permission.ActionType = model.ActionType;
                permission.ActionName = model.ActionName.Trim();
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeletePermissionAsync(int id)
        {
            var permission = await _context.Permission.Where(r => r.Id == id).SingleOrDefaultAsync();
            if (permission != null)
            {
                _context.Remove(permission);
                await _context.SaveChangesAsync();
            }
        }
    }
}
