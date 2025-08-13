using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.SchoolModel
{
    public partial class Shift
    {
        public int ShiftId { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
