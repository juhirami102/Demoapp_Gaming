import { FormControl } from '@angular/forms';
import { isNullOrUndefined } from 'util';

export class Utility {
    static ValidateControl(formControl: FormControl, mesageList: { [key: string]: string }): string {
        let message: string = '';
        if (formControl.invalid && !isNullOrUndefined(mesageList)) {
            let errorTypes = Object.keys(formControl.errors);
            for (let type of errorTypes) {
                message = mesageList[type];
                if (!isNullOrUndefined(message) && message != '') {
                    break;
                }
            }
        }
        return message;
    }
}