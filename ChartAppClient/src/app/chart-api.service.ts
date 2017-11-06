import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Rx";
import { Chart } from './models/chart.model';
import { environment } from '../environments/environment';

@Injectable()
export class ChartApiService {

  private chartData: Chart;

  constructor(private http: Http) { }

  public uploadDataFile(formData: FormData): Observable<Chart> {
    return this.http.post(`${environment.api}/chart`, formData)
      .map(res => {
        this.chartData = res.json();
        return this.chartData;
      })
      .catch(error => Observable.throw(error));
  }
}
