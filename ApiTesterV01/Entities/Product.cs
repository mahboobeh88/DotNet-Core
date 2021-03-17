using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public float Price { get; set; }
        public int ProductUnitId { get; set; }
        public int FactoryId { get; set; }
        public DateTime? ManufacturedDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public short Status { get; set; }
        public long CompanyId { get; set; }
        public virtual Company Company { get; set; }
        public virtual Category Category { get; set; }
        public virtual Factory Factory { get; set; }
        public virtual Unit Unit { get; set; }
        public virtual ICollection<StoreHouse> StoreHouses { get; set; }
    }
}
