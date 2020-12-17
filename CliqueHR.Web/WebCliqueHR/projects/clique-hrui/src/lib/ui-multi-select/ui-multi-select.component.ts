import { Component, OnInit, Input, ContentChild, TemplateRef, ChangeDetectionStrategy } from '@angular/core';
import { UiBaseComponent } from '../Common/ui-base-component';
import { FormControl } from '@angular/forms';
import { UiMultiselect } from '../ui-models';
import { isNullOrUndefined } from 'util';

@Component({
  selector: 'lib-ui-multi-select',
  templateUrl: './ui-multi-select.component.html',
  styleUrls: ['./ui-multi-select.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class UiMultiSelectComponent extends UiBaseComponent implements OnInit {

  @Input('SelectedItem')
  private set SelectedItems(value: string[]) {
    this.selectedItems = value;
    this.displayText = this.DisplayText;
  }
  private selectedItems: string[];
  @Input('SearchInput')
  public formControl: FormControl = new FormControl('');
  @Input('Configuration')
  public config: UiMultiselect;
  @ContentChild(TemplateRef, {static: true, read: false})
  public dropdownContaint: TemplateRef<any>;
  public multiDdOpen: boolean = false;
  public displayText: string;

  constructor() {
    super();
  }

  ngOnInit() {
    this.displayText = this.DisplayText;
  }

  private get DisplayText() {
    if (isNullOrUndefined(this.selectedItems) || this.selectedItems.length == 0) {
      return this.Placeholder;
    }
    else if (this.selectedItems.length > 3) {
      return "Selected Item(" + this.selectedItems.length + ")";
    }
    else {
      return this.selectedItems.join(',');
    }
  }
  public get isDisplay(): boolean {
    return true;
  }
  public get Placeholder() {
    return this.isConfigAvailable && !isNullOrUndefined(this.config.Placeholder) ?
      this.config.Placeholder : "";
  }
  public toggleDdl(event) {
    event.stopPropagation();
    if(this.isEditable){
      this.multiDdOpen = !this.multiDdOpen;
    }
  }
}
