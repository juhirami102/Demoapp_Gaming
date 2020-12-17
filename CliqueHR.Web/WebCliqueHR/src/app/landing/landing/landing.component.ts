import { Component, OnInit, Inject, ChangeDetectorRef } from '@angular/core';
import { WebComponents } from 'src/Application/Components/componenets.api';
import { WebInterface, WebTokens } from 'src/Application/Types/types.api';
import { Components } from 'src/Application/Types/Constants';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html'
})
export class LandingComponent extends WebComponents.ApplicationComponent implements OnInit {

  constructor(
    @Inject(WebTokens.APPLICATION_SERVICE)
    protected applicationService: WebInterface.IApplicationService,
    protected changeDetection: ChangeDetectorRef
  ) {
    super(Components.LandingComponent, applicationService, changeDetection);
  }

  public ngOnInit() {
  }
  
  public TriggerCommand(request: WebInterface.CommandRequest) {
  }
}
