using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperStudentDiscountApi.Domain
{
    public class SuperStudentDiscountCriteria
    {
        public int DriverAge { get; set; }

        public double DriverGPA { get; set; }

        public bool DriverIsSingle { get; set; }

        public string DriverRelationship { get; set; }

        public bool DriverHasNoViolations { get; set; }

        public bool IsFullTimeStudent { get; set; }
    }
}
