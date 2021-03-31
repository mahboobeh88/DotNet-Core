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
    public class RoleServices : IRoleServices
    {
        private readonly APITesterDBContext _context;
        private readonly IMapper _mapper;
        public RoleServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ICollection<RoleViewModel>> GetAllAsync()
        {
            var Roles = await _context.Role.AsNoTracking().ToListAsync();
            var RoleModel = _mapper.Map<ICollection<RoleViewModel>>(Roles);
            return RoleModel;
        }
        public async Task<RoleViewModel> GetRoleAsync(int id)
        {
            var Role = await _context.Role.Where(r => r.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var RoleModel = _mapper.Map<RoleViewModel>(Role);
            return RoleModel;
        }

        public async Task AddNewAsync(RoleViewModel model)
        {
            var role = _mapper.Map<Role>(model);
            await _context.AddAsync(role);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateRoleAsync(RoleViewModel model)
        {
            var role = await _context.Role.Where(r => r.Id == model.Id).SingleOrDefaultAsync();
            if (role != null)
            {
                role.Name = model.Name.Trim();
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteRoleAsync(int id)
        {
            var role = await _context.Role.Where(r => r.Id == id).SingleOrDefaultAsync();
            _context.Remove(role);
            await _context.SaveChangesAsync();
        }
    }
}
