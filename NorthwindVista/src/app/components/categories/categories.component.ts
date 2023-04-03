import { Component, OnInit } from '@angular/core';
import { CategoriesModel } from '../../shared/models/categories/categories.model';
import { CategoriesService } from './../../shared/service/categories/categories.service';
import { BehaviorSubject } from 'rxjs';


@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.scss']
})
export class CategoriesComponent implements OnInit {

  public categories: CategoriesModel[];
  public categoryToDelete: CategoriesModel;
  public filtroSearch = new BehaviorSubject<string>('');
  error: string = '';
  exito: string = '';

  constructor(private categoriesService: CategoriesService) {
    this.categories= [];
    this.categoryToDelete = {
      CategoryID: null,
      CategoryName: '',
      CategoryDescription: ''
    }
   }

  ngOnInit() :void {
    this.hideMessagesAfterDelay();
    this.getCategories();
    this.hideMessagesAfterDelay();
  }

  getCategories() :void{
    this.categoriesService.getCategories()
      .subscribe({
        next: categories => {
          this.categories = categories;
        },
        error: () => {
          this.error = 'No se pudo cargar la lista de categorias, por favor intentelo más tarde.';
        }
      });
  }

  deleteCategory(categoryId: number | null) :void {
    if(categoryId) {
      this.categoriesService.deleteCategory(categoryId)
      .subscribe({
        next: ()=>{
          this.exito = 'Categoria eliminada con éxito.';
          this.getCategories();
        },
        error: () => {
          this.error = 'No fue posible eliminar la categoria.';
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
