import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskgroupElementsComponent } from './taskgroup-elements.component';

describe('TaskgroupElementsComponent', () => {
  let component: TaskgroupElementsComponent;
  let fixture: ComponentFixture<TaskgroupElementsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [TaskgroupElementsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TaskgroupElementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
