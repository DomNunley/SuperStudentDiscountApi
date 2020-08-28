using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;
using SuperStudentDiscountApi.Services;
using SuperStudentDiscountApi.Mapper;

namespace SuperStudentDiscountApi.Controllers
{
    [Route("api/[controller]")]
    public class SuperStudentDiscountController : ControllerBase
    {
        private readonly SuperStudentDiscountResultProcessor _discountProcessor;
        private readonly SuperStudentDiscountMap _superStudentDiscountMap;

        public SuperStudentDiscountController(SuperStudentDiscountResultProcessor discountProcessor, SuperStudentDiscountMap superStudentDiscountMap)
        {
            _discountProcessor = discountProcessor;
            _superStudentDiscountMap = superStudentDiscountMap;
        }
        
        [HttpPost]
        public async Task<ActionResult<SuperStudentDiscountResult>> GetSuperStudentDiscount([FromBody] DriverRequestInfo driverRequestInfo)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            DriverRequestInputsConverter requestConverter = new DriverRequestInputsConverter(driverRequestInfo);
            SuperStudentDiscountCriteria driver = requestConverter.ConvertDriverRequest();
            //SuperStudentDiscountResultProcessor discountProcessor = new SuperStudentDiscountResultProcessor(criteria);
            var parms = await _superStudentDiscountMap.GetDiscountParms(driverRequestInfo.State);
            var response = _discountProcessor.GetEligibilityResult(parms,driver);
            return Ok(response);
        }
    }
}
