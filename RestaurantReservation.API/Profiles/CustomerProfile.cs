using AutoMapper;
using RestaurantReservation.API.Models;
using RestaurantReservation.Db.Models;

namespace RestaurantReservation.API.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customers , CustomerDTO>();
            CreateMap<CustomerForCreationDTO , Customers>();
            CreateMap<CustomerDTO , Customers>();
        }
    }
}