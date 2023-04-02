import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CategoriesComponent } from '../../../components/categories/categories.component';
import { CategoriesFormComponent } from '../../../components/categories/categoriesForm/categoriesForm.component';


const routes: Routes = [
  { path: 'categories', component: CategoriesComponent },
  { path: 'categories/agregar', component: CategoriesFormComponent},
  { path: 'categories/editar/:id', component: CategoriesFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }
