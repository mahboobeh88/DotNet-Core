using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Media
    {
        public long Id { get; set; }
        public MediaType MediaType { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public byte[] File { get; set; }
    }
}
