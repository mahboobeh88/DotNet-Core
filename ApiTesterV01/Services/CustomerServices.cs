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
    public class CustomerServices : ICustomerServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public CustomerServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region Gets : All , By Id , By UserId, By UserName , By NationalId , By CityId
        public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
        {
            var customers = await _context.Customer.AsNoTracking().ToListAsync();
            var customerModel = _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
            return customerModel;
        }
        public async Task<CustomerViewModel> GetCustomerBydIdAsync(int customerId)
        {
            var customer = await _context.Customer.Where(c => c.Id == customerId).AsNoTracking().SingleOrDefaultAsync();
            var customerModel = _mapper.Map<CustomerViewModel>(customer);
            return customerModel;

        }
        public async Task<CustomerViewModel> GetCustomerByUserIdAsync(string userId)
        {
            var customer = await _context.Customer.Where(c => c.UserId.ToString() == userId.Trim()).AsNoTracking().SingleOrDefaultAsync();
            var customerModel = _mapper.Map<CustomerViewModel>(customer);
            return customerModel;
        }
        public async Task<CustomerViewModel> GetCustomerByUserNameAsync(string userName)
        {
            var customer = await _context.Customer
                .Join(_context.User
                , c => c.UserId
                , u => u.Id
                , (c, u) =>
                new 
                { c, u.UserName })
                .Where(c => c.UserName.Trim() == userName.Trim()).AsNoTracking().SingleOrDefaultAsync();
            var customerModel = _mapper.Map<CustomerViewModel>(customer);
            return customerModel;
        }
        public async Task<IEnumerable<CustomerViewModel>> GetCustomerByCityIdAsync(int cityId)
        {
            var customers = await _context.Customer
                .Where(c=> c.CityId == cityId)
                .AsNoTracking()
                .ToListAsync();
            var customerModel = _mapper.Map<IEnumerable<CustomerViewModel>>(customers);
            return customerModel;
        }
        public async Task<CustomerViewModel> GetCustomerByNationalIdAsync(string NationalId)
        {
            var customer = await _context.Customer
                .Where(c => c.NationalId.Trim() == NationalId.Trim())
                .AsNoTracking()
                .SingleOrDefaultAsync();
            var customerModel = _mapper.Map<CustomerViewModel>(customer);
            return customerModel;
        }
        #endregion

        #region Add
        public async Task AddnewAsync(CustomerViewModel model)
        {
            var customer = _mapper.Map<Customer>(model);
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateCustomerInfoAsync(CustomerViewModel model)
        {
            var customer = await _context.Customer.Where(c => c.Id == model.Id).SingleOrDefaultAsync();
            customer.FirstName = model.FirstName.Trim();
            customer.LastName = model.LastName.Trim();
            customer.Mobile = model.Mobile;
            customer.BirthDate = (DateTime)(model.BirthDate.ToMiladi());
            customer.CityId = model.CityId;
            customer.CreditCardNumber = model.CreditCardNumber.Trim();
            customer.Status = model.Status;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteCustomerByIdAsync(int customerId)
        {
            var customer = await _context.Customer.Where(c => c.Id == customerId).SingleOrDefaultAsync();
            _context.Remove(customer);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
