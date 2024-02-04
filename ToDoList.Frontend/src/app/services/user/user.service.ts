import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Responsemodel } from '../../models/responsemodel/responsemodel.model';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { UserdataService } from '../userdata/userdata.service';
import { Taskgroupmodel } from '../../models/taskgroupmodel/taskgroupmodel.model';
import { Usermodel } from '../../models/usermodel/usermodel.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private basePath: string = "https://localhost:7252/api/user/";

  constructor(private http: HttpClient, private userdata: UserdataService) { }

  addTask(taskModel: Taskmodel): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "AddTask", taskModel,
      {
        headers: headers,
        params: {userId: this.userdata.getUserModel().id}
      }
    );
  }
  
  addTaskGroup(taskGroup: Taskgroupmodel): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "AddTaskGroup", taskGroup,
      {
        headers: headers,
        params: { userId: this.userdata.getUserModel().id }
      }
    );
  }

  addUser(user: Usermodel): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "CreateUser", user,
      { headers: headers }
    );
  }

  removeUser(): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "RemoveUser", {},
      { headers: headers, params: { id: this.userdata.getUserModel().id } }
    );
  }

  updateUser(usermodel: Usermodel): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "UpdateUser", usermodel,
      { headers: headers, params: { id: this.userdata.getUserModel().id } }
    );
  }

  getAll(): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetAll", { headers });
  }

  getUserByEmail(email: string): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetUserByEmail", { headers, params: { email } });
  }

  getTaskGroups(): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetTaskGroups", {
      headers: headers,
      params: { userId: this.userdata.getUserModel().id }
    });
  }

  getAccessibleGroups(): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetAccessibleGroups", {
      headers: headers,
      params: { userId: this.userdata.getUserModel().id }
    });
  }

  getTasks(): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetTasks", {
      headers: headers,
      params: { userId: this.userdata.getUserModel().id }
    });
  }

  getUser(userId: number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetUser", {
      headers: headers,
      params: { id: userId }
    });
  }

}
