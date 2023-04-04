import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

<<<<<<< HEAD
import { AppComponent } from './app.component';
import { SideNavOuterToolbarModule, SideNavInnerToolbarModule, SingleCardModule } from './layouts';
import { FooterModule, ResetPasswordFormModule, CreateAccountFormModule, ChangePasswordFormModule, LoginFormModule } from './shared/components';
import { AuthService, ScreenService, AppInfoService } from './shared/services';
import { UnauthenticatedContentModule } from './unauthenticated-content';
import { AppRoutingModule } from './app-routing.module';
import { DxButtonModule } from 'devextreme-angular';
import { DxDataGridModule } from 'devextreme-angular';
import { FormsModule } from '@angular/forms';
import { ClientesService } from './services/clientes.service';
import { FacturacionService } from './services/facturacion.service';
import { InventarioService } from './services/inventario.service';
import { HttpClientModule } from '@angular/common/http';
 

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    HttpClientModule ,
    FormsModule,
    BrowserModule,
    DxDataGridModule,
    DxButtonModule,
    SideNavOuterToolbarModule,
    SideNavInnerToolbarModule,
    SingleCardModule,
    FooterModule,
    ResetPasswordFormModule,
    CreateAccountFormModule,
    ChangePasswordFormModule,
    LoginFormModule,
    UnauthenticatedContentModule,
    AppRoutingModule,
  ],
  providers: [
    AuthService,
    ScreenService,
    AppInfoService, 
    FacturacionService,
    InventarioService,ClientesService
  ],
=======
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
>>>>>>> 8ed109d526751ee2a14d8ac81db21e87d531951c
  bootstrap: [AppComponent]
})
export class AppModule { }
