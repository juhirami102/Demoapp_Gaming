import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


const routes: Routes = [
  {
    path: "", redirectTo: 'main', pathMatch: 'full'
  },
  {
    path: "main", loadChildren: () => import("./landing/landing.module").then(x => x.LandingModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
