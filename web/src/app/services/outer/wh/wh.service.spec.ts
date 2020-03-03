import { TestBed } from '@angular/core/testing';

import { WhService } from './wh.service';

describe('WhService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: WhService = TestBed.get(WhService);
    expect(service).toBeTruthy();
  });
});
