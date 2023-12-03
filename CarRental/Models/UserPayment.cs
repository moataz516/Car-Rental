namespace CarRental.Models
{
    public class UserPayment
    {
        public string UserPaymentId { get; set; } = Guid.NewGuid().ToString();
        public string cardName { get; set; }
        public int cardNumber { get; set; }
        public int expMonth { get; set; }
        public int expYear { get; set; }
        public int cvv { get; set; }
        public int amount { get; set; } = 1000;
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
