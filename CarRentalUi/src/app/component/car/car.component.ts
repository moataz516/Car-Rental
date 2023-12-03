import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/service/car.service';

@Component({
  selector: 'app-car',
  templateUrl: './car.component.html',
  styleUrls: ['./car.component.css']
})
export class CarComponent implements OnInit{

  carList:any[]
  p: number = 1;
  itemPerPage:number=3;


  constructor(private carService:CarService){}
  ngOnInit(): void {
    this.carService.GetAvailableCar().subscribe(data => this.carList = data)
  }
}
