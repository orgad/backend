import { TestBed } from '@angular/core/testing';

import { PickService } from './pick.service';

describe('PickService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PickService = TestBed.get(PickService);
    expect(service).toBeTruthy();
  });
});
