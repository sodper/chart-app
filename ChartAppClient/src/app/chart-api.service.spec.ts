import { TestBed, inject } from '@angular/core/testing';

import { ChartApiService } from './chart-api.service';

describe('ChartApiService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ChartApiService]
    });
  });

  it('should be created', inject([ChartApiService], (service: ChartApiService) => {
    expect(service).toBeTruthy();
  }));
});
