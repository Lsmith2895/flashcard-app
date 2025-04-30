import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface FlashCard {
  id: string;
  front: string;
  back: string;
  isFlipped: boolean;
}

@Injectable({
  providedIn: 'root'
})
//TODO: update based on your URL i.e. 5001, 5164, etc
export class FlashDeckService {
  private apiUrl = 'https://lively-plant-0d0125a1e.6.azurestaticapps.net';

  constructor(private http: HttpClient) {}

  getAll(): Observable<FlashCard[]> {
    return this.http.get<FlashCard[]>(this.apiUrl);
  }

  get(id: string): Observable<FlashCard> {
    return this.http.get<FlashCard>(`${this.apiUrl}/${id}`);
  }

  create(card: FlashCard): Observable<FlashCard> {
    return this.http.post<FlashCard>(this.apiUrl, card);
  }

  update(card: FlashCard): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${card.id}`, card);
  }

  delete(id: string): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
