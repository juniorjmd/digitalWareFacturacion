import { Component } from '@angular/core';

import DataGrid from "devextreme/ui/data_grid";
import CustomStore from 'devextreme/data/custom_store';
import Swal from 'sweetalert2';
import { InventarioService } from '../../../../services/inventario.service';
import { globales } from 'src/app/globals';

@Component({
  selector: 'app-bodegas',
  templateUrl: './bodegas.component.html',
  styleUrls: ['./bodegas.component.scss']
})
export class BodegasComponent {

  updateRowKey:number = 0 
  dataGridInstance!: DataGrid; 
  dataSource : any ;
 

  constructor( private sInventario : InventarioService)
{
  
  globales.llamador = 'bodegas';
  this.dataSource = new CustomStore({
    key: 'idBodega',
    load: () => this.sInventario.getBodegas() ,
    insert:  (values) =>  this.sInventario.postBodegas(values)  ,
    update: async (key, values) => {
      values = await this.generarJsonActualizar(values);
      return this.sInventario.putBodegas(values, key )},
    remove: (key) => this.sInventario.deleteBodegas(key),
  });}

  async generarJsonActualizar(values:any){
    console.log('debe esperar terminar');
    await this.dataGridInstance.byKey(this.updateRowKey ).then(
      filaDg=>{
      let claves = Object.keys(filaDg); 
      claves.forEach((value:any) => {
        console.log('datos data grid',filaDg[value],value);
        if(!values[value]){
          values[value] = filaDg[value];
        }
      });
  }) 
    
     
  
  
    return values;
  }
  
  onEditingStart(e:any){
    this.dataGridInstance = e.component;
    this.updateRowKey = e.key; 
  }
}
