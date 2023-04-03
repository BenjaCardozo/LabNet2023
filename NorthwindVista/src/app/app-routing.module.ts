import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersRoutingModule } from './modules/shippers/shippers-routing.module';
import { HomeComponent } from './components/home/home.component';
import { CategoriesRoutingModule } from './modules/categories/categories-routing.module';
import { AboutmeComponent } from './components/aboutme/aboutme.component';


const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full', component: HomeComponent},
  { path: 'acercade', component: AboutmeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ShippersRoutingModule, CategoriesRoutingModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
