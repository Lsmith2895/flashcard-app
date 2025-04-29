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

  currentCard: FlashCard | null = null;
  isLoading: boolean = true;
  isDeckEmpty: boolean = false;

  constructor(private flashDeckService: FlashDeckService) {}

  ngOnInit() {
    this.loadCurrentCard();
  }

  loadCurrentCard() {
    this.isLoading = true;
    this.flashDeckService.getCurrentCard().subscribe({
      next: (card) => {
        this.currentCard = card;
        this.isLoading = false;
      },
      error: () => {
        this.isDeckEmpty = true;
        this.isLoading = false;
      }
    });
  }

  flipCard() {
    this.flashDeckService.flipCurrentCard().subscribe(() => {
      if (this.currentCard) {
        this.currentCard.isFlipped = !this.currentCard.isFlipped;
      }
    });
  }

  submitAnswer(correct: boolean) {
    this.flashDeckService.submitAnswer(correct).subscribe(() => {
      this.moveToNextCard();
    });
  }

  moveToNextCard() {
    this.flashDeckService.moveToNextCard().subscribe(() => {
      this.loadCurrentCard();
    });
  }
}
