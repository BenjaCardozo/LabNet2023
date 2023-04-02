import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ShippersService } from '../../../shared/service/northwind/shippers/shippers.service';
import { ShippersRoutingModule } from './shippers-routing.module';
import { ShippersComponent } from '../../../components/shippers/shippers.component';
import { ShippersFormComponent } from '../../../components/shippers/shippersForm/shippersForm.component';



@NgModule({
  declarations: [
    ShippersFormComponent,
    ShippersComponent,
  ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    ShippersRoutingModule,
    BrowserAnimationsModule,
  ],
  providers: [ShippersService ],
  bootstrap: [ShippersComponent]
})
export class ShippersModule { }
