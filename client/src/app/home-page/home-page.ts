import { Component ,signal,Inject,OnInit} from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CarouselModule as owlCarouselModule } from 'ngx-owl-carousel-o';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';

 import { Store } from '@ngrx/store';
 import { Observable } from 'rxjs';
 import { CategoryResDto } from '../core/Models/catalog';
 import { AppState } from '../redux/store';
 import { selectCategories } from '../redux/catalog/catalog.selector';
import { BASE_IMAGE_API } from '../core/token/baseImage.token';
  

@Component({
  selector: 'app-home-page',
  standalone: true,
  styleUrl: './home-page.css',
  templateUrl: './home-page.html',
  imports:[
    CommonModule,
     CarouselModule,
   owlCarouselModule,
   MatCardModule
  ]
})
export class HomePage implements OnInit {
  myInterval:number=1000;

  categories$:Observable<CategoryResDto[]>;
  
 constructor(
  private store:Store<AppState>,
  @Inject(BASE_IMAGE_API) public imageApi:string
 ){
  this.categories$=this.store.select(selectCategories);
 }

 ngOnInit(): void {
   
 }

   customOptions: OwlOptions = {
    loop: true,
    mouseDrag: false,
    touchDrag: false,
    pullDrag: false,
    dots: false,
    navSpeed: 700,
    navText: ['', ''],
    responsive: {
      0: {
        items: 1
      },
      400: {
        items: 2
      },
      740: {
        items: 3
      },
      940: {
        items: 4
      }
    },
    nav: false,
    autoplay:true,
    autoplaySpeed:1000
  };

}
