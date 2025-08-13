using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.SchoolModel
{
    public partial class StudentPosition
    {
        public int Id { get; set; }
        public int? RollNo { get; set; }
        public int? StudentId { get; set; }
        public int? ClassId { get; set; }
        public int? SectionId { get; set; }
        public int? ShiftId { get; set; }
        public DateTime? SectionStartDate { get; set; }
        public DateTime? SectionEndDate { get; set; }
        public string LastSchoolName { get; set; }
        public DateTime AdmissionDate { get; set; }
    }
}
