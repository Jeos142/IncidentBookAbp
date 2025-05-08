import type { EntityDto } from '@abp/ng.core';

export interface CreateUpdateResolutionDto {
  resolutionName: string;
}

export interface ResolutionDto extends EntityDto<string> {
  resolutionName?: string;
}
