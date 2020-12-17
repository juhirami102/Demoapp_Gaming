import { Component, OnInit, Input, ContentChild, TemplateRef } from '@angular/core';
import { UiBaseComponent } from '../Common/ui-base-component';
import { isNullOrUndefined } from 'util';
import { FormControl } from '@angular/forms';
import { UiTextArea } from '../ui-models';

@Component({
  selector: 'lib-text-area',
  templateUrl: './text-area.component.html',
  styleUrls: ['./text-area.component.css']
})
export class TextAreaComponent extends UiBaseComponent implements OnInit {

  @Input('FormInput')
  public formControl: FormControl;
  @Input('Configuration')
  public config: UiTextArea;
  @Input('ValidationMessages')
  public validationMessages: { [key: string]: string };

  @ContentChild(TemplateRef, { read: TemplateRef, static: true })
  validationContent: TemplateRef<any>;

  constructor() {
    super();
  }

  ngOnInit() {
  }
  public get isDisplay(): boolean {
    return isNullOrUndefined(this.config) || isNullOrUndefined(this.formControl) ?
      false : true;
  }
  public get PlaceHolder(): string {
    return this.isDisplay && isNullOrUndefined(this.config.PlaceHolder) ?
      '' : this.config.PlaceHolder;
  }
  public get Rows(): number {
    return this.isDisplay && isNullOrUndefined(this.config.Rows) ?
      4 : this.config.Rows;
  }

}
