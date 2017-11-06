import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { ChartApiService } from '../chart-api.service';
import { ChartModel } from '../models/chart.model';
import Chart from 'chart.js';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  @ViewChild('chartCanvas')
  public chartCanvas: ElementRef;

  public chartModel: ChartModel;

  constructor(private chartApiService: ChartApiService) { }

  ngOnInit() {
    this.chartApiService.getData().subscribe(data => {
      this.chartModel = data;

      let myChart = new Chart(this.chartCanvas.nativeElement.getContext('2d'), {
        type: 'bar',
        data: {
          labels: this.chartModel.labels,
          datasets: [{
            data: this.chartModel.data,
            backgroundColor: this.chartModel.colors
          }]
        },
        options: {
          scales: {
            yAxes: [{
              ticks: {
                beginAtZero: true
              }
            }]
          }
        }
      });
    });
  }

}
