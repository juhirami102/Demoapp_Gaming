import { Subject } from 'rxjs';
import { isNullOrUndefined } from 'util';
import * as CliqueHRInterface from './AppInterface';
import { Renderer2 } from '@angular/core';

export const rendererService = 'renderer';

export namespace WebAppService {
    export abstract class AbstractApplicationService implements CliqueHRInterface.WebInterface.IApplicationService {
        private m_componentSubjectMap: { [key: string]: Subject<CliqueHRInterface.WebInterface.CommandRequest> } = {};
        private m_services: { [key: string]: any } = {};
        

        constructor(protected renderer: Renderer2) {
            this.m_services[rendererService] = renderer;
        }
        public ServiceFactory(serviceName: string): void {
            return this.m_services[serviceName];
        }
        public RegisterComponent(ComponentName: string): void {
            this.m_componentSubjectMap[ComponentName] = new Subject<CliqueHRInterface.WebInterface.CommandRequest>();
        }
        public UnRegisterComponent(ComponentName: string): void {
            if (!isNullOrUndefined(this.m_componentSubjectMap[ComponentName])) {
                this.m_componentSubjectMap[ComponentName].unsubscribe();
            }
        }
        public GetComponentSubscriber(ComponentName: string): Subject<CliqueHRInterface.WebInterface.CommandRequest> {
            if (!isNullOrUndefined(this.m_componentSubjectMap[ComponentName])) {
                return this.m_componentSubjectMap[ComponentName];
            }
            return null;
        }
        public SendCommand(ComponentName: string, Type: string, Data: any): boolean {
            if (!isNullOrUndefined(this.m_componentSubjectMap[ComponentName])) {
                let request: CliqueHRInterface.WebInterface.CommandRequest = {
                    ComponentName: ComponentName,
                    Type: Type,
                    Data: Data
                };
                this.m_componentSubjectMap[ComponentName].next(request);
                return true;
            }
            else {
                return false;
            }
        }
    }
}