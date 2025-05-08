import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ResolutionService} from '@proxy/resolutions';
import { ResolutionDto, CreateUpdateResolutionDto} from '@proxy/resolutions/dto';
import { SharedModule } from '../../shared/shared.module';
import { FieldCheckService } from '../../shared/field-check.service';
import { AuthService } from '@abp/ng.core';
@Component({
  selector: 'app-resolution-directory',
  templateUrl: './resolution-directory.component.html',
  styleUrls: ['./resolution-directory.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule,SharedModule],
})
export class ResolutionDirectoryComponent implements OnInit {
  isAuthenticated = false;
  resolutions: ResolutionDto[] = [];
  newResolution: CreateUpdateResolutionDto = { resolutionName: '' };
  editedResolution: ResolutionDto | null = null;
  modalMessage = '';
  isModalVisible = false;
  constructor(private resolutionService: ResolutionService,private fieldCheckService: FieldCheckService,private authService: AuthService) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated;
    this.getResolutions();
  }

  getResolutions(): void {
    this.resolutionService.getList({ skipCount: 0, maxResultCount: 1000 }).subscribe({
      next: (result) => {
        this.resolutions = result.items;
      },
      error: (error) => {
        console.error('Ошибка при загрузке разрешений:', error);
        alert(`Ошибка при загрузке разрешений: ${error.message}`);
      },
    });
  }

  addResolution(): void {
    if (!this.fieldCheckService.areFieldsFilled(this.newResolution)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else {

      this.resolutionService.create(this.newResolution).subscribe({
        next: (createdResolution) => {
          this.resolutions.push(createdResolution);
          this.newResolution = { resolutionName: '' };
        },
        error: (err) => {
          console.error('Ошибка при добавлении разрешения:', err);
          alert(`Ошибка при добавлении разрешения: ${err.message}`);
        },
      });
    }
  }

  startEditing(resolution: ResolutionDto): void {
    this.editedResolution = { ...resolution };
  }

  saveResolution(): void {
    if (!this.fieldCheckService.areFieldsFilled(this.editedResolution)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else {

      const updateDto: CreateUpdateResolutionDto = {
        resolutionName: this.editedResolution.resolutionName,
      };

      this.resolutionService.update(this.editedResolution.id, updateDto).subscribe({
        next: () => {
          const index = this.resolutions.findIndex((r) => r.id === this.editedResolution!.id);
          if (index !== -1) {
            this.resolutions[index] = this.editedResolution!;
          }
          this.editedResolution = null;
        },
        error: (err) => {
          console.error('Ошибка при редактировании разрешения:', err);
          alert(`Ошибка при редактировании разрешения: ${err.message}`);
        },
      });
    }
  }

  cancelEditing(): void {
    this.editedResolution = null;
  }

  deleteResolution(resolutionId: string): void {
    this.resolutionService.delete(resolutionId).subscribe({
      next: () => {
        this.resolutions = this.resolutions.filter((resolution) => resolution.id !== resolutionId);
      },
      error: (err) => {
        console.error('Ошибка при удалении разрешения:', err);
        alert(`Ошибка при удалении разрешения: ${err.message}`);
      },
    });
  }
}
