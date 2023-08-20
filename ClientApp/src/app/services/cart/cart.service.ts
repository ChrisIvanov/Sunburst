import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UrlConfigService } from '../url-config.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  constructor(
    private http: HttpClient,
    private urlConfig: UrlConfigService) { }

    checkIfCartExists(userName: string): Observable<any> {
      return this.http.get(this.urlConfig.cartUrl + '/Check/' + userName);
    }

    createCart(cart: any): Observable<any> {
      const httpOptions = {
        headers: new HttpHeaders({
          'Content-Type': 'application/json',
        }),
      };
      console.log('inside cart service create-cart')
      return  this.http.post<any>(this.urlConfig.cartUrl + "/create", cart, httpOptions);
    }

    updateCart(cart: any): Observable<any> {
      return this.http.put(this.urlConfig.cartUrl + "/update", cart);
    }

    deleteCart(id: number): Observable<any> {
      return this.http.delete(this.urlConfig.cartUrl + '/${id}');
    }

    getCartItemByName(cartName: string): Observable<any> {
      return this.http.get(this.urlConfig.cartUrl + "/GetCartItem/${cartItem}");
    }

    getUserCart(userName: string): Observable<any> {
      return this.http.get(this.urlConfig.cartUrl + "/GetCartByUserName/" + userName);
    }
}
