using AutoMapper;
using CarShopWeb.Application.DTOs.AccountDetailDTOs;
using CarShopWeb.Application.DTOs.CarBrandDTOs;
using CarShopWeb.Application.DTOs.CarModelDTOs;
using CarShopWeb.Application.DTOs.CarsDTOs;
using CarShopWeb.Application.DTOs.ContactTypeDTOs;
using CarShopWeb.Application.DTOs.CustomersDTOs;
using CarShopWeb.Application.DTOs.FeaturesDTOs;
using CarShopWeb.Application.DTOs.OrdersDTOs;
using CarShopWeb.Application.DTOs.PaymentsDTOs;
using CarShopWeb.Application.DTOs.UsersDTOs;
using CarShopWeb.Domain.Entities;
using CarShopWeb.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopWeb.Application.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cars,CreateCarDTO>().ReverseMap();
            CreateMap<Cars,GetCarsDTO>().ReverseMap();
            CreateMap<Cars,UpdateCarsDTO>().ReverseMap();
            CreateMap<Customers,CustomersCreateDTO>().ReverseMap();
            CreateMap<Customers,CustomersGetDTO>().ReverseMap();
            CreateMap<Customers,CustomersUpdateDTO>().ReverseMap();
            CreateMap<Features,CreateFeaturesDTO>().ReverseMap();
            CreateMap<Features,GetFeaturesDTO>().ReverseMap();
            CreateMap<Features,UpdateFeaturesDTO>().ReverseMap();
            CreateMap<Orders,CreateOrdersDTO>().ReverseMap();
            CreateMap<Orders,GetOrdersDTO>().ReverseMap();
            CreateMap<Orders,UpdateOrdersDTO>().ReverseMap();
            CreateMap<AccountDetail,CreateAccountDetailDTO>().ReverseMap();
            CreateMap<AccountDetail,GetAccountDetailsDTO>().ReverseMap();
            CreateMap<AccountDetail, UpdateAccountDetailDTO>().ReverseMap();
            CreateMap<ContactType,CreateContactTypeDTO>().ReverseMap();
            CreateMap<ContactType, GetContactTypeDTO>().ReverseMap();
            CreateMap<ContactType, UpdateContactTypeDTO>().ReverseMap();
            CreateMap<Payments,CreatePaymentsDTO>().ReverseMap();
            CreateMap<Payments, GetPaymentsDTO>().ReverseMap();
            CreateMap<Payments, UpdatePaymentsDTO>().ReverseMap();
            CreateMap<AppUser, CreateUserDTO>().ReverseMap();
            CreateMap<AppUser, UserGetDTO>().ReverseMap();
            CreateMap<AppUser, UserUpdateDTO>().ReverseMap();
            CreateMap<CarBrand,CreateCarBrandDTO>().ReverseMap();
            CreateMap<CarBrand, GetCarBrandDTO>().ReverseMap();
            CreateMap<CarBrand, UpdateCarBrandDTO>().ReverseMap();
            CreateMap<CarModel, CreateCarModelDTO>().ReverseMap();
            CreateMap<CarModel, GetCarModelDTO>().ReverseMap();
            CreateMap<CarModel, UpdateCarModelDTO>().ReverseMap();
        }
    }
}
