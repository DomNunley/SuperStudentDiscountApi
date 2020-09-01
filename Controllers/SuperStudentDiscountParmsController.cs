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
    [ApiController]
    public class SuperStudentParmsDiscountController : ControllerBase
    {
        private readonly SuperStudentDiscountMap _superStudentDiscountMap;
        public SuperStudentParmsDiscountController(SuperStudentDiscountMap superStudentDiscountMap)
        {
            _superStudentDiscountMap = superStudentDiscountMap;
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SuperStudentDiscountDTO discountDTO)
        {
            bool result = await _superStudentDiscountMap.UpdateDiscount(discountDTO);
            var response = new
            {
                status =  result ? $"{discountDTO.State} updated": "{discountDTO.State} NOT updated"
            };
            return Ok(response);
            //return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _superStudentDiscountMap.GetDiscounts();
            var discountsDTO = new 
            {
                discounts = result
            };
            return Ok(discountsDTO);
        }

        [HttpGet("{state}")]
        public async Task<ActionResult> Get(string state)
        {
            var result = await _superStudentDiscountMap.GetDiscountParms(state);
            return Ok(result);
        }
    }
}
        