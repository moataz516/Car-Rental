import { CarReservation } from "./car.model";
import { PaymentReservation } from "./payment.model";
import { UserReservation } from "./user.model";

export interface Reservation{

}

export interface ReservationDto{
    carId : string;
    startDate:string ;
    endDate:string;
    startLocation:string;
    endLocation:string;
    totalPrice:string;
}

export interface ReservationOwner{
    reservationId:string;
    startDate:string ;
    endDate:string;
    startLocation:string;
    endLocation:string;
    totalPrice:string;
    isConfirmed:boolean;
    status:string;
    paymentStatue : string;
    user:UserReservation;
    carReservation:CarReservation
    payment:PaymentReservation
}



export interface ChangeResStatus{
    reservationId : string;
    status:string;
}