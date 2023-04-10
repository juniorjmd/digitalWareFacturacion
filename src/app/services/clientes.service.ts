
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core'; 
import { Cliente, TipoId } from '../interfaces/cliente';

import { lastValueFrom } from 'rxjs';
import { formatDate } from 'devextreme/localization';
import { globales } from '../globals';
 

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
 
  requests: string[] = [];
  URL = globales.url + 'Cl_customer/';
  URLTI = globales.url + 'Cl_typeId/';
  headers = new HttpHeaders().set('Content-Type' , 'application/json'); 
  optHeader =  {headers : this.headers } ;

  constructor(private http: HttpClient) { 
    console.log('clientes service inicializado');
  }


getClientes(){ 
    console.log(`${this.URL}` , this.optHeader);
    
   let result =   this.http.get<Cliente[]>( `${this.URL}` , this.optHeader);


  result  

return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
  throw e && e.error && e.error.Message && e.error.ExceptionMessage;
});

}
postClientes(datos:any){
  console.log(`${this.URL}`, datos , this.optHeader);
   

 let params = 'json=' + JSON.stringify(datos); 
    
 let result =   this.http.post<Cliente[]>(`${this.URL}` , datos , this.optHeader );


return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message && e.error.ExceptionMessage;
});

}

putClientes(datos:any|Cliente ,id : number){
  console.log('putClientes',`${this.URL}${id}`, datos , this.optHeader);  
 let result =   this.http.put<Cliente[]>(`${this.URL}${id}` , datos , this.optHeader );
return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message && e.error.ExceptionMessage;
});

}
deleteClientes( id : number){ 
  console.log(`${this.URL}${id}`,   this.optHeader);  
 let result =   this.http.delete<Cliente[]>(`${this.URL}${id}` ,  this.optHeader );


return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message && e.error.ExceptionMessage;
});

}
getTipIdClientes(){
  console.log(`${this.URLTI}` , this.optHeader);
  
return this.http.get<TipoId[]>( `${this.URLTI}` , this.optHeader);

} 
}
