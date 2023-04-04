import { NgModule } from '@angular/core'; 
import { RouterModule, Routes } from '@angular/router';
import { ClienteComponent } from './pages/cliente/cliente.component';



const rutas: Routes = [
  {
    path: '',
    children: [
      { path: 'lista', component: ClienteComponent }, 
      { path: '**', redirectTo: 'lista' }
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
export class ClientesRoutingModule { }
