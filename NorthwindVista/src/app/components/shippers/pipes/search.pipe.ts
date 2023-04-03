import { Pipe, PipeTransform } from '@angular/core';
import { ShippersModel } from '../../../shared/models/shippers/shippers.model';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(lista: ShippersModel[], texto: string | null): ShippersModel[] {
    if (!texto) return lista
    return lista.filter(shippers => shippers.CompanyName.toUpperCase().includes(texto.toUpperCase()))
  }
}
