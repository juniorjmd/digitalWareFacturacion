import { Component, ViewChild } from '@angular/core';
import { Cliente, TipoId } from 'src/app/interfaces/cliente';
import { ClientesService } from 'src/app/services/clientes.service';

import { global } from '../../../../globals';
import DataGrid from 'devextreme/ui/data_grid';
import CustomStore from 'devextreme/data/custom_store';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.scss'],
})
export class ClienteComponent {
  // @ViewChild(DxDataGridComponent,  { static: false }) dataGrid!: DxDataGridComponent
  updateRowKey: number = 0;
  dataGridInstance!: DataGrid;
  dataSource: any;
  TipoId: TipoId[] = [];
  constructor(private sCliente: ClientesService) {
    this.getTipIdClientes();
  }

  onEditingStart(e: any) {
    this.dataGridInstance = e.component;
    this.updateRowKey = e.key;
    console.log(
      'onEditingStart',
      this.dataGridInstance,
      this.updateRowKey,
      'datagrid '
    );
    const editRowIndex = this.dataGridInstance.getRowIndexByKey(
      this.updateRowKey
    );
    if (editRowIndex >= 0) {
      console.log(
        'columna ',
        this.dataGridInstance.cellValue(editRowIndex, 'name')
      );
    }
  }
  enviarDatosNuevos() {
    alert('datos');
  } //getTipIdClientes

  getTipIdClientes() { 
    this.sCliente.getTipIdClientes().subscribe({
      next: (res) => {
        console.log(res);
        this.TipoId = res;

        this.dataSource = new CustomStore({
          key: 'idCliente',
          load: () => this.sCliente.getClientes(),
          insert: (values) => this.sCliente.postClientes(values),
          update: async (key, values) => {
            values = await this.generarJsonActualizar(values);
            return this.sCliente.putClientes(values, key);
          },
          remove: (key) => this.sCliente.deleteClientes(key),
        });
        console.log('dataSource', this.dataSource);
      },
      error: (err) => {
        Swal.fire(err);
      },
    });
  }

  async generarJsonActualizar(values: any | Cliente) {
    console.log('debe esperar terminar');
    await this.dataGridInstance.byKey(this.updateRowKey).then((filaDg) => {
      console.log('datos data grid', filaDg);

      let claves = Object.keys(filaDg); // claves = ["nombre", "color", "macho", "edad"]

      claves.forEach((value: any) => {
        console.log('datos data grid', filaDg[value], value);
        if (!values[value]) {
          values[value] = filaDg[value];
        }
      });
    });

    console.log('espero terminar', values);

    return values;
  }
}
