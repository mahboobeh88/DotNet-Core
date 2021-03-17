using ApiTesterV01.ISevices;
using ApiTesterV01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Controllers
{

    public class CategoryController : BaseController
    {
        private ICategoryServices _categoryServices;
        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        #region Gets : All , By Id or ProductId
        /// <summary>
        /// Get All Categories in DB
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryServices.GetAllAsync();
            return Ok(categories);
        }

        /// <summary>
        /// Get Category By Id or ProductId 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="byProduct"></param>
        /// <returns></returns>
        [HttpGet("{id}, {byProduct}")]
       public async Task<IActionResult> Get(int id , bool byProduct= false)
        {
            if (!byProduct)
            {
                var category = await _categoryServices.GetCategoryAsync(id);
                return Ok(category);
            }
            else
            {
                var category = await _categoryServices.GetCategoryByProductIdAsync(id);
                return Ok(category);
            }
        }
        #endregion


        #region Post
        /// <summary>
        /// insert New Category In DB
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(CategoryViewModel model )
        {
            await _categoryServices.AddNewAsync(model);
            return Ok();
        }
        #endregion


        #region Put
        /// <summary>
        /// Update a category absolutly just Name
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> Put(CategoryViewModel model)
        {
            await _categoryServices.UpdateCategoryAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a Category from DB
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id )
        {
            await _categoryServices.DeleteCategoryAsync(id);
            return Ok();
        }
        #endregion
    }
}
