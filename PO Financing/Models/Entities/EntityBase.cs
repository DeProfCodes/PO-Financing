using System;

namespace PO_Financing.Models.Entities
{
    public class EntityBase
    {
        public long Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
