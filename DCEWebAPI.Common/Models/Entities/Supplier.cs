﻿

namespace DCEWebAPI.Common.Models.Entities
{
    public class Supplier
    {
        public Guid SupplierId { get; set; }
        public string SupplierName { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
