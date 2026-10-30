import { createAction, props } from "@ngrx/store";
import { CategoryResDto } from "../../core/Models/catalog";

export const loadCategories=createAction('[Category] Load Categories');

export const loadCategoriesSucess=createAction(
    '[Category] Load Categories Sucess',
    props<{categories:CategoryResDto}>()
)

export const loadCategoriesFailure=createAction(
    '[Category] Load Categories Failure',
    props<{error:any}>()
)