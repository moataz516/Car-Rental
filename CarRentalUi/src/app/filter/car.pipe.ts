import { Pipe, PipeTransform } from "@angular/core";
import { CarDro } from "../model/car.model";



@Pipe({
    name:'CarFilter'
})

export class BrandFilter implements PipeTransform{
    transform(car:CarDro[], search:string) {
        if(search == (null || ""))
            return car;
        return  car.filter(x=>x.brand.name == search)
    }
    
}