import { TestBed } from '@angular/core/testing';

import { RecheckService } from './recheck.service';

describe('RecheckService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RecheckService = TestBed.get(RecheckService);
    expect(service).toBeTruthy();
  });
});
