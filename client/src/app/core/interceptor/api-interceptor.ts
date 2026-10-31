import { HttpInterceptorFn } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { inject } from '@angular/core';
import { BASE_API } from '../token/baseUrl.token';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {

const apiUrl=inject(BASE_API);

  if(!req.url.startsWith('http')) {
     const apiReq=req.clone({
    url:`${apiUrl}/${req.url}`
  });
    return next(apiReq);
  
  }
  
 


  return next(req);
};
