import { Component, OnInit } from '@angular/core';
import { ShippersModel } from '../../shared/models/northwind/shippers/shippersModel';
import { ShippersService } from '../../shared/service/northwind/shippers/shippers.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.scss']
})
export class ShippersComponent implements OnInit {

  public shippers: ShippersModel [];
  public shipperToDelete: ShippersModel;
  public searchForm: FormGroup;

  constructor(private shippersService: ShippersService) {
    this.shippers = [];
    this.shipperToDelete = {
      ShipperId: null,
      CompanyName: '',
      Phone: ''
    }
    this.searchForm = new FormGroup({
      companyName: new FormControl('')
    })
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

  getShipperByString(companyName: string | null) : void {
      if (companyName) {
        this.shippersService.getShipperByString(companyName)
          .subscribe({
            next: shipper => {
              this.shippers = shipper;
              console.log('Resultado de búsqueda:', this.shippers);
            },
            error: error => {
              console.log('Error al buscar el shipper', error);
            }
          });
        }
  }

  onSearch(): void {
    if (this.searchForm.valid) {
      const companyName = this.searchForm.get('companyName')?.value;
      if (companyName) {
        this.getShipperByString(companyName);
        }
    }
  }
}
