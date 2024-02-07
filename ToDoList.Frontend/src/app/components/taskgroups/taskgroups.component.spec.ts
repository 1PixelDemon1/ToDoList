import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskgroupsComponent } from './taskgroups.component';

describe('TaskgroupsComponent', () => {
  let component: TaskgroupsComponent;
  let fixture: ComponentFixture<TaskgroupsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskgroupsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskgroupsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
