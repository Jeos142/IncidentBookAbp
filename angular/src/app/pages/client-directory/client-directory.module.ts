import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ClientDirectoryComponent } from './client-directory.component';

@NgModule({
  imports: [
    ClientDirectoryComponent,
    RouterModule.forChild([
      {
        path: '',
        component: ClientDirectoryComponent,
      },
    ]),
  ],
})
export class ClientDirectoryModule {}
