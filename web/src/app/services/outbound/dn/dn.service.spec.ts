import { TestBed } from '@angular/core/testing';

import { DnService } from './dn.service';

describe('DnService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: DnService = TestBed.get(DnService);
    expect(service).toBeTruthy();
  });
});
