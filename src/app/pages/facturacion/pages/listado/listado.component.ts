import { Component } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { FacturacionService } from '../../../../services/facturacion.service';

@Component({
  selector: 'app-listado',
  templateUrl: './listado.component.html',
  styleUrls: ['./listado.component.scss']
})
export class ListadoComponent {
  dataSource:any;
  constructor(private sFacturacion:FacturacionService){
this.dataSource =  new CustomStore({
  key: 'idDocumento',
  load: () => this.sFacturacion.sendGetRequestLastValue('documentosClienteActivos')  
});}
  }

 
