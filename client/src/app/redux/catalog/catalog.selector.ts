import { createFeatureSelector, createSelector } from "@ngrx/store";
import { CatalogState } from "./catalog.reducer";


export const selectCatalogsState=createFeatureSelector<CatalogState>('catalogStore');

export const selectCategories=createSelector(
    selectCatalogsState,
    (state:CatalogState)=>state.categories
)