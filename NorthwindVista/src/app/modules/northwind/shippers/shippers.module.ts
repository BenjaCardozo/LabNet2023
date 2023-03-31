import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

import { ShippersService } from 'src/app/shared/service/northwind/shippers/shippers.service';
import { ShippersRoutingModule } from './shippers-routing.module';
import { ShippersComponent } from './shippers.component';



@NgModule({
  declarations: [
    ShippersComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    ShippersRoutingModule,
    FormsModule
  ],
  providers: [ShippersService ]
})
export class ShippersModule { }
