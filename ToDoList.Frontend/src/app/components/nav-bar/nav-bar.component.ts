import { Component } from '@angular/core';
import { UserdataService } from '../../services/userdata/userdata.service';
import { OnInit } from '@angular/core';
import { AuthService } from '../../services/auth/auth.service';
@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css'
})
export class NavBarComponent implements OnInit{

  username: string = '';

  constructor(private userdataService : UserdataService, private authservice: AuthService) {}
  ngOnInit(): void {
    if(this.isLogged()) {
      this.username = this.userdataService.getUserModel().fullName;
    }
  }

  isLogged() : boolean {
    return this.userdataService.isLogged();
  }
  
  logout() {
    this.authservice.logout();
  }

}
