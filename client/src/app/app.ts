import { Component, OnInit, signal } from '@angular/core';
import { Store } from '@ngrx/store';
import { AppState } from './redux/store';
import { Observable, tap } from 'rxjs';
import { CategoryResDto } from './core/Models/catalog';
import { loadCategories } from './redux/catalog/catalog.action';
import { selectCategories } from './redux/catalog/catalog.selector';

@Component({
  selector: 'app-root',
  standalone: false,
  styleUrl: './app.css',
  templateUrl: './app.html',
})
export class App implements OnInit{
  protected readonly title = signal('client');
   categories$:Observable<CategoryResDto[]>;
  constructor(private store:Store<AppState>){
    this.categories$=this.store.select(selectCategories);
  }

 
  ngOnInit(): void {
    this.categories$.pipe(
      tap((categories)=>{
        if (categories.length===0) {
          this.store.dispatch(loadCategories())
        }
      })
    ).subscribe();
  }
}
