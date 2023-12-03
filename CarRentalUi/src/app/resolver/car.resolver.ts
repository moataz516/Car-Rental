import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { CarService } from '../service/car.service';
import { Car } from '../model/car.model';

@Injectable({
  providedIn: 'root'
})
export class CarResolver implements Resolve<Car> {

  constructor(private carService: CarService) { }

  resolve(route: ActivatedRouteSnapshot): Observable<any> {
    const id = route.params['id'];
    return this.carService.GetCarById(id);
  }
}