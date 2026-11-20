import { Injectable, inject } from "@angular/core"; // ✅ Importa inject
import { Actions, createEffect, ofType } from "@ngrx/effects";
import { catchError, map, mergeMap, of } from "rxjs";
import { Catalog } from "../../core/Services/catalog";
import { loadCategories, loadCategoriesFailure, loadCategoriesSucess } from "./catalog.action";

@Injectable()
export class CatalogEffects {
    // ✅ Inyección con inject() en la propiedad
    private actions$ = inject(Actions); 
    private catalogService = inject(Catalog);

    // ✅ Ahora this.actions$ ya está definido cuando se evalúa esto
    loadCategories$ = createEffect(() =>
        this.actions$.pipe(
            ofType(loadCategories),
            mergeMap(() => 
                this.catalogService.getCategories().pipe(
                    map((res) => {
                        return res.isSuccessed 
                            ? loadCategoriesSucess({ categories: res.data ? res.data : [] })
                            : loadCategoriesFailure({ error: res.message });
                    }),
                    catchError((error) => of(loadCategoriesFailure({ error })))
                )
            )
        )
    );
}
