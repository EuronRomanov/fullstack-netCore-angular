import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from "@angular/common";
import { MatIcon } from "@angular/material/icon";

@Component({
  selector: 's-rating',
  imports:[CommonModule,MatIcon],
  styleUrl: './rating.css',
  templateUrl: './rating.html',
})
export class Rating {
 @Input() rating:number=0 ;

  get starCount(): number {
   return  this.rating=this.rating>5?5:Math.floor(this.rating);
  }
 

}
