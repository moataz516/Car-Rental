namespace CarRental.Models
{
    public class Reservation
    {
        public string ReservationId { get; set; } = Guid.NewGuid().ToString();
        public string CarId { get; set; }
        public string UserId { get; set; }
        public string CusDetId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get { return startLocation; } set { startLocation = value; } } 
        public decimal totalPrice { get; set; }
        public bool isConfirmed { get; set; } = false;
        public string status { get; set; } = "Pending";
        public string cancellationReason { get; set; } = string.Empty;


        public CustomerDetails CusDet { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual Car Car { get; set; }
        public virtual ApplicationUser User { get; set; }

    }
}
