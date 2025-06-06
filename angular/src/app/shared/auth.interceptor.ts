// src/app/core/interceptors/silent-auth.interceptor.ts
import { Injectable } from '@angular/core';
import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, EMPTY } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from '@abp/ng.core';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Пропускаем запросы к API ABP (настройки, локализация и т.д.)
    if (req.url.includes('/abp/')) {
      return next.handle(req);
    }

    return next.handle(req).pipe(
      catchError((error: HttpErrorResponse) => {
        // Игнорируем 401 ошибки для API приложения
        if (error.status === 401 && req.url.includes('/api/app/')) {
          return EMPTY; // Полностью подавляем ошибку
        }

        // Для всех остальных ошибок - пробрасываем дальше
        throw error;
      })
    );
  }
}
