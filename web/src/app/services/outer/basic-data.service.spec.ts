import { TestBed } from '@angular/core/testing';

import { BasicDataService } from './basic-data.service';

describe('BasicDataService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: BasicDataService = TestBed.get(BasicDataService);
    expect(service).toBeTruthy();
  });
});
