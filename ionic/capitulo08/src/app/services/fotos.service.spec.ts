import { TestBed } from '@angular/core/testing';

import { FotosService } from './fotos.service';

describe('FotosService', () => {
  let service: FotosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FotosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
