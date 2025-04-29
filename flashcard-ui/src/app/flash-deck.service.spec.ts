import { TestBed } from '@angular/core/testing';

import { FlashDeckService } from './flash-deck.service';

describe('FlashDeckService', () => {
  let service: FlashDeckService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FlashDeckService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
