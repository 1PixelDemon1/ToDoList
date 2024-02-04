import { TestBed } from '@angular/core/testing';

import { TaskgroupService } from './taskgroup.service';

describe('TaskgroupService', () => {
  let service: TaskgroupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TaskgroupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
