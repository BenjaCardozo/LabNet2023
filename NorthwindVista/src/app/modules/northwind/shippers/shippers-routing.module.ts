import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersComponent } from './shippers.component';
import { ShippersFormComponent } from './child/shippersForm/shippersForm.component';

const routes: Routes = [
  { path: 'shippers', component: ShippersComponent },
  { path: 'shippers/agregar', component: ShippersFormComponent},
  { path: 'shippers/editar/:id', component: ShippersFormComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ShippersRoutingModule { }
