import { CommonModule } from "@angular/common";
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormsModule } from "@angular/forms";

import { CollapseModule } from "ngx-bootstrap/collapse";
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { faEye, faEyeSlash, faEdit, faTrash } from "@fortawesome/free-solid-svg-icons";
import { ToastrService } from "ngx-toastr";

import { EventoService } from "../../services/evento.service";
import { Evento } from "../../models/Evento";
import { DateTimeFormatPipe } from "../../helpers/DateTimeFormat.pipe";
import { NgxSpinnerService } from "ngx-spinner";
import { TituloComponent } from "../../shared/titulo/titulo.component";

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [
    CommonModule,
    CollapseModule,
    TooltipModule,
    BsDropdownModule,
    FormsModule,
    FontAwesomeModule,
    DateTimeFormatPipe,
    TituloComponent
  ],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss',
  providers: [
    EventoService,
    BsModalService,
    ToastrService
  ]
})

export class EventosComponent implements OnInit{
  modalRef?: BsModalRef;

  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];

  public exibirImagem = true;
  public larguraImagem: number = 150;
  public margemImagem: number = 2;
  private _filtroLista: string = '';

  // Icones
  faEye = faEye;
  faEyeSlash = faEyeSlash;
  faEdit = faEdit;
  faTrash = faTrash;

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) {}

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(value: string) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();
    return this.eventos.filter((evento: Evento) =>
      evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
      evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    )
  }

  public ngOnInit(): void {
    this.getEventos()
  }

  public toggleImagem(): void {
    this.exibirImagem = !this.exibirImagem
  }

  public getEventos(): void {
    this.spinner.show();

    this.eventoService.getEventos()
      .subscribe({
        next: (_eventos: Evento[]) => {
          this.eventos = _eventos
          this.eventosFiltrados = this.eventos
        },
        error: (error: any) => {
          if (error.statusText !== 'Unknown Error') {
            this.spinner.hide(),
            this.toastr.error('Erro ao carregar os Eventos', 'Erro!');
          }
        },
        complete: () => this.spinner.hide()
      });
  }

  // Modal de confirmacao
  openModal(template: TemplateRef<void>): void {
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Deletado com sucesso!', 'Deletado!');
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
