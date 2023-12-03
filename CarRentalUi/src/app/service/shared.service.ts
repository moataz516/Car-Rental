import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import jwtDecode from 'jwt-decode';
import { SharedStuffService } from './shared-stuff.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class SharedService {
  constructor(private jwtHelper: JwtHelperService, public router:Router) { }

  public getUser() {
    const userJson = localStorage.getItem('jwt');
    if (userJson) {
      return userJson;
    }
    return null;
  }

  isLoggedIn():boolean{
    const user = this.getUser();
    if(user){
      return user != null && user.length >1;
    }
    return false
  }

  public getToken(): any | null {
    const user = this.getUser();
    if (user) {
      return user;
    }
    return null;
  }

  getUserData(){
    const data = localStorage.getItem('user');
    if (data) {
      const userData = JSON.parse(data);
      return userData;
    }
    return null;
  }

  
  getUserEmail(){
    const data = this.getUserData();
    if(data)
      return data['email'];
    return null
    }

  public getUserName(){
    const data = this.getUserData();
    if(data){
      return data['username'];    
    }
    return null
  }

  public getUserId(){
    const token = this.getUser()
    if(token){
      const decode = jwtDecode(token)
          return decode['Uid']
    }
    return null
    
  }

  getUserRole(){
    const token = this.getUser()
    if(token){
    const decode = jwtDecode(token)
    return decode['roles']
    }
    return null
  }


  CheckAuth(){
    if(this.getUserRole() != null){
      return this.getUserRole()
  }
  return null;
}

}
