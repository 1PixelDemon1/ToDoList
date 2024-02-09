import { Component } from '@angular/core';
import { Taskgroupmodel } from '../../models/taskgroupmodel/taskgroupmodel.model';
import { UserService } from '../../services/user/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-taskgroup',
  templateUrl: './new-taskgroup.component.html',
  styleUrl: './new-taskgroup.component.css'
})
export class NewTaskgroupComponent {

  taskgroupmodel : Taskgroupmodel =
  {
    id: 0,
    isPrivate: false,
    name: ''
  }

  constructor(private userService: UserService, private router: Router) {}

  create() : void {
    console.log("AGAGGAGAG");
    this.userService.addTaskGroup(this.taskgroupmodel).subscribe();
  }
}
