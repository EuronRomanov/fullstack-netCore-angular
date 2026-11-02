import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadCategories, loadCategoriesFailure, loadCategoriesSucess } from "./catalog.action";
import { catchError, map, mergeMap, of } from "rxjs";
import { Catalog } from "../../core/Services/catalog";


@Injectable()
export class CatalogEffects {
    constructor(private action$:Actions,private catalogService:Catalog) {}

    loadCategories$=createEffect(()=>
    this.action$.pipe(
        ofType(loadCategories),
        mergeMap(()=>
         this.catalogService.getCategories().pipe(
            map((res)=>{
              return  res.isSuccessed==true?
              loadCategoriesSucess({categories:res.data?res.data:[]})
              :
              loadCategoriesFailure({error:res.message});
            }),
            catchError((error)=>of(loadCategoriesFailure({error})))
         )
       )
    )
    )
}