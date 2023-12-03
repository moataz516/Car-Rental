import { UserDetails } from "./user-details.model";

export interface User{
    Id:string;
    firstName:string;
    lastName:string;
    email:string;
    username:string;
    userDetails?:UserDetails;
}
export interface UserDto{
    firstName:string;
    lastName:string;
    email:string;
    username:string;
    UserDetails?:UserDetails;
}

export interface UserReservation{
    firstName:string;
    lastName:string;
    email:string; 
}