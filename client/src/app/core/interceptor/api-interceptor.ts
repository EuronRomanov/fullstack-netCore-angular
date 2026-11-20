import { HttpInterceptorFn,HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { inject } from '@angular/core';
import { BASE_API } from '../token/baseUrl.token';
import { AuthService } from '../Services/auth';
import { catchError,switchMap,throwError } from 'rxjs';
import { Router } from '@angular/router';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {

const apiUrl=inject(BASE_API);
const authService=inject(AuthService);
const router=inject(Router);



const accessToken=authService.getAccessToken();


let authReq=req;
  if(!req.url.startsWith('http')) {
     const apiReq=req.clone({
    url:`${apiUrl}/${req.url}`
  });
    return next(apiReq);
  
  }
  
 


  return next(req);
};
