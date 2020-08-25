using System.Text.Json.Serialization;
namespace SuperStudentDiscountApi.Models
{
    public class SuperStudentDiscountDTO
    {
        
        [JsonPropertyName("state")]
        public string State { get; set; }
        [JsonPropertyName("driverage")]
        public int DriverAge { get; set; }
        [JsonPropertyName("drivereligiblegpa")]
        public double DriverEligibleGPA { get; set; }
        [JsonPropertyName("drivermediumgpa")]
        public double DriverMediumGPA { get; set; }
        [JsonPropertyName("driverhighgpa")]
        public double DriverHighGPA { get; set; }
        [JsonPropertyName("discountmediumamount")]
        public double DiscountMediumAmount { get; set; }
        [JsonPropertyName("discounthighamount")]
        public double DiscountHighAmount { get; set; }

    }
}