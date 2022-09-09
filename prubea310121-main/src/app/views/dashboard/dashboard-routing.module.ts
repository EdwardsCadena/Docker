import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrarComponent } from './pages/registrar/registrar.component';
import { ListarComponent } from './pages/listar/listar.component';
import { DashboardComponent } from './dashboard.component';
import { RegistrarGuard } from './util/registrar.guard';
import { HomeComponent } from './pages/home/home.component';

const routes: Routes = [
  {
    path: '',
    component: DashboardComponent,
    children: [
      {
        path: 'home',
        component: HomeComponent,
      },
      {
        path: 'registrar',
        component: RegistrarComponent,
        canActivate: [RegistrarGuard]
      },
      {
        path: 'listar',
        component: ListarComponent,
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class DashboardPageRoutingModule { }
