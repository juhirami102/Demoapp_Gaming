import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent, HttpClient, HttpResponse, HttpErrorResponse, HttpEventType } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { isNullOrUndefined } from 'util';
import { ApplicationVeriable } from '../Types/Constants';
import { catchError } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class CliqueHRInterceptorService implements HttpInterceptor {

  constructor(private httpClient: HttpClient) { }

  private AddAuthToken(req: HttpRequest<any>) {
    let token = localStorage.getItem(ApplicationVeriable.AuthTokenKey);
    if (isNullOrUndefined(token) || token == "") {
      return req;
    }
    return req.clone({
      setHeaders: {
        "Authorization": "bearer " + token
      }
    });
  }

  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    req = this.AddAuthToken(req);
    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        if (!isNullOrUndefined(error)) {
          if (error.status == 401) {
            // Handle error code
          }
          else if (error.status == 403) {
            // Handle error code
          }
        }
        return throwError(error);
      }
      )
    );
  }
}
