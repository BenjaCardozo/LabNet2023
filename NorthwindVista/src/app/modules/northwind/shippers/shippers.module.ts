import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule, AsyncPipe  } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { ShippersService } from '../../../shared/service/northwind/shippers/shippers.service';
import { ShippersRoutingModule } from './shippers-routing.module';
import { ShippersComponent } from '../../../components/shippers/shippers.component';
import { ShippersFormComponent } from '../../../components/shippers/shippersForm/shippersForm.component';
import { SearchComponent } from '../../../components/shippers/search/search.component';
import { SearchPipe } from '../../../components/pipes/search.pipe';



@NgModule({
  declarations: [
    ShippersFormComponent,
    ShippersComponent,
    SearchComponent,
    SearchPipe,
  ],
  imports: [
    ReactiveFormsModule,
    CommonModule,
    ShippersRoutingModule,
    BrowserAnimationsModule,
    AsyncPipe
  ],
  providers: [ShippersService ],
  bootstrap: [ShippersComponent]
})
export class ShippersModule { }
