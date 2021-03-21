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
    public class SectionPageServices : ISectionPageServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public SectionPageServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #region Gets : All , By Id , By PageId , BySectionType
        public async Task<IEnumerable<SectionPageViewModel>> GetAllAsync()
        {
            var spages = await _context.SectionPage.AsNoTracking().ToListAsync();
            var sPageModel = _mapper.Map<IEnumerable<SectionPageViewModel>>(spages);
            return sPageModel;

        }
        public async Task<IEnumerable<SectionPageViewModel>> GetByPageIdAsync(int pageId)
        {
            var spages = await _context.SectionPage.Where(p => p.PageId == pageId).AsNoTracking().ToListAsync();
            var sPageModel = _mapper.Map<IEnumerable<SectionPageViewModel>>(spages);
            return sPageModel;
        }
        public async Task<SectionPageViewModel> GetByIdAsync(int id)
        {
            var spages = await _context.SectionPage.Where(p => p.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var sPageModel = _mapper.Map<SectionPageViewModel>(spages);
            return sPageModel;
        }
        public async Task<IEnumerable<SectionPageViewModel>> GetBySectionTypeAsync(short sectionType)
        {
            var spages = await _context.SectionPage.Where(p => p.SectionType == (SectionType)sectionType).AsNoTracking().ToListAsync();
            var sPageModel = _mapper.Map<IEnumerable<SectionPageViewModel>>(spages);
            return sPageModel;
        }

        #endregion
        #region Add
        public async Task AddNewAsync(SectionPageViewModel model)
        {
            var sPage = _mapper.Map<SectionPage>(model);
            await _context.AddAsync(sPage);
            await _context.SaveChangesAsync();
        }
        #endregion
        #region Update
        public async Task UpdateSectionPageByIdAsync(SectionPageViewModel model)
        {
            var spage = await _context.SectionPage.Where(p => p.Id == model.Id).SingleOrDefaultAsync();
            if (spage != null)
            {
                spage.MediaId = model.MediaId;
                spage.PageId = model.PageId;
                spage.Title = model.Title.Trim();
                spage.ContentText = model.ContentText.Trim().Substring(0, 500);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
        #region Delete
        public async Task DeleteSectionPageByIdAsync(int id)
        {
            var spage = await _context.SectionPage.Where(p => p.Id == id).SingleOrDefaultAsync();
            if (spage != null)
            {
                _context.Remove(spage);
                await _context.SaveChangesAsync();
            }
        }
        public async Task DeleteSectionPagesByPageAsync(int pageId)
        {
            var spages = await _context.SectionPage.Where(p => p.PageId == pageId).ToListAsync();
            if (spages != null)
            {
                _context.RemoveRange(spages);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
