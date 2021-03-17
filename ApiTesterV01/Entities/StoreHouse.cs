using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class StoreHouse
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public int FirstInventory { get; set; }
        public DateTime InventoryStartDateTime { get; set; }
        public DateTime  InventoryEndDateTime { get; set; }
        public short UnitId { get; set; }
        [ForeignKey("Company")]
        public long ComapnyId { get; set; }
        public short Status { get; set; }
        public virtual Company Company { get; set; }
        public virtual Product Product { get; set; }

    }
}
