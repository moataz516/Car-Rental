import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import { NavbarComponent } from './component/shared/navbar/navbar.component';
import { LoginComponent } from './component/account/login/login.component';
import { ErrorInterceptor } from './intercept/error.interceptor';
import { ToastrModule, ToastNoAnimation, ToastNoAnimationModule } from 'ngx-toastr';
import { JwtModule } from '@auth0/angular-jwt';
import { RegisterComponent } from './component/account/register/register.component';
import { AuthGuard } from './guard/auth.guard.service';
import { HomeComponent } from './component/home/home.component';
import { TokenIntercepterService } from './intercept/token.interceptor.service';
import { SearchCarComponent } from './component/home/search-car/search-car.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { CarComponent } from './component/car/car.component';
import { CarActionComponent } from './component/car/car-action/car-action.component';
import { CarOwnerComponent } from './component/car/car-owner/car-owner.component';
import { CarDetailsComponent } from './component/car/car-details/car-details.component';
import { CarItemComponent } from './component/car/car-item/car-item.component';
import { CarRentedComponent } from './component/car/car-rented/car-rented.component';
import { CarReturnedComponent } from './component/car/car-returned/car-returned.component';
import { AvailableCarComponent } from './component/car/available-car/available-car.component';
import {MatTableModule} from '@angular/material/table';
import {MatDialogModule} from '@angular/material/dialog';
import { EditCarComponent } from './component/car/car-action/edit-car/edit-car.component';
import { DeleteConfirmationDialogComponent } from './component/car/car-action/delete-car-dialog.component';
import { ObserversModule } from '@angular/cdk/observers';
import { ReservationComponent } from './component/reservation/reservation.component';
import { PaymentComponent } from './component/reservation/payment/payment.component';
import { BookingComponent } from './component/reservation/booking/booking.component';
import { ResActionComponent } from './component/reservation/booking/res-action/res-action.component';
import { VehicletypeComponent } from './component/home/vehicletype/vehicletype.component';
import { FilterPipe } from './filter/vehicle-car.pipe';
import { ResDialogComponent } from './component/reservation/res-dialog/res-dialog.component';
import { BrandFilter } from './filter/car.pipe';
import { MatPaginatorModule } from '@angular/material/paginator';
import { SlickCarouselModule } from 'ngx-slick-carousel';
import { ProfileComponent } from './component/profile/profile.component';
import { UpdateProfileComponent } from './component/profile/update-profile/update-profile.component';
import { UserBookingComponent } from './component/car/user-booking/user-booking.component';
import { BookingDetailsComponent } from './component/car/user-booking/booking-details/booking-details.component';
import { DatePipe } from '@angular/common';
import {MatMenuModule} from '@angular/material/menu';
import { ContactUsComponent } from './component/shared/contact-us/contact-us.component';
import { FooterComponent } from './component/shared/footer/footer.component';
import { BookingPdfReaderComponent } from './component/car/user-booking/booking-pdf-reader/booking-pdf-reader.component';
import { NgxExtendedPdfViewerModule } from 'ngx-extended-pdf-viewer';

export function tokenGetter() {
  return localStorage.getItem("jwt");
}

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    SearchCarComponent,
    CarComponent,
    CarActionComponent,
    CarOwnerComponent,
    CarDetailsComponent,
    CarItemComponent,
    CarRentedComponent,
    CarReturnedComponent,
    AvailableCarComponent,
    EditCarComponent,
    DeleteConfirmationDialogComponent,
    ReservationComponent,
    PaymentComponent,
    BookingComponent,
    ResActionComponent,
    VehicletypeComponent,
    FilterPipe,
    ResDialogComponent,
    BrandFilter,
    ProfileComponent,
    UpdateProfileComponent,
    UserBookingComponent,
    BookingDetailsComponent,
    ContactUsComponent,
    FooterComponent,
    BookingPdfReaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatTableModule,
    MatDialogModule,
    MatPaginatorModule,
    ObserversModule,
    MatMenuModule,
    NgxExtendedPdfViewerModule,
    ToastNoAnimationModule.forRoot(),
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:7292"],
        disallowedRoutes: []
      }}),
      NgxPaginationModule,
      SlickCarouselModule,
  ],
  //schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [
    AuthGuard,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenIntercepterService,
      multi: true,
    },
    {
    provide: HTTP_INTERCEPTORS,
    useClass: ErrorInterceptor,
    multi: true
  },
  DatePipe
],
  bootstrap: [AppComponent]
})
export class AppModule { }
