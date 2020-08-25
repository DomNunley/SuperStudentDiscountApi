using System;
using System.Threading.Tasks;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;
namespace SuperStudentDiscountApi.Mapper
{
    public class SuperStudentDiscountMap
    {
        private readonly IMapper _mapper;
        private readonly DbContext _context = null;
        public SuperStudentDiscountMap(IMapper mapper,IOptions<Settings> settings)
        {
            _mapper = mapper;
            _context = new DbContext(settings);;
        }

        public async Task<List<SuperStudentDiscountDTO>> GetDiscounts()
        {
            var  discounts = await _context.SuperStudentDiscounts.Find(_ => true).ToListAsync();
            return discounts.Select((discountMongo) => _mapper.Map<SuperStudentDiscountDTO>(discountMongo)).ToList();
        }

        public async Task<bool> UpdateDiscount(SuperStudentDiscountDTO discountDTO)
        {
            
            var studentDiscount = _mapper.Map<SuperStudentDiscountMongo>(discountDTO);
            var findDiscount = await _context.SuperStudentDiscounts.FindAsync(x => x.State == studentDiscount.State);
            if(findDiscount!=null)
            {
                await _context.SuperStudentDiscounts.DeleteOneAsync(x => x.State == studentDiscount.State);
                await _context.SuperStudentDiscounts.InsertOneAsync(studentDiscount);
            }
            else
            {
                await _context.SuperStudentDiscounts.InsertOneAsync(studentDiscount);
            }
            return true;
        }
    }
}