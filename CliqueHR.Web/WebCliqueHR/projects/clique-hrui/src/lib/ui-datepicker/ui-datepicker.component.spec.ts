import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UiDatepickerComponent } from './ui-datepicker.component';

describe('UiDatepickerComponent', () => {
  let component: UiDatepickerComponent;
  let fixture: ComponentFixture<UiDatepickerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UiDatepickerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UiDatepickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
