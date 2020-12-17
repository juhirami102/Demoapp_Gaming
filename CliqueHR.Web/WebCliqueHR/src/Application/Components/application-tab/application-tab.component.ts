import { Component, OnInit, Input, ComponentFactoryResolver, ViewChild, TemplateRef, ViewContainerRef, Output, EventEmitter } from '@angular/core';
import { WebAppModels } from 'src/Application/Models/models.api';
import { isNullOrUndefined } from 'util';
@Component({
  selector: 'app-application-tab',
  templateUrl: './application-tab.component.html',
  styleUrls: ['./application-tab.component.css']
})
export class ApplicationTabComponent implements OnInit {
  @Input('TabData')
  tabData: WebAppModels.TabData;
  @ViewChild('tabheader', { static: true, read: ViewContainerRef })
  private tabHeader: ViewContainerRef
  @ViewChild('tabcontent', { static: true, read: ViewContainerRef })
  private tabContent: ViewContainerRef
  @ViewChild('tabitem', { static: true, read: TemplateRef })
  private tabItem: TemplateRef<any>;
  @Output('OnTabChange')
  public tabChange: EventEmitter<WebAppModels.IHeader> = new EventEmitter<WebAppModels.IHeader>();

  constructor(
    private componentResolver: ComponentFactoryResolver
  ) { }

  ngOnInit() {
    if (!isNullOrUndefined(this.tabData)) {
      this.GenerateTab();
    }
  }

  private GenerateTab() {
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

  private LoadTabHeader(data: any) {
    this.tabHeader.createEmbeddedView(this.tabItem, { $implicit: data });
  }
  private LoadContent(data: any) {
    let component = this.componentResolver.resolveComponentFactory(data.Component);
    this.tabContent.clear();
    this.tabContent.createComponent(component);
  }
  private ResetTabs() {
    let i = 0;
    for (let tab of this.tabData.Hearder) {
      this.tabData.Hearder[i].Selected = false;
      i++;
    }
  }
  public OnSelectTab(index: number) {
    if (!this.tabData.Hearder[index].Selected) {
      this.ResetTabs();
      this.LoadContent(this.tabData.Hearder[index]);
      this.tabData.Hearder[index].Selected = true;
      this.tabChange.emit(this.tabData.Hearder[index]);
    }
  }

}
