import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pie-chart',
  templateUrl: './pie-chart.component.html',
  styleUrls: ['./pie-chart.component.css']
})
export class PieChartComponent implements OnInit {

  constructor() { }

  // properties
  pieChartData: number[] = [350, 450, 120];
  pieChartLabels: string[] = ['client1', 'client2', 'client3'];
  colors: any[] = [
    {
      backgroundColor: ['#26547c', '#ff6b6b', '#ffd166'],
      borderColor: 'white'
    }
  ];
  pieChartType = 'pie';

  ngOnInit(): void {
  }

}
