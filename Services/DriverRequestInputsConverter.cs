using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SuperStudentDiscountApi.Services
{
    public class DriverRequestInputsConverter
    {
        private readonly DriverRequestInfo _driverRequestInfo;

        public DriverRequestInputsConverter(DriverRequestInfo driverRequestInfo)
        {
            _driverRequestInfo = driverRequestInfo;
        }

        public SuperStudentDiscountCriteria ConvertDriverRequest()
        {
            return new SuperStudentDiscountCriteria
            {
                DriverAge = _driverRequestInfo.DriverAge,
                DriverGPA = _driverRequestInfo.DriverGPA,
                DriverRelationship = _driverRequestInfo.Relationship,
                DriverHasNoViolations = HasNoViolations(),
                DriverIsSingle = IsSingleDriver(),
                IsFullTimeStudent = IsFullTimeStudent()
            };
        }

        private bool HasNoViolations()
        {
            return _driverRequestInfo.Violations.ToList().Count == 0; //If no violations are in the collection then driver has no violations
        }

        private bool IsSingleDriver()
        {
            return _driverRequestInfo.MaritalStatus.ToLower() == "single" || _driverRequestInfo.MaritalStatus.ToLower() == "divorced";
        }

        private bool IsFullTimeStudent()
        {
            return _driverRequestInfo.StudentStatus.ToLower().Contains("enrolled");
        }
    }
}
