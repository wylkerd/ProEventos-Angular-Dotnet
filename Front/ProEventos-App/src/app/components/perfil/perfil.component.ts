import { Component, OnInit } from '@angular/core';
import { TituloComponent } from "../../shared/titulo/titulo.component";

@Component({
  selector: 'app-perfil',
  standalone: true,
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss'],
  imports: [TituloComponent]
})
export class PerfilComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
