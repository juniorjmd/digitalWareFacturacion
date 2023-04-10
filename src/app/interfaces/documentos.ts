export interface Documentos { 
    idDocumento:number , 
    idEstado:number , 
    Sub_total:number , 
    Impuestos:number , 
    Descuento:number , 
    totalFactura:number , 
    doc_date?:string , 
    idCliente:number ,
    Sl_document_products?:any[]
}
