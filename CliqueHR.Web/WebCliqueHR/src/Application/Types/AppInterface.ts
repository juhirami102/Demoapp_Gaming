import { Subject } from "rxjs";

export namespace WebInterface {
    export interface IApplicationService {
        RegisterComponent(ComponentName: string): void;
        UnRegisterComponent(ComponentName: string): void;
        SendCommand(ComponentName: string, Type: string, Data: any): boolean;
        GetComponentSubscriber(ComponentName: string): Subject<CommandRequest>;
        ServiceFactory(serviceName:string): any;
    }
    export interface CommandRequest {
        ComponentName: string;
        Type: string;
        Data: any;
    }
    export interface PaginationModel {
        StartRow: number;
        EndRow: number;
        Sort?: { PropertyName: string, Direction: string };
        SearchText?: string;
    }
}