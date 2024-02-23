import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { PreloadAllModules, provideRouter, withDebugTracing, withPreloading } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideHttpClient } from "@angular/common/http";
import { provideAnimations } from "@angular/platform-browser/animations";
import { provideToastr } from "ngx-toastr";

export const appConfig: ApplicationConfig = {
  providers: [
    // provider to inject routes, preload all modules and trace route change events
    provideRouter(routes, withPreloading(PreloadAllModules), withDebugTracing()),
    provideClientHydration(),
    provideHttpClient(),
    provideAnimations(),
    provideToastr({
      timeOut: 4000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressAnimation: "increasing",
      progressBar: true
    })
  ]
};
