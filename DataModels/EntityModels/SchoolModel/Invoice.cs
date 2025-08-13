using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.SchoolModel
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DueDate { get; set; }
        public int? InvoiceTotal { get; set; }
        public int? PaidAmount { get; set; }
        public int? Discount { get; set; }
    }
}
