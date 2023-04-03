import { Component, OnInit } from '@angular/core';
import { ShippersModel } from '../../shared/models/northwind/shippers/shippers.model';
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
  error: string= '';
  exito: string = '';

  constructor(private shippersService: ShippersService) {
    this.shippers = [];
    this.shipperToDelete = {
      ShipperId: null,
      CompanyName: '',
      Phone: ''
    }
  }

  ngOnInit(): void {
    this.hideMessagesAfterDelay();
    this.getShippers();
    this.hideMessagesAfterDelay();
  }

  getShippers(): void {
    this.shippersService.getShippers()
      .subscribe({
        next: shippers => {
          this.shippers = shippers;
        },
        error: () => {
          this.error = 'No se pudo cargar la lista de expedidores, por favor intentelo más tarde.';
        }
      });
  }

  deleteShipper(shipperId: number | null) :void {
    if (shipperId) {
      this.shippersService.deleteShipper(shipperId)
      .subscribe({
        next: () => {
          this.exito = 'Expedidor eliminado con éxito.';
          this.getShippers();
        },
        error: () => {
          this.error = 'No fue posible eliminar el expedidor.';
        }
      });
    }
  }

  handleSearch(value: string) {
    this.filtroSearch.next(value);
  }

  hideMessagesAfterDelay(): void {
    setTimeout(() => {
      this.error = ''
      this.exito = ''
    }, 5000);
  }
}
