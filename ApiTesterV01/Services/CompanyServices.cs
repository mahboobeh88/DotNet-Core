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
    public class CompanyServices : ICompanyServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public CompanyServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Gets:
        public async Task<IEnumerable<CompanyViewModel>> GetAllAsync()
        {
            var companies = await _context.Company.AsNoTracking().ToListAsync();
            var companyModel = _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
            return companyModel;

        }
        public async Task<CompanyViewModel> GetCompanyByIdAsync(int id)
        {
            var company = await _context.Company.Where(c => c.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var companyModel = _mapper.Map<CompanyViewModel>(company);
            return companyModel;
        }
        public async Task<IEnumerable<CompanyViewModel>> GetAllByCompanyOwnerIdAsync(int companyOwnerId)
        {
            var companies = await _context.Company.Where(c => c.CompanyOwnerId == companyOwnerId).AsNoTracking().ToListAsync();
            var companyModel = _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
            return companyModel;
        }
        public async Task<IEnumerable<CompanyViewModel>> GetAllByUserIdAsync(string userId)
        {
            var companies = await _context.Company
                .Join(_context.CompanyOwner
                , c => c.CompanyOwnerId
                , co => co.Id
                , (c, co) =>
                 new
                 {
                     c,
                     co.UserId
                 })
                .Where(o => o.UserId.ToString() == userId.Trim())
                .Select(r => r.c)
                .AsNoTracking()
                .ToListAsync();

            var companyModel = _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
            return companyModel;

        }
        public async Task<IEnumerable<CompanyViewModel>> GetAllByCityIdAsync(int cityId)
        {
            var companies = await _context.Company.Where(c => c.CityId != null && c.CityId == cityId).AsNoTracking().ToListAsync();
            var companyModel = _mapper.Map<IEnumerable<CompanyViewModel>>(companies);
            return companyModel;
        }
        #endregion

        #region Add
        public async Task AddNewAsync(CompanyViewModel model)
        {
            var company = _mapper.Map<Company>(model);
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateCompanyInfoByIdAsync(CompanyViewModel model)
        {
            var company = await _context.Company.Where(c => c.Id == model.Id).SingleOrDefaultAsync();
            company.CompanyOwnerId = model.CompanyOwnerId;
            company.CityId = model.CityId;
            company.Address = model.Address;
            company.AccountNumber = model.AccountNumber;
            company.Name = model.Name;
            company.PhoneNumber = model.PhoneNumber;
            company.RegisterDateTime = (DateTime)(model.RegisterDateTime.ToMiladi());
            company.Status = model.Status;
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Delete
        public async Task DeleteCompanyByIdAsync(int id)
        {
            var company = await _context.Company.Where(c => c.Id == id).SingleOrDefaultAsync();
            _context.Remove(company);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompanyByCompanyOwnerIdAsync(int companyOwnerId)
        {
            var companies = await _context.Company.Where(c => c.CompanyOwnerId == companyOwnerId).ToListAsync();
            _context.RemoveRange(companies);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteCompanyByUserIdAsync(string userid)
        {
            var companies = await _context.Company
               .Join(_context.CompanyOwner
               , c => c.CompanyOwnerId
               , co => co.Id
               , (c, co) =>
                new
                {
                    c,
                    co.UserId
                })
               .Where(o => o.UserId.ToString() == userid.Trim())
               .Select(r => r.c)
               .ToListAsync();
            _context.RemoveRange(companies);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
