import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OrdensdeservicoAddEditPage } from './ordensdeservico-add-edit.page';

describe('OrdensdeservicoAddEditPage', () => {
  let component: OrdensdeservicoAddEditPage;
  let fixture: ComponentFixture<OrdensdeservicoAddEditPage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdensdeservicoAddEditPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OrdensdeservicoAddEditPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
