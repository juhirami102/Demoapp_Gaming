
import { InjectionToken } from "@angular/core";
import * as CliqueHR from "./AppInterface"
export namespace WebTokens {
    export const APPLICATION_SERVICE = new InjectionToken<CliqueHR.WebInterface.IApplicationService>('APP Service');
}