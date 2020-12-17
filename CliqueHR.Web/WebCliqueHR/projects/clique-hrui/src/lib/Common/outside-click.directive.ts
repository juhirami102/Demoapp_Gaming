import { Directive, ElementRef, HostListener, Input, Renderer2, Output, EventEmitter } from '@angular/core';

@Directive({
  selector: '[appOutsideClick]'
})
export class OutsideClickDirective {

  @Output('appOutsideClick')
  public outsideClickEvent:EventEmitter<any> = new EventEmitter<any>();

  constructor(
    private current_elm: ElementRef,
    private rederer: Renderer2) { }

  @HostListener('document:click', ['$event'])
  @HostListener('document:touchstart', ['$event'])
  public handleOutsideClick(event) {
    // Some kind of logic to exclude clicks in Component.
    let closableSection = this.current_elm.nativeElement.querySelector("#closable-sec");
    if ((closableSection != null && closableSection.contains(event.target)) || !this.current_elm.nativeElement.contains(event.target)) {
      this.outsideClickEvent.emit(event);
    }
    event.stopPropagation();
  }

}
