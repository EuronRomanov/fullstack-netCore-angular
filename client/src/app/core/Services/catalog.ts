import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseDto } from '../Models/response';
import { CategoryResDto } from '../Models/catalog';

@Injectable({
    providedIn:'root'
})
export class Catalog {
    constructor(private http:HttpClient){}

    getCategories(){
        return this.http.get<ResponseDto<CategoryResDto[]>>('catalog/category/getall');
    }
}
