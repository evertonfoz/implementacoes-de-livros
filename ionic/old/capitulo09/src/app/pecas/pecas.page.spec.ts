import { CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PecasPage } from './pecas.page';

describe('PecasPage', () => {
  let component: PecasPage;
  let fixture: ComponentFixture<PecasPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PecasPage ],
      schemas: [CUSTOM_ELEMENTS_SCHEMA],
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PecasPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
