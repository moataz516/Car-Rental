import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../model/user.model';
import { API_URL } from 'src/constantdata';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  BASE_URL = API_URL + "/Account";
  UserProfile = new Subject<User>()
  userId?:string;
  constructor(private http:HttpClient,private toastr:ToastrService) { }

  GetUserProfile(userId:string){
    this.userId = userId
    return this.http.get<User>(`${this.BASE_URL}/${userId}`)
  }

  UpdateUserProfileImg(fileImg:any,id:string){
    this.http.put(`${this.BASE_URL}/updateProfileImg/${id}`,fileImg).subscribe(()=>{
      this.toastr.success("Image updated successfully");
      this.OnEmitData()
    } )
  }
  UpdateUserProfile(data:any){
    this.http.patch(`${this.BASE_URL}/updateProfile`,data).subscribe(()=>{
      this.toastr.success("profile updated successfully");
      this.OnEmitData()
    })
  }



  OnEmitData(){
    this.GetUserProfile(this.userId).subscribe(d=>{
      this.UserProfile.next(d)
    })
  }
}
