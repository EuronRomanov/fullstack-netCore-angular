import { Component, EventEmitter, Input, Output } from '@angular/core';
import { BrandResDto, CategoryResDto } from '../../core/Models/catalog';

@Component({
  selector: 'app-filters',
  standalone: false,
  styleUrl: './filters.css',
  templateUrl: './filters.html',
})
export class Filters {
  categories:CategoryResDto[]=[
    {
      id:1,
      name:'TV',
      image:null

    },
     {
      id:2,
      name:'Mobile',
      image:null
      
    },
     {
      id:3,
      name:'Camera',
      image:null
      
    },
     {
      id:4,
      name:'Computer',
      image:null
      
    }

  ]

  brands:BrandResDto[]=[
     {
      id:1,
      name:'xiomi',
      image:null
      
    }
  ]
 // minPrice:number=0;
  //maxPrice:number=300;

  ratings=[
    {value:5,selected:false},
    {value:4,selected:false},
    {value:3,selected:false},
    {value:2,selected:false},
    {value:1,selected:false}

  ];

  @Input() selectedCategoryIds:number[]=[];
  @Input() selectedBrandIds:number[]=[];
  @Input() selectedStockType:boolean=true;
  @Input() selectedRating:number[]=[];

  @Input() minPrice: number=0;
  @Input() maxPrice:number=300;
  @Input() selectedMinPrice: number=this.minPrice;
  @Input() selectedMaxPrice: number=this.maxPrice;

 @Output() filtersChanged=new EventEmitter<any>();

 //update the selected price range
minPriceChange(priceData:any){
  this.selectedMinPrice=priceData.value;
  this.applyFilters();
}
maxPriceChange(priceData:any){
  this.selectedMaxPrice=priceData.value;
  this.applyFilters();
}


toggleRating(ratingValue:number){
  const index=this.selectedRating.indexOf(ratingValue);
  if (index===-1) {
    this.selectedRating.push(ratingValue);
  } else {
    this.selectedRating.splice(index,1);
  }
  this.applyFilters();
}


toggleCategory(categoryValue:number){
  const index=this.selectedCategoryIds.indexOf(categoryValue);
  if (index===-1) {
    this.selectedCategoryIds.push(categoryValue);
  } else {
    this.selectedCategoryIds.splice(index,1);
  }
  this.applyFilters();
}

toggleBrand(brandValue:number){
  const index=this.selectedBrandIds.indexOf(brandValue);
  if (index===-1) {
    this.selectedBrandIds.push(brandValue);
  } else {
    this.selectedBrandIds.splice(index,1);
  }
  this.applyFilters();
}


toggleStock(value:boolean){
  this.selectedStockType=value;
  this.applyFilters();
}


 applyFilters(){
  const selectedFilters={
    categoryId:this.selectedCategoryIds,
    brandId:this.selectedBrandIds,
    minPrice:this.selectedMinPrice,
    maxPrice:this.maxPrice,
    stockType:this.selectedStockType,
    ratings:this.selectedRating
  };

  this.filtersChanged.emit(selectedFilters)
 }
}
