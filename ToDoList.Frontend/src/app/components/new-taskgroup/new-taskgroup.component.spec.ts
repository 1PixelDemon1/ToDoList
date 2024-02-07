import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewTaskgroupComponent } from './new-taskgroup.component';

describe('NewTaskgroupComponent', () => {
  let component: NewTaskgroupComponent;
  let fixture: ComponentFixture<NewTaskgroupComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewTaskgroupComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewTaskgroupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
