import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Brand } from 'src/app/model/brand.model';
import { Location } from 'src/app/model/car-location.model';
import { Car } from 'src/app/model/car.model';
import { Feature } from 'src/app/model/feature.model';
import { VehicleType } from 'src/app/model/vehicle-type.model';
import { CarCategoryService } from 'src/app/service/car-category.service';
import { CarService } from 'src/app/service/car.service';
import { SharedService } from 'src/app/service/shared.service';

@Component({
  selector: 'app-car-action',
  templateUrl: './car-action.component.html',
  styleUrls: ['./car-action.component.css']
})
export class CarActionComponent implements OnInit {
  carForm: FormGroup;
  carEdit: any;
  location = Location;
  isEdit: boolean = false;
  carBrands: Brand[];
  carVehicle: VehicleType[];
  carFeatures: Feature[];
  selectedImage: string | Blob | ArrayBuffer | null = null;
  selectedFeatures: Feature[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private carCategory: CarCategoryService,
    private carService: CarService,
    private sharedSer: SharedService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.carEdit = this.route.snapshot.data['data'];
    console.log(this.carEdit)
    this.isEdit = this.carEdit != null;

    this.carCategory.CarCategoryList().subscribe((data) => {
      this.carBrands = data;
    });
    this.carCategory.CarVehicleList().subscribe((d) => {
      this.carVehicle = d;
    });
    this.carCategory.CarFeatureList().subscribe((d) => {
      this.carFeatures = d;
      if (this.isEdit) {
        this.selectCheckboxes(this.carEdit.features);
      }else {
        // If adding a new car, select all features by default
        //this.selectAllFeatures();
      }
    });

    this.initForm();
  }

  initForm(): void {
    this.carForm = this.formBuilder.group({
      carId: [this.isEdit ? this.carEdit.carId : null],
      brandId: [this.isEdit ? this.carEdit.brand.brandId : null, Validators.required],
      vehicleTypeId: [this.isEdit ? this.carEdit.vehicleType.vehicleTypeId : null, Validators.required],
      userId: [this.sharedSer.getUserId()],
      year: [this.isEdit ? this.carEdit.year : null],
      model: [this.isEdit ? this.carEdit.model : null, Validators.required],
      price: [this.isEdit ? this.carEdit.price : null, Validators.required],
      plateNumber: [this.isEdit ? this.carEdit.plateNumber : null, Validators.required],
      color: [this.isEdit ? this.carEdit.color : null, Validators.required],
      description: [this.isEdit ? this.carEdit.description : null, Validators.required],
      image: [this.isEdit ? this.carEdit.image : null, Validators.required],
      availability: [this.isEdit ? this.carEdit.availability : true, Validators.required],
      currentLocation: [this.isEdit ? this.carEdit.currentLocation : null, Validators.required],
      features: this.formBuilder.array([]),
    });
  }
  selectAllFeatures() {
    this.carFeatures.forEach((feature) => {
      this.featureFormArray.push(this.formBuilder.group(feature));
    });
  }
  
  selectCheckboxes(selectedFeatures: Feature[]) {
    selectedFeatures.forEach((feature) => {
      const selectedFeature = this.carFeatures.find((f) => f.carFeatureId === feature.carFeatureId);
      if (selectedFeature) {
        selectedFeature.isSelected = true;
        this.featureFormArray.push(this.formBuilder.group(selectedFeature));
        console.log(selectedFeature)
      }
    });
  }

  get featureFormArray() {
    return this.carForm.get('features') as FormArray;
  }

  onSubmit(): void {
    if (this.carForm.valid) {
      if (this.isEdit) {
        this.carService.UpdateCar(this.carEdit.carId, this.carForm.value);
      } else {
        this.carService.AddCar(this.carForm.value);
      }
    } else {
      // Form is invalid, show validation errors
      // For example, highlight invalid fields
    }
  }

  onFeatureCheckboxChange(feature: Feature, event: any) {
    if (event.target.checked) {
      console.log(feature)
      this.featureFormArray.push(this.formBuilder.group(feature));
    } else {
      const index = this.featureFormArray.controls.findIndex((i) => i.value.carFeatureId === feature.carFeatureId);
      this.featureFormArray.removeAt(index);
    }
  }

  onImageSelect(event: Event): void {
    const fileImage = (event.target as HTMLInputElement).files?.[0];
    if (fileImage) {
      const reader = new FileReader();
      reader.onload = () => {
        this.selectedImage = reader.result;
        const base64String = reader.result?.toString().split(',')[1];
        this.carForm.patchValue({ image: base64String });
      };
      reader.readAsDataURL(fileImage);
    }
  }
}
