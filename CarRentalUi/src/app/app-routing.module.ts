import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './component/account/login/login.component';
import { RegisterComponent } from './component/account/register/register.component';
import { AppComponent } from './app.component';
import { AuthGuard } from './guard/auth.guard.service';
import { HomeComponent } from './component/home/home.component';
import { AvailableCarResolver } from './resolver/available.resolver';
import { CarActionComponent } from './component/car/car-action/car-action.component';
import { CarOwnerComponent } from './component/car/car-owner/car-owner.component';
import { CarDetailsComponent } from './component/car/car-details/car-details.component';
import { CarResolver } from './resolver/car.resolver';
import { CarRentedComponent } from './component/car/car-rented/car-rented.component';
import { CarReturnedComponent } from './component/car/car-returned/car-returned.component';
import { AvailableCarComponent } from './component/car/available-car/available-car.component';
import { EditCarComponent } from './component/car/car-action/edit-car/edit-car.component';
import { PaymentComponent } from './component/reservation/payment/payment.component';
import { BookingComponent } from './component/reservation/booking/booking.component';
import { ResActionComponent } from './component/reservation/booking/res-action/res-action.component';
import { ProfileComponent } from './component/profile/profile.component';
import { UserProfileResolver } from './resolver/profile.resolver';
import { UserBookingComponent } from './component/car/user-booking/user-booking.component';
import { BookingDetailsComponent } from './component/car/user-booking/booking-details/booking-details.component';
import { UserBookingDetailsResolver } from './resolver/user-booking-details.resolver';
import { BookingPdfReaderComponent } from './component/car/user-booking/booking-pdf-reader/booking-pdf-reader.component';

const routes: Routes = [
  {path:'',component:HomeComponent},
  {path:"available-car",component:AvailableCarComponent /*, resolve:{cars:AvailableCarResolver}*/},
  {path:"login" , component:LoginComponent},
  {path:'register', component:RegisterComponent},
  {path:'add-car', component:CarActionComponent},
  {path:'add-car/:id', component:CarActionComponent, resolve:{data:CarResolver}},

  {path:'car-owner', component:CarOwnerComponent},
  {path:'car-details/:id', component:CarDetailsComponent, resolve:{data:CarResolver}},
  {path:'car-rented', component:BookingComponent},
  {path:'car-returned', component:CarReturnedComponent},
  {path:'payment', component:PaymentComponent},
  {path:'res-action/:id', component:ResActionComponent},
  {path:'userBooking', component:UserBookingComponent},
  {path:'BookingDetails/:id', component:BookingDetailsComponent,resolve:{data:UserBookingDetailsResolver}},
  {path:'booking/pdf', component:BookingPdfReaderComponent},

  {path:'profile/:id', component:ProfileComponent, resolve:{data:UserProfileResolver}},


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
