/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { FlappyService } from './flappy.service';

describe('Service: Flappy', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [FlappyService]
    });
  });

  it('should ...', inject([FlappyService], (service: FlappyService) => {
    expect(service).toBeTruthy();
  }));
});
