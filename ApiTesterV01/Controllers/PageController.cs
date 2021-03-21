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
   
    public class PageController : BaseController
    {
        private IPageServices _pageServices;
        public PageController(IPageServices pageServices)
        {
            _pageServices = pageServices;
        }

        #region Gets : All , By Id , By CompanyId , By PageTypeId 
        /// <summary>
        /// Get All Pages In DB
        /// </summary>
        /// <returns></returns>
        [HttpGet("All/")]
        public async Task<IActionResult> GetAllAsync()
        {
            var pages = await _pageServices.GetAllAsync();
            return Ok(pages);
        }

        /// <summary>
        /// Get All Pages belong to a CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("ByCompany/{companyId}")]
        public async Task<IActionResult> GetByCompanyAsync(int companyId)
        {
            var pages = await _pageServices.GetByCompanyIdAsync(companyId);
            return Ok(pages);
        }
        /// <summary>
        /// Get Page By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var page = await _pageServices.GetByIdAsync(id);
            return Ok(page);
        }
        /// <summary>
        /// Get All Pages with a special PageTypeId
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("ByType/{typeId}")]
        public async Task<IActionResult> GetByTypeIdAsync(int id)
        {
            var pages = await _pageServices.GetByPageTypeAsync(id);
            return Ok(pages);
        }
        #endregion

        #region Post
        /// <summary>
        /// Add New Page 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(PageViewModel model)
        {
            await _pageServices.AddNewAsync(model);
            return Ok();
        }
        #endregion

        #region Put
        /// <summary>
        /// Update a page By Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(PageViewModel model)
        {
            await _pageServices.UpdatePageByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete a Page By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(int id)
        {
            await _pageServices.DeletePageByIdAsync(id);
            return Ok();
        }

        /// <summary>
        /// Delete All Pages Belong to a Company
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpDelete("ByCompany/{companyId}")]
        public async Task<IActionResult> DeleteByCompanyAsync(int companyId)
        {
            await _pageServices.DeletePagesByCompanyAsync(companyId);
            return Ok();
        }
        #endregion
    }
}
