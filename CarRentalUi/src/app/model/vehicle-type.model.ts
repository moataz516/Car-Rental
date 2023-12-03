
export interface VehicleType{
    vehicleTypeId:string;
    typeName : string;
    capacity:number;
    vehicleClass : string;
    transmissionType:string;
    mileage:string;
    fuelType:string;
}

export interface VehicleTypeDto{
    typeName : string;
    capacity:number;
    vehicleClass : string;
    transmissionType:string;
    mileage:string;
    fuelType:string;
}





export interface VehicleTypeReservation{
    typeName : string;
    vehicleClass : string;
}