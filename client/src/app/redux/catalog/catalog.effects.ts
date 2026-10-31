import { Injectable } from "@angular/core";
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { loadCategories, loadCategoriesSucess } from "./catalog.action";
import { mergeMap, of } from "rxjs";
import { Catalog } from "../../core/Services/catalog";


@Injectable()
export class CatalogEffects {
    constructor(private action$:Actions,private catalogService:Catalog) {}

    loadCategories$=createEffect(()=>
    this.action$.pipe(
        ofType(loadCategories),
        mergeMap(()=>of(loadCategoriesSucess({categories:[]})))
    )
    )
}