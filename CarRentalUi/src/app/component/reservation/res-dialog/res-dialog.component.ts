import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ReservationService } from 'src/app/service/reservation.service';
import { VehicletypeComponent } from '../../home/vehicletype/vehicletype.component';
import { Location } from 'src/app/model/car-location.model';

@Component({
  selector: 'app-res-dialog',
  templateUrl: './res-dialog.component.html',
  styleUrls: ['./res-dialog.component.css']
})
export class ResDialogComponent  implements OnInit {
  myForm:FormGroup;
  locations = Location;

    constructor(private res:ReservationService, private router:Router , private fb:FormBuilder,public dialogRef: MatDialogRef<VehicletypeComponent>,@Inject(MAT_DIALOG_DATA) public data,){}
    ngOnInit(): void {
      this.InitForm();
    }
  
    CarAvailable(){
      this.res.IsCarAvailable(this.myForm.value, this.data)
    }
  
  
    InitForm(){
      this.myForm = this.fb.group({
        carId:[this.data.carId],
        startDate : ['',Validators.required],
        endDate : ['',Validators.required],
        location : ['',Validators.required],

      })
    }
}
