import { Service } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable,tap } from 'rxjs'; 

@Injectable({
 providedIn:'root'
})
export class AuthService {
private apiUrl='/api/auth';

constructor(private http: HttpClient){}


login(credentials:any):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/login`,credentials).pipe(
        tap(response=>{
            if (response.isSuccessed && response.data) {
                this.saveTokens(response.data.accessToken,response.data.refreshToken);
            }
        })
    );
}


refreshToken(refreshToken:string,accessToken:string):Observable<any>{
    return this.http.post<any>(`${this.apiUrl}/refresh`,{refreshToken,accessToken});
}

    saveTokens(accessToken: string, refreshToken: string) {
        localStorage.setItem('accessToken',accessToken);
        localStorage.setItem('refreshtoken',refreshToken);
    }


    
     getAccessToken() : string | null {
        return localStorage.getItem('accessToken');
    }
    
    getRefreshToken() : string | null {
        return localStorage.getItem('refreshToken');
    }


    logout(){
        localStorage.removeItem('accessToken');
        localStorage.removeItem('refreshToken');
    }


}
