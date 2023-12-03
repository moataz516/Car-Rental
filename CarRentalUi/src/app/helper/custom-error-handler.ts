import { HttpErrorResponse } from "@angular/common/http";
import { ErrorHandler,Injectable, Injector  } from "@angular/core";
import { ToastrService } from "ngx-toastr";


@Injectable()

export class CustomErrorHandler implements ErrorHandler{
    
    constructor(private injector: Injector, private toastr:ToastrService){}
    
    handleError(error: any): void {

        let errorMessage =''
        
        if(error instanceof HttpErrorResponse){
            const httpError = error as HttpErrorResponse;
            switch (httpError.status){
                case 400:
                    errorMessage = `${httpError.error}`;
                    break;
                case 401:
                    errorMessage = `status code(${httpError.status}):  ${httpError.error}`;
                    break;
                case 404:
                    errorMessage = `status code(${httpError.status}):  ${httpError.error}`;
                    break;    
                default:
                    errorMessage = 'An unexpected error occurred.';
                    break;   
            }
        }else{
            console.error('An error occurred:', error);
        }

        //let errorService = this.injector.get(ErrorService);
        //errorService.setErrorMessage(errorMessage);

    }
}