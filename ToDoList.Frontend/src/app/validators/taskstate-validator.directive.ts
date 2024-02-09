import { Directive } from '@angular/core';
import { AbstractControl, NG_VALIDATORS, ValidationErrors, Validator } from '@angular/forms';

@Directive({
  selector: '[taskstate-validator]',
  providers: [{
    provide: NG_VALIDATORS,
    useExisting:TaskstateValidatorDirective,
    multi: true
}]
})
export class TaskstateValidatorDirective implements Validator {

  constructor() { }
  validate(control: AbstractControl<any, any>): ValidationErrors | null {
    const value = control.value;

    if (!value) {
      return null;
    }

    const isValid = value >= 0;

    return !isValid ? { taskstate: true } : null;
  }
  
}
