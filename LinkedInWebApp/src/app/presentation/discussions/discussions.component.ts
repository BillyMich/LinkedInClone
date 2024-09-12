import { Component, OnInit } from '@angular/core';
import { DiscussionService } from '../../services/discussion.service';

@Component({
  selector: 'app-discussions',
  templateUrl: './discussions.component.html',
  styleUrls: ['./discussions.component.css'],
})
export class DiscussionsComponent implements OnInit {
  conversations: any[] = [];
  selectedConversation: any = null;
  messages: any[] = [];
  newMessage: string = ''; 

  constructor(private discussionService: DiscussionService) {}

  ngOnInit() {
    this.loadConversations();
  }

  loadConversations() {
    this.discussionService.getConversations().subscribe((data) => {
      this.conversations = data;
      if (this.conversations.length > 0) {
        this.selectConversation(this.conversations[0]);
      }
    });
  }

  selectConversation(conversation: any) {
    this.selectedConversation = conversation;
    this.loadMessages(conversation.id);
  }

  loadMessages(conversationId: string) {
    this.discussionService.getMessages(conversationId).subscribe((data) => {
      this.messages = data;
    });
  }

  sendMessage() {
    if (this.newMessage && this.selectedConversation) {
      this.discussionService
        .sendMessage(this.selectedConversation.id, this.newMessage)
        .subscribe(() => {
          this.newMessage = ''; // clear  input
          this.loadMessages(this.selectedConversation.id);
        });
    }
  }
}
