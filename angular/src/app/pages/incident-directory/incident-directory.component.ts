import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IncidentService} from '@proxy/incidents';
import {IncidentDto, CreateUpdateIncidentDto,IncidentWithNavigationPropertiesDto} from '@proxy/incidents/dto';
import { ResolutionService} from '@proxy/resolutions';
import {ClientService} from '@proxy/clients';
import { IncidentClassificationService} from '@proxy/incident-classifications';
import {ClientDto,CreateUpdateClientDto} from '@proxy/clients/dto';
import { IncidentClassificationDto, CreateUpdateIncidentClassificationDto} from '@proxy/incident-classifications/dto';
import { ResolutionDto, CreateUpdateResolutionDto} from '@proxy/resolutions/dto';
import { FieldCheckService } from '../../shared/field-check.service';
import {SimpleModalComponent} from '../../shared/simple-modal/simple-modal.component';
import { SharedModule } from '../../shared/shared.module';
import { AuthService } from '@abp/ng.core';
@Component({
  selector: 'app-incident-directory',
  templateUrl: './incident-directory.component.html',
  styleUrls: ['./incident-directory.component.css'],
  standalone: true,
  imports: [CommonModule, FormsModule, SharedModule]
})
export class IncidentDirectoryComponent implements OnInit {
  isAuthenticated = false;
  incidents: IncidentWithNavigationPropertiesDto[] = [];
  classifications: IncidentClassificationDto[] = [];
  clients: ClientDto[] = [];
  resolutions: ResolutionDto[] = [];

  newIncident: CreateUpdateIncidentDto = {
    description: '',
    clientId: '',
    classificationId: '',
    dateTime: this.getCurrentDateTimeString(),
    isComplete: false,
    resolutionId: undefined,
  };

  editedIncident: IncidentWithNavigationPropertiesDto | null = null;
  confirmDeleteId: string | null = null;
  modalMessage = '';
  isModalVisible = false;

  constructor(
    private incidentService: IncidentService,
    private clientService: ClientService,
    private classificationService: IncidentClassificationService,
    private resolutionService: ResolutionService,
    private fieldCheckService: FieldCheckService,
    private authService: AuthService
  ) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated;

    this.loadAll();
  }

  loadAll(): void {
    this.loadIncidents();
    this.loadClients();
    this.loadClassifications();
    this.loadResolutions();
  }

  loadIncidents(): void {
    this.incidentService.getListWithNavigation({ skipCount: 0, maxResultCount: 1000 }).subscribe({
      next: (result) => {
        this.incidents = result.items;
      },
      error: (error) => {
        console.error('Ошибка при загрузке инцидентов:', error);
        alert('Ошибка при загрузке инцидентов.');
      },
    });
  }

  loadClients(): void {
    this.clientService.getList({ skipCount: 0, maxResultCount: 1000 }).subscribe({
      next: (result) => {
        this.clients = result.items;
      },
      error: (error) => {
        console.error('Ошибка при загрузке клиентов:', error);
      },
    });
  }

  loadClassifications(): void {
    this.classificationService.getList({ skipCount: 0, maxResultCount: 1000 }).subscribe({
      next: (result) => {
        this.classifications = result.items;
      },
      error: (error) => {
        console.error('Ошибка при загрузке классификаций:', error);
      },
    });
  }

  loadResolutions(): void {
    this.resolutionService.getList({ skipCount: 0, maxResultCount: 1000 }).subscribe({
      next: (result) => {
        this.resolutions = result.items;
      },
      error: (error) => {
        console.error('Ошибка при загрузке резолюций:', error);
      },
    });
  }

  addIncident(): void {
    if (!this.fieldCheckService.areFieldsFilled(this.newIncident)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else{
      this.incidentService.create(this.newIncident).subscribe({
        next: () => {
          this.loadIncidents();
          this.resetNewIncident();
        },
        error: (error) => {
          console.error('Ошибка при добавлении инцидента:', error);
          alert('Ошибка при добавлении инцидента.');
        },
      });
    }
  }

  startEditing(incident: IncidentWithNavigationPropertiesDto): void {
    this.editedIncident = {
      ...JSON.parse(JSON.stringify(incident)),
      resolutionId: incident.resolution?.id ?? null // если есть, скопировать
    };
  }

  saveIncident(): void {
    if (!this.editedIncident) return;
    if (!this.fieldCheckService.areFieldsFilled(this.editedIncident)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else{
      const updatedIncident: CreateUpdateIncidentDto = {
        description: this.editedIncident.description || '',
        clientId: this.editedIncident.client.id,
        classificationId: this.editedIncident.classification.id,
        dateTime: this.editedIncident.dateTime,
        isComplete: this.editedIncident.isComplete,
        resolutionId: this.editedIncident.isComplete ? this.editedIncident.resolutionId : undefined,
      };

      this.incidentService.update(this.editedIncident.id!, updatedIncident).subscribe({
        next: () => {
          this.loadIncidents();
          this.editedIncident = null;
        },
        error: (error) => {
          console.error('Ошибка при сохранении инцидента:', error);
        },
      });
    }
  }

  cancelEditing(): void {
    this.editedIncident = null;
  }



  askDelete(id: string): void {
    this.confirmDeleteId = id;
  }

  performDelete(): void {
    if (!this.confirmDeleteId) return;

    this.incidentService.delete(this.confirmDeleteId).subscribe({
      next: () => {
        this.loadIncidents();
        this.confirmDeleteId = null;
      },
      error: (error) => {
        console.error('Ошибка при удалении инцидента:', error);
      },
    });
  }

  cancelDelete(): void {
    this.confirmDeleteId = null;
  }
  //Очистка формы
  private resetNewIncident(): void {
    this.newIncident = {
      description: '',
      clientId: '',
      classificationId: '',
      dateTime: '',
      isComplete: false,
      resolutionId: undefined,
    };
  }
  //Преобразование даты в привычный глазу формат
  private getCurrentDateTimeString(): string {
    const now = new Date();
    const year = now.getFullYear();
    const month = String(now.getMonth() + 1).padStart(2, '0');
    const day = String(now.getDate()).padStart(2, '0');
    const hours = String(now.getHours()).padStart(2, '0');
    const minutes = String(now.getMinutes()).padStart(2, '0');

    return `${year}-${month}-${day}T${hours}:${minutes}`;
  }

}

