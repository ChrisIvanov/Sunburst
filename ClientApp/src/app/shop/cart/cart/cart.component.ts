import { CartCommunicationService } from 'src/app/services/cart/cart-communication.service';
import { CartService } from 'src/app/services/cart/cart.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  constructor(
    private authService: AuthService, 
    private router: Router,
    private cartService: CartService,
    private cartCommunicationService: CartCommunicationService,) { }

    addItemToCart() {
      const selectedItem = this.cartCommunicationService.getSelectedItem();
      if (selectedItem) {
        console.log(selectedItem)
        // Create cart item using selectedItem and call the cart service
        // to add the item to the cart
      }
    }
    
    createCart() {
      const cartItem = { /* construct your cart item object */ };
      this.cartService.createCart(cartItem).subscribe({
        next: (response) => {
          console.log('Cart created:', response);
          // Perform any other actions after successful cart creation
        },
        error: (error) => {
          console.error('Error creating cart:', error);
          // Handle the error
        }
      });
    }

    deleteCartItem(cartId: number) {
      this.cartService.deleteCart(cartId).subscribe({
        next: () => {
          console.log('Cart item deleted successfully.');
          // Perform any other actions after successful deletion
        },
        error: (error) => {
          console.error('Error deleting cart item:', error);
          // Handle the error
        }
      });
    }

  ngOnInit(): void {
  }
}

