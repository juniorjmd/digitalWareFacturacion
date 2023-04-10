import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { DxDrawerComponent, DxSelectBoxComponent } from 'devextreme-angular';
import CustomStore from 'devextreme/data/custom_store';
import { FacturacionService } from '../../../../services/facturacion.service'; 
import Swal from 'sweetalert2';
import DataGrid from 'devextreme/ui/data_grid';
import { Documentos } from 'src/app/interfaces/documentos';
import { TabbedItem } from 'devextreme/ui/form';
import { By } from '@angular/platform-browser';
 
@Component({
  selector: 'app-pos',
  templateUrl: './pos.component.html',
  styleUrls: ['./pos.component.scss']
})
export class PosComponent   {
  @ViewChild(DxDrawerComponent, { static: false }) drawer!: DxDrawerComponent;
  @ViewChild(DxSelectBoxComponent, { static: false }) selecCliente!: DxSelectBoxComponent;
  showFirstSubmenuModes:any;
  showAll=false;
  documentos:any;
  showSubmenuModes:any;
  addButtonOptions:any;
  dsLProductos:any;
  dsProductos:any;
  dsDocumentos:any;
  dataGridInstance:any;
  updateRowKey:any;
  clientes:any;
  instanciaAcutal:any;
  documentoActual : Documentos ={
    idDocumento:0 , 
    idEstado:0 , 
    Sub_total:0 , 
    Impuestos:0 , 
    Descuento:0 , 
    totalFactura:0 , 
    doc_date:'' , 
    idCliente:0 
  } ;
constructor( private sFacturacion:FacturacionService) { 
 this.incio();
}
async incio() {
  await  this.getDocumentos();
  await  this.getClientes(); 
  await  this.getProductos();
this.showAll = true;

  }

 
async generarJsonActualizar(values:any){
  console.log('debe esperar terminar');
  await this.dataGridInstance.byKey(this.updateRowKey ).then(
    (filaDg :any)=>{
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
 

actualizarClientes(e:any, ei:any){
  console.log('actualizarClientes ' , e,  ei);
  let documentoSend:Documentos={
    idDocumento:this.documentoActual.idDocumento , 
    idEstado:this.documentoActual.idEstado , 
    Sub_total:this.documentoActual.Sub_total , 
    Impuestos:this.documentoActual.Impuestos, 
    Descuento:this.documentoActual.Descuento , 
    totalFactura:this.documentoActual.totalFactura , 
    doc_date:this.documentoActual.doc_date , 
    idCliente:this.documentoActual.idCliente
  } ;


  if(this.documentoActual.idCliente != e.value){
    documentoSend.idCliente = e.value;
  }else{return;}
   this.sFacturacion.sendPutRequest( documentoSend,this.documentoActual.idDocumento,'Sl_document').subscribe(
    {next:()=>{ 
        this.getDocumentos();
    },
  error:(e:any)=>{Swal.fire('error',e && e.error && e.error.Message && e.error.ExceptionMessage ,'error') ;}}
  ); 
}
getProductos(){
  this.sFacturacion.sendGetRequest('V_prd_product').subscribe(
    {next:(data)=>{
      this.dsProductos =  data;
    },
  error:(e:any)=>{throw e && e.error && e.error.Message && e.error.ExceptionMessage;}}
  );
}
getClientes(){
  this.sFacturacion.sendGetRequest('Cl_customer').subscribe(
    {next:(data)=>{
      this.clientes =  data;
    },
  error:(e:any)=>{throw e && e.error && e.error.Message && e.error.ExceptionMessage;}}
  );
}
   getDocumentos(){
  
  this.showSubmenuModes = [{
    name: 'onHover',
    delay: { show: 0, hide: 500 },
  }, {
    name: 'onClick',
    delay: { show: 0, hide: 300 },
  }];
  
  this.showFirstSubmenuModes = this.showSubmenuModes[1];
  this.documentos =  new CustomStore({
    key: 'idDocumento',
    load:   () => { console.log('voy a cargar documentos');
      return this.sFacturacion.sendGetRequestLastValue('documentosActivos'); }
    
    
    
  })
    this.addButtonOptions = {
      icon: 'plus',
      onClick: () => {this.agregarDocumento()
      },
    };
    
 }
 eliminaDocumento(){
  this.sFacturacion.sendPutRequest(this.documentoActual,this.documentoActual.idDocumento,  `eliminarDocumento`  ).subscribe(
    {next:(a:any[])=>{ 
      console.log('documento',a);
      this.getDocumentos();
    },
  error:(error:any)=>Swal.fire('error',error.error.ExceptionMessage, 'error' )}
  );

 }



 cerrarDocumento(){
  this.sFacturacion.sendPutRequest(this.documentoActual,this.documentoActual.idDocumento,  `cerrarDocumento`  ).subscribe(
    {next:(a:any[])=>{ 
      console.log('documento',a);
      this.getDocumentos();
    },
  error:(error:any)=>{
    console.error(error);
    
    Swal.fire('error',error.error.ExceptionMessage, 'error' )}}
  );
 }
 recargarDocumentoActual(){ 
  this.getDocumentos();
  this.sFacturacion.sendGetRequest('documentosActivos').subscribe(
    {next:(a:any[])=>{
      let id = this.documentoActual.idDocumento;
      a.forEach((element:any) => {
        if(element.idDocumento == id){
          this.documentoActual = element;
        }
      });
      
      console.log('documento',a);
      
    },
  error:(error:any)=>Swal.fire('error',error, 'error' )}
  );


 }
   cargarDocuento(e:any , tabPanel:any){ console.log('elemento tocado',tabPanel, e); 
    this.documentoActual = e.itemData    ;  
    this.instanciaAcutal = e;
    this.dsLProductos =   new CustomStore({
      key: 'idDocProduct',
      load: () => this.sFacturacion.sendGetRequestLastValue(`listadoPrdDocumento/${this.documentoActual.idDocumento}`),
      insert: (values) => { values.idDocumento= this.documentoActual.idDocumento
        return this.sFacturacion.sendPostRequestLastValue('Sl_document_products',values)},
      update: async (key, values) => {
        values = await this.generarJsonActualizar(values);
        values.idDocumento= this.documentoActual.idDocumento
        return this.sFacturacion.sendPutRequestLastValue('Sl_document_products',values, key);
      },
      remove: (key) => this.sFacturacion.sendDeleteRequestLastValue('Sl_document_products',key),
    })
 
    ;
    this.selecCliente.value = this.documentoActual.idCliente;
    console.log('cargarDocuento',this.selecCliente); 
 
    
  }


  agregarDocumento(){


    this.sFacturacion.sendPostRequest( {idEstado : 0 , idCliente:1004} ,'Sl_document').subscribe(
      {next:()=>{ 
          this.getDocumentos();
      },
    error:(e:any)=>{Swal.fire('error',e && e.error && e.error.Message && e.error.ExceptionMessage ,'error') ;}}
    ); 

  }
  
}
