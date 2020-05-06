import { Component, OnInit } from '@angular/core';

// data test
const SAMPLE_BARCHART_DATA: any[] = [
  { data: [65, 59, 80, 81, 56, 54, 30], label: 'Q3 Sales'},
  { data: [25, 39, 60, 91, 36, 54, 50], label: 'Q4 Sales'}
];

// labels
const SAMPLE_BARCHART_LABELS: string[] = ['W1', 'W2', 'W3', 'W4', 'W5', 'W6', 'W7'];

@Component({
  selector: 'app-bar-chart',
  templateUrl: './bar-chart.component.html',
  styleUrls: ['./bar-chart.component.css']
})

export class BarChartComponent implements OnInit {

  constructor() { }

  // public barChartData: any[];
  public barChartData: any[] = SAMPLE_BARCHART_DATA;
  // public barChartLabels: string[];
  public barChartLabels: string[] = SAMPLE_BARCHART_LABELS;
  public barChartType = 'bar';
  public barChartLegend = true;
  public barChartOptions: any = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  ngOnInit(): void {
  }

}
