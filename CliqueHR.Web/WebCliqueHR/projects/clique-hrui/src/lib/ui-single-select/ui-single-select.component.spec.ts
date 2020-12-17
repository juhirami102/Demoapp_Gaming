import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UiSingleSelectComponent } from './ui-single-select.component';

describe('UiSingleSelectComponent', () => {
  let component: UiSingleSelectComponent;
  let fixture: ComponentFixture<UiSingleSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UiSingleSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UiSingleSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
