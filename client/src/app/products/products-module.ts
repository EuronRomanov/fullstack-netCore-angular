import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ProductsRoutingModule } from './products-routing-module';
import { Products } from './products';
import { Pagination } from './pagination/pagination';
import { MatButtonModule } from '@angular/material/button';
import { MatIcon } from '@angular/material/icon';

@NgModule({
  declarations: [Products, Pagination],
  imports: [CommonModule,
     ProductsRoutingModule,
     MatButtonModule,
     MatIcon
    ],
})
export class ProductsModule {}
