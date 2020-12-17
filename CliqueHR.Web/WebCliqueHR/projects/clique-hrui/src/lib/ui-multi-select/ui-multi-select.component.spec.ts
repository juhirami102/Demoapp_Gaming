import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { UiMultiSelectComponent } from './ui-multi-select.component';

describe('UiMultiSelectComponent', () => {
  let component: UiMultiSelectComponent;
  let fixture: ComponentFixture<UiMultiSelectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ UiMultiSelectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(UiMultiSelectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
