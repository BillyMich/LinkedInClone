import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BypassLoginComponent } from './bypass-login.component';

describe('BypassLoginComponent', () => {
  let component: BypassLoginComponent;
  let fixture: ComponentFixture<BypassLoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BypassLoginComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BypassLoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
