import { CoreModule, provideAbpCore, withOptions } from '@abp/ng.core';
import { AbpOAuthModule, provideAbpOAuth } from '@abp/ng.oauth';
import { provideSettingManagementConfig } from '@abp/ng.setting-management/config';
import { provideFeatureManagementConfig } from '@abp/ng.feature-management';
import { ThemeSharedModule, provideAbpThemeShared,} from '@abp/ng.theme.shared';
import { provideIdentityConfig } from '@abp/ng.identity/config';
import { provideAccountConfig } from '@abp/ng.account/config';
import { provideTenantManagementConfig } from '@abp/ng.tenant-management/config';
import { registerLocale } from '@abp/ng.core/locale';
import { ThemeLeptonXModule } from '@abp/ng.theme.lepton-x';
import { SideMenuLayoutModule } from '@abp/ng.theme.lepton-x/layouts';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { environment } from '../environments/environment';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { APP_ROUTE_PROVIDER } from './route.provider';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ApiInterceptor } from '@abp/ng.core';
import {LoaderComponent} from './shared/loader/loader.component';

import {LoaderInterceptor} from './shared/loader/loader.interceptor';



import { ResolutionDirectoryModule } from './pages/resolution-directory/resolution-directory.module';
import { IncidentDirectoryModule } from './pages/incident-directory/incident-directory.module';
import { ClassificationDirectoryModule } from './pages/classification-directory/classification-directory.module';
import { ClientDirectoryModule } from './pages/client-directory/client-directory.module';

import { AccountConfigModule } from '@abp/ng.account/config';
import { registerLocaleData } from '@angular/common';
import localeRu from '@angular/common/locales/ru';

import { AuthService } from '@abp/ng.core'; // именно core, он содержит getAuthState

@NgModule({
  declarations: [
    AppComponent,
    LoaderComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    ThemeLeptonXModule.forRoot(),
    BrowserAnimationsModule,

    ThemeSharedModule,


    SideMenuLayoutModule.forRoot(),
    ClientDirectoryModule,
    ClassificationDirectoryModule,
    IncidentDirectoryModule,
    ResolutionDirectoryModule,


  ],
  providers: [

    { provide: HTTP_INTERCEPTORS, useClass: LoaderInterceptor, multi: true },
    APP_ROUTE_PROVIDER,
    provideAbpCore(
      withOptions({
        environment,
        registerLocaleFn: registerLocale(),
      }),
    ),
    provideAbpOAuth(),

    provideIdentityConfig(),
    provideSettingManagementConfig(),
    provideFeatureManagementConfig(),
    provideAccountConfig(),
    provideTenantManagementConfig(),
    provideAbpThemeShared(),

  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
