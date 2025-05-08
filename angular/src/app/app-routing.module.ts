import { authGuard, permissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'clients',
    loadChildren: () =>
      import('./pages/client-directory/client-directory.module').then(
        (m) => m.ClientDirectoryModule
      ),
  },
  {
    path: 'incidents',
    loadChildren: () =>
      import('./pages/incident-directory/incident-directory.module').then(
        (m) => m.IncidentDirectoryModule
      ),
  },
  {
    path: 'classifications',
    loadChildren: () =>
      import('./pages/classification-directory/classification-directory.module').then(
        (m) => m.ClassificationDirectoryModule
      ),
  },
  {
    path: 'resolutions',
    loadChildren: () =>
      import('./pages/resolution-directory/resolution-directory.module').then(
        (m) => m.ResolutionDirectoryModule
      ),
  },
  {
    path: '',
    redirectTo: '/clients',
    pathMatch: 'full',
  },
  {
    path: 'account',
    loadChildren: () =>
      import('@abp/ng.account').then((m) => m.AccountModule),
  }

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

