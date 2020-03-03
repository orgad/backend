import { TestBed } from '@angular/core/testing';

import { HandOverService } from './hand-over.service';

describe('HandOverService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: HandOverService = TestBed.get(HandOverService);
    expect(service).toBeTruthy();
  });
});
