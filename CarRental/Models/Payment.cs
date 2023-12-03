namespace CarRental.Models
{
    public class Payment
    {
        public string PaymentId { get; set; } = Guid.NewGuid().ToString();
        public string ReservationId { get; set; }
        public string UserId { get; set; }
        public string paymentMethod { get; set; } = "Credit Card";
        public decimal amount { get; set; }
        public DateTime paymentDate { get; set; }
        public string paymentStatus { get; set; }

        public virtual Reservation Reservation { get; set; }
        public ApplicationUser User { get; set; }
    }
}
