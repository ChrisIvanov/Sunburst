import { CartCommunicationService } from 'src/app/services/cart/cart-communication.service';
import { InventoryService } from 'src/app/services/inventory/inventory.service';
import { AuthorizeService } from '../../../api-authorization/authorize.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CartService } from 'src/app/services/cart/cart.service';
import { Observable, Observer, Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { HttpEvent } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { User, UserManager } from 'oidc-client';

@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
  styleUrls: ['./item-page.component.css']
})

export class ItemPageComponent implements OnInit {
  item: any;
  private subscription!: Subscription;
  public isAuthenticated?: Observable<string | null>;
  user = this.authService.isAuthenticated();

  constructor(
    private cartCommunication: CartCommunicationService,
    private inventoryService: InventoryService,
    private authorizeService: AuthorizeService,
    private authService: AuthService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private router: Router,
  ) { }

  ngOnInit(): void {
    const itemName = this.route.snapshot.params['name'];
    this.isUserLoggedIn();

    const observer: Observer<any> = {
      next: (data) => {
        this.item = data;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log('Item Observer completed');
      }
    };

    this.item = this.inventoryService.getItemByName(itemName).subscribe(observer);;
  }

  isUserLoggedIn(): boolean {
    const user = this.authService.isAuthenticated();

    return user !== null;
  }

  buyItem(item: any): void {
    if (this.isUserLoggedIn()) {
      this.cartCommunication.setSelectedItem(item);
      let userName = JSON.parse(String(this.user));
      console.log(userName.profile.name);
  
      this.cartService.checkIfCartExists(userName.profile.name)
        .subscribe({
          next: (cartExists) => {
            if (cartExists) {
              console.log("inside updateCart")
              this.cartService.updateCart(item);
            } else {
              let cart = { UserName: `${userName}`, TotalPrice: item.Price, Items: [item] };
              console.log("inside createCart")

              this.cartService.createCart(cart);
            }
          },
          error: (error) => {
            console.error('Error checking if cart exists:', error);
          }
        });
    } else {
      this.router.navigate(['authentication/login'], { queryParams: { message: 'Please log in to buy items.' } });
    }
  }
}
