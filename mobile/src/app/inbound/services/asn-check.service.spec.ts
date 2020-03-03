import { TestBed } from '@angular/core/testing';

import { AsnCheckService } from './asn-check.service';

describe('AsnCheckService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AsnCheckService = TestBed.get(AsnCheckService);
    expect(service).toBeTruthy();
  });
});
