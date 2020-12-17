import * as CliqueHRType from '../Types/types.api'
import { OnInit, OnDestroy, ChangeDetectorRef, Renderer2 } from '@angular/core';
import { Subscription } from 'rxjs';
import { FormGroup } from '@angular/forms';
import { WebAppModels } from '../Models/models.api';
declare var $: any;

export namespace WebComponents {
    export abstract class ApplicationComponent implements OnInit, OnDestroy {
        private m_componentName: string;
        private m_applicationService: CliqueHRType.WebInterface.IApplicationService;
        protected SubjectDestroy: Array<Subscription> = new Array<Subscription>();
        private m_changeDetector: ChangeDetectorRef;

        public validationMessage: Array<WebAppModels.ValidationMessage> = new Array<WebAppModels.ValidationMessage>();

        constructor(
            ComponentName: string,
            applicationService: CliqueHRType.WebInterface.IApplicationService,
            changeDetection: ChangeDetectorRef
        ) {
            this.m_applicationService = applicationService;
            this.m_changeDetector = changeDetection;
            this.m_componentName = ComponentName;
            this.m_applicationService.RegisterComponent(ComponentName);
            this.SubjectDestroy.push(
                this.m_applicationService.GetComponentSubscriber(ComponentName).subscribe(
                    request => {
                        this.TriggerCommand(request);
                    }
                )
            );
        }
        protected abstract TriggerCommand(request: CliqueHRType.WebInterface.CommandRequest);

        protected SendCommand(ComponentName: string, Type: string, Data: any): boolean {
            return this.m_applicationService.SendCommand(ComponentName, Type, Data);
        }
        protected OpenModelPopup(id: string) {
            $(id).modal('show');
        }
        protected CloseModelPopup(id: string) {
            $(id).modal('hide');
        }
        protected triggerValidation(formGrp: FormGroup) {
            formGrp.markAllAsTouched();
            formGrp.markAsDirty();
        }
        public ngOnInit(): void {

        }
        public ngOnDestroy(): void {
            this.m_applicationService.UnRegisterComponent(this.m_componentName);
            if (this.SubjectDestroy != null) {
                for (let sub of this.SubjectDestroy) {
                    sub.unsubscribe();
                }
            }
        }
    }
}