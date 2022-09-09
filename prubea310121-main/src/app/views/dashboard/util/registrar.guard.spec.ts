import { TestBed } from '@angular/core/testing';

import { RegistrarGuard } from './registrar.guard';

describe('RegistrarGuard', () => {
  let guard: RegistrarGuard;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    guard = TestBed.inject(RegistrarGuard);
  });

  it('should be created', () => {
    expect(guard).toBeTruthy();
  });
});
