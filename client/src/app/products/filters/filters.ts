import { Component } from '@angular/core';
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
  minPrice:number=0;
  maxPrice:number=300;

  ratings=[
    {value:5,selected:false},
    {value:4,selected:false},
    {value:3,selected:false},
    {value:2,selected:false},
    {value:1,selected:false}

  ];
}
