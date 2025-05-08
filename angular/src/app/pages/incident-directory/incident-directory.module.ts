import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IncidentDirectoryComponent } from './incident-directory.component';

@NgModule({
  imports: [
    IncidentDirectoryComponent,
    RouterModule.forChild([
      {
        path: '',
        component: IncidentDirectoryComponent,
      },
    ]),
  ],
})
export class IncidentDirectoryModule {}
