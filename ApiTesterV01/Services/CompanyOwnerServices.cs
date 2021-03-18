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
    public class CompanyOwnerServices : ICompanyOwnerServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public CompanyOwnerServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Gets: All , By OwnerId , By CompanyId
        public async Task<IEnumerable<CompanyOwnerViewModel>> GetAllAsync()
        {
            var companyOwners = await _context.CompanyOwner.AsNoTracking().ToListAsync();
            var companyOwnerModel = _mapper.Map<IEnumerable<CompanyOwnerViewModel>>(companyOwners);
            return companyOwnerModel;
        }
        public async Task<CompanyOwnerViewModel> GetCompanyOwnerByIdAsync(int id)
        {
            var companyOwner = await _context.CompanyOwner.Where(c => c.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var companyOwnerModel = _mapper.Map<CompanyOwnerViewModel>(companyOwner);
            return companyOwnerModel;
        }
        public async Task<CompanyOwnerViewModel> GetCompanyOwnerByCompanyIdAsync(int companyId)
        {
            var companyOwner = await _context.CompanyOwner
                .Join(_context.Company, o => o.Id
                , co => co.CompanyOwnerId
                , (o, co) => o)
                .SingleOrDefaultAsync();

            var companyOwnerModel = _mapper.Map<CompanyOwnerViewModel>(companyOwner);
            return companyOwnerModel;
        }
        #endregion


        #region Add
        public async Task AddNewAsync(CompanyOwnerViewModel model)
        {
            var companyOwner = _mapper.Map<CompanyOwner>(model);
            await _context.AddAsync(companyOwner);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task UpdateCompanyOwnerByIdAsync(CompanyOwnerViewModel model)
        {
            var companyOwner = await _context.CompanyOwner.Where(co => co.Id == model.Id).SingleOrDefaultAsync();
            companyOwner.LastName = model.LastName;
            companyOwner.FirstName = model.FirstName;
            companyOwner.CityId = model.CityId;
            companyOwner.BirthDate = (DateTime)(model.BirthDate).ToMiladi();
            companyOwner.MobileNo = model.MobileNo;
            companyOwner.NationalId = model.NationalId;
            companyOwner.Status = model.Status;
            companyOwner.UserId = model.UserId;
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Delete
        public async Task DeleteCompanyOwnerByIdAsync(int id)
        {
            var companyOwner = await _context.CompanyOwner.Where(co => co.Id == id).SingleOrDefaultAsync();
            _context.Remove(companyOwner);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
