import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { LandingComponent } from '../landing/landing.component';

const routes: Routes = [
  {
    path: "", component: LandingComponent,
    children: [
      {
        path: "admin-panel", loadChildren: () => import('../Modules/admin-panel/admin-panel.module').then(x => x.AdminPanelModule)
      }
    ]
  }
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [RouterModule]
})
export class LandingRouteModule { }
