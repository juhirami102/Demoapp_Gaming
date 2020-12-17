import { Type } from '@angular/core';

export namespace WebAppModels{
    export interface IHeader {
        Name: string,
        Component: Type<unknown>,
        Selected:boolean
    }
    export class TabData {
        public Hearder: IHeader[];
    }
    export class BreadCrumb{
        public CurrentNavigation: string;
        public PreviousNavigation:{RouteLink:string, Name:string}[];
    }
    export class ValidationResponse {
        public Index: Array<number>;
        public Messages: Array<ValidationMessage>;
    }
    export class ValidationMessage {
        public Property: string;
        public Message: string;
    }
}