import { Component } from '@angular/core';
import DataGrid from 'devextreme/ui/data_grid';
import CustomStore from 'devextreme/data/custom_store';
import Swal from 'sweetalert2';
import { InventarioService } from '../../../../services/inventario.service';
import { globales } from 'src/app/globals';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss'],
})
export class ProductosComponent {
  updateRowKey: number = 0;
  dataGridInstance!: DataGrid;
  dataSource: any;
 compact = 'compact';
  brandSource: any; 
  categoriaSource: any;
  taxesSource: any;
  descuentoSource: any;
  constructor(private sInventario: InventarioService) {
    this.inicioListado();
    globales.llamador = 'productos';
  }

  async generarJsonActualizar(values: any) {
    console.log('debe esperar terminar');
    await this.dataGridInstance.byKey(this.updateRowKey).then((filaDg) => {
      let claves = Object.keys(filaDg);
      claves.forEach((value: any) => {
        console.log('datos data grid', filaDg[value], value);
        if (!values[value]) {
          values[value] = filaDg[value];
        }
      });
    });

    return values;
  }

  async inicioListado() {
    await this.listarBrands();
    await this.listarDescuento();
    await this.listarGrupos();
    await this.listarImpuesto();
console.log('termino con los source','brandSource',
  this.brandSource, 'categoriaSource',
  this.categoriaSource,'taxesSource',
  this.taxesSource,'descuentoSource',
  this.descuentoSource);

    this.dataSource = new CustomStore({
      key: 'iDproducto',
      load: () => this.sInventario.getProductos(),
      insert: (values) => this.sInventario.postProductos(values),
      update: async (key, values) => {
        values = await this.generarJsonActualizar(values);
        return this.sInventario.putProductos(values, key);
      },
      remove: (key) => this.sInventario.deleteProductos(key),
    });
    console.log('fin de data source');
    
  }

  
  listarBrands() { 
    this.sInventario.enviarPeticionGet('V_prd_brands') .subscribe({
      next: (res) => {
        console.log(res);
        this.brandSource = res;  
      },
      error: (err) => {
        Swal.fire(err);
      },
    }); 
    
  }
  listarGrupos() { 
      this.sInventario.enviarPeticionGet('V_prd_groups') .subscribe({
        next: (res) => {
          console.log(res);
          this.categoriaSource = res;  
        },
        error: (err) => {
          Swal.fire(err);
        },
      }); 
  }
  listarImpuesto() { 
      this.sInventario.enviarPeticionGet('taxesProducto') .subscribe({
        next: (res) => {
          console.log(res);
          this.taxesSource = res;  
        },
        error: (err) => {
          Swal.fire(err);
        },
      }); 
    
  }
  listarDescuento() { 
    this.sInventario.enviarPeticionGet('descuentosProducto') .subscribe({
      next: (res) => {
        console.log(res);
        this.descuentoSource = res;  
      },
      error: (err) => {
        Swal.fire(err);
      },
    }); 
    
  }

  onEditingStart(e: any) {
    this.dataGridInstance = e.component;
    this.updateRowKey = e.key;
  }
}
