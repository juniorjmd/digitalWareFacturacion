import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClienteComponent } from './pages/cliente/cliente.component';
import { FormsModule } from '@angular/forms';
import { DxDataGridModule } from 'devextreme-angular';
import { ClientesRoutingModule } from './clientes-routing.module';
import { ClientesService } from 'src/app/services/clientes.service';



@NgModule({
  declarations: [
    ClienteComponent
  ],
  imports: [ClientesRoutingModule,
    CommonModule,FormsModule,DxDataGridModule,
  ]  
})
export class ClientesModule { }
