import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CarReservation } from 'src/app/model/car.model';
import { ChangeResStatus, ReservationOwner } from 'src/app/model/reservation.model';
import { ReservationService } from 'src/app/service/reservation.service';
import { SharedService } from 'src/app/service/shared.service';

@Component({
  selector: 'app-booking',
  templateUrl: './booking.component.html',
  styleUrls: ['./booking.component.css']
})
export class BookingComponent {

 ownerRes:ReservationOwner[]=[]
  displayedColumns: string[] = ['Pickup', 'Return', 'Car Type', 'Client','Total Price', 'Status', 'actions'];
  paymentStatusOption : string[] = ['Pending','Cancelled','Completed','In Progress','Upcoming']


  constructor(private resService:ReservationService, private dialog: MatDialog, private shared: SharedService){}
  ngOnInit(): void {
    this.resService.CarOwnerReservations(this.shared.getUserId()).subscribe(data=>{
      this.ownerRes = data;
      console.log(data)
    })
  }
  

  CheckReservationStatus(status:any){
    console.log(status)
    return this.paymentStatusOption.filter(x => x !== status)
  }

  ChangeRStatus(id:string,event:any){
    const ChangeRStatus : ChangeResStatus = {
      reservationId : id,
      status:event.target.value
    }
    this.resService.ChangeReservationStatus(ChangeRStatus)
  }

  deleteReservation(id:string){
    this.resService.DeleteReservation(id)
  }
    

}
