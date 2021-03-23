using ApiTesterV01.Common;
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
    public class UserServices : IUserServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        private EncryptionUtility _encryption;
        public UserServices(APITesterDBContext context, IMapper mapper , EncryptionUtility encryption)
        {
            _context = context;
            _mapper = mapper;
            _encryption = encryption;
        }

        #region Gets : All , By Id , By UserName
        public async Task<IEnumerable<UserViewModel>> GetAllAsync()
        {
            var users = await _context.User.AsNoTracking().ToListAsync();
            var userModel = _mapper.Map<IEnumerable<UserViewModel>>(users);
            return userModel;
        }
        public async Task<UserViewModel> GetUserByUserNameAsync(string userName)
        {
            var user = await _context.User.Where(u => u.UserName.Trim() == userName.Trim()).AsNoTracking().SingleOrDefaultAsync();
            var userModel = _mapper.Map<UserViewModel>(user);
            return userModel;
        }
        public async Task<UserViewModel> GetUserByIdAsync(string id)
        {
            var user = await _context.User.Where(u => u.Id.ToString() == id).AsNoTracking().SingleOrDefaultAsync();
            var userModel = _mapper.Map<UserViewModel>(user);
            return userModel;
        }
        public async Task<UserViewModel> GetUserByUserNamePasswordAsync(string userName , string password)
        {
            string hashPass = _encryption.Encription(password);
            var user = await _context.User.Where(u => u.UserName.Trim() == userName.Trim()  && u.Password.Trim() == hashPass + u.PasswordSalt.ToString()).AsNoTracking().SingleOrDefaultAsync();
            
            var userModel = _mapper.Map<UserViewModel>(user);
            return userModel;
           
        }

        #endregion

        #region Add
        public async Task AddNewAsync(UserViewModel model)
        {
           
            var user = _mapper.Map<User>(model);
            user.PasswordSalt = Guid.NewGuid();
            //Make hash Password :
            user.Password = _encryption.HashWithSalt(model.Password , user.PasswordSalt.ToString());
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateUserByUserNameAsync(UserViewModel model)
        {
            var user = await _context.User.Where(u => u.UserName == model.UserName).SingleOrDefaultAsync();
            user.UserName = model.UserName.Trim();
            user.IsActive = model.IsActive;
            user.Password = model.Password.Trim();
            user.Status = model.Status;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateUserByIdAsync(UserViewModel model)
        {
            var user = await _context.User.Where(u => u.Id == model.Id).SingleOrDefaultAsync();
            user.UserName = model.UserName.Trim();
            user.IsActive = model.IsActive;
            user.Password = model.Password.Trim();
            user.Status = model.Status;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete: By UserName , By Id
        public async Task DeleteUserByUserNameAsync(string userName)
        {
            var user = await _context.User.Where(u => u.UserName.Trim() == userName.Trim()).SingleOrDefaultAsync();
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteUserByIdAsync(string id)
        {
            var user = await _context.User.Where(u => u.Id.ToString() == id.Trim()).SingleOrDefaultAsync();
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
