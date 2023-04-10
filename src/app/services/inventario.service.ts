import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { globales } from '../globals';
import { Bodega } from '../interfaces/bodega';
import { Categoria } from '../interfaces/categoria';
import { TaxesDescuentos } from '../interfaces/taxes-descuentos';

@Injectable({
  providedIn: 'root',
})
export class InventarioService {
  requests: string[] = [];
  URL_bodega = globales.url + 'prd_inventory_warehouse/';
  URL_descuentos = globales.url + 'Sl_discounts/';
  URL_taxes = globales.url + 'Sl_taxes/';
  URL_brand = globales.url + 'prd_brands/';
  URL_group = globales.url + 'prd_groups/';
  URL_productos = globales.url  + 'prd_product/';
  URL_view_brand = globales.url + 'V_prd_brands/';
  URL_view_descuentos = globales.url + 'V_Sl_discounts/';
  URL_view_taxes = globales.url + 'V_Sl_taxes/'; 
  URL_view_group = globales.url + 'V_prd_groups/'; 



  
  URL_taxesProducto = globales.url + 'taxesProducto/'; 
  URL_taxesFactura = globales.url + 'taxesFactura/'; 
  URL_descuentosFactura = globales.url + 'descuentosFactura/'; 
  URL_descuentosProducto = globales.url + 'descuentosProducto/'; 

  headers = new HttpHeaders().set('Content-Type', 'application/json');
  optHeader = { headers: this.headers };

  constructor(private http: HttpClient) {
    console.log('Bodegas service inicializado');
  }

  enviarPeticionGet(url:string = '') { 
    if(url == ''  ){ throw('la url del servicio no debe estar vacio')}
  return this.http.get<any[]>( `${globales.url}${url}/` , this.optHeader);
  
  } 

  enviarPeticionGetlastValue(url:string = '') { 
    if(url == ''  ){ throw('la url del servicio no debe estar vacio')}
    let result = this.http.get<any[]>( `${globales.url}${url}` , this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
      });
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        console.error(e);
        
        throw e && e.error && e.error.Message && e.error.ExceptionMessage ;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
      });
  }

  //-----------------------------------------------------------------------
  //   CRUD descuentos y taxes  URL_descuentos ,  URL_taxes
  //-----------------------------------------------------------------------
/**
  URL_taxesProducto = globales.url + 'taxesProducto/'; 
  URL_taxesFactura = globales.url + 'taxesFactura/'; 
  URL_descuentosFactura = globales.url + 'descuentosFactura/'; 
  URL_descuentosProducto = globales.url + 'descuentosProducto/';  */


  getTaxes_DescuentosProductos(tRegitro = 'T') {
    let url = this.URL_taxesProducto;
    if (tRegitro == 'D') url = this.URL_descuentosProducto;
    let result = this.http.get<TaxesDescuentos[]>(`${url}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
      });
  }


  getTaxes_DescuentosFacturas(tRegitro = 'T') {
    let url = this.URL_taxesFactura;
    if (tRegitro == 'D') url = this.URL_descuentosFactura;
    let result = this.http.get<TaxesDescuentos[]>(`${url}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
      });
  }












  getTaxes_Descuentos(tRegitro = 'T') {
    let url = this.URL_view_taxes;
    if (tRegitro == 'D') url = this.URL_view_descuentos;
    let result = this.http.get<TaxesDescuentos[]>(`${url}`, this.optHeader);
    return lastValueFrom(result)
      .then((data: any) => data)
      .catch((e) => {
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
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
        throw e && e.error && e.error.Message && e.error.ExceptionMessage;
      });
  }
}
