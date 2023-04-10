import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { lastValueFrom } from 'rxjs';
import { globales } from '../globals';
import { Cliente } from '../interfaces/cliente';
import { Documentos } from '../interfaces/documentos';

@Injectable({
  providedIn: 'root'
})
export class FacturacionService {

  headers = new HttpHeaders().set('Content-Type', 'application/json');
  optHeader = { headers: this.headers };

  constructor(private http: HttpClient) {
    console.log('Bodegas service inicializado');
  }


 


  sendGetRequest(url:string) {
    console.log(`${globales.url}${url}`, this.optHeader);
   
    return this.http.get<any[]>(`${globales.url}${url}`, this.optHeader);
  }


  
sendPutRequest(datos:any ,id : number ,url:string ){
  console.log('putClientesFactura',`${globales.url}${url}/${id}`,'datos', datos , this.optHeader);  
 return  this.http.put<any[]>(`${globales.url}${url}/${id}` , datos , this.optHeader ); 
}

 
sendPostRequest(datos:any   ,url:string ){
  console.log('postClientesFactura',`${globales.url}${url}`,'datos', datos , this.optHeader);  
 return  this.http.post<any[]>(`${globales.url}${url}` , {idEstado : 0 , idCliente:1004} , this.optHeader ); 
}



///----------------------------------------

sendGetRequestLastValue(url:string) {
  console.log(`${globales.url}${url}`, this.optHeader);
  let result = this.http.get<any[]>(`${globales.url}${url}`, this.optHeader);
  return lastValueFrom(result)
    .then((data: any) => data)
    .catch((e) => {
      throw e && e.error && e.error.Message && e.error.ExceptionMessage;
    });
}
sendPostRequestLastValue(url:string,datos:any){
console.log('sendPostRequestLastValue',`${globales.url}${url}`, datos , this.optHeader);  
let result =   this.http.post<any[]>(`${globales.url}${url}` , datos , this.optHeader ); 
return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message && e.error.ExceptionMessage;
});}

sendPutRequestLastValue(url:string , datos:any|Cliente ,id : number){
console.log('sendPutRequestLastValue',`${globales.url}${url}/${id}`, datos , this.optHeader);  
let result =   this.http.put<any[]>(`${globales.url}${url}/${id}` , datos , this.optHeader );
return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message && e.error.ExceptionMessage;
});

}
sendDeleteRequestLastValue( url:string ,id : number){ 
console.log('sendDeleteRequestLastValue',`${globales.url}${url}/${id}`,   this.optHeader);  
let result =   this.http.delete<any[]>(`${globales.url}${url}/${id}` ,  this.optHeader );


return lastValueFrom(result)
.then((data: any) =>  data)
.catch((e) => {
throw e && e.error && e.error.Message && e.error.ExceptionMessage;
});

}

}
