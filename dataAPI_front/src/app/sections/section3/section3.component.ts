import { Component, OnInit } from '@angular/core';
import {Server} from 'shared/server'

// test data
const SAMPLE_SERVERS = [
  {id: 1, name: 'LAMP server', isOnline:true},
  {id: 2, name: 'HTTP server', isOnline:false},
  {id: 3, name: 'MQTT server', isOnline:true},
  {id: 4, name: 'Sensors server', isOnline:true},
  {id: 5, name: 'SmartSensor01', isOnline:true},
  {id: 6, name: 'SmartSensor02', isOnline:true},
]

@Component({
  selector: 'app-section3',
  templateUrl: './section3.component.html',
  styleUrls: ['./section3.component.css']
})
export class Section3Component implements OnInit {

  constructor() { }

  servers: Server[] = SAMPLE_SERVERS;

  ngOnInit(): void {
  }

}
