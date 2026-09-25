import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  standalone: false,
  styleUrl: './header.css',
  templateUrl: './header.html',
})
export class Header {
  categories:string[]=[
    'TV & Video',
    'Audio & Home Theater',
    'Mobile',
    'Computers',
    'Camera & Photo',
    'Wearable Technology'
  ]
}
