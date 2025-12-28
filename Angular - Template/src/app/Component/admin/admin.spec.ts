import { ComponentFixture, TestBed } from '@angular/core/testing';

import { clsAdmin } from './admin';

describe('clsAdmin', () => {
  let component: clsAdmin;
  let fixture: ComponentFixture<clsAdmin>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [clsAdmin],
    }).compileComponents();

    fixture = TestBed.createComponent(clsAdmin);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
