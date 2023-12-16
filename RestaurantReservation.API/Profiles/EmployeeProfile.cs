﻿using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employees , EmployeeDTO>();
            CreateMap<EmployeeForCreationDTO, Employees>();
            CreateMap<EmployeeDTO, Employees>();
        }
    }
}