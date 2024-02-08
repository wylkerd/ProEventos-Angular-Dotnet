import { CommonModule } from "@angular/common";
import { HttpClient } from "@angular/common/http";
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  standalone: true,
  imports: [
    CommonModule
  ],
  templateUrl: './eventos.component.html',
  styleUrl: './eventos.component.scss'
})

export class EventosComponent implements OnInit{
  public eventos: any;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.getEventos()
  }

  public getEventos(): void {
    this.http.get("https://localhost:5001/api/eventos")
      .subscribe({
        next: (response) => { this.eventos = response },
        error: (error) => console.log(error)
      });
  }
}
