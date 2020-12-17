import { FormControl } from '@angular/forms';
import { isNullOrUndefined } from 'util';
import { UiConfig } from '../ui-models';
import { Utility } from './Utility';

export abstract class UiBaseComponent {
    public formControl: FormControl;
    public validationMessages: { [key: string]: string };
    public config: UiConfig;

    abstract get isDisplay(): boolean;
    public get validationMessage() {
        return this.isDisplay && this.isConfigAvailable && (this.formControl.touched || this.formControl.dirty) ? Utility.ValidateControl(this.formControl, this.validationMessages) : "";
    }
    public get isEditable() {
        return this.isDisplay && !isNullOrUndefined(this.config.isEditable)
            ? this.config.isEditable : true;
    }
    public get isValid(): boolean {
        return this.formControl.valid;
    }
    public get isConfigAvailable() {
        return !isNullOrUndefined(this.config);
    }
}