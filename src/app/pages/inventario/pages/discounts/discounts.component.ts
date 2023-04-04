import { Component } from '@angular/core';
import CustomStore from 'devextreme/data/custom_store';

import DataGrid from 'devextreme/ui/data_grid';
import Swal from 'sweetalert2';
import { InventarioService } from '../../../../services/inventario.service';
@Component({
  selector: 'app-discounts',
  templateUrl: './discounts.component.html',
  styleUrls: ['./discounts.component.scss'],
})
export class DiscountsComponent {
  updateRowKey: number = 0;
  dataGridInstance!: DataGrid;
  dataSource: any;
  tipoValor: any = [
    {
      id: 'P',
      name: '% - Porcentaje',
    },
    {
      id: 'V',
      name: '$ - Valor',
    },
  ];
  aplicaA: any = [
    {
      id: 'F',
      name: 'Factura',
    },
    {
      id: 'P',
      name: 'Producto',
    },
  ];

  esIncluido: any = [
    {
      id: 'S',
      name: 'Si',
    },
    {
      id: 'N',
      name: 'No',
    },
  ];

  estado: any = [
    {
      id: 'A',
      name: 'Activo',
    },
    {
      id: 'I',
      name: 'Inactivo',
    },
  ];

  constructor(private sInventario: InventarioService) {
    this.dataSource = new CustomStore({
      key: 'iDdescuento',
      load: () => this.sInventario.getTaxes_Descuentos('D'),
      insert: (values) => this.sInventario.postTaxes_Descuentos(values,'D'),
      update: async (key, values) => {
        values = await this.generarJsonActualizar(values);
        return this.sInventario.putTaxes_Descuentos(values, key,'D');
      },
      remove: (key) => this.sInventario.deleteTaxes_Descuentos(key,'D'),
    });
  }

  async generarJsonActualizar(values: any) {
    await this.dataGridInstance.byKey(this.updateRowKey).then((filaDg) => {
      let claves = Object.keys(filaDg);
      claves.forEach((value: any) => {if (!values[value]) {values[value] = filaDg[value];}});
    });
    return values;
  }

  onEditingStart(e: any) {
    this.dataGridInstance = e.component;
    this.updateRowKey = e.key; 
  }
  enviarDescuento() {
    Swal.fire(
      'elemento guardado',
      'el elemento fue generado con existo',
      'success'
    );
  }
}
