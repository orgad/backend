import { TestBed } from '@angular/core/testing';

import { PutAwayService } from './put-away.service';

describe('PutAwayService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PutAwayService = TestBed.get(PutAwayService);
    expect(service).toBeTruthy();
  });
});
