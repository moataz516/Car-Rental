import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  // intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
  //   return next.handle(request).pipe(
  //     catchError((error: HttpErrorResponse) => {

  //       let errorMessage = 'An error occurred'
  //       if(error instanceof HttpErrorResponse){
  //           const httpError = error as HttpErrorResponse;
  //           switch (httpError.status){
  //               case 400:
  //                   errorMessage = `${httpError.error}`;
  //                   break;
  //               case 401:
  //                   errorMessage = `Unauthurized`;
  //                   break;
  //               case 404:
  //                   errorMessage = `Not Found`;
  //                   break;    
  //               default:
  //                   errorMessage = 'Unexpected error occurred.';
  //                   break;   
  //           }
  //       }
  //       return throwError(errorMessage);
  //     })
  //   );
  // }


  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError((error: HttpErrorResponse) => {
        
        return throwError(error?.error)
      })
    );
  }

}