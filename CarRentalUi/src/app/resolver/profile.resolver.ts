import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve } from "@angular/router";
import { User } from "../model/user.model";
import { AccountService } from "../service/account.service";
import { Observable } from "rxjs";




@Injectable({
    providedIn: 'root'
  })

  export class UserProfileResolver implements Resolve<User>{
    constructor(private acc:AccountService){}
    resolve(route:ActivatedRouteSnapshot):Observable<User>{
        const id = route.params.id;
        
        return this.acc.GetUserProfile(id)
    }
  }