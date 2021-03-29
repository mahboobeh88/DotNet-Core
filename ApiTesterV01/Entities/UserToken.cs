using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class UserToken
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public string RefreshToken { get; set; }
        public DateTime GenerationDate { get; set; }
        public bool IsValid { get; set; }
        public User User { get; set; }
    }
}
