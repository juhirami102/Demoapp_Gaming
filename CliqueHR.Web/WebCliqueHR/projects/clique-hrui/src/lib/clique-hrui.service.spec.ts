import { TestBed } from '@angular/core/testing';

import { CliqueHRUiService } from './clique-hrui.service';

describe('CliqueHRUiService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: CliqueHRUiService = TestBed.get(CliqueHRUiService);
    expect(service).toBeTruthy();
  });
});
