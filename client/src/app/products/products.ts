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
}
