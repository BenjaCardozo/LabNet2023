import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersRoutingModule } from './modules/northwind/shippers/shippers-routing.module';


const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot(routes), ShippersRoutingModule],
  exports: [RouterModule]
})
export class AppRoutingModule { }
