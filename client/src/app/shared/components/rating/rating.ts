import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 's-rating',
   standalone: false,
  styleUrl: './rating.css',
  templateUrl: './rating.html',
})
export class Rating implements OnInit{
 @Input() rating:number=0 

  ngOnInit(): void {
this.rating=this.rating>5?5:Math.floor(this.rating);
  }
 

}
