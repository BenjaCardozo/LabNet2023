import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersRoutingModule } from './modules/northwind/shippers/shippers-routing.module';
import { HomeComponent } from './components/home/home.component';
import { CategoriesRoutingModule } from './modules/northwind/categories/categories-routing.module';


const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ShippersRoutingModule, CategoriesRoutingModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
