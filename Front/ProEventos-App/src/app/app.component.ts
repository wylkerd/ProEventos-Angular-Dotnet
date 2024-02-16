import { CUSTOM_ELEMENTS_SCHEMA, Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

import { NgxSpinnerModule } from "ngx-spinner";

import { EventosComponent } from "./components/eventos/eventos.component";
import { PalestrantesComponent } from "./components/palestrantes/palestrantes.component";
import { NavComponent } from "./shared/nav/nav.component";
import { CommonModule } from "@angular/common";
import { ContatosComponent } from "./components/contatos/contatos.component";
import { DashboardComponent } from "./components/dashboard/dashboard.component";
import { PerfilComponent } from "./components/user/perfil/perfil.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss',
    imports: [
      EventosComponent,
      ContatosComponent,
      DashboardComponent,
      PerfilComponent,
      PalestrantesComponent,
      RouterOutlet,
      RouterLink,
      PalestrantesComponent,
      NavComponent,
      CommonModule,
      NgxSpinnerModule
    ],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppComponent {
  title = 'ProEventos-App';
}
