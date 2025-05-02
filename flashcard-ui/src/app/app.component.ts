import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MouseGlowBackgroundComponent } from "./mouse-glow-background/mouse-glow-background.component"

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule, MouseGlowBackgroundComponent],
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
