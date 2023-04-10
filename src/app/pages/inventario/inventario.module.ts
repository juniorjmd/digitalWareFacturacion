import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BodegasComponent } from './pages/bodegas/bodegas.component';
import { ProductosComponent } from './pages/productos/productos.component';
import { HomeComponent } from './pages/home/home.component';
import { NewProductoComponent } from './pages/new-producto/new-producto.component';
import { InventarioRoutingModule } from './inventario-routing.module';
import { BrandsComponent } from './pages/brands/brands.component';
import { DiscountsComponent } from './pages/discounts/discounts.component';
import { TaxesComponent } from './pages/taxes/taxes.component';
import { DxButtonModule, DxDataGridModule } from 'devextreme-angular';
import { CategoriasComponent } from './pages/categorias/categorias.component';
import { ExistenciasComponent } from './pages/existencias/existencias.component';



@NgModule({
  declarations: [
    
    BodegasComponent,
    ProductosComponent,
    HomeComponent,
    NewProductoComponent,
    BrandsComponent,
    DiscountsComponent,
    TaxesComponent,
    CategoriasComponent,
    ExistenciasComponent
  ],
  imports: [
    DxDataGridModule,
    DxButtonModule,
    CommonModule,
    InventarioRoutingModule
  ]
})
export class InventarioModule { }
