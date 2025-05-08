
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class FieldCheckService {
  constructor( ) {}

  areFieldsFilled(fields: Record<string, any>): boolean {
    for (const [key, value] of Object.entries(fields)) {
      // Пропускаем поля-чекбоксы (boolean) и поля, которые могут быть незаполненными
      if ((typeof value === 'boolean') || key=='resolutionId'|| key=='resolution') continue;

      // Проверка на пустоту
      if (value === null || value === undefined || value === '') {
        console.warn(`Поле "${key}" не заполнено.`);
        return false;
      }
    }
    return true;
  }

}
