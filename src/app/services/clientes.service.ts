<<<<<<< HEAD
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { global } from '../globals';
import { Cliente, TipoId } from '../interfaces/cliente';

import { lastValueFrom } from 'rxjs';
import { formatDate } from 'devextreme/localization';
=======
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cliente } from '../interfaces/cliente';
import { global } from './globals';
>>>>>>> 8ed109d526751ee2a14d8ac81db21e87d531951c

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
<<<<<<< HEAD
  requests: string[] = [];
  URL = global.url + 'Cl_customer/';
  URLTI = global.url + 'Cl_typeId/';
  headers = new HttpHeaders().set('Content-Type' , 'application/json');
=======
  URL = global.url + 'Cl_customer/';
  headers = new HttpHeaders().set('Content-Type' , 'application/x-www-form-urlencoded');
>>>>>>> 8ed109d526751ee2a14d8ac81db21e87d531951c
  optHeader =  {headers : this.headers } ;

  constructor(private http: HttpClient) { 
    console.log('clientes service inicializado');
  }


  getClientes(){
<<<<<<< HEAD
    console.log(`${this.URL}` , this.optHeader);
    
   let result =   this.http.get<Cliente[]>( `${this.URL}` , this.optHeader);


  result  

return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
  throw e && e.error && e.error.Message;
});

}



postClientes(datos:any){
  console.log(`${this.URL}`, datos , this.optHeader);
   

 let params = 'json=' + JSON.stringify(datos); 
    
 let result =   this.http.post<Cliente[]>(`${this.URL}` , datos , this.optHeader );


return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message;
});

}

putClientes(datos:any|Cliente ,id : number){
  console.log('putClientes',`${this.URL}${id}`, datos , this.optHeader);  
 let result =   this.http.put<Cliente[]>(`${this.URL}${id}` , datos , this.optHeader );
return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message;
});

}


deleteClientes( id : number){ 
  console.log(`${this.URL}${id}`,   this.optHeader);  
 let result =   this.http.delete<Cliente[]>(`${this.URL}${id}` ,  this.optHeader );


return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message;
});

}
getTipIdClientes(){
  console.log(`${this.URLTI}` , this.optHeader);
  
return this.http.get<TipoId[]>( `${this.URLTI}` , this.optHeader);

}
=======
      
    return this.http.get<Cliente[]>( `${this.URL}` , this.optHeader);
 
  }
>>>>>>> 8ed109d526751ee2a14d8ac81db21e87d531951c
}
