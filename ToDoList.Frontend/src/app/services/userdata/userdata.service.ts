import { Injectable } from '@angular/core';
import { Usermodel } from '../../models/usermodel/usermodel.model';
import {CookieService} from 'ngx-cookie-service';
import path from 'node:path';

@Injectable({
  providedIn: 'root'
})
export class UserdataService {

  constructor(private cookieService: CookieService) { }

  isLogged() : boolean {
    return this.cookieService.get('token') != ''; 
  }
  setToken(token: string): void {
    var expire = new Date();
    var time = Date.now() + ((3600 * 1000) * 24 * 7);
    expire.setTime(time);
    this.cookieService.set('token', token, {expires: expire, path: "/"});
  }

  getToken(): string {
    return "Bearer " + this.cookieService.get('token');
  }

  removeToken(): void {
    this.cookieService.delete('token', "/");
  }

  updateUserModel(usermodel: Usermodel) : void {
    var expire = new Date();
    var time = Date.now() + ((3600 * 1000) * 24 * 7);
    expire.setTime(time);
    this.cookieService.set('user', JSON.stringify(usermodel), {expires: expire, path: "/"});
  }
  
  removeUserModel() : void {
    this.cookieService.delete('user', "/");
  }

  getUserModel() : Usermodel {
    if(this.isLogged())
      return JSON.parse(this.cookieService.get('user'))
    else return {
        email : '',
        fullName : '',
        id : 0
      };
  }
}
