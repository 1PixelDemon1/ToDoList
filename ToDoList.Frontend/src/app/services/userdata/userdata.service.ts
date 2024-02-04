import { Injectable } from '@angular/core';
import { Usermodel } from '../../models/usermodel/usermodel.model';
import {CookieService} from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class UserdataService {

  constructor(private cookieService: CookieService) { }

  isLogged() : boolean {
    return this.cookieService.get('token') != ''; 
  }
  setToken(token: string): void {
    this.cookieService.set('token', token);
  }

  getToken(): string {
    return "Bearer " + this.cookieService.get('token');
  }

  removeToken(): void {
    this.cookieService.delete('token');
  }

  updateUserModel(usermodel: Usermodel) : void {
    this.cookieService.set('user', JSON.stringify(usermodel));
  }
  
  removeUserModel() : void {
    this.cookieService.delete('user');
  }

  getUserModel() : Usermodel {
    return JSON.parse(this.cookieService.get('user'))
  }
}
