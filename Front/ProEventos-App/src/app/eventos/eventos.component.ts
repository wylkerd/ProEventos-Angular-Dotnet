import { CommonModule } from "@angular/common";
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from '@angular/core';
import { FormsModule } from "@angular/forms";

import { CollapseModule } from "ngx-bootstrap/collapse";

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [
    CommonModule,
    CollapseModule,
    FormsModule
  ],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})

export class EventosComponent implements OnInit{
  public eventos: any = [];
  public eventosFiltrados: any = [];

  exibirImagem = true;
  larguraImagem: number = 150;
  margemImagem: number = 2;
  private _filtroLista: string = '';

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  filtrarEventos(filtrarPor: string): any {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter((evento: any) =>
      evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos()
  }

  toggleImagem() {
    this.exibirImagem = !this.exibirImagem
  }

  public getEventos(): void {
    this.http.get("https://localhost:5001/api/eventos")
      .subscribe({
        next: (response) => {
          this.eventos = response
          this.eventosFiltrados = this.eventos
        },
        error: (error) => console.log(error)
      });
  }
}
