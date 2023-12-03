import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { API_URL } from 'src/constantdata';
import { Brand } from '../model/brand.model';
import { Feature } from '../model/feature.model';
import { VehicleType } from '../model/vehicle-type.model';

@Injectable({
  providedIn: 'root'
})
export class CarCategoryService {
  url = API_URL + '/Brands'
  vUrl = API_URL + '/VehicleTypes';
  fUrl = API_URL + '/CarFeatures';

  constructor(private http:HttpClient) { }
  
  CarCategoryList(){
    return this.http.get<Brand[]>(`${this.url}`)
  }

  CarVehicleList(){
    return this.http.get<VehicleType[]>(`${this.vUrl}`)
  }

  CarFeatureList(){
    return this.http.get<Feature[]>(`${this.fUrl}`)
  }

}
