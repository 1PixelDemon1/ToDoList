import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskgroupListComponent } from './taskgroup-list.component';

describe('TaskgroupListComponent', () => {
  let component: TaskgroupListComponent;
  let fixture: ComponentFixture<TaskgroupListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskgroupListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskgroupListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
