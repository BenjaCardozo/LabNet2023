import { Pipe, PipeTransform } from '@angular/core';
import { CategoriesModel } from '../../../shared/models/categories/categories.model';

@Pipe({
  name: 'search'
})
export class SearchPipe implements PipeTransform {

  transform(lista: CategoriesModel[], texto: string | null): CategoriesModel[] {
    if (!texto) return lista
    return lista.filter(categories => categories.CategoryName.toUpperCase().includes(texto.toUpperCase()))
  }
}
