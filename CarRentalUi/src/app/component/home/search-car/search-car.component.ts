import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Location } from 'src/app/model/car-location.model';
import { ReservationService } from 'src/app/service/reservation.service';
import * as moment from 'moment';

@Component({
  selector: 'app-search-car',
  templateUrl: './search-car.component.html',
  styleUrls: ['./search-car.component.css']
})
export class SearchCarComponent implements OnInit {
// carBrands: any[];
locations = Location;
myForm:FormGroup;
testForm:FormGroup;
  constructor(private res:ReservationService, private router:Router , private fb:FormBuilder){}
  ngOnInit(): void {
    
    // this.cat.CarCategoryList().subscribe(data=>{
    //   this.carBrands = data
    // })
    this.InitForm();
  }

  ShowAvailableCars(){
    sessionStorage.setItem('bookingDetails' , JSON.stringify(this.myForm.value))
    this.router.navigate(["/available-car"])
  }



  InitForm(){
    this.myForm = this.fb.group({
      carId : [''],
      startDate : ['',Validators.required],
      endDate : ['',Validators.required],
      location : ['',Validators.required],
    })
  }



}
