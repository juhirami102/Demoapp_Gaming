import { NgModule } from '@angular/core';
import { TextBoxComponent } from './text-box/text-box.component';
import { TextAreaComponent } from './text-area/text-area.component';
import { DropDownComponent } from './drop-down/drop-down.component';
import { UiButtonComponent } from './ui-button/ui-button.component';
import { DecimalDirective } from './text-box/decimal.directive';
import { NumericDirective } from 'src/Application/Directives/numeric.directive';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UiDatepickerComponent } from './ui-datepicker/ui-datepicker.component';
import { UiMultiSelectComponent } from './ui-multi-select/ui-multi-select.component';
import { DpDatePickerModule } from "ng2-date-picker";
import { OutsideClickDirective } from './Common/outside-click.directive';
import { UiDataTableComponent } from './ui-data-table/ui-data-table.component';
import { UiSingleSelectComponent } from './ui-single-select/ui-single-select.component';


@NgModule({
  declarations: [
    TextBoxComponent,
    TextAreaComponent,
    DropDownComponent,
    UiButtonComponent,
    NumericDirective,
    DecimalDirective,
    UiDatepickerComponent,
    UiMultiSelectComponent,
    OutsideClickDirective,
    UiDataTableComponent,
    UiSingleSelectComponent
  ],
  imports: [
    ReactiveFormsModule,
    FormsModule,
    CommonModule,
    DpDatePickerModule
  ],
  exports: [
    TextBoxComponent,
    TextAreaComponent,
    DropDownComponent,
    UiButtonComponent,
    UiDatepickerComponent,
    UiMultiSelectComponent,
    UiDataTableComponent,
    UiSingleSelectComponent
  ]
})
export class CliqueHRUiModule { }
