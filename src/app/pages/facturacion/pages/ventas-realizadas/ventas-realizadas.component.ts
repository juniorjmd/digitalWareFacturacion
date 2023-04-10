import { Component, Input } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import { FacturacionService } from '../../../../services/facturacion.service';

@Component({
  selector: 'app-ventas-realizadas',
  templateUrl: './ventas-realizadas.component.html',
  styleUrls: ['./ventas-realizadas.component.scss']
})
export class VentasRealizadasComponent {
  @Input() key!: number;
  dataSource:any;
  constructor( private sInventario:FacturacionService ){}

  
  ngAfterViewInit() {
    this.dataSource =   new CustomStore({
      key: 'idDocProduct',
      load: () =>  this.sInventario.sendGetRequestLastValue(  `listadoPrdDocumento/${this.key}`)  
    });
  }
}
