using System;
using AutoMapper;
using SuperStudentDiscountApi.Domain;
using SuperStudentDiscountApi.Models;
namespace SuperStudentDiscountApi.Config
{
    public class SuperStudentDiscountConfig:Profile
    {
        public SuperStudentDiscountConfig()
        {
            CreateMap<SuperStudentDiscountDTO,SuperStudentDiscountMongo>()
                .ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<SuperStudentDiscountMongo,SuperStudentDiscountDTO>();
            CreateMap<SuperStudentDiscountMongo,SuperStudentDiscountParms>();

        }
    }
}