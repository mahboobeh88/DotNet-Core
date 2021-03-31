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
    public class PermissionGroupServices : IPermissionGroupServices
    {
        private readonly APITesterDBContext _context;
        private readonly IMapper _mapper;
        public PermissionGroupServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<PermissionGroupViewModel>> GetAllAsync()
        {
            var prGroups = await _context.PermissionGroups.AsNoTracking().ToListAsync();
            var prGroupModel = _mapper.Map<ICollection<PermissionGroupViewModel>>(prGroups);
            return prGroupModel;
        }
        public async Task<PermissionGroupViewModel> GetPermissionGroupAsync(int id)
        {
            var prGroup = await _context.PermissionGroups.Where(pg => pg.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var prGroupModel = _mapper.Map<PermissionGroupViewModel>(prGroup);
            return prGroupModel;
        }
        public async Task AddNewAsync(PermissionGroupViewModel model)
        {
            var prGroup = _mapper.Map<PermissionGroup>(model);
            await _context.AddAsync(prGroup);
            await _context.SaveChangesAsync();
        }
        public async Task UpdatePermissionGroupAsync(PermissionGroupViewModel model)
        {
            var prGroup = await _context.PermissionGroups.Where(r => r.Id == model.Id).SingleOrDefaultAsync();
            if (prGroup != null)
            {
                prGroup.Title = model.Title.Trim();
                prGroup.ShowInMenu = model.ShowInMenu;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeletePermissionGroupAsync(int id)
        {
            var prGroup = await _context.PermissionGroups.Where(r => r.Id == id).SingleOrDefaultAsync();
            if (prGroup != null)
            {
                _context.Remove(prGroup);
                await _context.SaveChangesAsync();
            }
        }
    }
}
