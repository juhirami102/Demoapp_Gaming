import { Component, OnInit, Inject, ChangeDetectorRef } from '@angular/core';
import { WebComponents } from 'src/Application/Components/componenets.api';
import { WebInterface, WebTokens } from 'src/Application/Types/types.api';
import { Components, RequestTypes } from 'src/Application/Types/Constants';
import { isNullOrUndefined } from 'util';
declare var $: any;
@Component({
  selector: 'app-change-theam',
  templateUrl: './change-theam.component.html',
  styleUrls: ['./change-theam.component.css']
})
export class ChangeTheamComponent extends WebComponents.ApplicationComponent implements OnInit {

  public colorList = ['000000', '1AAF42', '007B87', '001D4B', '57C158', 'F4C507', 'E2585A', 'E85FA3', '298FF4', '20c997', '17a2b8', '118cf5'];
  public selectedColor = new Array<boolean>();

  constructor(
    @Inject(WebTokens.APPLICATION_SERVICE)
    protected applicationService: WebInterface.IApplicationService,
    protected changeDetection: ChangeDetectorRef
  ) {
    super(Components.ChangeTheamComponent, applicationService, changeDetection);
  }

  protected TriggerCommand(request: WebInterface.CommandRequest) {
    if (request.Type == RequestTypes.ChangeTheme) {
      if (request.Data == 'show') {
        this.OpenModelPopup('#changeTheme');
      }
      else if (request.Data == 'hide') {
        this.CloseModelPopup('#changeTheme');
      }
    }
  }

  public ngOnInit() {
  }
  public GetColorStyle(color: string) {
    return '#' + color;
  }

  public OnColorSelect(color, i:number) {
    var codeHex = '#' + color;
    $('.color-holder').css('background-color', codeHex);
    if ($('head #primaryFill').length > 0) {
      $('head #primaryFill').remove();
    }
    $("<style id='primaryFill'>:root .body{ --theme-icon-color:" + codeHex + "!important;}  </style>").appendTo("head"); // .navbar{ background: "+ codeHex + "!important; }
    // $(this).addClass("selected-color");
    document.querySelectorAll('object').forEach(function (e) {
      e.contentDocument && e.contentDocument.querySelectorAll("[class='icon-fill']").forEach(function (f:any) { f.style.fill = codeHex });
    });
    let index = 0;
    for(let status of this.selectedColor){
      if(!isNullOrUndefined(status)){
        this.selectedColor[index] = false;
      }
      index++;
    }
    this.selectedColor[i] = true;
  }
}