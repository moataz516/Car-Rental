import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { API_URL } from 'src/constantdata';
import { SharedService } from './shared.service';
import { Car, CarCreation } from '../model/car.model';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { Location } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class CarService {
  BASE_URL = API_URL + "/Cars";
  carListSubject = new Subject<Car[]>(); 
  constructor(private http:HttpClient, private shared:SharedService, private router:Router, private toastr:ToastrService,private location: Location) { }
  
  AddCar(data:CarCreation){
    this.http.post(`${this.BASE_URL}`, data).subscribe(()=>{
      this.emitCarList();
      this.toastr.success("Car Added Successfully")

    })
  }

  GetCarList(){
    return this.http.get<any[]>(`${this.BASE_URL}`)
  }

  GetOwnerCars(){
    const id = this.shared.getUserId();
    return this.http.get<Car[]>(`${this.BASE_URL}/OwnerCarList/${id}`)
  }

  GetCarById(id:string){
    return this.http.get<Car>(`${this.BASE_URL}/${id}`)
  }

  UpdateCar(id:string , data:CarCreation){
    const headers = new HttpHeaders();
    // headers.append('Content-Type', 'multipart/form-data');
    this.http.put(`${this.BASE_URL}/${id}`,data).subscribe(d=>{
      this.emitCarList();
      this.toastr.success("Car Updated Successfully")


    })
  }

  GetAvailableCar(){
   return this.http.get<any[]>(`${this.BASE_URL}/available`)
  }

  DeleteCar(id:string){
    this.http.delete(`${this.BASE_URL}/${id}`).subscribe(d=>{
      this.emitCarList();

    })

  }

  GetVehicleTypeList(){
   return this.http.get<any[]>(`${this.BASE_URL}/getvehicletype`)

  }


  GetByVehicleType(v:string ){
    this.http.get(`${this.BASE_URL}/getbyvehicletype/${v}`).subscribe(d=>{console.log(d)})
  }

  
    changeAvailableCar(id:string){
      this.http.get(`${this.BASE_URL}/availablechange/${id}`).subscribe(()=>{
        this.emitCarList();
      })
    }

  emitCarList(){
    this.GetOwnerCars().subscribe(d=>{
      this.carListSubject.next(d);
      // this.location.back();
      this.router.navigate(['/car-owner'])
    })
  }


}

