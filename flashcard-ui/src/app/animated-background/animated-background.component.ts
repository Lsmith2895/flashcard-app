import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-animated-background',
  standalone: true,
  templateUrl: './animated-background.component.html',
  styleUrls: ['./animated-background.component.scss']
})
export class AnimatedBackgroundComponent implements OnInit {
  plusSymbols: { x: number, y: number }[] = [];
  mouseX = 0;
  mouseY = 0;
  spacing = 40;

  ngOnInit(): void {
    const rows = Math.ceil(window.innerHeight / this.spacing);
    const centerX = window.innerWidth / 2;

    for (let i = 0; i < rows; i++) {
      this.plusSymbols.push({ x: centerX, y: i * this.spacing });
    }
  }

  @HostListener('window:mousemove', ['$event'])
  onMouseMove(event: MouseEvent) {
    this.mouseX = event.clientX;
    this.mouseY = event.clientY;

    this.plusSymbols = this.plusSymbols.map(symbol => {
      const dx = symbol.x - this.mouseX;
      const dy = symbol.y - this.mouseY;
      const dist = Math.sqrt(dx * dx + dy * dy);
      const near = dist < 60;

      return {
        ...symbol,
        color: near ? 'rgba(255, 255, 255, 0.9)' : 'rgba(255, 255, 255, 0.1)'
      };
    });
  }
}
