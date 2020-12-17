import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupCompanyComponent } from './group-company.component';

describe('GroupCompanyComponent', () => {
  let component: GroupCompanyComponent;
  let fixture: ComponentFixture<GroupCompanyComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GroupCompanyComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GroupCompanyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
