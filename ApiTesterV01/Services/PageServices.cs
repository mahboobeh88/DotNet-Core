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
    public class PageServices : IPageServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public PageServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PageViewModel>> GetAllAsync()
        {
            var pages = await _context.Pages.AsNoTracking().ToListAsync();
            var pageModel = _mapper.Map<IEnumerable<PageViewModel>>(pages);
            return pageModel;
        }
        public async Task<IEnumerable<PageViewModel>> GetByCompanyIdAsync(int companyId)
        {
            var pages = await _context.Pages.Where(p => p.CompanyId == companyId).AsNoTracking().ToListAsync();
            var pageModel = _mapper.Map<IEnumerable<PageViewModel>>(pages);
            return pageModel;
        }
        public async Task<IEnumerable<PageViewModel>> GetByPageTypeAsync(int type)
        {
            var pages = await _context.Pages.Where(p => p.PageType == (PageType)type).AsNoTracking().ToListAsync();
            var pageModel = _mapper.Map<IEnumerable<PageViewModel>>(pages);
            return pageModel;
        }
        public async Task<PageViewModel> GetByIdAsync(int id)
        {
            var page = await _context.Pages.Where(p => p.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var pageModel = _mapper.Map<PageViewModel>(page);
            return pageModel;
        }

        public async Task AddNewAsync(PageViewModel model)
        {
            if (model != null)
            {
                var page = _mapper.Map<Page>(model);
                await _context.AddAsync(page);
                await _context.SaveChangesAsync();
            }

        }
        public async Task UpdatePageByIdAsync(PageViewModel model)
        {

            var page = await _context.Pages.Where(p => p.Id == model.Id).SingleOrDefaultAsync();
            if (page != null)
            {
                page.CompanyId = model.CompanyId;
                page.PageName = model.PageName;
                page.PageType = (PageType)model.PageType;
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeletePageByIdAsync(int id)
        {
            var page = await _context.Pages.Where(p => p.Id == id).SingleOrDefaultAsync();
            if (page != null)
            {
                _context.Remove(page);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeletePagesByCompanyAsync(int companyId)
        {
            var pages = await _context.Pages.Where(p => p.CompanyId == companyId).ToListAsync();
            if (pages.Count > 0)
            {
                _context.RemoveRange(pages);
                await _context.SaveChangesAsync();
            }
           
        }
    }
}
