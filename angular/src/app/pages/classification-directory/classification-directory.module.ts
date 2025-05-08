import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ClassificationDirectoryComponent } from './classification-directory.component';

@NgModule({
  imports: [
    ClassificationDirectoryComponent,
    RouterModule.forChild([
      {
        path: '',
        component: ClassificationDirectoryComponent,
      },
    ]),
  ],
})
export class ClassificationDirectoryModule {}
