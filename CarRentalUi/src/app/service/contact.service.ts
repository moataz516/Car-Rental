import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { API_URL } from 'src/constantdata';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  BASE_URL = API_URL + "/ContactUs"

  constructor(private http:HttpClient, private toastr:ToastrService) { }

  SendContactUsMessage(data:any){
    this.http.post<any>(`${this.BASE_URL}`,data).subscribe(d=>{
      this.toastr.success("Message Send Successfully");
      window.scrollTo({ top: 0, behavior: 'smooth' });

    })
  }


}
