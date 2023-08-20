import { CartCommunicationService } from 'src/app/services/cart/cart-communication.service';
import { CartService } from 'src/app/services/cart/cart.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Component, OnInit, NgModule } from '@angular/core';
import { Router } from '@angular/router';
import { CartLoginDialogComponent } from '../cart-login-dialog/cart-login-dialog.component';
import { map } from 'rxjs';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})

export class CartComponent implements OnInit {
  user = this.authService.isAuthenticated();
  purchaseComplete: boolean = false;
  deliveryDate: string = '';
  cartItems: any[] = [];
  cart: any;

  constructor(
    private authService: AuthService,
    private router: Router,
    private cartService: CartService,
    private cartCommunicationService: CartCommunicationService,) { }

  addItemToCart() {
    const selectedItem = this.cartCommunicationService.getSelectedItem();
    if (selectedItem) {
      console.log(selectedItem)
    }
  }

  getCart() {
    let userName = JSON.parse(String(this.user)).profile.name;
    this.cart = this.cartService.getUserCart(userName).subscribe({
      next: (response) => {
        const cartItems = this.getCartItems(this.cart)
        console.log(cartItems)
        return cartItems;
      },
      error: (error) => {
        console.error('Error finding cart:', error);
      }
    });
  }

  getCartItems(cart: any) {
    return this.cartItems = cart.items;
  }

  getTotalPrice(): number {
    return this.cartItems.reduce((total, item) => total + item.price, 0);
  }

  completePurchase(): void {
    this.purchaseComplete = true;

    const currentDate = new Date();
    const threeDaysFromNow = new Date();
    threeDaysFromNow.setDate(currentDate.getDate() + 3);
    this.deliveryDate = threeDaysFromNow.toDateString(); 
  }

  ngOnInit(): void {
    this.getCart();

  }
}

