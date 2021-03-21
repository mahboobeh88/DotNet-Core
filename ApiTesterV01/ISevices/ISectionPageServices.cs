using ApiTesterV01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.ISevices
{
   public interface ISectionPageServices
    {
        Task<IEnumerable<SectionPageViewModel>> GetAllAsync();
        Task<IEnumerable<SectionPageViewModel>> GetByPageIdAsync(int pageId);
        Task<SectionPageViewModel> GetByIdAsync(int id);
        Task<IEnumerable<SectionPageViewModel>> GetBySectionTypeAsync(short sectionType);

        Task AddNewAsync(SectionPageViewModel model);
        Task UpdateSectionPageByIdAsync(SectionPageViewModel model);
        Task DeleteSectionPageByIdAsync(int id);
        Task DeleteSectionPagesByPageAsync(int pageId);
    }
}
