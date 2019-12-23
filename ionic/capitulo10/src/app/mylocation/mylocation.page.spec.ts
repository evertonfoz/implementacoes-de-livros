import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MylocationPage } from './mylocation.page';

describe('MylocationPage', () => {
  let component: MylocationPage;
  let fixture: ComponentFixture<MylocationPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MylocationPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MylocationPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
