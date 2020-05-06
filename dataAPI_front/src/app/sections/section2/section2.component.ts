import { Component, OnInit } from '@angular/core';
import {Order} from 'shared/orders';

@Component({
  selector: 'app-section2',
  templateUrl: './section2.component.html',
  styleUrls: ['./section2.component.css']
})
export class Section2Component implements OnInit {

  constructor() { }

  orders: Order[] = [
    {
      id: 1,
      client: {id: 1, name:'Client1', state:'NO', email:'client1@client1.com'}, 
      total: 200, 
      placed: new Date(2020, 5, 5), 
      fullfilled: new Date(2019, 12, 2)},
    {
      id: 2,
      client: {id: 2, name:'Client2', state:'NO', email:'client2@client2.com'}, 
      total: 200, 
      placed: new Date(2020, 5, 5), 
      fullfilled: new Date(2019, 12, 2)},
    {
      id: 3,
      client: {id: 3, name:'Client3', state:'NO', email:'client3@client3.com'}, 
      total: 200, 
      placed: new Date(2020, 5, 5), 
      fullfilled: new Date(2019, 12, 2)},
    {
      id: 4,
      client: {id: 4, name:'Client4', state:'NO', email:'client4@client4.com'}, 
      total: 200, 
      placed: new Date(2020, 5, 5), 
      fullfilled: new Date(2019, 12, 2)},
    {
      id: 5,
      client: {id: 5, name:'Client5', state:'NO', email:'client5@client5.com'}, 
      total: 200, 
      placed: new Date(2020, 5, 5), 
      fullfilled: new Date(2019, 12, 2)}  
  ];

  ngOnInit(): void {
  }

}
