using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Models
{
    public class UserTokenViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public string RefreshToken { get; set; }
        public DateTime GenerationDate { get; set; }
        public bool IsValid { get; set; }
    }
}
