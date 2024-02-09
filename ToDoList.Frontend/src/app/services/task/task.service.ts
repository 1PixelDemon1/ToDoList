import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { Responsemodel } from '../../models/responsemodel/responsemodel.model';
import { UserdataService } from '../userdata/userdata.service';

@Injectable({
  providedIn: 'root'
})
export class TaskService {

  private basePath: string = "http://localhost:7252/api/task/";
  
  constructor(private http: HttpClient, private userdata: UserdataService) { }

  getAll(): Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetAll", { headers });
  }

  getOwner(taskId : number) : Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetOwner", 
      { headers : headers, 
        params: {taskId: taskId} 
      }
    );
  }

  getTask(taskId : number) : Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetTask", 
      { headers : headers, 
        params: {taskId: taskId} 
      }
    );
  }

  getTaskgroups(taskId : number) : Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.get<Responsemodel>(this.basePath + "GetTaskGroups", 
      { headers : headers, 
        params: {taskId: taskId} 
      }
    );
  }
  
  removeTask(taskId : number) : Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "RemoveTask",'',
      { headers : headers, 
        params: {taskId: taskId} 
      }
    );
  }
  
  updateTask(taskId : number, newTask : Taskmodel) : Observable<Responsemodel> {
    const headers = new HttpHeaders().set('Authorization', this.userdata.getToken());
    return this.http.post<Responsemodel>(this.basePath + "UpdateTask", newTask, {headers: headers, params: {taskId: taskId}}     
    );
  }
}
