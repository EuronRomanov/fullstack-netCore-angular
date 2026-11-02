import { Component } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryResDto } from '../../core/Models/catalog';
import { AppState } from '../../redux/store';
import { Store } from '@ngrx/store';
import { selectCategories } from '../../redux/catalog/catalog.selector';

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

 
  categories$:Observable<CategoryResDto[]>;
    constructor(private store:Store<AppState>){
      this.categories$=this.store.select(selectCategories);
    }
  
}
