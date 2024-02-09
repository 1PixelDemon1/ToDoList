import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Responsemodel } from '../../models/responsemodel/responsemodel.model';
import { UserdataService } from '../userdata/userdata.service';
import { Taskgroupmodel } from '../../models/taskgroupmodel/taskgroupmodel.model';

@Injectable({
  providedIn: 'root'
})
export class TaskgroupService {
  private basePath: string = "http://localhost:7252/api/taskgroup/";

  constructor(private http: HttpClient, private userdata: UserdataService) { }

  addAllowedUser(taskGroupId: number, userId: number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "AddAllowedUser", {},
      {
        headers: headers,
        params: { taskGroupId: taskGroupId, userId: userId }
      }
    );
  }  

  getAll(): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetAll",
      {
        headers: headers
      }
    );
  }

  getAllowedUsers(taskGroupId : number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetAllowedUsers",
      {
        headers: headers,
        params: {
          taskGroupId: taskGroupId
        }
      }
    );
  }

  getOwner(taskGroupId : number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetOwner",
      {
        headers: headers,
        params: {
          taskGroupId: taskGroupId
        }
      }
    );
  }

  getTaskGroup(taskGroupId : number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetTaskGroup",
      {
        headers: headers,
        params: {
          id: taskGroupId
        }
      }
    );
  }

  getTasks(taskGroupId: number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetTasks",
      {
        headers: headers,
        params: { taskGroupId: taskGroupId }
      }
    );
  }

  removeAllowedUser(taskGroupId: number, userId: number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "RemoveAllowedUser", {},
      {
        headers: headers,
        params: { taskGroupId: taskGroupId, userId: userId }
      }
    );
  }

  addTask(taskGroupId: number, taskId: number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "AddTask", {},
      {
        headers: headers,
        params: { taskGroupId: taskGroupId, taskId: taskId }
      }
    );
  }
  
  removeTask(taskGroupId: number, taskId: number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "RemoveTask", {},
      {
        headers: headers,
        params: { taskGroupId: taskGroupId, taskId: taskId }
      }
    );
  }

  removeTaskGroup(taskGroupId: number): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "RemoveTaskGroup", {},
      {
        headers: headers,
        params: { id: taskGroupId}
      }
    );
  }

  updateTaskGroup(taskGroupId: number, newTaskgroup : Taskgroupmodel): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "RemoveTaskGroup", {newTaskgroup},
      {
        headers: headers,
        params: { taskGroupId: taskGroupId}
      }
    );
  }



}
