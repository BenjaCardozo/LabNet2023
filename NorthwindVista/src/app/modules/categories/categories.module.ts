import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule, AsyncPipe  } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSnackBarModule} from '@angular/material/snack-bar';

import { CategoriesComponent } from '../../components/categories/categories.component';
import { CategoriesFormComponent } from 'src/app/components/categories/categoriesForm/categoriesForm.component';
import { CategoriesRoutingModule } from './categories-routing.module';
import { SearchPipe } from '../../components/categories/pipes/search.pipe';
import { SearchComponent } from '../../components/categories/search/search.component';



@NgModule({
  declarations: [
    CategoriesComponent,
    CategoriesFormComponent,
    SearchComponent,
    SearchPipe
  ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    CategoriesRoutingModule,
    BrowserAnimationsModule,
    AsyncPipe,
    MatSnackBarModule
  ]
})
export class CategoriesModule { }
