import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

const oAuthConfig = {
  issuer: 'https://localhost:44359/',
  redirectUri: baseUrl,
  clientId: 'IncidentBookAbp_App',
  responseType: 'code',
  scope: 'offline_access IncidentBookAbp',
  requireHttps: true,
};

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'IncidentBookAbp',
  },
  oAuthConfig,
  apis: {
    default: {
      url: 'https://localhost:44359',
      rootNamespace: 'IncidentBookAbp',
    },
    AbpAccountPublic: {
      url: oAuthConfig.issuer,
      rootNamespace: 'AbpAccountPublic',
    },
  },
  remoteEnv: {
    url: '/getEnvConfig',
    mergeStrategy: 'deepmerge'
  }
} as Environment;
