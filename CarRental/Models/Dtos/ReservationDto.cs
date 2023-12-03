namespace CarRental.Models.Dtos
{
    public class ReservationDto
    {
        public string ReservationId { get; set; }
        public string CarId { get; set; }
        public string UserId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }
        public decimal totalPrice { get; set; }
        public bool isConfirmed { get; set; } = false;
        public string status { get; set; } 
        public string cancellationReason { get; set; } 
        public ApplicationUser User { get; set; }
        public Car Car { get; set; }
        public Payment Payment { get; set; }
    }


    public class MakeReservationDto
    {
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }
        public int totalPrice { get; set; }
    }



    public class ReservationOwnerDto
    {

            public string ReservationId { get; set; }
            public string startDate { get; set; }
            public string endDate { get; set; }
            public string startLocation { get; set; }
            public string endLocation { get; set; }
            public decimal totalPrice { get; set; }
            public bool isConfirmed { get; set; } = false;
            public string status { get; set; }
            public UserDto User { get; set; }
            public CarReservationDto Car { get; set; }
            public PaymentReservationDto Payment { get; set; }

    }
    public class RStatusDto
    {
        public string reservationId { get; set; }
        public string status { get; set; }
    }


    public class ReservationByRef
    {
        public string ReservationId { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string startLocation { get; set; }
        public string endLocation { get; set; }
        public decimal totalPrice { get; set; }
        public bool isConfirmed { get; set; } = false;
        public string status { get; set; }
        public string cancellationReason { get; set; }

        public CustomerDetailsDto CustomerDetails { get; set; }
        public CarDto Car { get; set; }
        public UserDto User { get; set; }
    }

    public class ReservationByRefForm
    {
        public string email { get; set; }
        public string refID { get; set; }
    }



}
