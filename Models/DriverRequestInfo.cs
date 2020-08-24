using System.Collections.Generic;

namespace SuperStudentDiscountApi.Models
{
    public class DriverRequestInfo
    {
        public string State { get; set; }

        public int DriverAge { get; set; }

        public double DriverGPA { get; set; }

        public IEnumerable<string> Violations { get; set; }

        public string MaritalStatus { get; set; }

        public string Relationship { get; set; }

        public string StudentStatus { get; set; }
    }
}
