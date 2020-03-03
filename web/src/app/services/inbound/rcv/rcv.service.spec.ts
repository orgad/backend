import { TestBed } from '@angular/core/testing';

import { RcvService } from './rcv.service';

describe('RcvService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: RcvService = TestBed.get(RcvService);
    expect(service).toBeTruthy();
  });
});
