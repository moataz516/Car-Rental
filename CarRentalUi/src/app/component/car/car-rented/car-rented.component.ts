import { Component, OnInit } from '@angular/core';
// import {  CarRentedInfo } from 'src/app/model/car.model';
import { ReservationService } from 'src/app/service/reservation.service';
import { SharedService } from 'src/app/service/shared.service';

@Component({
  selector: 'app-car-rented',
  templateUrl: './car-rented.component.html',
  styleUrls: ['./car-rented.component.css']
})
export class CarRentedComponent implements OnInit {
  carList:any[];
  constructor(private resService:ReservationService,private shared:SharedService){}
  ngOnInit(): void {
    // this.resService.carRented(this.shared.getUserId()).subscribe(data => {
    //   this.carList = data;
    // })

    
  }
}
