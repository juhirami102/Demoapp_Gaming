import { Component, OnInit, Inject, ChangeDetectorRef, ViewChild, ViewContainerRef, TemplateRef, ComponentFactoryResolver } from '@angular/core';
import { WebComponents } from 'src/Application/Components/componenets.api';
import { WebInterface, WebTokens } from 'src/Application/Types/types.api';
import { Components } from 'src/Application/Types/Constants';
import { WebAppModels } from 'src/Application/Models/models.api';
import { CompanyComponent } from './Pages/company/company.component';
import { isNullOrUndefined } from 'util';
import { MasterComponent } from './Pages/master/master.component';

const tabData = {
  Hearder: [
    {
      Name: 'Company',
      Component: CompanyComponent,
      Selected:true,
      Icon: 'icon icon-business mr-2'
    },
    {
      Name: 'Master',
      Component: MasterComponent,
      Selected:false,
      Icon: 'icon icon-manager mr-2'
    }
  ]
};

@Component({
  selector: 'app-panel-landing',
  templateUrl: './panel-landing.component.html',
  styleUrls: ['./panel-landing.component.css']
})
export class PanelLandingComponent extends WebComponents.ApplicationComponent implements OnInit {
  @ViewChild('tabheader', { static: true, read: ViewContainerRef })
  private tabHeader: ViewContainerRef
  @ViewChild('tabcontent', { static: true, read: ViewContainerRef })
  private tabContent: ViewContainerRef
  @ViewChild('tabitem', { static: true, read: TemplateRef })
  private tabItem: TemplateRef<any>;
  
  public tabData = tabData;
  public breadcrumbData: WebAppModels.BreadCrumb = new WebAppModels.BreadCrumb();

  constructor(
    @Inject(WebTokens.APPLICATION_SERVICE)
    protected applicationService: WebInterface.IApplicationService,
    protected changeDetection: ChangeDetectorRef,
    private componentResolver: ComponentFactoryResolver
  ) {
    super(Components.PanelLandingComponent, applicationService, changeDetection);
  }

  protected TriggerCommand(request: WebInterface.CommandRequest) {
  }

  ngOnInit() {
    this.breadcrumbData.CurrentNavigation = 'Admin Panel';
    this.breadcrumbData.PreviousNavigation = [{
      Name: 'Home',
      RouteLink: '/main'
    }];
    this.GenerateLeftTabs();
  }

  private GenerateLeftTabs(){
    let i = 0;
    for (let data of this.tabData.Hearder) {
      if (!isNullOrUndefined(data)) {
        let dataObj = data as any;
        dataObj.Index = i;
        this.LoadTabHeader(data);
        if (data.Selected) {
          this.LoadContent(data);
        }
      }
      i++;
    }
  }
  private ResetTabs() {
    let i = 0;
    for (let tab of this.tabData.Hearder) {
      this.tabData.Hearder[i].Selected = false;
      i++;
    }
  }
  private LoadTabHeader(data: any) {
    this.tabHeader.createEmbeddedView(this.tabItem, { $implicit: data });
  }
  private LoadContent(data: any) {
    let component = this.componentResolver.resolveComponentFactory(data.Component);
    this.tabContent.clear();
    this.tabContent.createComponent(component);
  }
  public OnLeftItemSelect(index: number) {
    if(!this.tabData.Hearder[index].Selected){
      this.ResetTabs();
      this.LoadContent(this.tabData.Hearder[index]);
      this.tabData.Hearder[index].Selected = true;
    }
  }
}
