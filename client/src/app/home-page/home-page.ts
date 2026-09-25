import { Component ,signal} from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { CarouselModule as owlCarouselModule } from 'ngx-owl-carousel-o';
import {MatCardModule} from '@angular/material/card';
import { CommonModule } from '@angular/common';

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
export class HomePage {
  myInterval:number=1000
  
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
  }
   slidesStore = signal<any[]>([
    { id: '1', src: 'assets/Audio&HomeTheater.jpg', alt: 'Audio & Home Theater', title: 'Audio & Home Theater' },
    { id: '2', src: 'assets/Camera.jpg', alt: 'Camera', title: 'Camera' },
    { id: '3', src: 'assets/Computers.jpg', alt: 'Computers', title: 'Computers' },
    { id: '4', src: 'assets/smarthphone.jpg', alt: 'Mobile', title: 'Mobile' },
    { id: '5', src: 'assets/smartTv.jpg', alt: 'TV & video', title: 'TV & video' },
    { id: '6', src: 'assets/smartwatch.jpg', alt: 'Wearable Technology', title: 'Wearable Technology' },

  ]);

}
