import { createReducer, on } from "@ngrx/store";
import { CategoryResDto } from "../../core/Models/catalog";
import { loadCategories, loadCategoriesFailure, loadCategoriesSucess } from "./catalog.action";


export interface CatalogState{
    categories:CategoryResDto[],
    error:any
}

const initialState:CatalogState={
    categories:[],
    error:null
}

export const catalogReducer=createReducer(
    initialState,
    on(loadCategories,(state)=>({...state, error: null})),
    on(loadCategoriesSucess,(state,{categories})=>(
        {
            ...state,
            categories: categories,
            error:null
        }
    )),
    on(loadCategoriesFailure,(state,{error})=>(
        {
            ...state,
            error:error
        }
    ))
)
