
export interface PaymentCheckDto{
    cardName:string;
    cardNumber:number;
    expMonth:number;
    expYear:number;
    cvv:number;
}

export interface PaymentReservation{
    paymentMethod:string;
    paymentStatus:string;
}