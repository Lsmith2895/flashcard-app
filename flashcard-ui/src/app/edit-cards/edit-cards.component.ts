import { Component, OnInit } from '@angular/core';
import { FlashDeckService, FlashCard } from '../flash-deck.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-edit-cards',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './edit-cards.component.html',
  styleUrls: ['./edit-cards.component.scss']
})
export class EditCardsComponent implements OnInit {
  cards: FlashCard[] = [];
  isLoading = true;

  newCard: FlashCard = { id: '', front: '', back: '', isFlipped: false };
  editingCard: FlashCard | null = null;

  constructor(private flashDeckService: FlashDeckService) {}

  ngOnInit(): void {
    this.loadCards();
  }

  loadCards() {
    this.flashDeckService.getAll().subscribe(cards => {
      this.cards = cards;
      this.isLoading = false;
    });
  }

  createCard() {
    const { front, back, isFlipped } = this.newCard;
    const newCard = { front, back, isFlipped }; // ensures no accidental `id` field
  
    this.flashDeckService.create(newCard).subscribe(() => {
      this.newCard = { front: '', back: '', isFlipped: false };
      this.loadCards();
    });
  }
  

  startEdit(card: FlashCard) {
    this.editingCard = { ...card };
  }

  saveEdit() {
    if (!this.editingCard) return;

    this.flashDeckService.update(this.editingCard).subscribe(() => {
      this.editingCard = null;
      this.loadCards();
    });
  }

  cancelEdit() {
    this.editingCard = null;
  }

  deleteCard(id: string) {
    this.flashDeckService.delete(id).subscribe(() => {
      this.loadCards();
    });
  }

  // Getter + Setter proxies for safe two-way binding
  get editFront(): string {
    return this.editingCard?.front || '';
  }

  set editFront(value: string) {
    if (this.editingCard) {
      this.editingCard.front = value;
    }
  }

  get editBack(): string {
    return this.editingCard?.back || '';
  }

  set editBack(value: string) {
    if (this.editingCard) {
      this.editingCard.back = value;
    }
  }
}
