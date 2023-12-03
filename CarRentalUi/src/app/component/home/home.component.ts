import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/service/shared.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor( private sharedService : SharedService){}
  ngOnInit(): void {

  }

  IsUserPriv(){
    const userPriv = ["Owner","Admin"]
    return userPriv.includes(this.sharedService.getUserRole()) ? true : false
  }

}
