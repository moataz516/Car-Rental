import {
    HttpEvent,
    HttpHandler,
    HttpInterceptor,
    HttpRequest,
  } from '@angular/common/http';
  import { Injectable } from '@angular/core';
  import { Observable } from 'rxjs';
import { AuthenticationService } from '../service/authentication.service';
import { SharedService } from '../service/shared.service';
  
  @Injectable()
  export class TokenIntercepterService implements HttpInterceptor {
    constructor(public shared: SharedService) {}
  
    intercept(
      requist: HttpRequest<any>,
      next: HttpHandler
    ): Observable<HttpEvent<any>> {
      if (this.shared.isLoggedIn()) {
        const token = localStorage.getItem('jwt');
        requist = requist.clone({
          setHeaders:{
             Authorization: `Bearer ${token}`
          },
        });
      } 
      return next.handle(requist);
    }
  }