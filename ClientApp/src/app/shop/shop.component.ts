import { Component, OnInit } from '@angular/core';
import { InventoryService } from '../services/inventory.service';
import { Observer } from 'rxjs';
import { AuthService } from 'src/app/services/auth/auth.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.css']
})

export class ShopComponent implements OnInit {
  items: any[] = [];

  constructor(private inventoryService: InventoryService) { }

  ngOnInit(): void {
    const observer: Observer<any> = {
      next: (data) => {
        this.items = data;
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        console.log('Item Observer completed');
      }
    };
    
    this.inventoryService.getAllItems().subscribe(observer);
  }
}
