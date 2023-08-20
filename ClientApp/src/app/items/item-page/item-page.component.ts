import { CartLoginDialogComponent } from 'src/app/shop/cart/cart-login-dialog/cart-login-dialog.component';
import { CartCommunicationService } from 'src/app/services/cart/cart-communication.service';
import { InventoryService } from 'src/app/services/inventory/inventory.service';
import { AuthorizeService } from '../../../api-authorization/authorize.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CartService } from 'src/app/services/cart/cart.service';
import { Observable, Observer, Subscription } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { HttpEvent } from '@angular/common/http';
import { MatDialog, MatDialogConfig } from '@angular/material';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
  styleUrls: ['./item-page.component.css']
})

export class ItemPageComponent implements OnInit {
  private cartCheckSubscription: Subscription = new Subscription;
  public isAuthenticated?: Observable<string | null>;
  user = this.authService.isAuthenticated();
  cart: any;
  item: any;

  constructor(
    private cartCommunication: CartCommunicationService,
    private inventoryService: InventoryService,
    private authService: AuthService,
    private cartService: CartService,
    private route: ActivatedRoute,
    private dialog: MatDialog,
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
      let userName = JSON.parse(String(this.user)).profile.name;
      console.log(userName);

      this.cartService.checkIfCartExists(userName)
        .subscribe({
          next: (cartExists) => {
            if (cartExists) {
              console.log(item)
              this.updateCartWithItem(item);
            } else {
              // Define the current date
              const currentDate: Date = new Date();

              // Calculate the date 3 days from now
              const threeDaysFromNow: Date = new Date();
              threeDaysFromNow.setDate(currentDate.getDate() + 3);

              let cart: { userName: string, totalPrice: number, created: Date, deliveryDate: Date, items: any[] } = {
                userName: userName,
                totalPrice: 0,
                created: currentDate,
                deliveryDate: threeDaysFromNow,
                items: [item]
              };

              this.cartService.createCart(cart).subscribe({
                next: (response) => {
                  console.log('Cart created:', response);
                  cart.items.push(item); // Add the item to the cart
                  console.log('Item added to cart:', cart);

                  // Now update the cart with the new item
                  // this.updateCartWithItem(cart);
                },
                error: (error) => {
                  console.error('Error creating cart:', error);
                }
              });
            }
          },
          error: (error) => {
            console.error('Error checking if cart exists:', error);
          }
        });
    } else {

      this.router.navigate(['authentication/login']);
    }
  }

  async updateCartWithItem(item: any) {
    try {
      const cart = await firstValueFrom(this.getCart());
      cart.items.push(item);
      console.log(cart)
      const serializedCart = JSON.stringify(cart);
      this.cartService.updateCart(cart).subscribe({
        next: (updateResponse) => {
          console.log('Cart updated with new item:', updateResponse);
        },
        error: (updateError) => {
          console.error('Error updating cart with new item:', updateError);
        }
      });
    } catch (error) {
      console.error('Error getting cart:', error);
    }
  }

  getCart(): Observable<any> {
    let userName = JSON.parse(String(this.user)).profile.name;
    return this.cartService.getUserCart(userName);
  }

  // openLoginDialog()  {
  //   const dialogConfig = new MatDialogConfig();

  //   dialogConfig.disableClose = true;
  //   dialogConfig.autoFocus = true;
  //   dialogConfig.hasBackdrop = true;
  //   dialogConfig.position = {
  //     'top': '50%',
  //     'left': '50%'
  //   };

  //   const dialogRef = this.dialog.open(CartLoginDialogComponent, dialogConfig);

  //   dialogRef.afterClosed().subscribe(result => {
  //     // Handle dialog close event if needed
  //   });
  // }

  ngOnDestroy() {
    if (this.cartCheckSubscription) {
      console.log('inside unsubscribe')
      this.cartCheckSubscription.unsubscribe();
    }
  }
}
