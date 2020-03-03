import { TestBed } from '@angular/core/testing';

import { QcService } from './qc.service';

describe('QcService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: QcService = TestBed.get(QcService);
    expect(service).toBeTruthy();
  });
});
