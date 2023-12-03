import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { CarService } from 'src/app/service/car.service';

@Component({
  selector: 'app-delete-confirmation-dialog',
  template: `
    <h2 mat-dialog-title>Delete Car</h2>
    <mat-dialog-content>
      Are you sure you want to delete this car?
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-button mat-dialog-close color="primary">Cancel</button>
      <button mat-button [mat-dialog-close]="true" (click)="deleteCar()" color="warn">Delete</button>
    </mat-dialog-actions>
  `,
})
export class DeleteConfirmationDialogComponent {
  constructor(
    public dialogRef: MatDialogRef<DeleteConfirmationDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any, private carService:CarService) { }

  deleteCar(){
    this.carService.DeleteCar(this.data.carId);
  }
}