import { Routes } from '@angular/router';

import { PalestrantesComponent } from "./components/palestrantes/palestrantes.component";
import { ContatosComponent } from "./components/contatos/contatos.component";
import { DashboardComponent } from "./components/dashboard/dashboard.component";

import { UserComponent } from "./components/user/user.component";
import { LoginComponent } from "./components/user/login/login.component";
import { RegistrationComponent } from "./components/user/registration/registration.component";
import { PerfilComponent } from "./components/user/perfil/perfil.component";

import { EventosComponent } from "./components/eventos/eventos.component";
import { EventosDetalheComponent } from "./components/eventos/eventos-detalhe/eventos-detalhe.component";
import { EventosListaComponent } from "./components/eventos/eventos-lista/eventos-lista.component";

export const routes: Routes = [
  { path: 'eventos', redirectTo: 'eventos/lista' },
  {
    path: 'eventos', component: EventosComponent,
    children: [
      { path: 'detalhe/:id', component: EventosDetalheComponent },
      { path: 'detalhe', component: EventosDetalheComponent },
      { path: 'lista', component: EventosListaComponent },
    ],
  },
  {path: 'palestrantes', component: PalestrantesComponent},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'contatos', component: ContatosComponent},
  { path: 'user', redirectTo: 'user/perfil' },
      {
        path: 'user/perfil',
        component: PerfilComponent,
      },
  {
    path: 'user',
    component: UserComponent,
    children: [
      { path: 'login', component: LoginComponent },
      { path: 'registration', component: RegistrationComponent },
    ],
  },
  {path: '', redirectTo: 'dashboard', pathMatch: 'full'},
  {path: '*', redirectTo: 'dashboard', pathMatch: 'full'},
];
