import { ValidationType } from 'src/Application/Types/Constants';

export class ValidationMessage {
    public static data = {
        CourseTypeForm: {
            TypeName: {
                [ValidationType.required]: "Type Name Required."
            }
        }
    }
}