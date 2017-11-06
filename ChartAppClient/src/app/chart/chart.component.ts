import { Component, OnInit } from '@angular/core';
import { ChartApiService } from '../chart-api.service';
import { Chart } from '../models/chart.model';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.css']
})
export class ChartComponent implements OnInit {

  public data: Chart;

  constructor(private chartApiService: ChartApiService) { }

  ngOnInit() {
    this.data = this.chartApiService.getData();
  }

}
