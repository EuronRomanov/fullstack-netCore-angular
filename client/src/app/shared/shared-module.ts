import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Rating} from './components/rating/rating';
import { MatIcon } from '@angular/material/icon';


@NgModule({
  declarations: [ Rating],
  imports: [
    CommonModule,
    MatIcon
   
  ],
  exports: [
    Rating
  ]
})
export class SharedModule {}
