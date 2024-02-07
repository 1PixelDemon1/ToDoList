import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessibleTasksComponent } from './accessible-tasks.component';

describe('AccessibleTasksComponent', () => {
  let component: AccessibleTasksComponent;
  let fixture: ComponentFixture<AccessibleTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AccessibleTasksComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AccessibleTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
