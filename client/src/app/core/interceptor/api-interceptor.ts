import { HttpErrorResponse, HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { BASE_API } from '../token/baseUrl.token';
import { AuthService } from '../Services/auth';
import { catchError, switchMap, throwError } from 'rxjs';

export const apiInterceptor: HttpInterceptorFn = (req, next) => {
  const apiUrl = inject(BASE_API);
  const authService = inject(AuthService);

  // 1. Obtener el token
  const accessToken = authService.getAccessToken();

  // 2. Clonar la petición y añadir el token y la URL base
  let authReq = req;
  if (!req.url.startsWith('http')) {
    authReq = req.clone({
      url: `${apiUrl}/${req.url}`,
      setHeaders: accessToken ? { Authorization: `Bearer ${accessToken}` } : {}
    });
  }

  // 3. Manejar la respuesta y el error 401
  return next(authReq).pipe(
    catchError((error: HttpErrorResponse) => {
      if (error.status === 401 && authService.getRefreshToken()) {
        // Intentar refresh
        return authService.refreshToken(authService.getRefreshToken()!, accessToken!).pipe(
          switchMap((response: any) => {
            if (response.isSuccessed && response.data) {
              authService.saveTokens(response.data.accessToken, response.data.refreshToken);
              const retryReq = req.clone({
                url: `${apiUrl}/${req.url}`,
                setHeaders: { Authorization: `Bearer ${response.data.accessToken}` }
              });
              return next(retryReq);
            }
            authService.logout();
            return throwError(() => new Error('Sesión expirada'));
          }),
          catchError((refreshError) => {
            authService.logout();
            return throwError(() => refreshError);
          })
        );
      }
      return throwError(() => error);
    })
  );
};
