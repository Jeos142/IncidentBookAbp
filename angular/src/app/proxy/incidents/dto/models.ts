import type { EntityDto } from '@abp/ng.core';
import type { ClientDto } from '../../clients/dto/models';
import type { IncidentClassificationDto } from '../../incident-classifications/dto/models';
import type { ResolutionDto } from '../../resolutions/dto/models';

export interface CreateUpdateIncidentDto {
  description: string;
  dateTime?: string;
  isComplete: boolean;
  clientId: string;
  classificationId: string;
  resolutionId?: string;
}

export interface IncidentDto extends EntityDto<string> {
  description?: string;
  dateTime?: string;
  isComplete: boolean;
  clientId?: string;
  classificationId?: string;
  resolutionId?: string;
}

export interface IncidentWithNavigationPropertiesDto {
  incident: IncidentDto;
  client: ClientDto;
  classification: IncidentClassificationDto;
  resolution: ResolutionDto;
}
