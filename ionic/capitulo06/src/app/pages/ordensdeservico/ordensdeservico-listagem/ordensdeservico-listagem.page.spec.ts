import { ComponentFixture, TestBed, waitForAsync } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { OrdensdeservicoListagemPage } from './ordensdeservico-listagem.page';

describe('OrdensdeservicoListagemPage', () => {
  let component: OrdensdeservicoListagemPage;
  let fixture: ComponentFixture<OrdensdeservicoListagemPage>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      declarations: [ OrdensdeservicoListagemPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(OrdensdeservicoListagemPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
