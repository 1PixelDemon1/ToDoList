import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { TaskgroupService } from '../../services/taskgroup/taskgroup.service';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../../services/user/user.service';
import { Usermodel } from '../../models/usermodel/usermodel.model';

@Component({
  selector: 'app-taskgroup-elements',
  templateUrl: './taskgroup-elements.component.html',
  styleUrl: './taskgroup-elements.component.css'
})
export class TaskgroupElementsComponent implements OnInit {
  tasks : Taskmodel[] = [];
  allowedtasks : Taskmodel[] = [];
  allowedusers : Usermodel[] = [];
  taskgroupid: number = 0;
  taskgroupName : string = '';
  selectedTasks: number[] = [];
  userToAddEmail : string = '';

  constructor(private userService: UserService, private taskgroupService : TaskgroupService, private route: ActivatedRoute) {}

  ngOnInit(): void {
    this.route.params.subscribe(params => {
       this.taskgroupid = params['id'];
     });

     this.userService.getTasks().subscribe(
      response => 
      {
        this.allowedtasks = response.result;
      }
     );

     this.taskgroupService.getTasks(this.taskgroupid).subscribe(
        response =>
        {
          console.log(response);
          if(response.isSuccess) {
            this.tasks = response.result;
          }
        }
     );

     this.taskgroupService.getTaskGroup(this.taskgroupid).subscribe(
      response =>
      {
        this.taskgroupName = response.result.name;
      }
     );

     this.taskgroupService.getAllowedUsers(this.taskgroupid).subscribe(
      response => 
      {
        if(response.isSuccess) 
        {
          this.allowedusers = response.result;
        }
      }
     );
  }

  addTasks() : void {
    for (let taskId of this.selectedTasks) {
      this.taskgroupService.addTask(this.taskgroupid, taskId).subscribe();
    }
  }

  addUser() : void {
    var userModel : Usermodel;
    this.userService.getUserByEmail(this.userToAddEmail).subscribe(
      response =>
      {
        if(response.isSuccess) {
          userModel = response.result;
          this.taskgroupService.addAllowedUser(this.taskgroupid, userModel.id).subscribe();
        }
      }
    );
  }

  removeUser(userId : number) : void 
  {
    this.taskgroupService.removeAllowedUser(this.taskgroupid, userId).subscribe();
  }
}
