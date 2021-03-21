using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Page
    {
        
        public long Id { get; set; }
        [ForeignKey("Company")]
        public long CompanyId { get; set; }
        public string PageName { get; set; }
        public PageType PageType { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<SectionPage> SectionPages { get; set; }
    }
}
