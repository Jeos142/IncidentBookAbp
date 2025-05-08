import type { EntityDto } from '@abp/ng.core';

export interface CreateUpdateIncidentClassificationDto {
  classificationName: string;
}

export interface IncidentClassificationDto extends EntityDto<string> {
  classificationName?: string;
}
