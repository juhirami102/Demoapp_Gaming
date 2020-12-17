import { Component, OnInit, Input, ContentChild, TemplateRef, ViewChild, Output, EventEmitter } from '@angular/core';
import { UiBaseComponent } from '../Common/ui-base-component';
import { isNullOrUndefined } from 'util';
import { FormControl } from '@angular/forms';
import { UiDropDown, UiDatepicker, DateFormat } from '../ui-models';
import { IDayCalendarConfig, ECalendarValue, DatePickerComponent, DatePickerDirective } from 'ng2-date-picker';

@Component({
  selector: 'lib-ui-datepicker',
  templateUrl: './ui-datepicker.component.html',
  styleUrls: ['./ui-datepicker.component.css']
})
export class UiDatepickerComponent extends UiBaseComponent implements OnInit {

  @ViewChild('dateDp', { static: true, read: DatePickerDirective })
  private datePicker: DatePickerDirective;
  @Output('OnDateSelect')
  public OnDateSelectEvent: EventEmitter<any> = new EventEmitter<any>()
  @Input('FormInput')
  public formControl: FormControl;
  @Input('Configuration')
  public set SetConfig(value: UiDatepicker) {
    this.SetupConfig(value);
    this.config = value;
  }
  public config: UiDatepicker;
  @Input('SetValidationMessages')
  public dpValidationMessages: string;
  @ContentChild(TemplateRef, { read: TemplateRef, static: true })
  validationContent: TemplateRef<any>;
  public options: any = {};

  constructor() {
    super();
  }

  ngOnInit() {
    this.DefaultConfig();
  }
  private SetupConfig(value: UiDatepicker) {
    if (!isNullOrUndefined(value)) {
      this.options.disabled = value.disabled;
      this.options.plcaeholder = value.plcaeholder;
      let maxObj = this.GetDateFromString(value.max);
      let minObj = this.GetDateFromString(value.min);
      if (maxObj != null) {
        this.options.max = this.GetDateInString(maxObj);
      }
      if (minObj != null) {
        this.options.min = this.GetDateInString(minObj);

      }
      if (minObj != null) {
        if (this.isDateValueAvailable) {
          this.formControl.setValue(this.GetDateInString(minObj));
        }
      }
      else if (maxObj != null) {
        if (this.isDateValueAvailable) {
          this.formControl.setValue(this.GetDateInString(maxObj));
        }
      }
    }
  }
  private isDateValueAvailable() {
    return isNullOrUndefined(this.formControl)
      || isNullOrUndefined(this.formControl.value)
      || (this.formControl.value as string).trim() == '' ? false : true;
  }
  private DefaultConfig() {
    this.options.format = 'DD-MM-YYYY';
    this.options.monthFormat = 'MMM, YYYY';
    this.options.showMultipleYearsNavigation = false;
    this.options.showGoToCurrent = false;
    this.options.disableKeypress = true;
    this.options.returnedValueType = ECalendarValue.String;
  }

  private GetDateFromString(date: string) {
    if (!isNullOrUndefined(date)) {
      let dateArr = date.split('-');
      if (dateArr.length == 3) {
        let dateObj = new Date();
        dateObj.setDate(parseInt(dateArr[0]));
        dateObj.setMonth(parseInt(dateArr[1]));
        dateObj.setFullYear(parseInt(dateArr[2]));
        return dateObj;
      }
    }
    return null;
  }
  private GetDateInString(date: Date) {
    if (!isNullOrUndefined(date)) {
      return (date.getDate() < 10 ? '0' + date.getDate() : date.getDate())
        + '-' + (date.getMonth() < 10 ? '0' + date.getMonth() : date.getMonth())
        + '-' + date.getFullYear();
    }
    return null;
  }

  public get isDisplay(): boolean {
    return true;
  }
  public OnDateSelect(event) {
    if (
      !isNullOrUndefined(this.config) && !isNullOrUndefined(this.config.ReturnDateFormat)
      && this.config.ReturnDateFormat === DateFormat.DATE_OBJECT
    ) {
      this.OnDateSelectEvent.emit(this.GetDateFromString(event));
    }
    else {
      this.OnDateSelectEvent.emit(event);
    }
  }
  public isDisabled() {
    return isNullOrUndefined(this.config.disabled) ? false : this.config.disabled;
  }
  public Placeholder() {
    return isNullOrUndefined(this.config.plcaeholder) ? '' : this.config.plcaeholder;
  }

}
