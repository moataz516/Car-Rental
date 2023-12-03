import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Brand, BrandDto } from 'src/app/model/brand.model';
import { CarDro } from 'src/app/model/car.model';
import { VehicleTypeDto } from 'src/app/model/vehicle-type.model';
import { CarCategoryService } from 'src/app/service/car-category.service';
import { ReservationService } from 'src/app/service/reservation.service';
import { VehilcleService } from 'src/app/service/vehilcle.service';

@Component({
  selector: 'app-available-car',
  templateUrl: './available-car.component.html',
  styleUrls: ['./available-car.component.css']
})
export class AvailableCarComponent implements OnInit {
  availableCars : CarDro[];
  uniqueTransmission:string[];
  uniqueType:any[];
  vehicleTypeList:VehicleTypeDto[]
  timeAndPlaceDetails:any;
  durationInDays : number;
  brands:Brand[] = []
  priceFitler:string="";
  brandFilter:string = ''
  // selectedCheckboxes: { [key: string]: boolean } = {};
  isFiltered = false;
  filteredCars: CarDro[] = [];
  // checkboxes = {
  //   typeName: [],
  //   transmissionType:[]
  // }

  constructor(private route:ActivatedRoute,private resService:ReservationService,private router:Router,private vehicleService:VehilcleService, private brand:CarCategoryService){}

  ngOnInit(): void {
    this.vehicleService.GetAllVehicleType().subscribe(d=>{
      this.vehicleTypeList = d;
      this.uniqueTransmission = [...new Set(this.vehicleTypeList.map(v => v.transmissionType))]
      this.uniqueType = [...new Set(this.vehicleTypeList.map(v => v.typeName))]

    })
    this.timeAndPlaceDetails = JSON.parse(sessionStorage.getItem("bookingDetails"));    
    this.resService.CheckCarAvailable(this.timeAndPlaceDetails).subscribe(d=>{
        this.availableCars = d;
        // this.carAfterFiltering = this.availableCars.slice()
      })

      this.brand.CarCategoryList().subscribe(d=>{
        this.brands = d
      })
  }

  DurationInDays(startDate,endDate) : number{
    const sDate = new Date(startDate)
    const eDate = new Date(endDate)
    const durationInMillis = eDate.getTime() - sDate.getTime();
    const durationInDays = durationInMillis / (1000 * 60 * 60 * 24);
    const roundedDuration = Math.round(durationInDays)
    this.durationInDays = roundedDuration;
    return roundedDuration
  }


  rentCar(car:any){
    sessionStorage.setItem('carDetails', JSON.stringify(car));
    sessionStorage.setItem('durationInDays', JSON.stringify(this.durationInDays) ) 
    this.router.navigate(['/payment'])
  }

  sortCar(event:any)
{
  const name = event.target.value;
  return name == "a" 
  ? this.availableCars.sort((a, b) => b.model.localeCompare(a.model)) 
  : this.availableCars.sort((a, b) => a.model.localeCompare(b.model));
}


FilterByPrice(event:any)
{
  const name = event.target.value;
  return name == "l" 
  ? this.availableCars.sort((a, b) => a.price - b.price) 
  : this.availableCars.sort((a, b) => b.price - a.price);
}


  // onCheckboxChange(filter: string, event: any, name:string) {
  //   const checked = event.target.checked
  //   const index = this.checkboxes[name].indexOf(filter);

  //       if(!this.checkboxes[name].includes(filter)){
  //         this.checkboxes[name].push(filter)          
  //       }else{
  //         if(index !== -1){
  //           this.checkboxes[name].splice(index,1)
  //         }
  //       }
      
  // this.isFiltered = true
  // this.filterCars(name);

  // }

  // filterCars(name:string) {
  //    this.filteredCars = this.availableCars.filter(x=>{
  //      const selectedFilters  = this.checkboxes[name];
  //      return selectedFilters.length === 0 || selectedFilters.some(filter => x.vehicleType[name].includes(filter))
  //    })
  // }



}
