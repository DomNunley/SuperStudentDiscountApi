using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;

namespace SuperStudentDiscountApi.Services
{
    public class SuperStudentDiscountResultProcessor
    {
        private readonly SuperStudentDiscountCriteria _superStudentDiscountCriteria;

        public SuperStudentDiscountResultProcessor(SuperStudentDiscountCriteria superStudentDiscountCriteria)
        {
            _superStudentDiscountCriteria = superStudentDiscountCriteria;
        }

        public SuperStudentDiscountResult GetEligibilityResult()
        {
            return new SuperStudentDiscountResult { DiscountAmount = DiscountAmount(), DiscountGranted = IsEligibleForDiscount() };
        }

        private bool IsEligibleForDiscount()
        {
            bool isEligible = false;

            if(_superStudentDiscountCriteria.DriverAge < 30 && 
                _superStudentDiscountCriteria.DriverGPA >= 3.5 && 
                _superStudentDiscountCriteria.DriverHasNoViolations && 
                _superStudentDiscountCriteria.IsFullTimeStudent &&
                _superStudentDiscountCriteria.DriverIsSingle && 
                _superStudentDiscountCriteria.DriverRelationship.ToLower() == "child")
            {
                isEligible = true;
            }

            return isEligible;
        }

        private double DiscountAmount()
        {
            double discountAmount = 0;
            bool isEligible = IsEligibleForDiscount();

            if(isEligible && _superStudentDiscountCriteria.DriverGPA >= 3.8)
            {
                discountAmount = 40;
            }
            else if(isEligible && _superStudentDiscountCriteria.DriverGPA >= 3.5)
            {
                discountAmount = 20;
            }

            return discountAmount;
        }
    }
}
