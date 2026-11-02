import { catalogReducer, CatalogState } from "./catalog/catalog.reducer";


export interface AppState{
    catalog:CatalogState
}

export const store={
    catalogStore:catalogReducer
}