import { CommonModule } from "@angular/common";
import { Component, OnInit } from '@angular/core';

import { faCalendarAlt } from "@fortawesome/free-solid-svg-icons";
import { RouterOutlet } from "@angular/router";
import { TituloComponent } from "../../shared/titulo/titulo.component";

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [
    CommonModule,
    RouterOutlet,
    TituloComponent
  ],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})

export class EventosComponent implements OnInit{
  faCalendarAlt = faCalendarAlt;

  public ngOnInit(): void {

  }

}
