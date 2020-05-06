import { Routes } from '@angular/router';
// import { SectionSalesComponent } from './app/sections/section-sales/section-sales.component';
// Section1 -> Sales -> Menu1
// import { SectionOrdersComponent } from './app/sections/section-orders/section-orders.component';
// Section2 -> Orders -> Menu2
// import { SectionHealthComponent } from './app/sections/section-health/section-health.component';
// Section3 -> Health -> Menu3

import { Section1Component } from './app/sections/section1/section1.component';
import { Section2Component } from './app/sections/section2/section2.component';
import { Section3Component } from './app/sections/section3/section3.component';

export const appRoutes: Routes = [
    { path: 's1', component: Section1Component },       // menu1
    { path: 's2', component: Section2Component },       // menu2
    { path: 's3', component: Section3Component },       // menu3

    { path: '', redirectTo: '/s1', pathMatch: 'full'},  // if the path is empty -> redirect
];