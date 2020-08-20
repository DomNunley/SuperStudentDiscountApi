using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;
using SuperStudentDiscountApi.Services;

namespace SuperStudentDiscountApi.Controllers
{
    public class SuperStudentDiscountController : ControllerBase
    {
        [HttpGet("superstudentdiscount")]
        public ActionResult<SuperStudentDiscountResult> GetSuperStudentDiscount([FromBody] DriverRequestInfo driverRequestInfo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            DriverRequestInputsConverter requestConverter = new DriverRequestInputsConverter(driverRequestInfo);
            SuperStudentDiscountCriteria criteria = requestConverter.ConvertDriverRequest();
            SuperStudentDiscountResultProcessor discountProcessor = new SuperStudentDiscountResultProcessor(criteria);
            var response = discountProcessor.GetEligibilityResult();
            return Ok(response);
        }
    }
}
