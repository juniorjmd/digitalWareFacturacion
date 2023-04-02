import { Component } from '@angular/core';
import { Cliente } from 'src/app/interfaces/cliente';
import { ClientesService } from 'src/app/services/clientes.service';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent {
  clientes:Cliente[] = [];
 constructor(private sCliente:ClientesService){
  this.getClientes()
 }

 getClientes(){
  this.sCliente.getClientes().subscribe(  {next : (res) => {
    console.log(res);}, error : (err) => {
      console.error(err);
    }
    })
 }
}
