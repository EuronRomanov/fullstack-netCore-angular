import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing-module';
import { Products } from './products';
import { Pagination } from './pagination/pagination';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';
import { Filters } from './filters/filters';

import { MatCheckboxModule } from "@angular/material/checkbox";

@NgModule({
  declarations: [Products, Pagination, Filters],
  imports: [CommonModule, ProductsRoutingModule, MatButtonModule, MatIcon,MatCheckboxModule],
})
export class ProductsModule {}
