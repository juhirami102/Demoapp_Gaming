import { Component, OnInit, Input, ContentChild, TemplateRef } from '@angular/core';
import { UiBaseComponent } from '../Common/ui-base-component';
import { isNullOrUndefined } from 'util';
import { FormControl } from '@angular/forms';
import { UiDropDown } from '../ui-models';

@Component({
  selector: 'lib-drop-down',
  templateUrl: './drop-down.component.html',
  styleUrls: ['./drop-down.component.css']
})
export class DropDownComponent extends UiBaseComponent implements OnInit {

  @Input('FormInput')
  public formControl: FormControl;
  @Input('Configuration')
  public config: UiDropDown;
  @Input('ValidationMessages')
  public validationMessages: { [key: string]: string };

  @ContentChild('validation', { read: TemplateRef, static: true })
  validationContent: TemplateRef<any>;
  @ContentChild('options', { read: TemplateRef, static: true })
  optionsContent: TemplateRef<any>;

  constructor() {
    super();
  }

  ngOnInit() {
  }
  public get isDisplay(): boolean {
    return isNullOrUndefined(this.config) || isNullOrUndefined(this.formControl) ?
      false : true;
  }

}
