import { NgModule } from '@angular/core'; 
import { RouterModule, Routes } from '@angular/router'; 
import { BodegasComponent } from './pages/bodegas/bodegas.component';
import { ProductosComponent } from './pages/productos/productos.component';
import { NewProductoComponent } from './pages/new-producto/new-producto.component';
import { BrandsComponent } from './pages/brands/brands.component';
import { TaxesComponent } from './pages/taxes/taxes.component';
import { DiscountsComponent } from './pages/discounts/discounts.component';

const rutas: Routes = [
  {
    path: '',
    children: [
      { path: 'listado', component: ProductosComponent },
      { path: 'producto', component: NewProductoComponent },
      { path: 'bodegas', component: BodegasComponent } ,
      { path: 'marcas', component: BrandsComponent } ,
      { path: 'impuestos', component: TaxesComponent } ,
      { path: 'descuentos', component: DiscountsComponent } ,
      { path: '**', redirectTo: 'listado' }
    ]
  }
];



@NgModule({
  imports: [
    RouterModule.forChild( rutas )
  ],
  exports: [
    RouterModule
  ]
})
export class InventarioRoutingModule { }
