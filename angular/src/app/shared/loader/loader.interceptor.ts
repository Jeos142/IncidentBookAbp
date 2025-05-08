import { Injectable } from '@angular/core';
import {
  HttpEvent, HttpHandler, HttpInterceptor, HttpRequest
} from '@angular/common/http';
import { Observable, timer } from 'rxjs';
import { finalize, delayWhen } from 'rxjs/operators';
import { LoaderService } from './loader.service';

@Injectable()
export class LoaderInterceptor implements HttpInterceptor {
  constructor(private loaderService: LoaderService) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    this.loaderService.show(); // Показываем крутилку

    return next.handle(req).pipe(
      delayWhen(() => timer(300)), //  Добавляем хотя бы 300 мс минимальной задержки
      finalize(() => this.loaderService.hide()) // Скрываем потом
    );
  }
}
