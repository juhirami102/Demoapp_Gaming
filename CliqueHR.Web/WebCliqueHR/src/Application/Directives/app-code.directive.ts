import { Directive, Input, TemplateRef } from '@angular/core';

@Directive({
  selector: '[AppCode]'
})
export class AppCodeDirective {
  @Input('AppCode')
  public AppCode:string;
  constructor(public templateRef:TemplateRef<any>) { }

}
