import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Car } from 'src/app/model/car.model';
import { CarService } from 'src/app/service/car.service';
import { DeleteConfirmationDialogComponent } from '../car-action/delete-car-dialog.component';

@Component({
  selector: 'app-car-owner',
  templateUrl: './car-owner.component.html',
  styleUrls: ['./car-owner.component.css']
})
export class CarOwnerComponent implements OnInit{
  carOwner:Car[]=[]
  selectedCar: Car | null;
  isCreating: boolean = false;
  isEditing: boolean = false;
  displayedColumns: string[] = ['model', 'vehicleType', 'plateNumber', 'price','location', 'availability', 'actions'];



  constructor(private carService:CarService, private dialog: MatDialog){}
  ngOnInit(): void {
    this.carService.GetOwnerCars().subscribe(data=>{
      this.carOwner = data;
    })

    this.carService.carListSubject.subscribe(d=>{
      this.carOwner =d
    })

    
  }
  

  changeAvailability(id:string){
    this.carService.changeAvailableCar(id);
  }


  createCar() {
    
  }

  editCar(car: Car) {
    
  }

  saveCar() {
    
    }


    deleteCar(car: Car) {
      // Open the delete confirmation dialog
      const dialogRef = this.dialog.open(DeleteConfirmationDialogComponent, {
        width: '300px',
        data:car
      });
  
      // dialogRef.afterClosed().subscribe((result) => {
      //   if (result === true) {
      //     this.carService.DeleteCar(car.carId);
      //   }
      // });
    }
    

  cancel() {
    
  }

}
