import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { catchError, throwError } from 'rxjs';
import { ReservationService } from 'src/app/service/reservation.service';

@Component({
  selector: 'app-user-booking',
  templateUrl: './user-booking.component.html',
  styleUrls: ['./user-booking.component.css']
})
export class UserBookingComponent implements OnInit {

  myForm:FormGroup
  constructor(private resService:ReservationService,private fb:FormBuilder,private router:Router){}

  ngOnInit(): void {
    this.initForm();
  }

  onSubmit(){
    this.resService.CheckReservationByRef(this.myForm.value)
  }



  initForm(){
    this.myForm = this.fb.group({
      email:['',Validators.required],
      refID:['',Validators.required],
    })
  }
}
