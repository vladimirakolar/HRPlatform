import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InsertCandidateComponent } from './insert-candidate.component';

describe('InsertCandidateComponent', () => {
  let component: InsertCandidateComponent;
  let fixture: ComponentFixture<InsertCandidateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InsertCandidateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(InsertCandidateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
