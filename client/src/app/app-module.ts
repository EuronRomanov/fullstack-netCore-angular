import { NgModule, provideBrowserGlobalErrorListeners } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Home } from './home/home';
import { LayoutModule } from './layout/layout-module';
import { BASE_API } from './core/token/baseUrl.token';
import { environment } from '../environments/environment';
import {  provideHttpClient, withInterceptors } from '@angular/common/http';
import { apiInterceptor } from './core/interceptor/api-interceptor';





@NgModule({
  declarations: [App, Home],
  imports: [
    BrowserModule, 
    AppRoutingModule, 
    LayoutModule,
  
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
