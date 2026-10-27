import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Home } from './home/home';
import { HomePage } from './home-page/home-page';

const routes: Routes = [
  {
    path:"",
    component:Home,
    
    children:[
      {
        path:"",
        component:HomePage
      },
      {
        path:"products",
        loadChildren:()=>import('./products/products-module').then(m=>m.ProductsModule)
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
