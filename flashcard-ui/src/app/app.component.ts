import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import {AnimatedBackgroundComponent} from "../app/animated-background/animated-background.component"

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, AnimatedBackgroundComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent {
  title = 'flashcard-ui';
  isMenuOpen = false;

  toggleMenu() {
    this.isMenuOpen = !this.isMenuOpen;
  }
}
