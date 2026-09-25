import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Home } from './home/home';
import { HomePage } from './home-page/home-page';

const routes: Routes = [
  {
    path:"",
    component:Home,
    pathMatch:'full',
    children:[
      {
        path:"",
        component:HomePage
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
