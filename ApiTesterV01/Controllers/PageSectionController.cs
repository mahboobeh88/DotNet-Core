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
    
    public class PageSectionController : BaseController
    {
        private ISectionPageServices _spageSerices;
        public PageSectionController(ISectionPageServices spageSerices)
        {
            _spageSerices = spageSerices;
        }

        #region Gets : All , By Id  , By SectionType , By PageId
       /// <summary>
       /// Get All Section Pages In DB
       /// </summary>
       /// <returns></returns>
        [HttpGet("All/")]
       public async Task<IActionResult> GetAllAsync()
        {
            var sPages = await _spageSerices.GetAllAsync();
            return Ok(sPages);
        }

        /// <summary>
        /// Get By PageId
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        [HttpGet("ByPage/{pageId}")]
        public async Task<IActionResult> GetByPageIdAsync(int pageId)
        {
            var sPages = await _spageSerices.GetByPageIdAsync(pageId);
            return Ok(sPages);
        }
        /// <summary>
        /// Get By SectionPage Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var sPage = await _spageSerices.GetByPageIdAsync(id);
            return Ok(sPage);
        }
        /// <summary>
        /// Get by SectionType
        /// </summary>
        /// <param name="sectionType"></param>
        /// <returns></returns>
        [HttpGet("BySectionType/{sectionType}")]
        public async Task<IActionResult> GetBySectionTypeAsync(short sectionType)
        {
            var sPage = await _spageSerices.GetBySectionTypeAsync(sectionType);
            return Ok(sPage);
        }
        #endregion

        #region Post
        /// <summary>
        /// Add New Section Page
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Post(SectionPageViewModel model)
        {
            await _spageSerices.AddNewAsync(model);
            return Ok();
        }
        #endregion

        #region Put
        /// <summary>
        /// Update Section Page By Id
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put(SectionPageViewModel model)
        {
            await _spageSerices.UpdateSectionPageByIdAsync(model);
            return Ok();
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete Section Page By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _spageSerices.DeleteSectionPageByIdAsync(id);
            return Ok();
        }

        /// <summary>
        /// Delete All Section Page belong to a PageId
        /// </summary>
        /// <param name="pageId"></param>
        /// <returns></returns>
        [HttpDelete("ByPage/{pageId}")]
        public async Task<IActionResult> DeleteByPageAsync(int pageId)
        {
            await _spageSerices.DeleteSectionPagesByPageAsync(pageId);
            return Ok();
        }
        #endregion
    }
}
