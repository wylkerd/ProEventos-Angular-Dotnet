import { CommonModule } from "@angular/common";
import { Component, Input, OnInit } from '@angular/core';
import { Router } from "@angular/router";

import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { faUser, faCalendarAlt } from "@fortawesome/free-solid-svg-icons";

@Component({
  selector: 'app-titulo',
  standalone: true,
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss'],
  imports: [
    CommonModule,
    FontAwesomeModule,
  ]
})
export class TituloComponent implements OnInit {
  @Input() titulo: string = "";
  @Input() iconClass = 'fa fa-user';
  @Input() subtitulo = 'Desde 2024';
  @Input() botaoListar = false;

  constructor(private router: Router) {}

  ngOnInit(): void {}

  listar(): void {
    this.router.navigate([`/${this.titulo.toLocaleLowerCase()}/lista`]);
  }
}
