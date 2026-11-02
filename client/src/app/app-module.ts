import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Home } from './home/home';
import { LayoutModule } from './layout/layout-module';
import { BASE_API } from './core/token/baseUrl.token';
import { environment } from '../environments/environment';
import {  HttpClientModule, provideHttpClient, withInterceptors } from '@angular/common/http';
import { apiInterceptor } from './core/interceptor/api-interceptor';
import { StoreModule } from '@ngrx/store';
import { store } from './redux/store';
import { EffectsModule } from '@ngrx/effects';
import { CatalogEffects } from './redux/catalog/catalog.effects';





@NgModule({
  declarations: [App, Home],
  imports: [
    BrowserModule, 
    AppRoutingModule, 
    LayoutModule,
    HttpClientModule,
  StoreModule.forRoot(store),
  EffectsModule.forRoot([CatalogEffects])
  ],
  providers: [provideBrowserGlobalErrorListeners(),
    {
      provide:BASE_API,
      useValue:environment.baseApi
    },
    provideHttpClient(
      withInterceptors([
        apiInterceptor
      ])
    )
  ],
  bootstrap: [App],
})
export class AppModule {}
