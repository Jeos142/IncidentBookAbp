import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ResolutionDirectoryComponent } from './resolution-directory.component';

@NgModule({
  imports: [
    ResolutionDirectoryComponent,
    RouterModule.forChild([
      {
        path: '',
        component: ResolutionDirectoryComponent,
      },
    ]),
  ],
})
export class ResolutionDirectoryModule {}
