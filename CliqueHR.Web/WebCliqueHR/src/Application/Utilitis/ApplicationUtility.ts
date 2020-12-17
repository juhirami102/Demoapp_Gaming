import { HttpErrorResponse } from '@angular/common/http';
import { WebAppModels } from '../Models/models.api';

export class ValidationBuilder {
    public static build(error: HttpErrorResponse): WebAppModels.ValidationResponse {
        if (error.status == 400) {
            return error.error as WebAppModels.ValidationResponse
        }
        return null;
    }
}