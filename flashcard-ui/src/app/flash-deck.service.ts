import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

// Define what a FlashCard looks like
export interface FlashCard {
  id: string;
  front: string;
  back: string;
  isFlipped: boolean;
}

@Injectable({
  providedIn: 'root'
})
export class FlashDeckService {

  // TODO: Update this based on your own server URL
  private apiUrl = 'https://localhost:5164/flashcard';

  constructor(private http: HttpClient) { }

  getCurrentCard(): Observable<FlashCard> {
    return this.http.get<FlashCard>(`${this.apiUrl}/current`);
  }

  flipCurrentCard(): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/flip`, {});
  }

  submitAnswer(correct: boolean): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/submit?correct=${correct}`, {});
  }

  moveToNextCard(): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/next`, {});
  }

  isDeckEmpty(): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/empty`);
  }
}
