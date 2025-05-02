import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-mouse-glow-background',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './mouse-glow-background.component.html',
  styleUrls: ['./mouse-glow-background.component.scss']
})
export class MouseGlowBackgroundComponent {
  mouseX = 0;
  mouseY = 0;

  @HostListener('document:mousemove', ['$event'])
  onMouseMove(event: MouseEvent) {
    this.mouseX = event.clientX;
    this.mouseY = event.clientY;
  }
}