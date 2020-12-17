
import { FormGroup, AbstractControl } from '@angular/forms';

export class CustomValidator {

    public static MatchControlValue(source: string, destination: string) {
        return (formGroup: FormGroup) => {
            const sourceControl = formGroup.controls[source];
            const destinationControl = formGroup.controls[destination];

            if (!sourceControl || !destinationControl) {
                return null;
            }

            if (destinationControl.errors && !destinationControl.errors.valueMismatch) {
                return null;
            }
            if (sourceControl.value !== destinationControl.value) {
                destinationControl.setErrors({ valueMismatch: true });
            } else {
                destinationControl.setErrors(null);
            }

        }
    }
    public static DropdownValidation(control: AbstractControl) {
        if (control.value == '' || control.value == '0' || control.value == 'select') {
            return { required: true };
        }
        return null;
    }
}