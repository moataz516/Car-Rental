import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from 'src/constantdata';
import { VehicleTypeDto } from '../model/vehicle-type.model';

@Injectable({
  providedIn: 'root'
})
export class VehilcleService {
  baseURL = API_URL + "/VehicleTypes"
  vehicleType:[] = []
  constructor(private http:HttpClient) { }

  GetAllVehicleType(){
    return this.http.get<VehicleTypeDto[]>(`${this.baseURL}`)
  }
}
