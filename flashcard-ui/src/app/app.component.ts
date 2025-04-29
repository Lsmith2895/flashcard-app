import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { FlashCardComponent } from './flash-card/flash-card.component'


@Component({
  selector: 'app-root',
  imports: [RouterOutlet, FlashCardComponent],
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'flashcard-ui';
}
