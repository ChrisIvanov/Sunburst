import { Component, OnInit } from '@angular/core';
import { InventoryService } from '../services/inventory.service';
import { Observer } from 'rxjs';

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
        console.log(this.items);
      },
      error: (error) => {
        console.error(error);
      },
      complete: () => {
        this.displayImagePaths();
        // This part is optional, you can omit it if you don't need it
        console.log('Item Observer completed');
      }
    };
    
    this.inventoryService.getAllItems().subscribe(observer);
  }

  displayImagePaths() {
    this.items.forEach(item => {
      console.log(String(item.ImagePath));
    });
  }
}
