import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FacturacionComponent } from './components/pos/facturacion/facturacion.component';
import { HomeComponent } from './components/home/home.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { FormsModule } from '@angular/forms';
import { NavbarComponent } from './components/share/navbar/navbar.component';
import { FacturarComponent } from './components/facturar/facturar.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { ProductsComponent } from './components/products/products.component';
import { BrandsComponent } from './components/brands/brands.component';
import { TaxesComponent } from './components/taxes/taxes.component';
import { DiscountsComponent } from './components/discounts/discounts.component';

@NgModule({
  declarations: [
    AppComponent,
    FacturacionComponent,
    HomeComponent,
    InicioComponent,
    NavbarComponent,
    FacturarComponent,
    ClientesComponent,
    ProductsComponent,
    BrandsComponent,
    TaxesComponent,
    DiscountsComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule, 
    BrowserModule,
    AppRoutingModule
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
