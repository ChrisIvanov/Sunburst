import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CartCommunicationService {
  private selectedItem: any;

  setSelectedItem(item: any) {
    this.selectedItem = item;
  }

  getSelectedItem(): any {
    return this.selectedItem;
  }
}
