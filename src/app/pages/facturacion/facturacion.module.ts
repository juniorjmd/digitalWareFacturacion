import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PosComponent } from './pages/pos/pos.component';
import { ListadoComponent } from './pages/listado/listado.component';
import { FacturacionRoutingModule } from './facturacion-routing.module';
import { DxButtonModule,  DxDataGridModule,  DxDrawerModule, DxListModule, DxMenuModule, DxSelectBoxModule, DxSortableModule, DxTabPanelModule, DxTabsModule, DxTemplateModule, DxToolbarModule} from 'devextreme-angular';
import { VentasRealizadasComponent } from './pages/ventas-realizadas/ventas-realizadas.component';



@NgModule({
  declarations: [
    PosComponent,
    ListadoComponent,
    
    VentasRealizadasComponent
  ],
  imports: [ DxDrawerModule,
    DxMenuModule,DxToolbarModule,
    DxButtonModule, DxSortableModule, DxTabPanelModule, DxListModule, DxTemplateModule,
    CommonModule,FacturacionRoutingModule,
    DxDataGridModule,DxTabsModule, DxSelectBoxModule
    
  ]
})
export class FacturacionModule { }
