import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LandingComponent } from './landing/landing.component';
import { HeaderComponent } from './Pages/Layout/header/header.component';
import { CommonImportsModule } from 'src/Application/Modules/common-imports/common-imports.module';
import { LandingRouteModule } from './landing-route/landing-route.module';
import {WebTokens} from 'src/Application/Types/types.api';
import { ApplicationService } from 'src/Application/Services/application.service';
import { ChangeTheamComponent } from './Pages/PopUp/change-theam/change-theam.component';


@NgModule({
  declarations: [LandingComponent, HeaderComponent, ChangeTheamComponent],
  imports: [
    LandingRouteModule,
    CommonImportsModule.forChildWithInterceptor()
  ],
  providers:[
    {
      provide: WebTokens.APPLICATION_SERVICE,
      useClass: ApplicationService
    }
  ]
})
export class LandingModule { }
