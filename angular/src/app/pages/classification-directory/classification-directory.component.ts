import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { IncidentClassificationService} from '@proxy/incident-classifications';
import { IncidentClassificationDto, CreateUpdateIncidentClassificationDto} from '@proxy/incident-classifications/dto';
import { SimpleModalComponent } from '../../shared/simple-modal/simple-modal.component';

import { FieldCheckService } from '../../shared/field-check.service';
import { AuthService } from '@abp/ng.core';
@Component({
  selector: 'app-classification-directory',
  templateUrl: './classification-directory.component.html',
  styleUrls: ['./classification-directory.component.css'],
  standalone: true,
  imports: [FormsModule, CommonModule, SimpleModalComponent]
})
export class ClassificationDirectoryComponent implements OnInit {
  isAuthenticated = false;
  classifications: IncidentClassificationDto[] = [];
  newClassification: CreateUpdateIncidentClassificationDto = { classificationName: '' };
  editedClassification: IncidentClassificationDto | null = null;
  modalMessage = '';
  isModalVisible = false;
  constructor(private classificationService: IncidentClassificationService,private fieldCheckService: FieldCheckService,private authService: AuthService) {}

  ngOnInit(): void {
    this.isAuthenticated = this.authService.isAuthenticated;
    this.getClassifications();
  }

  getClassifications(): void {
    this.classificationService.getList({ skipCount: 0, maxResultCount: 1000 }).subscribe({
      next: (result) => {
        this.classifications = result.items;
      },
      error: (error) => {
        console.error('Ошибка при загрузке классификаций:', error);
        alert(`Ошибка при загрузке классификаций: ${error.message}`);
      },
    });
  }

  addClassification(): void {
    if (!this.fieldCheckService.areFieldsFilled(this.newClassification)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else {

      this.classificationService.create(this.newClassification).subscribe({
        next: (createdClassification) => {
          this.classifications.push(createdClassification);
          this.newClassification = { classificationName: '' };
        },
        error: (err) => {
          console.error('Ошибка при добавлении классификации:', err);
          alert(`Ошибка при добавлении классификации: ${err.message}`);
        },
      });
    }
  }

  startEditing(classification: IncidentClassificationDto): void {
    this.editedClassification = { ...classification };
  }

  saveClassification(): void {
    if (!this.fieldCheckService.areFieldsFilled(this.editedClassification)) {
      this.modalMessage = 'Пожалуйста, заполните все поля.';
      this.isModalVisible = true;
      return;
    }
    else {

      const updateDto: CreateUpdateIncidentClassificationDto = {
        classificationName: this.editedClassification.classificationName,
      };

      this.classificationService.update(this.editedClassification.id, updateDto).subscribe({
        next: () => {
          const index = this.classifications.findIndex((c) => c.id === this.editedClassification!.id);
          if (index !== -1) {
            this.classifications[index] = this.editedClassification!;
          }
          this.editedClassification = null;
        },
        error: (err) => {
          console.error('Ошибка при редактировании классификации:', err);
          alert(`Ошибка при редактировании классификации: ${err.message}`);
        },
      });
    }
  }

  cancelEditing(): void {
    this.editedClassification = null;
  }

  deleteClassification(classificationId: string): void {
    this.classificationService.delete(classificationId).subscribe({
      next: () => {
        this.classifications = this.classifications.filter((classification) => classification.id !== classificationId);
      },
      error: (err) => {
        console.error('Ошибка при удалении классификации:', err);
        alert(`Ошибка при удалении классификации: ${err.message}`);
      },
    });
  }
}
