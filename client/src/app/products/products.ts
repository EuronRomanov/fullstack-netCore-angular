import { Component } from '@angular/core';

@Component({
  selector: 'app-products',
  standalone: false,
  styleUrl: './products.css',
  templateUrl: './products.html',
})
export class Products {
  pageIndex!:number;
  display(pageIndex:number){
    this.pageIndex=pageIndex;
  }

  filters!:object;
  filtersChanged(filters:object){
    console.log(filters);
    this.filters=filters;
  }

  sortFilters!:object;
  sortFiltersChanged(filters:object){
    console.log(filters);
    this.sortFilters=filters;
  }
}
