import { Component, OnInit } from '@angular/core';
import { faEnvelopeOpenText } from "@fortawesome/free-solid-svg-icons";
import { TituloComponent } from "../../shared/titulo/titulo.component";

@Component({
  selector: 'app-contatos',
  standalone: true,
  templateUrl: './contatos.component.html',
  styleUrls: ['./contatos.component.scss'],
  imports: [TituloComponent]
})
export class ContatosComponent implements OnInit {
  faEnvelopeOpenText = faEnvelopeOpenText;

  constructor() { }

  ngOnInit() {
  }

}
