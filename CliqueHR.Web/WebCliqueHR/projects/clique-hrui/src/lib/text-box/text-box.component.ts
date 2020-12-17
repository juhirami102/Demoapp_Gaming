import { Component, OnInit, Input, ContentChild, TemplateRef } from '@angular/core';
import { UiBaseComponent } from '../Common/ui-base-component';
import { isNullOrUndefined } from 'util';
import { FormControl } from '@angular/forms';
import { UiTextbox } from '../ui-models';

@Component({
  selector: 'lib-text-box',
  templateUrl: './text-box.component.html',
  styleUrls: ['./text-box.component.css']
})
export class TextBoxComponent extends UiBaseComponent implements OnInit {

  @Input('FormInput')
  public formControl: FormControl;
  @Input('Configuration')
  public config: UiTextbox;
  @Input('ValidationMessages')
  public validationMessages: { [key: string]: string };

  @ContentChild(TemplateRef, { read: TemplateRef, static: true })
  validationContent: TemplateRef<any>;

  constructor() {
    super();
  }

  public get isDisplay(): boolean {
    return isNullOrUndefined(this.config) || isNullOrUndefined(this.formControl) ?
      false : true;
  }
  public get Type(): string {
    return this.isDisplay && isNullOrUndefined(this.config.Type) ?
      'text' : this.config.Type;
  }
  public get PlaceHolder(): string {
    return this.isDisplay && isNullOrUndefined(this.config.PlaceHolder) ?
      '' : this.config.PlaceHolder;
  }
  public get isNumeric() {
    return this.isDisplay && isNullOrUndefined(this.config.isNumeric) ? 
    false : this.config.isNumeric
  }
  public get isDecimal() {
    return this.isDisplay && isNullOrUndefined(this.config.isDecimal) ? 
    false : this.config.isDecimal
  }
  ngOnInit() {
  }

}
