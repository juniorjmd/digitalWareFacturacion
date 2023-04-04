import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { global } from '../globals';
import { Bodega } from '../interfaces/bodega';
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

  headers = new HttpHeaders().set('Content-Type', 'application/json');
  optHeader = { headers: this.headers };

  constructor(private http: HttpClient) {
    console.log('Bodegas service inicializado');
  }
  //-----------------------------------------------------------------------
  //   CRUD Bodegas
  //-----------------------------------------------------------------------
  getBrands() {
    console.log(`${this.URL_brand}`, this.optHeader);
    let result = this.http.get<Bodega[]>(`${this.URL_brand}`, this.optHeader);
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

  getTaxes_Descuentos(tRegitro = 'T') {
    let url = this.URL_taxes;
    if (tRegitro == 'D') url = this.URL_descuentos;
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
