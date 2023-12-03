import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root'
})
export class SharedStuffService {

  constructor(private toastr:ToastrService) { }
}
