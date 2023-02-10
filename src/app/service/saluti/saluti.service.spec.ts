import { TestBed } from '@angular/core/testing';

import { SalutiService } from './saluti.service';

describe('SalutiService', () => {
  let service: SalutiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SalutiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
