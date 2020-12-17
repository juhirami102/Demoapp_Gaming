import { Directive, Input, HostListener, ElementRef } from '@angular/core';

@Directive({
  selector: '[appDecimal]'
})
export class DecimalDirective {
  @Input()
  appDecimal: boolean = false;
  constructor(private _el: ElementRef) { }
  @HostListener('paste', ['$event']) blockPaste(e: KeyboardEvent) {
    if (this.appDecimal) {
      e.preventDefault();
    }
  }
  @HostListener('input', ['$event']) onKeyDown(event) {
    if (this.appDecimal) {
      const initalValue = this._el.nativeElement.value;
      if (
        initalValue.trim() == '.' ||
        (!this.endsWithDot() && !this.isValidDecimalNumber())
      ) {
        var newCharacter = "";
        var operationStr = this._el.nativeElement.value;
        this._el.nativeElement.value = operationStr.substring(0, operationStr.lastIndexOf(event.data)) + newCharacter + operationStr.substring(operationStr.lastIndexOf(event.data) + 1);
      }
      if (initalValue !== this._el.nativeElement.value) {
        event.stopPropagation();
      }
    }
  }

  private isValidDecimalNumber() {
    try {
      return /^[-+]?\d+(\.\d+)?$/.test(this._el.nativeElement.value);
    }
    catch (e) {
      return false;
    }
  }
  private endsWithDot() {
    try {
      return /^[-+]?\d+(\.)$/.test(this._el.nativeElement.value);
    }
    catch (e) {
      return false;
    }
  }

}
