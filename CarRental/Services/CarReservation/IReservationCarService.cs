using CarRental.Models;
using CarRental.Models.Dtos;

namespace CarRental.Services.Reservation
{
    public interface IReservationCarService
    {
        Task<bool> MakeReservation(ReservationAndPaymentDto model);
        Task<bool> CheckReservationByReferenceID(ReservationByRefForm model);
        Task<ReservationByRef> GetReservationByReferenceID(string id);

        Task<bool> AddReservation(ReservationDto model, string UserId);
        Task<IEnumerable<CarDto>> GetAvailableCars(CarSearchDto model );
        Task<IEnumerable<ReservationDto>> GetAllReservation();
        Task<ReservationDto> UpdateReservation(string id ,ReservationDto model);
        Task<IEnumerable<ReservationOwnerDto>> GetReservationByUser (string id);
        Task<ReservationOwnerDto> GetReservation(string id);
        Task<IEnumerable<ReservationDto>> GetReservationByCar (string carId);
        Task<bool> IsCarAvailable(CarSearchDto model);
        decimal CalculateTotalCost(DateTime startDate, DateTime endDate);
        ReservationDto SendReservationConfirmation(ReservationDto reservation);
        bool CancleReservation(string id);
        Task<bool> ValidatePaymentCard(string id, decimal totalPrice ,PaymentCheckDto paymentCheckDto);
        Task<bool> ChangeReservationStatus(RStatusDto model);
        Task<bool> DeleteReservation (string id);
        //GetReservedCars
        //Task DateEx(CarSearchCheck model);
    }
}
