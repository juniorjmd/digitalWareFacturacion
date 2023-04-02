import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { FacturarComponent } from './components/facturar/facturar.component';
import { ClientesComponent } from './components/clientes/clientes.component';

const routes: Routes = [
  { path : 'inicio' , component : InicioComponent},  
  { path : 'home' ,  component : HomeComponent , children:[
    { path : 'facturar' ,  component : FacturarComponent },
    { path : 'clientes' ,  component : ClientesComponent },
    { path : '**' , pathMatch:'full' , redirectTo : 'facturar'}
  ] },
{ path : '**' , pathMatch:'full' , redirectTo : 'inicio'}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
