import { Component, OnInit } from '@angular/core';
import { ShippersModel } from '../../../shared/models/northwind/shippers/shippersModel';
import { ShippersService } from 'src/app/shared/service/northwind/shippers/shippers.service';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.scss']
})
export class ShippersComponent implements OnInit {

  public shippers: ShippersModel[] = [];

  constructor(private shippersService: ShippersService) {
  }

  ngOnInit(): void {
    this.getShippers();
    console.log('Lista de shippers:', this.shippers);
  }

  getShippers(): void {
    this.shippersService.getShippers()
      .subscribe({
        next: shippers => {
          this.shippers = shippers;
          console.log('Lista de shippers:', this.shippers);
        },
        error: error => {
          console.log('Error al obtener la lista de shippers', error);
        }
      });
  }
}
