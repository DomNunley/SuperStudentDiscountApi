using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace SuperStudentDiscountApi.Models
{
    public class SuperStudentDiscountMongo
    {
        public ObjectId Id { get; set; }
        [BsonElement("state")]
        public string State { get; set; }
        [BsonElement("driverage")]
        public int DriverAge { get; set; }
        [BsonElement("drivereligiblegpa")]
        public double DriverEligibleGPA { get; set; }
        [BsonElement("drivermediumgpa")]
        public double DriverMediumGPA { get; set; }
        [BsonElement("driverhighgpa")]
        public double DriverHighGPA { get; set; }
        [BsonElement("discountmediumamount")]
        public double DiscountMediumAmount { get; set; }
        [BsonElement("discounthighamount")]
        public double DiscountHighAmount { get; set; }

    }
}