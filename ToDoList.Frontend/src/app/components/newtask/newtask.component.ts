import { Component } from '@angular/core';
import { Taskmodel } from '../../models/taskmodel/taskmodel.model';
import { Router } from '@angular/router';
import { UserService } from '../../services/user/user.service';

@Component({
  selector: 'app-newtask',
  templateUrl: './newtask.component.html',
  styleUrl: './newtask.component.css',
})
export class NewtaskComponent {

  taskmodel : Taskmodel =
  {
    id: 0,
    deadLine: '',
    description: '',
    name: '',
    state: -1
  }

  constructor(private userService: UserService, private router: Router) {}

  create() : void {
    this.taskmodel.deadLine = (new Date(this.taskmodel.deadLine)).toISOString()
    this.taskmodel.state = this.taskmodel.state - 0;
    this.userService.addTask(this.taskmodel).subscribe();
  }
}
