import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { ReservationService } from "../service/reservation.service";



@Injectable({
    providedIn:"root"
})

export class UserBookingDetailsResolver implements Resolve<any>{

    constructor(private resService:ReservationService){}
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        var id = route.params['id']
        return this.resService.GetReservationByRef(id)
    }
    
}
