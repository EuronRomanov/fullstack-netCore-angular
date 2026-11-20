import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadCategories, loadCategoriesFailure, loadCategoriesSucess } from "./catalog.action";
import { catchError, map, mergeMap, of } from "rxjs";
import { Catalog } from "../../core/Services/catalog";


@Injectable()
export class CatalogEffects {
    constructor(
      private actions$:Actions,
      private catalogService:Catalog
    ) {
      console.log('actions inyectado:', this.actions$);
      console.log('CatalogService inyectado:',this.catalogService);
    }

    loadCategories$=createEffect(()=>{


if(!this.actions$){
  console.log("El servicio Actions es undifined.Revisa AppModule");
  throw new Error("Actions service not injected");
}

   return  this.actions$.pipe(
        ofType(loadCategories),
        mergeMap(()=>{
          console.log('Effect disparado,llamando al servicio...');
         return this.catalogService.getCategories().pipe(
            map((res)=>{
              return  res.isSuccessed==true?
              loadCategoriesSucess({categories:res.data?res.data:[]})
              :
              loadCategoriesFailure({error:res.message});
            }),
            catchError((error)=>{
              console.error('Error en la peticion',error);
              return of(loadCategoriesFailure({error}));
          })
         );
})
    )
 } );
}