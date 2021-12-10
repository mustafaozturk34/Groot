using System;
using System.Collections.Generic;

#nullable disable

namespace Groot.DB.Entities
{
    public partial class Product
    {
        public int CategoryId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Idate { get; set; }
        public DateTime? Udate { get; set; }
        public int Iuser { get; set; }
        public int? Uuser { get; set; }

        public virtual Category Category { get; set; }
        public virtual User IuserNavigation { get; set; }
    }
}
