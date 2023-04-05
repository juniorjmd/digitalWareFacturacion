import { Component } from '@angular/core';
import DataGrid from "devextreme/ui/data_grid";
import CustomStore from 'devextreme/data/custom_store';
import Swal from 'sweetalert2';
import { InventarioService } from '../../../../services/inventario.service';

@Component({
  selector: 'app-categorias',
  templateUrl: './categorias.component.html',
  styleUrls: ['./categorias.component.scss']
})
export class CategoriasComponent {

  updateRowKey:number = 0 
  dataGridInstance!: DataGrid; 
  dataSource : any ;
 

  constructor( private sInventario : InventarioService)
{
  this.dataSource = new CustomStore({
    key: 'iDcategoria',
    load: () => this.sInventario.getCategorias() ,
    insert:  (values) =>  this.sInventario.postCategorias(values)  ,
    update: async (key, values) => {
      values = await this.generarJsonActualizar(values);
      return this.sInventario.putCategorias(values, key )},
    remove: (key) => this.sInventario.deleteCategorias(key),
  });}

  async generarJsonActualizar(values:any){
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