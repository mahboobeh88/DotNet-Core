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
    public class CategoryServices : ICategoryServices
    {
        private readonly APITesterDBContext _context;
        private IMapper _mapper;
        public CategoryServices(APITesterDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Gets : All , By CatgegoryId or ProductId
        public async Task<IEnumerable<CategoryViewModel>> GetAllAsync()
        {
           
            var Categories = await _context.Category.OrderByDescending(o => o.Id).AsNoTracking().ToListAsync();
            var CategoryModels = _mapper.Map<IEnumerable<CategoryViewModel>>(Categories);
            return CategoryModels;
        }
        public async Task<CategoryViewModel> GetCategoryAsync(int id)
        {
            var category = await _context.Category.Where(c => c.Id == id).AsNoTracking().SingleOrDefaultAsync();
            var categoryModel = _mapper.Map<CategoryViewModel>(category);
            return categoryModel;
        }
        public async Task<object> GetCategoryByProductIdAsync(int productId)
        {
            var category = await (
                from c in _context.Category
                join p in _context.Product
                on c.Id equals p.ProductUnitId
                where p.Id == productId
                select new { ProductId = p.Id, ProductName = p.Name, CategoryName = c.Name }).AsNoTracking().SingleOrDefaultAsync();
            return category;
        }
        #endregion Gets

        #region Add
        public async Task AddNewAsync(CategoryViewModel model)
        {
            var category = _mapper.Map<Category>(model);
            await _context.AddAsync<Category>(category);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Update
        public async Task UpdateCategoryAsync(CategoryViewModel model)
        {
            var oldCategory = await _context.Category.FindAsync(model.Id);
            oldCategory.Name = model.Name;
            await _context.SaveChangesAsync();
        }
        #endregion

        #region Delete
        public async Task DeleteCategoryAsync(int id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
