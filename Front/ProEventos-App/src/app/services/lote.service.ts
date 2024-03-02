import { HttpClient } from "@angular/common/http";
import { Injectable } from '@angular/core';

import { Lote } from "../models/Lote";

import { Observable, take } from "rxjs";
import { environments } from "@environments/environments";

@Injectable({
  providedIn: 'root'
})
export class LoteService {
  baseURL = environments.baseUrl + 'api/lotes';

  constructor(private http: HttpClient) {}

  public getLotesByEventoId(eventoId: number): Observable<Lote[]> {
    return this.http.get<Lote[]>(`${this.baseURL}/${eventoId}`).pipe(take(1));
  }

  public saveLote(eventoId: number, lotes: Lote[]): Observable<Lote[]> {
    return this.http
      .put<Lote[]>(`${this.baseURL}/${eventoId}`, lotes)
      .pipe(take(1));
  }

  public deleteLote(eventoId: number, loteId: number): Observable<any> {
    return this.http
      .delete(`${this.baseURL}/${eventoId}/${loteId}`)
      .pipe(take(1));
  }

}
