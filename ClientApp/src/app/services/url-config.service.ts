import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UrlConfigService {
  public readonly baseUrl = 'https://localhost:7215';

  public readonly itemsUrl = `${this.baseUrl}/api/Data/items`;

  public readonly cartUrl = `${this.baseUrl}/api/Cart`;

}
