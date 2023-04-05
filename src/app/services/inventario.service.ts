import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { global } from '../globals';
import { Bodega } from '../interfaces/bodega';
import { Categoria } from '../interfaces/categoria';
import { TaxesDescuentos } from '../interfaces/taxes-descuentos';

@Injectable({
  providedIn: 'root',
})
export class InventarioService {
  requests: string[] = [];
  URL_bodega = global.url + 'prd_inventory_warehouse/';
  URL_descuentos = global.url + 'Sl_discounts/';
  URL_taxes = global.url + 'Sl_taxes/';
  URL_brand = global.url + 'prd_brands/';
  URL_group = global.url + 'prd_groups/';
  URL_productos = global.url  + 'prd_product/';
  URL_view_brand = global.url + 'V_prd_brands/';
  URL_view_descuentos = global.url + 'V_Sl_discounts/';
  URL_view_taxes = global.url + 'V_Sl_taxes/'; 
  URL_view_group = global.url + 'V_prd_groups/'; 



  
  URL_taxesProducto = global.url + 'taxesProducto/'; 
  URL_taxesFactura = global.url + 'taxesFactura/'; 
  URL_descuentosFactura = global.url + 'descuentosFactura/'; 
  URL_descuentosProducto = global.url + 'descuentosProducto/'; 

  headers = new HttpHeaders().set('Content-Type', 'application/json');
  optHeader = { headers: this.headers };

  constructor(private http: HttpClient) {
    console.log('Bodegas service inicializado');
  }

  enviarPeticionGet(url:string){  
  return this.http.get<any[]>( `${global.url}${url}/` , this.optHeader);
  
  } 
  //-----------------------------------------------------------------------
  //   CRUD Marcas
  //-----------------------------------------------------------------------
  getBrands() {
    console.log(`${this.URL_view_brand}`, this.optHeader);
    let result = this.http.get<Bodega[]>(`${this.URL_view_brand}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  postBrands(datos: any) {
    console.log(`${this.URL_brand}`, datos, this.optHeader);

    let result = this.http.post<Bodega[]>(
      `${this.URL_brand}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  putBrands(datos: any | Bodega, id: number) {
    console.log('putBodegas', `${this.URL_brand}${id}`, datos, this.optHeader);
    let result = this.http.put<Bodega[]>(
      `${this.URL_brand}${id}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  deleteBrands(id: number) {
    console.log(`${this.URL_brand}${id}`, this.optHeader);
    let result = this.http.delete<Bodega[]>(
      `${this.URL_brand}${id}`,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }



  //-----------------------------------------------------------------------
  //   CRUD  Productos
  //-----------------------------------------------------------------------
  getProductos() {
    console.log(`${this.URL_productos}`, this.optHeader);
    let result = this.http.get<any[]>(`${this.URL_productos}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  postProductos(datos: any) {
    console.log(`${this.URL_productos}`, datos, this.optHeader);

    let result = this.http.post<any[]>(
      `${this.URL_productos}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  putProductos(datos: any | Bodega, id: number) {
    console.log('putBodegas', `${this.URL_productos}${id}`, datos, this.optHeader);
    let result = this.http.put<any[]>(
      `${this.URL_productos}${id}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  deleteProductos(id: number) {
    console.log(`${this.URL_productos}${id}`, this.optHeader);
    let result = this.http.delete<any[]>(
      `${this.URL_productos}${id}`,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }

 //-----------------------------------------------------------------------
  //   CRUD categorias(grupos)
  //-----------------------------------------------------------------------
  getCategorias() {
    console.log(`${this.URL_view_group}`, this.optHeader);
    let result = this.http.get<Categoria[]>(`${this.URL_view_group}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  postCategorias(datos: any) {
    console.log(`${this.URL_group}`, datos, this.optHeader);

    let result = this.http.post<Categoria[]>(
      `${this.URL_group}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  putCategorias(datos: any | Categoria, id: number) {
    console.log('putBodegas', `${this.URL_group}${id}`, datos, this.optHeader);
    let result = this.http.put<Categoria[]>(
      `${this.URL_group}${id}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  deleteCategorias(id: number) {
    console.log(`${this.URL_group}${id}`, this.optHeader);
    let result = this.http.delete<Categoria[]>(
      `${this.URL_group}${id}`,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }

  //-----------------------------------------------------------------------
  //   CRUD Bodegas
  //-----------------------------------------------------------------------
  getBodegas() {
    console.log(`${this.URL_bodega}`, this.optHeader);
    let result = this.http.get<Bodega[]>(`${this.URL_bodega}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  postBodegas(datos: any) {
    console.log(`${this.URL_bodega}`, datos, this.optHeader);

    let result = this.http.post<Bodega[]>(
      `${this.URL_bodega}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  putBodegas(datos: any | Bodega, id: number) {
    console.log('putBodegas', `${this.URL_bodega}${id}`, datos, this.optHeader);
    let result = this.http.put<Bodega[]>(
      `${this.URL_bodega}${id}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  deleteBodegas(id: number) {
    console.log(`${this.URL_bodega}${id}`, this.optHeader);
    let result = this.http.delete<Bodega[]>(
      `${this.URL_bodega}${id}`,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }

  //-----------------------------------------------------------------------
  //   CRUD descuentos y taxes  URL_descuentos ,  URL_taxes
  //-----------------------------------------------------------------------
/**
  URL_taxesProducto = global.url + 'taxesProducto/'; 
  URL_taxesFactura = global.url + 'taxesFactura/'; 
  URL_descuentosFactura = global.url + 'descuentosFactura/'; 
  URL_descuentosProducto = global.url + 'descuentosProducto/';  */


  getTaxes_DescuentosProductos(tRegitro = 'T') {
    let url = this.URL_taxesProducto;
    if (tRegitro == 'D') url = this.URL_descuentosProducto;
    let result = this.http.get<TaxesDescuentos[]>(`${url}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }


  getTaxes_DescuentosFacturas(tRegitro = 'T') {
    let url = this.URL_taxesFactura;
    if (tRegitro == 'D') url = this.URL_descuentosFactura;
    let result = this.http.get<TaxesDescuentos[]>(`${url}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }












  getTaxes_Descuentos(tRegitro = 'T') {
    let url = this.URL_view_taxes;
    if (tRegitro == 'D') url = this.URL_view_descuentos;
    let result = this.http.get<TaxesDescuentos[]>(`${url}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  postTaxes_Descuentos(datos: any, tRegitro = 'T') {
    let url = this.URL_taxes;
    if (tRegitro == 'D') url = this.URL_descuentos;
    let result = this.http.post<TaxesDescuentos[]>(
      `${url}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  putTaxes_Descuentos(
    datos: any | TaxesDescuentos,
    id: number,
    tRegitro = 'T'
  ) {
    let url = this.URL_taxes;
    if (tRegitro == 'D') url = this.URL_descuentos;
    let result = this.http.put<TaxesDescuentos[]>(
      `${url}${id}`,
      datos,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
  deleteTaxes_Descuentos(id: number, tRegitro = 'T') {
    let url = this.URL_taxes;
    if (tRegitro == 'D') url = this.URL_descuentos;
    let result = this.http.delete<TaxesDescuentos[]>(
      `${url}${id}`,
      this.optHeader
    );
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message;
      });
  }
}
