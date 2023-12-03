import { Brand, BrandDto } from "./brand.model";
import { Feature, FeatureDto } from "./feature.model";
import { VehicleType, VehicleTypeDto, VehicleTypeReservation } from "./vehicle-type.model";


export interface Car{
    carId:string;
    brand:Brand;
    vehicleType:VehicleType;
    features : Feature[] 
    userId:string;
    model:string;
    year:string;
    price:number;
    plateNumber:string;
    color:string;
    description:string;
    image:string;
    availability:boolean;
    currentLocation:string;
}




export interface CarDto{
    carId:string;
    brand:BrandDto;
    vehicleType:VehicleType;
    features : FeatureDto[] 
    model:string;
    year:string;
    price:number;
    color:string;
    description:string;
    image:string;
}





export interface CarDro{
    carId:string;
    brand:Brand;
    vehicleType:VehicleType;
    features : Feature[] 
    model:string;
    year:string;
    price:number;
    plateNumber:string;
    color:string;
    description:string;
    image:string;
    availability:boolean;
    currentLocation:string;
}

export interface CarCreation {
    carId:string;
    brandId:string;
    vehicleTypeId:string;
    userId:string;
    model:string;
    price:number;
    year:string;
    plateNumber:string;
    color:string;
    description:string;
    image:string;
    availability:boolean;
    currentLocation:string;
    features : Feature[]
}


export interface CarEdit  {
    carId:string;
    brand:string;
    vehicleType:string;
    userId:string;
    model:string;
    price:number;
    year:string;
    plateNumber:string;
    color:string;
    description:string;
    image:string;
    availability:boolean;
    currentLocation:string;
    features : Feature[]
}

export interface CarReservation {
    plateNumber:string;
    model:string;
    VehicleType:VehicleTypeReservation
}