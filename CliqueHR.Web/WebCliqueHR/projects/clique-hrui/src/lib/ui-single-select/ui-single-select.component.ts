import { Component, OnInit, Output, Input, ContentChild, TemplateRef, EventEmitter, ViewChild, ViewContainerRef } from '@angular/core';
import { UiBaseComponent } from '../Common/ui-base-component';
import { FormControl } from '@angular/forms';
import { UiSingleselect } from '../ui-models';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'lib-ui-single-select',
  templateUrl: './ui-single-select.component.html',
  styleUrls: ['./ui-single-select.component.css']
})
export class UiSingleSelectComponent extends UiBaseComponent implements OnInit {

  @Input('DisplayText')
  private displayText: string;
  @Input('SearchInput')
  public formControl: FormControl = new FormControl('');
  @Input('Configuration')
  public config: UiSingleselect;
  @Input('Options')
  public set options(value) {
    this.ConstructOptions(value);
  }
  public multiDdOpen: boolean = false;
  @ViewChild('optioncnt', { static: true, read: ViewContainerRef })
  private optionContainer: ViewContainerRef;

  @ContentChild(TemplateRef, { read: TemplateRef, static: true })
  optionsContent: TemplateRef<any>;
  constructor() {
    super();
  }

  ngOnInit() {
  }
  public toggleDdl(event) {
    event.stopPropagation();
    if (this.isEditable) {
      this.multiDdOpen = !this.multiDdOpen;
    }
  }
  private ConstructOptions(options: Array<any>) {
    if (!isNullOrUndefined(options)) {
      let i = 0;
      for (let opt of options) {
        this.optionContainer.createEmbeddedView(this.optionsContent,
          { $implicit: { index: i, data: opt } });
      }
    }
  }
  public get DisplayText() {
    if (!isNullOrUndefined(this.displayText)) {
      return this.displayText;
    }
    if (this.isConfigAvailable && !isNullOrUndefined(this.config.Placeholder)) {
      return this.config.Placeholder || '';
    }
  }
  public get isDisplay(): boolean {
    return true;
  }

}
