using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class StoreHouseViewModel
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public long ProductId { get; set; }
        public int FirstInventory { get; set; }
        [MinLength(10)]
        [MaxLength(10)]
        public string InventoryStartDateTime { get; set; }
        [StringLength(10)]
        public string InventoryEndDateTime { get; set; }
        [Required]
        public short UnitId { get; set; }
        [Required]
        public long ComapnyId { get; set; }
        public short Status { get; set; }
    }
}
