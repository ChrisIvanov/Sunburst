import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InventoryService } from 'src/app/services/inventory.service';
import { Observable, Observer } from 'rxjs';
import { AuthService } from 'src/app/services/auth/auth.service';
import { CommonModule } from '@angular/common';
import { AuthorizeService } from '../../../api-authorization/authorize.service';
import { HttpEvent } from '@angular/common/http';

@Component({
  selector: 'app-item-page',
  templateUrl: './item-page.component.html',
  styleUrls: ['./item-page.component.css']
})

export class ItemPageComponent implements OnInit {
  item: any;
  public isAuthenticated?: Observable<string | null>;
  
  constructor(
    private route: ActivatedRoute,
    private inventoryService: InventoryService,
    private authService: AuthService, 
    private router: Router,
    private authorizeService: AuthorizeService) { }
    
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
    this.authorizeService.signOut;

    return user !== null;
  }

  buyItem(item: any): void {
    if (this.isUserLoggedIn()) {
      console.log('logged');
    } else {
      console.log('not logged');
      this.router.navigate(['authentication/login'], { queryParams: { message: 'Please log in to buy items.' } });
    }
  }

}
