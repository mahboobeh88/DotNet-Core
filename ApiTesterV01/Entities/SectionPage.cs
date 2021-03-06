using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class SectionPage
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public SectionType SectionType { get; set; }
        [ForeignKey("Page")]
        public long PageId { get; set; }
        [ForeignKey ("Media")]
        public long? MediaId { get; set; }
        public string ContentText { get; set; }
        public virtual Page Page{ get; set; }
        public virtual Media Media { get; set; }


    }
}
