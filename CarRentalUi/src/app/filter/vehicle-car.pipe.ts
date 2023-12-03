import { Pipe, PipeTransform } from "@angular/core";



@Pipe({
    name:'vehicleFilter'
})

export class FilterPipe implements PipeTransform{
    transform(car: any[], search:string) {
        if(!search || search === "All"){
            return car;
        }
        return car.filter(car=>car.vehicleType.typeName === search )
    }
}