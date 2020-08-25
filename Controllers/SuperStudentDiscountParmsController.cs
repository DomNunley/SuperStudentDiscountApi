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
            await _superStudentDiscountMap.UpdateDiscount(discountDTO);
            return Ok("success");
        }
    }
}
        