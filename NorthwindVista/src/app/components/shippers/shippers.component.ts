import { Component, OnInit } from '@angular/core';
import { ShippersModel } from '../../shared/models/northwind/shippers/shippersModel';
import { ShippersService } from '../../shared/service/northwind/shippers/shippers.service';
import { BehaviorSubject } from 'rxjs';
@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.scss']
})
export class ShippersComponent implements OnInit {

  public shippers: ShippersModel [];
  public shipperToDelete: ShippersModel;
  public filtroSearch = new BehaviorSubject<string>('');

  constructor(private shippersService: ShippersService) {
    this.shippers = [];
    this.shipperToDelete = {
      ShipperId: null,
      CompanyName: '',
      Phone: ''
    }
  }

  ngOnInit(): void {
    this.getShippers();
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
  deleteShipper(shipperId: number | null) :void {
    if (shipperId) {
      this.shippersService.deleteShipper(shipperId)
      .subscribe({
        next: () => {
          this.getShippers();
        },
        error: error => {
          console.error(error);
        }
      });
    }
  }

  handleSearch(value: string) {
    this.filtroSearch.next(value);
  }

}
