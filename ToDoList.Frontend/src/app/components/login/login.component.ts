import { Component } from '@angular/core';
import { Loginrequestmodel } from '../../models/loginrequestmodel/loginrequestmode.model';
import { AuthService } from '../../services/auth/auth.service';
import { Router } from '@angular/router';
import { UserdataService } from '../../services/userdata/userdata.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {

  constructor(private authService: AuthService, private router: Router, private userdataService: UserdataService) {}

  loginRequest : Loginrequestmodel = {
    email: '',
    password: ''
  }

  login() : void {
      this.authService.login(this.loginRequest);
      this.router.navigate(['']);
  }
}
