import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Loginrequestmodel } from '../../models/loginrequestmodel/loginrequestmode.model';
import { Responsemodel } from '../../models/responsemodel/responsemodel.model';
import { UserdataService } from '../userdata/userdata.service';
import { UserService } from '../user/user.service';
import { Usermodel } from '../../models/usermodel/usermodel.model';
import { Registrationrequestmodel } from '../../models/registrationrequestmodel/registrationrequestmodel';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private basePath: string = "http://localhost:7014/api/auth/";

  constructor(private http: HttpClient, private userdataService: UserdataService, private userService: UserService) { }

  login(loginrequestmodel: Loginrequestmodel): void {
    this.http.post<Responsemodel>(this.basePath + "login", loginrequestmodel).subscribe(
      response => {
        if (response.isSuccess) {
          this.userdataService.setToken(response.result.token);
          this.userService.getUserByEmail(response.result.user.email).subscribe(
            userResponse => {
              this.userdataService.updateUserModel(userResponse.result);
            }
          )
        }
      }
    );
  }

  logout(): void {
    console.log("LOGOUT");
    this.userdataService.removeToken();
    this.userdataService.removeUserModel();
  }

  register(registrationrequestmodel: Registrationrequestmodel): void {

    this.http.post<Responsemodel>(this.basePath + "register", registrationrequestmodel).subscribe(
      response => {
        if (response.isSuccess) {
          var loginrequestmodel: Loginrequestmodel = {
            email: registrationrequestmodel.email,
            password: registrationrequestmodel.password
          }

          this.http.post<Responsemodel>(this.basePath + "login", loginrequestmodel).subscribe(
            response => {
              if (response.isSuccess) {
                this.logout();
                this.userdataService.setToken(response.result.token);
                var user: Usermodel = {
                  id: 0,
                  email: registrationrequestmodel.email,
                  fullName: registrationrequestmodel.fullName
                }
                this.userService.addUser(user).subscribe();
                this.logout();
                this.login(loginrequestmodel);
              }
            }
          );
        }
      }
    );
  }
}
