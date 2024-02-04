import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskgroupTaskListComponent } from './taskgroup-task-list.component';

describe('TaskgroupTaskListComponent', () => {
  let component: TaskgroupTaskListComponent;
  let fixture: ComponentFixture<TaskgroupTaskListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskgroupTaskListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskgroupTaskListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
