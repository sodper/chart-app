import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from "rxjs/Rx";
import { ChartModel } from './models/chart.model';
import { environment } from '../environments/environment';

@Injectable()
export class ChartApiService {

  private chartData: ChartModel;

  constructor(private http: Http) { }

  public uploadDataFile(formData: FormData): Observable<ChartModel> {
    return this.http.post(`${environment.api}/chart`, formData)
      .map(res => {
        this.chartData = res.json();
        return this.chartData;
      })
      .catch(error => Observable.throw(error));
  }

  public getData(): Observable<ChartModel> {
    if (this.chartData) {
      return Observable.of(this.chartData)
    };

    return this.refreshData();
  }

  public refreshData(): Observable<ChartModel> {
    return this.http.get(`${environment.api}/chart`)
      .map(res => {
        this.chartData = res.json();
        return this.chartData;
      })
      .catch(error => Observable.throw(error));
  }
}
