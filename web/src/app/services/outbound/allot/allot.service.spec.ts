import { TestBed } from '@angular/core/testing';

import { AllotService } from './allot.service';

describe('AllotService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: AllotService = TestBed.get(AllotService);
    expect(service).toBeTruthy();
  });
});
