import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cliente } from '../interfaces/cliente';
import { global } from './globals';

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  URL = global.url + 'Cl_customer/';
  headers = new HttpHeaders().set('Content-Type' , 'application/x-www-form-urlencoded');
  optHeader =  {headers : this.headers } ;

  constructor(private http: HttpClient) { 
    console.log('clientes service inicializado');
  }


  getClientes(){
      
    return this.http.get<Cliente[]>( `${this.URL}` , this.optHeader);
 
  }
}
