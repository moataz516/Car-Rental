namespace CarRental.Models.Dtos
{
    public class PaymentCheckDto
    {
        public string cardName { get; set; }
        public int cardNumber { get; set; }
        public int expMonth { get; set; }
        public int expYear { get; set; }
        public int cvv { get; set; }
    }

    public class PaymentReservationDto
    {
        public string paymentMethod { get; set; }
        public string paymentStatus { get; set; }

    }


}
