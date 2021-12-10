using System;
using System.Collections.Generic;

#nullable disable

namespace Groot.DB.Entities
{
    public partial class User
    {
        public User()
        {
            Category = new HashSet<Category>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idatetime { get; set; }
        public DateTime? UdateTime { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual ICollection<Category> Category { get; set; }
    }
}
