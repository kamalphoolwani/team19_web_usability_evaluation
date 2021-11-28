import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'environments/environment';
import { Portal } from 'app/portal';
import { Observable, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';
import { Schedule } from 'app/schedule';

const API_URL = environment.apiUrl;

@Injectable()
export class PortalService {
   constructor(private http: HttpClient) { }

    public getAllPortals(): Observable<Portal[]> {
        return this.http.get<Portal[]>(API_URL + 'api/testprovider').pipe(
            catchError(this.handleError)
        );
    }

    public savePortal(portal : Portal): Observable<Portal[]> {
        return this.http.post<any>(API_URL + 'api/testprovider/addtestportal', portal).pipe(
            catchError(this.handleError)
        );
    }

    public getAllSchedules(): Observable<Schedule[]> {
      return this.http.get<Schedule[]>(API_URL + 'api/schedule/getall').pipe(
          catchError(this.handleError)
      );
    }

    public saveSchedule(schedule : Schedule): Observable<Schedule[]> {
        return this.http.post<any>(API_URL + 'api/schedule/addschedule', schedule).pipe(
            catchError(this.handleError)
        );
    }

  private handleError(error: HttpErrorResponse) {
    if (error.status === 0) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong.
      console.error(
        `Backend returned code ${error.status}, body was: `, error.error);
    }
    // Return an observable with a user-facing error message.
    return throwError(
      'Something bad happened; please try again later.');
  }
}