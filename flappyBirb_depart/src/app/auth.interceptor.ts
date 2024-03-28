import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  noooon : String[] = ["http://localhost:7059/api/Users/Login","http://localhost:7059/api/Users/Register","http://localhost:7059/api/Scores/GetPublicScores"]
  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
    /*if(request.url != this.noooon.at(0)
    || request.url != this.noooon.at(1)
    || request.url != this.noooon.at(2)
    ){*/
      request = request.clone({
        setHeaders : {
          'Content-Type':'application/json',
          'Authorization':'Bearer '+ sessionStorage.getItem("token")
        }
      })

   //}
    
    return next.handle(request);
  }
}
