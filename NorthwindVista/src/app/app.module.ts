import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { NavBarComponent } from './components/navBar/navBar.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';

import { ShippersModule } from './modules/northwind/shippers/shippers.module';
import { CategoriesModule } from './modules/northwind/categories/categories.module';
import { AboutmeComponent } from './components/aboutme/aboutme.component';
import { RickandmortyComponent } from './components/rickandmorty/rickandmorty.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    FooterComponent,
    HomeComponent,
    AboutmeComponent,
    RickandmortyComponent,
  ],
  imports: [
  BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ShippersModule,
    CategoriesModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
