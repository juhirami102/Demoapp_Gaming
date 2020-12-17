import { Directive, HostListener, Input, ElementRef } from '@angular/core';

@Directive({
  selector: '[appNumeric]'
})
export class NumericDirective {

  @Input()
  appNumeric: boolean = false;
  constructor(private _el: ElementRef) { }
  @HostListener('paste', ['$event']) blockPaste(e: KeyboardEvent) {
    if (this.appNumeric) {
      e.preventDefault();
    }
  }
  @HostListener('input', ['$event']) onKeyDown(event) {
    if (this.appNumeric) {
      const initalValue = this._el.nativeElement.value;
      this._el.nativeElement.value = initalValue.replace(/[^0-9]*/g, '');
      if (initalValue !== this._el.nativeElement.value) {
        event.stopPropagation();
      }
    }
  }
}
