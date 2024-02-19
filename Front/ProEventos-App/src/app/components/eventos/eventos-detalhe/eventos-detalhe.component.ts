import { CommonModule } from "@angular/common";
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from "@angular/forms";
import { FontAwesomeModule } from "@fortawesome/angular-fontawesome";
import { NgxSpinnerService } from "ngx-spinner";

@Component({
  selector: 'app-eventos-detalhe',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FontAwesomeModule,
  ],
  templateUrl: './eventos-detalhe.component.html',
  styleUrl: './eventos-detalhe.component.scss',
})
export class EventosDetalheComponent implements OnInit {
  form: any = FormGroup;

  // get modoEditar(): boolean {
  //   return this.estadoSalvar === 'put';
  // }

  // get lotes(): FormArray {
  //   return this.form.get('lotes') as FormArray;
  // }

  get formValues(): any {
    return this.form.controls;
  }

  // get bsConfig(): any {
  //   return {
  //     adaptivePosition: true,
  //     dateInputFormat: 'DD/MM/YYYY hh:mm a',
  //     containerClass: 'theme-default',
  //     showWeekNumbers: false,
  //   };
  // }

  // public carregarEvento(): void {
  //   this.eventoId = +this.activatedRouter.snapshot.paramMap.get('id');

  //   if (this.eventoId !== null && this.eventoId !== 0) {
  //     this.spinner.show();

  //     this.estadoSalvar = 'put';

  //     this.eventoService
  //       .getEventoById(this.eventoId)
  //       .subscribe(
  //         (evento: Evento) => {
  //           this.evento = { ...evento };
  //           this.form.patchValue(this.evento);
  //           if (this.evento.imagemURL !== '') {
  //             this.imagemURL = environment.apiURL + 'resources/images/' + this.evento.imagemURL;
  //           }
  //           this.carregarLotes();
  //         },
  //         (error: any) => {
  //           this.toastr.error('Erro ao tentar carregar Evento.', 'Erro!');
  //           console.error(error);
  //         }
  //       )
  //       .add(() => this.spinner.hide());
  //   }
  // }

  // public carregarLotes(): void {
  //   this.loteService
  //     .getLotesByEventoId(this.eventoId)
  //     .subscribe(
  //       (lotesRetorno: Lote[]) => {
  //         lotesRetorno.forEach((lote) => {
  //           this.lotes.push(this.criarLote(lote));
  //         });
  //       },
  //       (error: any) => {
  //         this.toastr.error('Erro ao tentar carregar lotes', 'Erro');
  //         console.error(error);
  //       }
  //     )
  //     .add(() => this.spinner.hide());
  // }

  constructor(
    private fb: FormBuilder,
    private spinner: NgxSpinnerService,
  ) {

  }

  ngOnInit(): void {
    // this.carregarEvento();
    this.validation();
  }

  public validation(): void {
    this.form = this.fb.group({
      tema: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
      local: ['', Validators.required],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      imagemURL: [''],
      lotes: this.fb.array([]),
    });
  }

  // adicionarLote(): void {
  //   this.lotes.push(this.criarLote({ id: 0 } as Lote));
  // }

  // criarLote(lote: Lote): FormGroup {
  //   return this.fb.group({
  //     id: [lote.id],
  //     nome: [lote.nome, Validators.required],
  //     quantidade: [lote.quantidade, Validators.required],
  //     preco: [lote.preco, Validators.required],
  //     dataInicio: [lote.dataInicio],
  //     dataFim: [lote.dataFim],
  //   });
  // }

  // public mudarValorData(value: Date, indice: number, campo: string): void {
  //   this.lotes.value[indice][campo] = value;
  // }

  public retornaTituloLote(nome: string): string {
    return nome === null || nome === '' ? 'Nome do lote' : nome;
  }

  public resetForm(): void {
    this.form.reset();
  }

  // public cssValidator(campoForm: FormControl | AbstractControl): any {
  //   return { 'is-invalid': campoForm.errors && campoForm.touched };
  // }

  public salvarEvento(): void {
    // this.spinner.show();
    // if (this.form.valid) {
    //   this.evento =
    //     this.estadoSalvar === 'post'
    //       ? { ...this.form.value }
    //       : { id: this.evento.id, ...this.form.value };

    //   this.eventoService[this.estadoSalvar](this.evento).subscribe(
    //     (eventoRetorno: Evento) => {
    //       this.toastr.success('Evento salvo com Sucesso!', 'Sucesso');
    //       this.router.navigate([`eventos/detalhe/${eventoRetorno.id}`]);
    //     },
    //     (error: any) => {
    //       console.error(error);
    //       this.spinner.hide();
    //       this.toastr.error('Error ao salvar evento', 'Erro');
    //     },
    //     () => this.spinner.hide()
    //   );
    // }
  }

  // public salvarLotes(): void {
  //   if (this.form.controls.lotes.valid) {
  //     this.spinner.show();
  //     this.loteService
  //       .saveLote(this.eventoId, this.form.value.lotes)
  //       .subscribe(
  //         () => {
  //           this.toastr.success('Lotes salvos com Sucesso!', 'Sucesso!');
  //         },
  //         (error: any) => {
  //           this.toastr.error('Erro ao tentar salvar lotes.', 'Erro');
  //           console.error(error);
  //         }
  //       )
  //       .add(() => this.spinner.hide());
  //   }
  // }

  // public removerLote(template: TemplateRef<any>, indice: number): void {
  //   this.loteAtual.id = this.lotes.get(indice + '.id').value;
  //   this.loteAtual.nome = this.lotes.get(indice + '.nome').value;
  //   this.loteAtual.indice = indice;

  //   this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  // }

  // confirmDeleteLote(): void {
  //   this.modalRef.hide();
  //   this.spinner.show();

  //   this.loteService
  //     .deleteLote(this.eventoId, this.loteAtual.id)
  //     .subscribe(
  //       () => {
  //         this.toastr.success('Lote deletado com sucesso', 'Sucesso');
  //         this.lotes.removeAt(this.loteAtual.indice);
  //       },
  //       (error: any) => {
  //         this.toastr.error(
  //           `Erro ao tentar deletar o Lote ${this.loteAtual.id}`,
  //           'Erro'
  //         );
  //         console.error(error);
  //       }
  //     )
  //     .add(() => this.spinner.hide());
  // }

  // declineDeleteLote(): void {
  //   this.modalRef.hide();
  // }

  // onFileChange(ev: any): void {
  //   const reader = new FileReader();

  //   reader.onload = (event: any) => this.imagemURL = event.target.result;

  //   this.file = ev.target.files;
  //   reader.readAsDataURL(this.file[0]);

  //   this.uploadImagem();
  // }

  // uploadImagem(): void {
  //   this.spinner.show();
  //   this.eventoService.postUpload(this.eventoId, this.file).subscribe(
  //     () => {
  //       this.carregarEvento();
  //       this.toastr.success('Imagem atualizada com Sucesso', 'Sucesso!');
  //     },
  //     (error: any) => {
  //       this.toastr.error('Erro ao fazer upload de imagem', 'Erro!');
  //       console.log(error);
  //     }
  //   ).add(() => this.spinner.hide());
  // }

}
