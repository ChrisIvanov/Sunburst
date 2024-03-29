import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UrlConfigService } from '../url-config.service';

@Injectable({
  providedIn: 'root'
})
export class InventoryService {
  constructor(
    private http: HttpClient,
    private urlConfig: UrlConfigService
  ) { }

    getAllItems(): Observable<any> {
      return this.http.get(this.urlConfig.itemsUrl);
    }

    getItemByName(itemName: string): Observable<any> {
      const url = this.urlConfig.itemsUrl + "/" + itemName;
      //console.log(url)
      return this.http.get(url);
    }
}
