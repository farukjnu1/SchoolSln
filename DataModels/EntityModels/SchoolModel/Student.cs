using System;
using System.Collections.Generic;

namespace DataModels.EntityModels.SchoolModel
{
    public partial class Student
    {
        public int StudentId { get; set; }
        public int? Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public int? Mobile { get; set; }
        public DateTime? Dob { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string BloodGroup { get; set; }
    }
}
