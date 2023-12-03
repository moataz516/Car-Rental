import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Car, CarDro } from 'src/app/model/car.model';
import { ReservationService } from 'src/app/service/reservation.service';
import { SharedService } from 'src/app/service/shared.service';

@Component({
  selector: 'app-payment',
  templateUrl: './payment.component.html',
  styleUrls: ['./payment.component.css']
})
export class PaymentComponent implements OnInit {

  carSelected : CarDro
  timeAndPlaceDetails:any;
  durationInDays : number
  paymentForm:FormGroup;
  custumerDetailsForm:FormGroup
  constructor(private route:ActivatedRoute,private resService:ReservationService, private fb:FormBuilder, private shared:SharedService){


  }

  ngOnInit(): void {
    this.timeAndPlaceDetails = JSON.parse(sessionStorage.getItem("bookingDetails"));
    this.carSelected = JSON.parse(sessionStorage.getItem("carDetails"));
    this.durationInDays = JSON.parse(sessionStorage.getItem('durationInDays'))
    this.initForm();
    
  }


  onSubmit(){

    
    var sDate = new Date(this.timeAndPlaceDetails.startDate).toISOString();
    var eDate = new Date(this.timeAndPlaceDetails.endDate).toISOString();

    const reservation = {
      reservationDto:{
        startDate : sDate,
        endDate : eDate,
        startLocation : this.timeAndPlaceDetails.location,
        endLocation : this.timeAndPlaceDetails.location,
        totalPrice : this.durationInDays * this.carSelected.price
      } , 
      customerDetailsDto: this.custumerDetailsForm.value,
      paymentCheckDto : this.paymentForm.value,
      userId : this.shared.getUserId(),
      carId:this.carSelected.carId,
    }

    this.resService.ReservationCar(reservation)
  }


  initForm(){
    this.paymentForm = this.fb.group({
      cardName : [ , Validators.required] ,
      cardNumber  : [ , Validators.required],
      expMonth : [ , Validators.required] ,
      expYear  : [ , Validators.required],
      cvv : [ , Validators.required],
    })


    this.initDriverForm()
  }

  initDriverForm(){
    this.custumerDetailsForm = this.fb.group({
      firstName:['',Validators.required],
      lastName:['',Validators.required],
      email:['',Validators.required],
      phone:['',Validators.required],
      dateOfBirth:['',Validators.required],

    })
  }
}
