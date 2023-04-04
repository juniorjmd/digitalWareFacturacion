import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PosComponent } from './pages/pos/pos.component';
import { ListadoComponent } from './pages/listado/listado.component';
import { FacturacionRoutingModule } from './facturacion-routing.module';



@NgModule({
  declarations: [
    PosComponent,
    ListadoComponent
  ],
  imports: [
    CommonModule,FacturacionRoutingModule
  ]
})
export class FacturacionModule { }
