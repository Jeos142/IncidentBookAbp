import type { CreateUpdateIncidentDto, IncidentDto, IncidentWithNavigationPropertiesDto } from './dto/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class IncidentService {
  apiName = 'Default';
  

  create = (input: CreateUpdateIncidentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncidentDto>({
      method: 'POST',
      url: '/api/app/incident',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/incident/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncidentDto>({
      method: 'GET',
      url: `/api/app/incident/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<IncidentDto>>({
      method: 'GET',
      url: '/api/app/incident',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  getListWithNavigation = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<IncidentWithNavigationPropertiesDto>>({
      method: 'GET',
      url: '/api/app/incident/with-navigation',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateIncidentDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, IncidentDto>({
      method: 'PUT',
      url: `/api/app/incident/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
