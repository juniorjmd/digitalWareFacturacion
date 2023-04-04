import { NgModule } from '@angular/core';
<<<<<<< HEAD
import { Routes, RouterModule } from '@angular/router';
import { LoginFormComponent, ResetPasswordFormComponent, CreateAccountFormComponent, ChangePasswordFormComponent } from './shared/components';
import { AuthGuardService } from './shared/services';
import { HomeComponent } from './pages/home/home.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { TasksComponent } from './pages/tasks/tasks.component';
import { DxDataGridModule, DxFormModule } from 'devextreme-angular'; 

const routes: Routes = [ 
   

  {
    path: 'inventario',
    loadChildren: () => import('./pages/inventario/inventario.module').then( m => m.InventarioModule) 
  }, 
  {
    path: 'facturacion',
    loadChildren: () => import('./pages/facturacion/facturacion.module').then( m => m.FacturacionModule)
  },



  
  {
    path: 'clientes',
    loadChildren: () => import('./pages/clientes/clientes.module').then( m => m.ClientesModule)
  },
 
  
  {
    path: 'tasks',
    component: TasksComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'profile',
    component: ProfileComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'home',
    component: HomeComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'login-form',
    component: LoginFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'reset-password',
    component: ResetPasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'create-account',
    component: CreateAccountFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: 'change-password/:recoveryCode',
    component: ChangePasswordFormComponent,
    canActivate: [ AuthGuardService ]
  },
  {
    path: '**',
    redirectTo: 'home'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true }), DxDataGridModule, DxFormModule],
  providers: [AuthGuardService],
  exports: [RouterModule],
  declarations: [
    HomeComponent,
    ProfileComponent,
    TasksComponent
  ]
=======
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { InicioComponent } from './components/inicio/inicio.component';
import { FacturarComponent } from './components/facturar/facturar.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { ProductsComponent } from './components/products/products.component';
import { BrandsComponent } from './components/brands/brands.component';
import { DiscountsComponent } from './components/discounts/discounts.component';

const routes: Routes = [
  { path : 'inicio' , component : InicioComponent},  
  { path : 'home' ,  component : HomeComponent , children:[
    { path : 'facturar' ,  component : FacturarComponent },
    { path : 'clientes' ,  component : ClientesComponent },
    { path : 'products' ,  component : ProductsComponent },
    { path : 'brands' ,  component : BrandsComponent },
    { path : 'discounts' ,  component : DiscountsComponent },
    { path : '**' , pathMatch:'full' , redirectTo : 'facturar'}
  ] },
{ path : '**' , pathMatch:'full' , redirectTo : 'inicio'}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
>>>>>>> 8ed109d526751ee2a14d8ac81db21e87d531951c
})
export class AppRoutingModule { }
