import { TestBed } from '@angular/core/testing';

import { CliqueHRInterceptorService } from './clique-hrinterceptor.service';

describe('CliqueHRInterceptorService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CliqueHRInterceptorService = TestBed.get(CliqueHRInterceptorService);
    expect(service).toBeTruthy();
  });
});
