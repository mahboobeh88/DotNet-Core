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
    public class UserTokenServices : IUserTokenServices
    {
        private readonly APITesterDBContext _context;
        private readonly IMapper _mapper;
        public UserTokenServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserTokenViewModel> GetByUserIdAsync(Guid userId)
        {
            var userToken = await _context.UserToken.Where(ut => ut.UserId.ToString().ToLower() == userId.ToString().ToLower()).AsNoTracking().SingleOrDefaultAsync();
            var userTokenModel = _mapper.Map<UserTokenViewModel>(userToken);
            return userTokenModel;
        }
        public async Task AddNewAsync(UserTokenViewModel model)
        {
            var userToken = _mapper.Map<UserToken>(model);
            await _context.AddAsync(userToken);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var exception = ex.Message;
                throw;
            }
        
        }
        public async Task UpdateRefreshTokenByUserIdAsync(UserTokenViewModel model)
        {
            var userToken = await _context.UserToken.Where(ut => ut.UserId.ToString().ToLower() == model.UserId.ToString().ToLower()).SingleOrDefaultAsync();
            if (userToken != null)
            {
                userToken.RefreshToken = model.RefreshToken.Trim();
                userToken.IsValid = model.IsValid;
                userToken.GenerationDate = model.GenerationDate;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteRefreshTokenByUserIdAsync(Guid userId)
        {
            var userToken = await _context.UserToken.Where(ut => ut.UserId.ToString().ToLower() == userId.ToString().ToLower()).SingleOrDefaultAsync();
            if (userToken != null)
            {
                _context.Remove(userToken);
                await _context.SaveChangesAsync();
            }
        }
    }
}
