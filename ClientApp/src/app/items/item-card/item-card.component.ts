import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-item-card',
  templateUrl: './item-card.component.html',
  styleUrls: ['./item-card.component.css']
})

export class ItemCardComponent {
  @Input() item: any;
  @Input() ImagePath: any;
  
  constructor() {
    console.log(String(this.ImagePath));
  }
}