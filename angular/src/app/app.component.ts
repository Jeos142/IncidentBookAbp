import { Component, OnInit } from '@angular/core';
import { AuthService } from '@abp/ng.core';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent  implements OnInit{
  userName: string | null = null;

  constructor(private authService: AuthService) {
    this.extractUserNameFromToken();
  }

  get hasLoggedIn(): boolean {
    return this.authService.isAuthenticated;
  }

  login() {
    this.authService.navigateToLogin();
  }

  logout() {
    this.authService.logout();

  }
  ngOnInit(): void {
    this.extractUserNameFromToken();
  }

  private extractUserNameFromToken(): void {
    const claimsJson = localStorage.getItem('id_token_claims_obj');

    if (!claimsJson) {
      console.warn('️ Нет расшифрованного токена (id_token_claims_obj)');
      this.userName = null;
      return;
    }

    try {
      const claims = JSON.parse(claimsJson);

      console.log(' Расшифрованный id_token_claims_obj:', claims);

      this.userName =
        claims.name ??
        claims.preferred_username ??
        claims.sub ??
        'Пользователь';

      console.log(' this.userName:', this.userName);
    } catch (e) {
      console.error(' Ошибка при чтении токена:', e);
      this.userName = null;
    }
  }


}
