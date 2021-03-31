using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesterV01.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Guid PasswordSalt { get; set; }
        public bool IsActive { get; set; }
        public short Status { get; set; }
        public virtual CompanyOwner companyOwner { get; set; }
        public virtual Customer customer { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

    }
}
