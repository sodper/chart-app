import { Component, OnInit, ElementRef, ViewChild, Renderer } from '@angular/core';
import { ChartApiService } from '../chart-api.service';
import { ChartModel } from '../models/chart.model';
import { Chart } from 'chart.js';
import { Observable } from 'rxjs/Rx';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  @ViewChild('chartCanvas')
  public chartCanvas: ElementRef;
  public countDown: Observable<number>;
  
  private readonly secondsToCountDown: number = 60;
  private counter: number = this.secondsToCountDown;

  constructor(private chartApiService: ChartApiService, private renderer: Renderer) { }

  ngOnInit() {
    this.chartApiService.getData().subscribe(data => this.createChart(data));

    this.countDown = this.createTimer();

    setInterval(() => {
      this.chartApiService.refreshData().subscribe(data => {
        this.chartCanvas.nativeElement.innerHTML = '<canvas width="400" height="400"></canvas>';
        this.createChart(data)
        this.countDown = this.createTimer();
      });
    }, this.secondsToCountDown * 1000);
  }

  private createTimer(): Observable<number> {
    this.counter = this.secondsToCountDown;

    return Observable.timer(0, 1000)
    .take(this.counter)
    .map(() => --this.counter);
  }

  private createChart(chartModel) {
    let myChart = new Chart(this.chartCanvas.nativeElement.getContext('2d'), {
      type: 'bar',
      data: {
        labels: chartModel.labels,
        datasets: [{
          data: chartModel.data,
          backgroundColor: chartModel.colors
        }]
      },
      options: {
        legend: { display: false },
        scales: {
          yAxes: [{
            ticks: {
              beginAtZero: true
            }
          }]
        }
      }
    });
  }
}
