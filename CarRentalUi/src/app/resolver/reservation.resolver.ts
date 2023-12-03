import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { CarService } from '../service/car.service';
import { ReservationOwner } from '../model/reservation.model';
import { ReservationService } from '../service/reservation.service';

// @Injectable({
//   providedIn: 'root'
// })
// export class ReservationResolver implements Resolve<ReservationOwner> {

//   constructor(private resService: ReservationService) { }

//   resolve(route: ActivatedRouteSnapshot) {
//     const id = route.params['id'];
//     return this.resService
//   }
// }