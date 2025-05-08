import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {ClientService} from '@proxy/clients';
import {ClientDto,CreateUpdateClientDto} from '@proxy/clients/dto';
import { SharedModule } from '../../shared/shared.module';
import { FieldCheckService } from '../../shared/field-check.service';
import { AuthService } from '@abp/ng.core';


@Component({
  selector: 'app-client-directory',
  templateUrl: './client-directory.component.html',
  styleUrls: ['./client-directory.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule,SharedModule],
})
export class ClientDirectoryComponent implements OnInit {
  isAuthenticated = false;
  clients: ClientDto[] = [];
  newClient: CreateUpdateClientDto = { name: '' };
  editedClient: ClientDto | null = null;
  modalMessage = '';
  isModalVisible = false;
  constructor(private clientService: ClientService,private fieldCheckService: FieldCheckService,private authService: AuthService) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated;
    this.getClients();
  }

  getClients(): void {
    this.clientService.getList({ skipCount: 0, maxResultCount: 1000 }).subscribe({
      next: (result) => {
        this.clients = result.items;
      },
      error: (error) => {
        console.error('Ошибка при загрузке клиентов:', error);
        alert(`Ошибка при загрузке клиентов: ${error.message}`);
      },
    });
  }

  addClient(): void {
    if (!this.fieldCheckService.areFieldsFilled(this.newClient)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else {

      this.clientService.create(this.newClient).subscribe({
        next: (createdClient) => {
          this.clients.push(createdClient);
          this.newClient = { name: '' };
        },
        error: (err) => {
          console.error('Ошибка при добавлении клиента:', err);
          alert(`Ошибка при добавлении клиента: ${err.message}`);
        },
      });
    }
  }

  startEditing(client: ClientDto): void {
    this.editedClient = { ...client };
  }

  saveClient(): void {
    if (!this.fieldCheckService.areFieldsFilled(this.editedClient)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else {

      const updateDto: CreateUpdateClientDto = {
        name: this.editedClient.name,
      };

      this.clientService.update(this.editedClient.id, updateDto).subscribe({
        next: () => {
          const index = this.clients.findIndex((c) => c.id === this.editedClient!.id);
          if (index !== -1) {
            this.clients[index] = this.editedClient!;
          }
          this.editedClient = null;
        },
        error: (err) => {
          console.error('Ошибка при редактировании клиента:', err);
          alert(`Ошибка при редактировании клиента: ${err.message}`);
        },
      });
    }
  }

  cancelEditing(): void {
    this.editedClient = null;
  }

  deleteClient(clientId: string): void {
    this.clientService.delete(clientId).subscribe({
      next: () => {
        this.clients = this.clients.filter((client) => client.id !== clientId);
      },
      error: (err) => {
        console.error('Ошибка при удалении клиента:', err);
        alert(`Ошибка при удалении клиента: ${err.message}`);
      },
    });
  }
}

