import { Component, Input } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';
import DataSource from 'devextreme/data/data_source';
import { InventarioService } from 'src/app/services/inventario.service';
import { globales } from '../../../../globals';

@Component({
  selector: 'app-existencias',
  templateUrl: './existencias.component.html',
  styleUrls: ['./existencias.component.scss']
})
export class ExistenciasComponent {
  @Input() key!: number;
  requeridoDesde = globales.llamador;
  dataSource:any  ;
 constructor(private sInventario:InventarioService){

 }
  ngAfterViewInit() {
    this.dataSource =   new CustomStore({
      key: 'id',
      load: () => {
        let urlSend = '';
        switch(this.requeridoDesde){
          case 'productos':
            urlSend = `ExistenciasPorProducto/${this.key}`;
            break;
            case 'bodegas':
              urlSend = `ExistenciasPorBodega/${this.key}`;
              break;
        }
        return this.sInventario.enviarPeticionGetlastValue(urlSend) }
    });
  }
}
