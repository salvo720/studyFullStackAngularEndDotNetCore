import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GridArticoliComponent } from './grid-articoli.component';

describe('GridArticoliComponent', () => {
  let component: GridArticoliComponent;
  let fixture: ComponentFixture<GridArticoliComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GridArticoliComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GridArticoliComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
