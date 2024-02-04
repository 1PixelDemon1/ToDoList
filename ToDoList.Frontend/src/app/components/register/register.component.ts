import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth/auth.service';
import { UserdataService } from '../../services/userdata/userdata.service';
import { Registrationrequestmodel } from '../../models/registrationrequestmodel/registrationrequestmodel';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  constructor(private authService: AuthService, private router: Router, private userdataService: UserdataService) {}

  registerRequest : Registrationrequestmodel = {
    fullName: '',
    id: 0,
    email: '',
    password: ''
  }

  register() : void {
      this.authService.register(this.registerRequest);
      this.router.navigate(['']);
  }
}
