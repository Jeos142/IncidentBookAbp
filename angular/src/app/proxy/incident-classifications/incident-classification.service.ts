import type { CreateUpdateIncidentClassificationDto, IncidentClassificationDto } from './dto/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class IncidentClassificationService {
  apiName = 'Default';
  

  create = (input: CreateUpdateIncidentClassificationDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncidentClassificationDto>({
      method: 'POST',
      url: '/api/app/incident-classification',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/incident-classification/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncidentClassificationDto>({
      method: 'GET',
      url: `/api/app/incident-classification/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<IncidentClassificationDto>>({
      method: 'GET',
      url: '/api/app/incident-classification',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateIncidentClassificationDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncidentClassificationDto>({
      method: 'PUT',
      url: `/api/app/incident-classification/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
