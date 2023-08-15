import { Injectable } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { HttpClient } from '@angular/common/http';
import { Observer } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class AuthService {
  constructor(private cookieService: CookieService) { }

  isAuthenticated(): string | null {
    const accessToken = sessionStorage.getItem('oidc.user:https://localhost:44459:Sunburst');

    return accessToken;
  }
}
