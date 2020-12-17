import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelLandingComponent } from './panel-landing/panel-landing.component';
import { AdminPanelRouteModule } from './admin-panel-route/admin-panel-route.module';
import { CommonImportsModule } from 'src/Application/Modules/common-imports/common-imports.module';
import { LeftPanelComponent } from './panel-landing/Pages/left-panel/left-panel.component';
import { CompanyComponent } from './panel-landing/Pages/company/company.component';
import { ApplicationTabComponent } from 'src/Application/Components/application-tab/application-tab.component';
import { GroupCompanyComponent } from './panel-landing/Pages/company/Pages/group-company/group-company.component';
import { ApplicationBreadCrumbComponent } from 'src/Application/Components/application-bread-crumb/application-bread-crumb.component';
import { EntityComponent } from './panel-landing/Pages/company/Pages/entity/entity.component';
import { MasterComponent } from './panel-landing/Pages/master/master.component';
import { QualificationComponent } from './panel-landing/Pages/Pages/qualification/qualification.component';
import { EmployeeTypeComponent } from './panel-landing/Pages/Pages/employee-type/employee-type.component';
import { MasterService } from './panel-landing/Pages/master/master.service';



@NgModule({
  declarations: [
    PanelLandingComponent, 
    LeftPanelComponent, 
    CompanyComponent, 
    GroupCompanyComponent,
    ApplicationTabComponent,
    ApplicationBreadCrumbComponent,
    EntityComponent,
    MasterComponent,
    QualificationComponent,
    EmployeeTypeComponent],
  imports: [
    AdminPanelRouteModule,
    CommonImportsModule.forChildWithInterceptor()
  ],
  entryComponents:[
    CompanyComponent,
    GroupCompanyComponent,
    EntityComponent,
    MasterComponent,
    QualificationComponent,
    EmployeeTypeComponent
  ],
  providers:[
    MasterService
  ]
})
export class AdminPanelModule { }
