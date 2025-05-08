import type { EntityDto } from '@abp/ng.core';

export interface ClientDto extends EntityDto<string> {
  name?: string;
}

export interface CreateUpdateClientDto {
  name: string;
}
