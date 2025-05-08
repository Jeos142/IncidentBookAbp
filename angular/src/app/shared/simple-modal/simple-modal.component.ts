import { Component, Input, Output, EventEmitter, OnInit  } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-simple-modal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './simple-modal.component.html',
  styleUrl: './simple-modal.component.scss'
})
export class SimpleModalComponent  {
  @Input() message: string = '';
  @Input() visible: boolean = false;
  @Output() closed = new EventEmitter<void>();

  close() {
    this.closed.emit();
  }
}
