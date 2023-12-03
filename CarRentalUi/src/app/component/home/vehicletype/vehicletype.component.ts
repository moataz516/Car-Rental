import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { CarService } from 'src/app/service/car.service';

@Component({
  selector: 'app-vehicletype',
  templateUrl: './vehicletype.component.html',
  styleUrls: ['./vehicletype.component.css']
})
export class VehicletypeComponent implements OnInit{
  vehicleList:any[];
  carList : any[]
  nameFilter:string = "All";



  sliderConfig = {
    infinite: true,
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplaySpeed:5000,
    pauseOnHover:true,
    autoplay:true,
    arrows: true,
    dots: false,
    responsive: [
      {
        breakpoint: 768,
        settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
        },
      },
    ],
  };






  constructor(private carService:CarService,public dialog: MatDialog){}

ngOnInit(): void {
  this.carService.GetVehicleTypeList().subscribe((d)=>{this.vehicleList=d})
  this.carService.GetCarList().subscribe(d=>{this.carList = d;
  })
}




  ch(i:any){
    this.nameFilter = i.typeName;

  }

  // openDialog(item:any) {
  //   this.dialog.open(ResDialogComponent, {
  //     height: '700px',
  //     width: '500px',
  //     data:item
  // });
  // }

}
