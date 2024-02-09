import { Directive } from '@angular/core';
import { AbstractControl, ValidationErrors, Validator } from '@angular/forms';

@Directive({
  selector: '[asp-password-validator]'
})
export class AspPasswordValidatorDirective implements Validator {

  constructor() { }
  validate(control: AbstractControl<any, any>): ValidationErrors | null {
    
    const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$/;
    const value = control.value;

    if (!value) {
      return null;
    }
    const isValid = regex.test(value);
    
    return !isValid ? { password: true } : null;
  }

}
