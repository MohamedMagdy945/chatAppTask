import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChatRoomGroup } from './chat-room-group';

describe('ChatRoomGroup', () => {
  let component: ChatRoomGroup;
  let fixture: ComponentFixture<ChatRoomGroup>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ChatRoomGroup]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ChatRoomGroup);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
