import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticoliCardComponent } from './articoli-card.component';

describe('ArticoliCardComponent', () => {
  let component: ArticoliCardComponent;
  let fixture: ComponentFixture<ArticoliCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ArticoliCardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArticoliCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
