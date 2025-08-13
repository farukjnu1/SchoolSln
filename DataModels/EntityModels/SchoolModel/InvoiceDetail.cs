using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.SchoolModel
{
    public partial class InvoiceDetail
    {
        public int? Id { get; set; }
        public int? InvoiceId { get; set; }
        public int? ItemId { get; set; }
        public int? Unit { get; set; }
        public int? Rate { get; set; }
    }
}
