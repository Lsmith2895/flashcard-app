import { Routes } from '@angular/router';
import { FlashCardComponent } from './flash-card/flash-card.component';
import { HomeComponent } from './home/home.component';
import { EditCardsComponent } from './edit-cards/edit-cards.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'study', component: FlashCardComponent },
  { path: 'edit', component: EditCardsComponent },
  { path: '**', redirectTo: '' }
];
