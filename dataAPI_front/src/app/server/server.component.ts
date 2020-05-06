import { Component, OnInit, Input } from '@angular/core';
import {Server} from 'shared/server';

@Component({
  selector: 'app-server',
  templateUrl: './server.component.html',
  styleUrls: ['./server.component.css']
})
export class ServerComponent implements OnInit {

  constructor() { }
  
  color: string;
  buttonText: string;

  // input decorator -> server referes to the "serverInput" in section3.component.html
  @Input() serverInput: Server;

  ngOnInit(): void {
    this.setServerStatus(this.serverInput.isOnline);
  }

  setServerStatus(isOnline: boolean) {
    if (isOnline) {
      this.serverInput.isOnline = true;
      this.color = 'green';
      this.buttonText = 'ShutDown System'
    }
    else {
      this.serverInput.isOnline = false;
      this.color = 'red';
      this.buttonText = 'Start System';
    }
  }

  toggleStatus(onlineStatus: boolean) {
    // debug
    console.log(this.serverInput.name, ': ', onlineStatus)
    // change status of the server
    // this.serverInput.isOnline = !this.serverInput.isOnline;
    this.setServerStatus(!onlineStatus);
  }

}
