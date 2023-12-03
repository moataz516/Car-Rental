import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SharedService } from 'src/app/service/shared.service';
import { Location } from 'src/app/model/car-location.model';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ReservationService } from 'src/app/service/reservation.service';
import { catchError } from 'rxjs';

@Component({
  selector: 'app-car-details',
  templateUrl: './car-details.component.html',
  styleUrls: ['./car-details.component.css']
})
export class CarDetailsComponent implements OnInit {
  carInfo:any;
  locations = Location;
  myForm:FormGroup;
  displayErrorMessage  : boolean = false

  constructor(private route:ActivatedRoute , private shared:SharedService, private resService:ReservationService, private fb:FormBuilder){}
  ngOnInit(): void {
    this.carInfo = this.route.snapshot.data['data']
    console.log(this.carInfo)
    this.InitForm();
  }


  CheckCarAvailable(){
    if(!this.shared.isLoggedIn()){
      
       this.shared.router.navigate(['/login'])
       return;
    }
      this.resService.IsCarAvailable(this.myForm.value , this.carInfo)
  }

  InitForm(){
    this.myForm = this.fb.group({
      carId: [this.carInfo.carId, Validators.required],
      location: ["", Validators.required],
      startDate: ["", Validators.required],
      endDate: ["", Validators.required],
    })
  }


  isAdminOrOwner(): boolean{
    var allowedRole = ["Admin","Owner"]
    return allowedRole.includes(this.shared.getUserRole())  ? true : false; 
  }

}
