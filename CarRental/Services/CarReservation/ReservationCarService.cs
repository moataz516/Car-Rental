using AutoMapper;
using CarRental.Models;
using CarRental.Models.Data;
using CarRental.Models.Dtos;
using CarRental.Services.Reservation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Services.CarReservation
{
    public class ReservationCarService : IReservationCarService
    {
        private readonly CarRentingDbContext _context;
        private readonly IMapper _mapper;

        public ReservationCarService(CarRentingDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }



        public async Task<bool> CheckReservationByReferenceID(ReservationByRefForm model)
        {

            if(model.refID is null)
                return false;
            var data = await _context.Reservations
                .Include(res => res.User)
                .FirstOrDefaultAsync(res => res.ReservationId == model.refID && res.User.Email == model.email);
            if(data == null)
                return false;

            return true;
            
        }



        public async Task<ReservationByRef> GetReservationByReferenceID(string refID)
        {
            var data = await _context.Reservations
                .Include(res => res.Car).ThenInclude(res => res.VehicleType)
                .Include(res => res.CusDet)
                .Include(res => res.User)
                .FirstOrDefaultAsync(res => res.ReservationId ==refID );

            if (data == null)
                return null;

            var result = _mapper.Map<ReservationByRef>(data);
            return result;
        }




        public decimal CalculateTotalCost(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public bool CancleReservation(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReservationDto>> GetAllReservation()
        {
            throw new NotImplementedException();
        }

        //public async Task<IEnumerable<CarDto>> GetAvailableCars(CarSearchDto model)
        //{
        //    var availableCars = await  _context.Cars
        //    .Where(car => !car.Reservations.Any(r => (string.Compare(r.startDate , model.endDate ) <0 ) && (string.Compare(r.endDate , model.startDate) > 0) ) 
        //    && (model.location != "" ? model.location == car.CurrentLocation : true )
        //    && (model.brandId != "" ? car.BrandId == model.brandId : true)
        //    )
        //        .Include(car => car.CarFeatures).ThenInclude(ccf => ccf.CarFeature)
        //        .Include(car => car.Brand)
        //        .Include(car => car.VehicleType)
        //        .ToListAsync();

        //    var carDtos = _mapper.Map<List<CarDto>>(availableCars);
        //    return carDtos;
        //}

        
        /* Get available car from date to date*/
        public async Task<IEnumerable<CarDto>> GetAvailableCars(CarSearchDto model)
        {
            var availableCars = await _context.Cars
            .Where(car => !car.Reservations.Any(r => (string.Compare(r.startDate, model.endDate) < 0) && (string.Compare(r.endDate, model.startDate) > 0))
            && model.location == car.CurrentLocation
            )
                .Include(car => car.CarFeatures).ThenInclude(ccf => ccf.CarFeature)
                .Include(car => car.VehicleType)
                .Include(car => car.Brand)
                .AsNoTracking().ToListAsync();

            var carDtos = _mapper.Map<List<CarDto>>(availableCars);
            return carDtos;
        }


        public Task<IEnumerable<ReservationDto>> GetReservationByCar(string carId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReservationOwnerDto>> GetReservationByUser(string id)
        {
            var data = await _context.Reservations.Where(x => x.Car.UserId == id )
                .Include(x => x.User)
                .Include(x => x.Payment)
                .Include(x => x.Car).ThenInclude(x=>x.VehicleType)
                .ToListAsync();

           var currentDate = DateTime.Now;

           foreach (var res in data)
            {
                if( DateTime.TryParse(res.startDate, out DateTime startDate) && DateTime.TryParse(res.endDate, out DateTime endDate))
                {
                    string newStatus;
                    if(startDate <= currentDate && endDate >= currentDate)
                    {
                        newStatus = "In Progress";
                        
                    }else if(endDate < currentDate)
                    {
                        newStatus = "Completed";
                    }
                    else
                    {
                        newStatus = "Upcoming";
                    }
                    if (res.status != newStatus)
                    {
                        RStatusDto statusDto = new RStatusDto()
                        {
                            reservationId = res.ReservationId, status = newStatus,
                        };
                        await ChangeReservationStatus(statusDto);
                    }
                }
            }
            var reservation = _mapper.Map<IEnumerable<ReservationOwnerDto>>(data);

            return reservation;

        }


        //public bool IsCarAvailable(int carId, DateTime startDate, DateTime endDate)
        //{
        //    throw new NotImplementedException();
        //}

        public  async Task<bool> MakeReservation(ReservationAndPaymentDto model)
        {
            if (model.UserId == null) return false;
            bool isCardValid = await ValidatePaymentCard(model.UserId, model.reservationDto.totalPrice ,model.paymentCheckDto); 

            if(!isCardValid) return false;

            var cusDetails = new CustomerDetails();
            cusDetails.firstName = model.CustomerDetailsDto.firstName;
            cusDetails.lastName = model.CustomerDetailsDto.lastName;
            cusDetails.phone = model.CustomerDetailsDto.phone;
            cusDetails.email = model.CustomerDetailsDto.email;
            cusDetails.dateOfBirth = model.CustomerDetailsDto.dateOfBirth;

            _context.CustomerDetails.Add(cusDetails);
            await _context.SaveChangesAsync();

            var res = new Models.Reservation();
            res.UserId = model.UserId;
            res.CusDetId = cusDetails.CustomerDetailsId;
            res.CarId = model.CarId;
            res.startDate = model.reservationDto.startDate;
            res.endDate = model.reservationDto.endDate;
            res.startLocation = model.reservationDto.startLocation;
            res.totalPrice = model.reservationDto.totalPrice;
            res.status = "paid";
            res.isConfirmed = true;

            _context.Reservations.Add(res);
            await _context.SaveChangesAsync();
            

            Payment payment = new Payment();
            payment.ReservationId = res.ReservationId;
            payment.UserId = model.UserId;
            payment.amount = model.reservationDto.totalPrice;
            payment.paymentDate = DateTime.Now;
            payment.paymentStatus = "Paid";

            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return true;
        }



        public async Task<bool> ValidatePaymentCard(string id, decimal total, PaymentCheckDto model)
        {
            var data = await _context.UserPayments.FirstOrDefaultAsync(x => x.UserId == id);
            if (data is null)
                return false;   
            if(data.cardName == model.cardName 
                && data.cardNumber == model.cardNumber 
                && data.expMonth == model.expMonth
                && data.expYear == model.expYear 
                && data.cvv == model.cvv
                && data != null)
            { 
                if(total > data.amount)
                {
                    return false;
                }else
                {
                    data.amount = (int)(data.amount - total);
                    _context.UserPayments.Update(data);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }


        public async Task<bool> AddReservation(ReservationDto model, string userId)
        {
            return true;
            
        }
        public ReservationDto SendReservationConfirmation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public Task<ReservationDto> UpdateReservation(string id, ReservationDto model)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> IsCarAvailable(CarSearchDto model)
        {
            bool isCarReserved =  await _context.Reservations.AnyAsync(r => 
            r.CarId == model.carId 
            && (string.Compare(r.startDate, model.endDate) < 0)
            && (string.Compare(r.endDate, model.startDate) > 0) );

            return !isCarReserved;

        }

        public async Task<bool> ChangeReservationStatus(RStatusDto model)
        {
           var data = await _context.Reservations.FirstOrDefaultAsync(x => x.ReservationId == model.reservationId);
            data.status = model.status;
            _context.Reservations.Update(data);
            await _context.SaveChangesAsync();
            return true ;
        }

        public Task<ReservationOwnerDto> GetReservation(string id)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> DeleteReservation(string id)
        {
            var reservation = _context.Reservations.Include(r => r.Payment).Include(r => r.CusDet).FirstOrDefault(x => x.ReservationId == id);
            if(reservation == null)
            {
                return false;
            }


            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return true;

        }

        public Task<bool> checkReservationByReferenceID(ReservationByRefForm model)
        {
            throw new NotImplementedException();
        }



        //public Task DateEx(CarSearchCheck model)
        //{
        //    DateTime.TryParse(model.s, out DateTime parses);
        //    DateTime.TryParse(model.e, out DateTime parsee);
        //    var data = _context.DateTests.Where(x=> xx(x, parses, parsee)).ToList();


        //    return null;
        //}

        //private bool xx(DateTest a , DateTime b ,DateTime c)
        //{
        //    DateTime.TryParseExact(a.sDate, "yyyy-MM-ddTHH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime ss);
        //    DateTime.TryParseExact(a.eDate, "yyyy-MM-ddTHH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime ee);

        //    return b < ee && c > ss ? true : false;

        //}
    }


}
