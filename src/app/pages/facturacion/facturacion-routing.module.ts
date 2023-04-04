import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PosComponent } from './pages/pos/pos.component';
import { ListadoComponent } from './pages/listado/listado.component';
import { RouterModule, Routes } from '@angular/router';

const rutas: Routes = [
  {
    path: '',
    children: [
      { path: 'pos', component: PosComponent },
      { path: 'listado', component: ListadoComponent },
      { path: '**', redirectTo: 'pos' }
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
export class FacturacionRoutingModule { }
