import type { CreateUpdateResolutionDto, ResolutionDto } from './dto/models';
import { RestService, Rest } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ResolutionService {
  apiName = 'Default';
  

  create = (input: CreateUpdateResolutionDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResolutionDto>({
      method: 'POST',
      url: '/api/app/resolution',
      body: input,
    },
    { apiName: this.apiName,...config });
  

  delete = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/resolution/${id}`,
    },
    { apiName: this.apiName,...config });
  

  get = (id: string, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResolutionDto>({
      method: 'GET',
      url: `/api/app/resolution/${id}`,
    },
    { apiName: this.apiName,...config });
  

  getList = (input: PagedAndSortedResultRequestDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, PagedResultDto<ResolutionDto>>({
      method: 'GET',
      url: '/api/app/resolution',
      params: { sorting: input.sorting, skipCount: input.skipCount, maxResultCount: input.maxResultCount },
    },
    { apiName: this.apiName,...config });
  

  update = (id: string, input: CreateUpdateResolutionDto, config?: Partial<Rest.Config>) =>
    this.restService.request<any, ResolutionDto>({
      method: 'PUT',
      url: `/api/app/resolution/${id}`,
      body: input,
    },
    { apiName: this.apiName,...config });

  constructor(private restService: RestService) {}
}
