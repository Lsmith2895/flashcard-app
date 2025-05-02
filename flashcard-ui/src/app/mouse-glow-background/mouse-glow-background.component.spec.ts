import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MouseGlowBackgroundComponent } from './mouse-glow-background.component';

describe('MouseGlowBackgroundComponent', () => {
  let component: MouseGlowBackgroundComponent;
  let fixture: ComponentFixture<MouseGlowBackgroundComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MouseGlowBackgroundComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MouseGlowBackgroundComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
