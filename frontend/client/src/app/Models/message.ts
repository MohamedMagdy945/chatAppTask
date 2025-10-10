export interface IMessage {
  id: number;
  senderId: number;
  groupId: number;
  content?: string | null;
  fileUrl?: string | null;
  type: number;
  sentAt: Date; 
}
