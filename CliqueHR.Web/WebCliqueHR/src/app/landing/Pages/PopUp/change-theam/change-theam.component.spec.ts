import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeTheamComponent } from './change-theam.component';

describe('ChangeTheamComponent', () => {
  let component: ChangeTheamComponent;
  let fixture: ComponentFixture<ChangeTheamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChangeTheamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChangeTheamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
