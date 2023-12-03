import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject, catchError, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { API_URL } from 'src/constantdata';
import { ToastrService } from 'ngx-toastr';
import { ChangeResStatus } from '../model/reservation.model';
import { FormGroup } from '@angular/forms';
import { searchByCarIdDto } from '../model/search.model';
import { CarDto } from '../model/car.model';

@Injectable({
  providedIn: 'root'
})
export class ReservationService {
  availableCar = new Subject<any[]>()
  BASE_URL = API_URL + "/Reservations"

  constructor(private http:HttpClient , private toastr:ToastrService,private router:Router) { }

  CheckCarAvailable(data:any){
    console.log(typeof new Date(data.startDate).toISOString())
    return this.http.post<any[]>(`${this.BASE_URL}/availablecar`,data)/*
    .subscribe(d=>{
      this.availableCar.next(d)
    })
    */
  }

  CheckReservationByRef(data:any){
    this.http.post<any>(`${this.BASE_URL}/checkReservationReference`,data).pipe(catchError(error=>{
      this.toastr.error(error)
      return throwError(null)
    })
  ).subscribe(d=>{
      this.router.navigate(['BookingDetails',data.refID])
    })
  }
  


  GetReservationByRef(id:string){
    return this.http.get<any>(`${this.BASE_URL}/getReservationReference/${id}`)
  }



  IsCarAvailable(date:searchByCarIdDto , data:any){


      this.http.post<any>(`${this.BASE_URL}/isCarAvailable`,date).pipe(catchError(e=>{ this.toastr.error(e);
      throw e})).subscribe(()=>{
        sessionStorage.setItem('bookingDetails' , JSON.stringify(date))
        sessionStorage.setItem('carDetails' , JSON.stringify(data))
        sessionStorage.setItem('durationInDays', JSON.stringify(this.DurationInDays(date.startDate,date.endDate)) ) 

      this.router.navigate(["/payment"])
      })
  }

   CheckCar(data:any){
     this.http.post<any[]>(`${this.BASE_URL}/AvailableCar`,data).subscribe((d:any)=>{
       if(d == true){
         this.ReservationCar(data)
       }else{
         this.toastr.error("Car is already Rented")
       }
     })
   }

  ReservationCar(data:any){
    
    this.http.post(`${this.BASE_URL}/makeReservation`,data).pipe(catchError((error:string)=>{
      this.toastr.error(error)
      return throwError(error)
    })).subscribe(d=>{
      sessionStorage.removeItem("carDetails")
      sessionStorage.removeItem("durationInDays")
      sessionStorage.removeItem("bookingDetails")
      this.router.navigate(['/']);
      this.toastr.success('car ordered successfully')
    })
  }

  carRented(id:string){
    return this.http.get<any[]>(`${this.BASE_URL}/carRented/${id}`)
  }

  CarOwnerReservations(id : string){
    return this.http.get<any[]>(`${this.BASE_URL}/GetOwnerReservation/${id}`);
  }

  ChangeReservationStatus(data:ChangeResStatus){
    this.http.post<any>(`${this.BASE_URL}/ChangeReservationStatus`,data).subscribe()
  }


  DurationInDays(startDate,endDate) : number{
    const sDate = new Date(startDate)
    const eDate = new Date(endDate)
    const durationInMillis = eDate.getTime() - sDate.getTime();
    const durationInDays = durationInMillis / (1000 * 60 * 60 * 24);
    const roundedDuration = Math.round(durationInDays)
    return roundedDuration
  }


  DeleteReservation(id:string){
    this.http.delete<any>(`${this.BASE_URL}/deleteReservation/${id}`).subscribe(x=>{
      this.toastr.success(x)
    })

  }


}
