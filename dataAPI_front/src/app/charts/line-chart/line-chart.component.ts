import { Component, OnInit } from '@angular/core';
import {LINE_CHART_COLORS} from 'shared/chartColors';

// samples test data
const LINE_CHART_SAMPLE_DATA: any[] = [
  { data: [32, 14, 46, 23, 38, 56, 32, 14, 46, 23, 38, 56], label: 'Service 1'},
  { data: [12, 18, 26, 13, 28, 26, 12, 18, 26, 13, 28, 26], label: 'Service 2'},
  { data: [52, 34, 49, 53, 68, 62, 52, 34, 49, 53, 68, 62], label: 'Service 3'}
];

const LINE_CHART_LABELS: string[] = ['Jan', 'Fev', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dec']


@Component({
  selector: 'app-line-chart',
  templateUrl: './line-chart.component.html',
  styleUrls: ['./line-chart.component.css']
})
export class LineChartComponent implements OnInit {

  constructor() { }

  lineChartData = LINE_CHART_SAMPLE_DATA;
  lineChartLabels = LINE_CHART_LABELS;
  lineChartOptions: any = {
    responsive: true
  };
  lineChartLegend = true;
  lineChartType = 'line';
  lineChartColors = LINE_CHART_COLORS;

  ngOnInit(): void {
  }

}
