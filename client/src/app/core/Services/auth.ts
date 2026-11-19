import { Service } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,tap } from 'rxjs'; 

@Service()
export class AuthService {
private apiUrl='/api/auth';

constuctor(private http: HttpClient){}


login(credentials:any):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/login`,credentials).pipe(
        tap(response=>{
            if (response.isSuccessed && response.data) {
                this.saveTokens(response.data.accessToken,response.data.refreshToken);
            }
        })
    );
}


}
