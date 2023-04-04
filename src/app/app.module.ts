import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

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
  bootstrap: [AppComponent]
})
export class AppModule { }
