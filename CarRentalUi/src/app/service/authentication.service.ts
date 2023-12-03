import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Login, Register } from '../model/account.model';
import { API_URL } from 'src/constantdata';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  

  constructor(private http:HttpClient, private router:Router,  private toastr:ToastrService) { }
  url = API_URL

  SignInUser(data:Login){
    this.http.post<Login>(`${this.url}/Auth/login`,data).pipe(catchError((error)=>{
       throw this.toastr.error(error)  
    })).subscribe(response=>{
      if(response['isAuthenticated']){
        //console.log(response)
        this.clearDataStorage();
        localStorage.setItem('jwt',response['token']);
        localStorage.setItem('user',JSON.stringify({'email':response['email'], 'username':response['userName']}))
        this.router.navigate(['/'])
        this.toastr.success(response['message'])  
      }
    });
  }


  RegisterUser(data:Register){
    this.http.post<any>(`${this.url}/Auth/register`,data).subscribe(response=>{
      this.toastr.success(response['message'])  
    })
  }

  Logout(){
    this.clearDataStorage();
    this.router.navigate(['/login'])
  }


  clearDataStorage(){
    localStorage.removeItem('user');
    localStorage.removeItem('jwt');
  }



}
