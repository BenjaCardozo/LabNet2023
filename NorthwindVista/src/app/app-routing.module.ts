import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersRoutingModule } from './modules/northwind/shippers/shippers-routing.module';
import { HomeComponent } from './components/home/home.component';


const routes: Routes = [
  { path: '', redirectTo: '', pathMatch: 'full', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), ShippersRoutingModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
