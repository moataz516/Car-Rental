namespace CarRental.Models.Dtos
{
    public class ReservationAndPaymentDto
    {
        public MakeReservationDto reservationDto { get; set; }
        public CustomerDetailsDto CustomerDetailsDto { get; set; }
        public PaymentCheckDto paymentCheckDto { get; set; }
        public string UserId { get; set; }
        public string CarId { get; set; }
    }
}
