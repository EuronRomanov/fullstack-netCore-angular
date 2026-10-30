import { Component, EventEmitter, Input, Output } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';

@Component({
  selector: 'app-sort-header',
  standalone: false,
  styleUrl: './sort-header.css',
  templateUrl: './sort-header.html',
})
export class SortHeader {
 readonly showOptions:number[]=[10,20,30,50,100];
  readonly sortOptions:string[]=['Featured','Price:Low to High','Price:High to Low','Rating','Newest'];

@Input()  itemsToShow:number=10;
@Input()  sortBy:string="Featured";

@Output() sortHeaderChanges=new EventEmitter<any>();

itemsToShowChange(obj:MatSelectChange){
  this.itemsToShow=obj.value;
  this.applyChanges();
}

sortByChange(obj:MatSelectChange){
  this.sortBy=obj.value;
  this.applyChanges();
}

applyChanges(){
  const sortFiller={
    itemsToShow:this.itemsToShow,
    sortBy:this.sortBy
  }
  this.sortHeaderChanges.emit(sortFiller);
}

}
