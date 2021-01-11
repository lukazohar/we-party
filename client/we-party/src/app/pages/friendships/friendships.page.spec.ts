import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';
import { FriendshipsPage } from './friendships.page';

describe('FriendshipsPage', () => {
  let component: FriendshipsPage;
  let fixture: ComponentFixture<FriendshipsPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [FriendshipsPage],
      imports: [IonicModule.forRoot()],
    }).compileComponents();

    fixture = TestBed.createComponent(FriendshipsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
