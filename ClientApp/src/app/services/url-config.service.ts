import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlConfigService {
  private baseUrl = 'https://localhost:7215';

  public readonly itemsUrl = `${this.baseUrl}/api/Data`;
}
