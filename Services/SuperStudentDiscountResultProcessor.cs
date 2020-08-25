using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;
using SuperStudentDiscountApi.Mapper;

namespace SuperStudentDiscountApi.Services
{
    public class SuperStudentDiscountResultProcessor
    {
        public SuperStudentDiscountResultProcessor()
        {
            
        }
        public SuperStudentDiscountResult GetEligibilityResult(SuperStudentDiscountParms parms, SuperStudentDiscountCriteria driver)
        {
            return new SuperStudentDiscountResult { DiscountAmount = DiscountAmount(parms,driver), DiscountGranted = IsEligibleForDiscount(parms,driver) };
        }

        private bool IsEligibleForDiscount(SuperStudentDiscountParms parms, SuperStudentDiscountCriteria driver)
        {
            bool isEligible = false;

            if(driver.DriverAge < parms.DriverAge && 
                driver.DriverGPA >= parms.DriverEligibleGPA && 
                driver.DriverHasNoViolations && 
                driver.IsFullTimeStudent &&
                driver.DriverIsSingle && 
                driver.DriverRelationship.ToLower() == "child")
            {
                isEligible = true;
            }

            return isEligible;
        }

        private double DiscountAmount(SuperStudentDiscountParms parms, SuperStudentDiscountCriteria driver)
        {
            double discountAmount = 0;
            bool isEligible = IsEligibleForDiscount(parms,driver);

            if(isEligible && driver.DriverGPA >= parms.DriverHighGPA)
            {
                discountAmount = 40;
            }
            else if(isEligible && driver.DriverGPA >= parms.DriverMediumGPA)
            {
                discountAmount = 20;
            }

            return discountAmount;
        }
    }
}
