import { Component, OnInit } from '@angular/core';
import { FlashDeckService, FlashCard } from '../flash-deck.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-flash-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './flash-card.component.html',
  styleUrls: ['./flash-card.component.scss']
})
export class FlashCardComponent implements OnInit {

  cards: FlashCard[] = [];
  currentIndex: number = 0;
  isLoading: boolean = true;
  isDeckEmpty: boolean = false;

  constructor(private flashDeckService: FlashDeckService) {}

  ngOnInit() {
    this.loadDeck();
  }

  loadDeck() {
    this.isLoading = true;
    this.flashDeckService.getAll().subscribe({
      next: (cards) => {
        this.cards = cards.map(card => ({ ...card, isFlipped: false }));
        this.currentIndex = 0;
        this.isDeckEmpty = cards.length === 0;
        this.isLoading = false;
      },
      error: () => {
        this.isDeckEmpty = true;
        this.isLoading = false;
      }
    });
  }

  get currentCard(): FlashCard | null {
    if (this.cards.length === 0 || this.currentIndex >= this.cards.length) {
      return null;
    }
    return this.cards[this.currentIndex];
  }

  flipCard() {
    if (this.currentCard) {
      this.currentCard.isFlipped = !this.currentCard.isFlipped;
    }
  }

  submitAnswer(correct: boolean) {
    if (!this.currentCard) return;

    if (!correct) {
      // Add to the end to retry
      const retryCard = { ...this.currentCard, isFlipped: false };
      this.cards.push(retryCard);
    }

    this.moveToNextCard();
  }

  moveToNextCard() {
    this.currentIndex++;
    if (this.currentIndex >= this.cards.length) {
      this.isDeckEmpty = true;
    }
  }
}
