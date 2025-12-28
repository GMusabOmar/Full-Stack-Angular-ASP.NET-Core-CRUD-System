import { ComponentFixture, TestBed } from '@angular/core/testing';

import { clsAddnewstudent } from './addnewstudent';

describe('clsAddnewstudent', () => {
  let component: clsAddnewstudent;
  let fixture: ComponentFixture<clsAddnewstudent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [clsAddnewstudent],
    }).compileComponents();

    fixture = TestBed.createComponent(clsAddnewstudent);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
