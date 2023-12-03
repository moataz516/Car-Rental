using AutoMapper;
using CarRental.Models;
using CarRental.Models.Dtos;

namespace CarRental.Helpers
{
    public class MappingProfile : Profile
    {

        public MappingProfile() {
            //CreateMap<Car, CarDto>().ForMember(des => des.image, opt => opt.MapFrom(s =>
            //Convert.ToBase64String(System.IO.File.
            //ReadAllBytes(Path.Combine(@"P:\Angular and .Net\CarRental\wwwroot\Images\carImage", s.image))))).ReverseMap();


            CreateMap<Car, CarDto>().ForMember(des => des.image, opt => 
            opt.MapFrom(s => s.image == null ? "" :
                Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(@"P:\Angular and .Net\CarRental\wwwroot\Images\carImage", s.image)))))
                .ForMember(dest => dest.Brand , opt => opt.MapFrom(src => src.Brand))
                .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.CarFeatures.Select(ccf => ccf.CarFeature)))
                .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(src => src.VehicleType))
                .ReverseMap();


            
            CreateMap<CarFeature, CarFeatureDto>().ReverseMap();
            CreateMap<Car_CarFeature, CarFeatureDto>().ReverseMap();

            CreateMap<Reservation, ReservationDto>()
                .ForMember(dest => dest.Car, opt => opt.MapFrom(src => src.Car))
                .ReverseMap();

            CreateMap<Brand, BrandDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeFiltering>().ReverseMap();


            CreateMap<Car, CarCreationDto>()
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.CarFeatures.Select(cf => cf.CarFeature))).ReverseMap();

            //CreateMap<ApplicationUser, UserDto>().ReverseMap();
     
            CreateMap<CarReservationDto, Car>()
                .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(src => src.VehicleType))
                .ReverseMap();

            CreateMap<VehicleTypeReservationDto, VehicleType>().ReverseMap();
           
            CreateMap<PaymentReservationDto, Payment>().ReverseMap();

            CreateMap<ReservationOwnerDto, Reservation>()
                .ReverseMap();

            CreateMap<PaymentCheckDto, UserPayment>()
            .ReverseMap();

            CreateMap<Car, CarDetailsDto>()
            .ForMember(des => des.image, opt => opt.MapFrom(s => s.image == null ? "" :
                Convert.ToBase64String(System.IO.File.ReadAllBytes(Path.Combine(@"P:\Angular and .Net\CarRental\wwwroot\Images\carImage", s.image)))))
            .ForMember(dest => dest.Brand, opt => opt.MapFrom(src => src.Brand))
            .ForMember(dest => dest.Features, opt => opt.MapFrom(src => src.CarFeatures.Select(ccf => ccf.CarFeature)))
            .ForMember(dest => dest.VehicleType, opt => opt.MapFrom(src => src.VehicleType))
            .ReverseMap();


            CreateMap<UserDto,ApplicationUser>().ForMember(dest => dest.UserDetails, opt => opt.MapFrom(src => src.UserDetails)).ReverseMap();

            CreateMap<UserDetailsDto, UserDetails>().ReverseMap();


            CreateMap<ReservationByRef, Reservation>().ReverseMap();


            CreateMap<ContactDto, ContactUs>().ReverseMap();



        }


    }
}
