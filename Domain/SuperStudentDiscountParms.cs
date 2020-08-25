namespace SuperStudentDiscountApi.Models
{
    public class SuperStudentDiscountParms
    {
        public string State { get; set; }
        public int DriverAge { get; set; }       
        public double DriverEligibleGPA { get; set; }
        public double DriverMediumGPA { get; set; }
        public double DriverHighGPA { get; set; }
        public double DiscountMediumAmount { get; set; }
        public double DiscountHighAmount { get; set; }
    }
}