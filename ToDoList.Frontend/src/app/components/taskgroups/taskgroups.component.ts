import { Component } from '@angular/core';
import { UserService } from '../../services/user/user.service';
import { OnInit } from '@angular/core';
import { Taskgroupmodel } from '../../models/taskgroupmodel/taskgroupmodel.model';
import { UserdataService } from '../../services/userdata/userdata.service';

@Component({
  selector: 'app-taskgroups',
  templateUrl: './taskgroups.component.html',
  styleUrl: './taskgroups.component.css'
})
export class TaskgroupsComponent implements OnInit {

  constructor(private userService: UserService, private userdataService: UserdataService) { }

  islogged: boolean = false;

  taskgroups: Taskgroupmodel[] = []

  isLogged(): boolean {
    return this.islogged;
  }

  ngOnInit(): void {
    this.islogged = this.userdataService.isLogged()
    if (this.islogged) {

      this.userService.getTaskGroups().subscribe(
        response => {
          if (response.isSuccess) {
            this.taskgroups = response.result;
          }
        }
      );
    }
  }
}
