import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PanelLandingComponent } from '../panel-landing/panel-landing.component';

const routes: Routes = [
  {
    path:'', component: PanelLandingComponent
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports:[
    RouterModule
  ]
})
export class AdminPanelRouteModule { }
