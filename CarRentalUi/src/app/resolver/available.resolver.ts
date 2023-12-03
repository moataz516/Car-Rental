import { Injectable } from '@angular/core';
import { Resolve } from '@angular/router';
import { Observable } from 'rxjs';
import { ReservationService } from '../service/reservation.service';

@Injectable({
  providedIn: 'root'
})
export class AvailableCarResolver implements Resolve<any[]> {

  constructor(private res: ReservationService) { }

  resolve(): Observable<any[]> {
    return this.res.availableCar;
  }
}